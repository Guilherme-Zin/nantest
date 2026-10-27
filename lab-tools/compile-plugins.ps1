# Auto-compila plugins de laboratorio usando PluginCompiler.exe (GUI automation)
# Uso: .\compile-plugins.ps1
# Certifique-se de que o PluginCompiler.exe esteja na pasta raiz.

$ErrorActionPreference = "Stop"
$base = Split-Path $PSScriptRoot -Parent

$plugins = @(
    @{ Name = "LabMonitorPlugin"; Dll = "lab-plugins\output\LabMonitor.dll" },
    @{ Name = "PacketLoggerPlugin"; Dll = "lab-plugins\output\PacketLogger.dll" }
)

# PluginCompiler window layout (from decompiled MainForm.cs):
# ServerPlugin radio = RadioButton at (11, 21)
# DLL TextBox = TextBox3 at (354, 139), width 272
# Output TextBox = TextBox4 at (354, 178), width 272
# DLL browse = Button3 at (632, 135), width 76
# Output browse = Button4 at (632, 174), width 76
# Compile button = Button8 at (354, 513), width 259
# Output label = Label4 at (354, 163) -> "Output File:"
# DLL label = Label3 at (354, 124) -> "Input File:"

$compiler = Join-Path $base "PluginCompiler.exe"

foreach ($plugin in $plugins) {
    $dllPath = Join-Path $base $plugin.Dll
    $outputPath = Join-Path $base "Plugins\$($plugin.Name).ncp"

    if (-not (Test-Path $dllPath)) {
        Write-Host "DLL nao encontrada: $dllPath" -ForegroundColor Red
        continue
    }

    Write-Host "Compilando $($plugin.Name)..." -ForegroundColor Cyan

    # Start PluginCompiler
    $proc = Start-Process -FilePath $compiler -WindowStyle Normal -PassThru
    Start-Sleep -Seconds 2

    try {
        # Get the main window handle
        $hwnd = $proc.MainWindowHandle
        if (-not $hwnd) {
            # Try to find it by process
            $hwnd = (Get-Process -Id $proc.Id).MainWindowHandle
        }

        if (-not $hwnd) {
            Write-Host "  [WARN] Nao foi possivel obter handle da janela, tentando SendKeys cego..." -ForegroundColor Yellow
        }

        # Bring window to foreground
        $null = [System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Add-Type @"
            using System;
            using System.Runtime.InteropServices;
            public class Win32 {
                [DllImport("user32.dll")]
                public static extern bool SetForegroundWindow(IntPtr hWnd);
                [DllImport("user32.dll")]
                public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            }
"@
        if ($hwnd) {
            [Win32]::ShowWindow($hwnd, 1) | Out-Null  # SW_SHOWNORMAL
            [Win32]::SetForegroundWindow($hwnd) | Out-Null
        }

        Start-Sleep -Milliseconds 500

        # Tab through fields and set values
        # The GUI has:
        #   TextBox3 (DLL path) at TabIndex 4
        #   TextBox4 (Output path) at TabIndex 12
        #   Server radio at TabIndex 31 (already checked)

        # Focus the DLL textbox (TextBox3) - Tab index 4
        # We need to tab through: GroupBox(0) -> picture(16) -> LinkLabel(2) ->
        #   Label(1) -> Label(3) -> Label(0) -> Label(8) -> TextBox3(4)
        # This is fragile... let's use a different approach.

        # Alternative: Use clip to paste text directly
        # The textboxes seem to have sequential TabIndex within the group

        # Type ALT + F to check menu... no, it's simpler.
        # Let's just press Tab until we reach the right fields

        # From the window's initial focus:
        # Press Tab ~10 times to reach the DLL textbox
        $shell = New-Object -ComObject WScript.Shell

        # Wait for window to be fully ready
        Start-Sleep -Milliseconds 1000

        # Select server plugin radio (already default)
        $shell.SendKeys("{TAB 2}")
        Start-Sleep -Milliseconds 200

        # Focus is probably on some other control.
        # Let's use a simpler approach: copy paths to clipboard,
        # tab to fields, paste.

        # The PluginCompiler has this structure:
        # GroupBox1 (Plugin type) -> RadioButton3(focus starts here)
        # Tab x3 -> TextBox DLL path
        # Tab -> Browse DLL button
        # Tab x2 -> TextBox Output path
        # Tab -> Browse Output button
        # ...
        # Tab many times -> Compile button

        # Clean approach: Send full tab path
        # Start from radio button -> Tab to DLL textbox (Tab Index 4)
        # We know from decompiled code: TabIndex order in the UI
        # Let's just try the approximate path:

        Write-Host "  Preenchendo caminho da DLL..." -ForegroundColor Gray

        # Set clipboard to DLL path
        Set-Clipboard $dllPath
        Start-Sleep -Milliseconds 200

        # Tab to DLL textbox
        $shell.SendKeys("{TAB 3}")
        Start-Sleep -Milliseconds 300
        $shell.SendKeys("^v")
        Start-Sleep -Milliseconds 300

        # Tab to Output textbox
        $shell.SendKeys("{TAB 3}")
        Start-Sleep -Milliseconds 300

        # Set clipboard to output path
        Set-Clipboard $outputPath
        Start-Sleep -Milliseconds 200
        $shell.SendKeys("^v")
        Start-Sleep -Milliseconds 300

        # Tab many times to reach Compile button (TabIndex 27)
        Write-Host "  Clicando Compile..." -ForegroundColor Gray
        $shell.SendKeys("{TAB 12}")
        Start-Sleep -Milliseconds 200
        $shell.SendKeys(" ")
        Start-Sleep -Milliseconds 2000

        # Check if compilation might have happened
        if (Test-Path $outputPath) {
            Write-Host "  OK: $outputPath" -ForegroundColor Green
        } else {
            Write-Host "  [WARN] .ncp nao encontrado em $outputPath" -ForegroundColor Yellow
            Write-Host "  [INFO] PluginCompiler pode estar aberto para compilacao manual." -ForegroundColor Yellow
            Write-Host "  [INFO] Preencha manualmente: DLL = $dllPath, Output = $outputPath" -ForegroundColor Yellow
        }

        # Close PluginCompiler
        $shell.SendKeys("%{F4}")
        Start-Sleep -Milliseconds 500

    } catch {
        Write-Host "  ERRO: $_" -ForegroundColor Red
        Write-Host "  PluginCompiler pode estar aberto. Feche manualmente." -ForegroundColor Yellow
    }
}

Write-Host "`nVerificando plugins gerados:" -ForegroundColor Cyan
$base = Split-Path $PSScriptRoot -Parent
Get-ChildItem (Join-Path $base "Plugins") -Filter "*.ncp" | Select-Object Name, Length
