using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

class PluginAutomation
{
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);
    delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
    delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll")]
    static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    static extern bool IsWindowVisible(IntPtr hWnd);

    [StructLayout(LayoutKind.Sequential)]
    struct RECT { public int left; public int top; public int right; public int bottom; }

    const uint BM_CLICK = 0x00F5;
    const uint WM_CLOSE = 0x0010;
    const uint WM_SETTEXT = 0x000C;
    const int SW_RESTORE = 9;

    static uint targetPid;

    static int Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.Error.WriteLine("Usage: PluginAutomation <plugincompiler.exe> <input.dll> <output.ncp> [plugin_name]");
            return 1;
        }

        string compilerPath = Path.GetFullPath(args[0]);
        string dllPath = Path.GetFullPath(args[1]);
        string outputPath = Path.GetFullPath(args[2]);

        if (!File.Exists(compilerPath)) { Console.Error.WriteLine("PluginCompiler not found"); return 1; }
        if (!File.Exists(dllPath)) { Console.Error.WriteLine("DLL not found"); return 1; }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        if (File.Exists(outputPath)) File.Delete(outputPath);

        Console.Write("Starting PluginCompiler... ");
        Process proc = new Process();
        proc.StartInfo = new ProcessStartInfo
        {
            FileName = compilerPath,
            WorkingDirectory = Path.GetDirectoryName(compilerPath),
            WindowStyle = ProcessWindowStyle.Normal,
            UseShellExecute = true,
        };
        proc.Start();
        Console.WriteLine("PID={0}", proc.Id);
        targetPid = (uint)proc.Id;

        Console.Write("Waiting for window");
        IntPtr mainWnd = IntPtr.Zero;
        for (int i = 0; i < 30; i++)
        {
            Thread.Sleep(500);
            EnumWindows((hwnd, lp) =>
            {
                uint wp;
                GetWindowThreadProcessId(hwnd, out wp);
                if (wp == targetPid)
                {
                    StringBuilder sb = new StringBuilder(256);
                    GetWindowText(hwnd, sb, 256);
                    if (sb.Length > 0) { mainWnd = hwnd; return false; }
                }
                return true;
            }, IntPtr.Zero);
            if (mainWnd != IntPtr.Zero) break;
            Console.Write(".");
        }
        if (mainWnd == IntPtr.Zero) { Console.WriteLine(" FAILED"); return 1; }
        Console.WriteLine(" OK");

        Thread.Sleep(1000);
        ShowWindow(mainWnd, SW_RESTORE);
        SetForegroundWindow(mainWnd);
        Thread.Sleep(500);

        // Enumerate buttons to find Browse.. and Compile buttons
        var buttons = new List<CtrlInfo>();

        EnumChildWindows(mainWnd, (hwnd, lp) =>
        {
            StringBuilder cls = new StringBuilder(256);
            GetClassName(hwnd, cls, 256);
            StringBuilder txt = new StringBuilder(256);
            GetWindowText(hwnd, txt, 256);
            string t = txt.ToString().Trim();
            RECT r;
            GetWindowRect(hwnd, out r);
            if (cls.ToString().Contains("BUTTON"))
                buttons.Add(new CtrlInfo { HWnd = hwnd, Text = t, Rect = r });
            return true;
        }, IntPtr.Zero);

        Console.WriteLine("Buttons found: {0}", buttons.Count);

        // Sort buttons by Y position (top to bottom)
        buttons.Sort((a, b) => a.Rect.top.CompareTo(b.Rect.top));
        foreach (var b in buttons)
            Console.WriteLine("  ({0},{1}) '{2}'", b.Rect.left, b.Rect.top, b.Text);

        // Find Compile button
        IntPtr compileBtn = IntPtr.Zero;
        foreach (var b in buttons)
            if (b.Text.IndexOf("Compile", StringComparison.OrdinalIgnoreCase) >= 0)
                compileBtn = b.HWnd;

        // Browse buttons sorted by Y ascending:
        // [0] Icon (y=291)
        // [1] ??? (y=330)
        // [2] DLL (y=369) - from code analysis: uses OpenFileDialog, sets DLL path field
        // [3] Output (y=408) - from code analysis: uses SaveFileDialog, sets output path field
        var browseButtons = buttons.FindAll(b => b.Text.IndexOf("Browse", StringComparison.OrdinalIgnoreCase) >= 0);
        IntPtr browseDll = browseButtons.Count >= 3 ? browseButtons[2].HWnd : IntPtr.Zero;
        IntPtr browseOut = browseButtons.Count >= 4 ? browseButtons[3].HWnd : IntPtr.Zero;

        Console.WriteLine("\n  Browse DLL:  0x{0:X8} (index 2 of {1})", browseDll.ToInt32(), browseButtons.Count);
        Console.WriteLine("  Browse Out:  0x{0:X8} (index 3 of {1})", browseOut.ToInt32(), browseButtons.Count);
        Console.WriteLine("  Compile:     0x{0:X8}", compileBtn.ToInt32());

        // === AUTOMATE DLL BROWSE ===
        if (browseDll != IntPtr.Zero && ClickAndOpenDialog(browseDll, dllPath, "Open", proc))
        {
            Thread.Sleep(500);
        }

        // === AUTOMATE OUTPUT BROWSE ===
        if (browseOut != IntPtr.Zero && ClickAndOpenDialog(browseOut, outputPath, "Save", proc))
        {
            Thread.Sleep(500);
        }

        // === CLICK COMPILE ===
        if (compileBtn != IntPtr.Zero)
        {
            Console.Write("Clicking Compile... ");
            SetForegroundWindow(mainWnd);
            Thread.Sleep(300);
            SendMessage(compileBtn, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("clicked");
        }

        // === WAIT FOR OUTPUT ===
        bool compiled = false;
        Console.Write("Waiting for output");
        for (int i = 0; i < 240; i++)
        {
            Thread.Sleep(500);
            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 64)
            {
                compiled = true;
                Console.WriteLine("\nOutput: {0} bytes", new FileInfo(outputPath).Length);
                break;
            }
            if (i % 10 == 9) Console.Write(".");
        }
        if (!compiled) Console.WriteLine("\nTIMEOUT");

        // Cleanup
        if (!proc.HasExited)
        {
            SendMessage(mainWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            if (!proc.WaitForExit(3000)) proc.Kill();
        }

        Console.WriteLine(compiled ? "\nSUCCESS" : "\nFAILED");
        return compiled ? 0 : 1;
    }

    static bool ClickAndOpenDialog(IntPtr browseBtn, string filePath, string btnText, Process proc)
    {
        Console.Write("\nClicking {0} Browse... ", btnText);
        SendMessage(browseBtn, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        Thread.Sleep(1500);

        // Find the dialog window belonging to our process
        IntPtr dlg = IntPtr.Zero;
        for (int i = 0; i < 30 && dlg == IntPtr.Zero; i++)
        {
            EnumWindows((hwnd, lp) =>
            {
                StringBuilder cls = new StringBuilder(256);
                GetClassName(hwnd, cls, 256);
                if (cls.ToString() == "#32770")
                {
                    uint pid;
                    GetWindowThreadProcessId(hwnd, out pid);
                    if (pid == targetPid)
                    {
                        dlg = hwnd;
                        return false;
                    }
                }
                return true;
            }, IntPtr.Zero);
            if (dlg == IntPtr.Zero) Thread.Sleep(200);
        }

        if (dlg == IntPtr.Zero)
        {
            Console.WriteLine("dialog NOT FOUND");
            DumpAllWindows();
            return false;
        }

        Console.WriteLine("dialog found");
        ShowWindow(dlg, SW_RESTORE);
        Thread.Sleep(300);

        // Find filename edit (usually first Edit or ComboBox)
        IntPtr fnEdit = FindWindowEx(dlg, IntPtr.Zero, "Edit", null);
        if (fnEdit == IntPtr.Zero)
        {
            // On newer Windows, the filename area might be inside a ComboBox
            IntPtr combo = FindWindowEx(dlg, IntPtr.Zero, "ComboBox", null);
            if (combo != IntPtr.Zero)
                fnEdit = FindWindowEx(combo, IntPtr.Zero, "Edit", null);
        }

        if (fnEdit != IntPtr.Zero)
        {
            Console.WriteLine("  Setting path...");
            SendMessage(fnEdit, WM_SETTEXT, IntPtr.Zero, filePath);
            Thread.Sleep(300);
        }

        // Find and click the button (Open/Save)
        IntPtr actionBtn = FindButtonByText(dlg, btnText);

        if (actionBtn != IntPtr.Zero)
        {
            Console.WriteLine("  {0} clicked", btnText);
            SendMessage(actionBtn, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("  ({0} button not found, trying Enter)", btnText);
            SetForegroundWindow(dlg);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
        }

        return true;
    }

    static IntPtr FindButtonByText(IntPtr parent, string text)
    {
        IntPtr result = IntPtr.Zero;
        EnumChildWindows(parent, (hwnd, lp) =>
        {
            StringBuilder cls = new StringBuilder(256);
            GetClassName(hwnd, cls, 256);
            if (cls.ToString().Contains("BUTTON"))
            {
                StringBuilder tb = new StringBuilder(256);
                GetWindowText(hwnd, tb, 256);
                string t = tb.ToString().Trim();
                if (t.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result = hwnd;
                    return false;
                }
            }
            return true;
        }, IntPtr.Zero);
        return result;
    }

    static void DumpAllWindows()
    {
        Console.WriteLine("\n  --- All top-level windows ---");
        EnumWindows((hwnd, lp) =>
        {
            StringBuilder cls = new StringBuilder(128);
            GetClassName(hwnd, cls, 128);
            StringBuilder txt = new StringBuilder(256);
            GetWindowText(hwnd, txt, 256);
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            string t = txt.ToString().Trim();
            string c = cls.ToString();
            if (t.Length > 0 || c == "#32770")
                Console.WriteLine("  [{0}] PID={1} class='{2}' title='{3}'",
                    hwnd.ToInt32().ToString("X8"), pid, c, t.Length > 40 ? t.Substring(0, 40) : t);
            return true;
        }, IntPtr.Zero);
    }

    class CtrlInfo
    {
        public IntPtr HWnd;
        public string Text;
        public RECT Rect;
    }
}
