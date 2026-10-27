using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using x3ZZ6yTIUcsq7BQfVo1;

[StandardModule]
public sealed class GClass18
{
	public static int int_0;

	public static int int_1;

	public static int int_2;

	public static int int_3;

	public static int int_4;

	public static int int_5;

	public static int int_6;

	public static int int_7;

	public static int int_8;

	public static int int_9;

	public static int int_10;

	public static int int_11;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GClass18()
	{
		KINZ4oTBhjvdwZVriDN.gsXNk5bTfx();
		int num = 8;
		if (FCndYfJYtJBJFFh5QKh())
		{
			goto IL_0015;
		}
		goto IL_0077;
		IL_0015:
		int_6 = 4;
		num = 4;
		goto IL_0077;
		IL_0077:
		while (true)
		{
			switch (num)
			{
			case 12:
				break;
			case 5:
			case 10:
				int_9 = 4243;
				num = 14;
				if (0 == 0)
				{
					continue;
				}
				goto case 3;
			case 3:
				int_4 = 4620;
				FCndYfJYtJBJFFh5QKh();
				num = ((!BOkVUgJgh3CFB1YSoQp()) ? 5 : 0);
				continue;
			case 0:
			case 6:
				int_5 = 8;
				break;
			default:
				num = 12;
				continue;
			case 8:
				S9nZlLJ4vb6hktCantx();
				num = 11;
				continue;
			case 13:
				int_3 = 4619;
				num = 3;
				continue;
			case 14:
				int_10 = 4150;
				num = 7;
				continue;
			case 9:
				int_1 = 1024;
				num = 2;
				continue;
			case 4:
				int_7 = 2;
				num = 1;
				if (FCndYfJYtJBJFFh5QKh())
				{
				}
				continue;
			case 11:
				int_0 = 4;
				num = 9;
				continue;
			case 1:
				int_8 = 4127;
				goto case 5;
			case 2:
				int_2 = 512;
				num = 13;
				if (0 == 0)
				{
					continue;
				}
				goto case 7;
			case 7:
				int_11 = 4396;
				num = 15;
				if (true)
				{
					continue;
				}
				return;
			case 15:
				return;
			}
			break;
		}
		goto IL_0015;
	}

	[DllImport("shell32.dll", SetLastError = true)]
	public static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string string_0, IntPtr intptr_0, ref IntPtr intptr_1, int int_12, ref int int_13);

	[DllImport("shell32.dll", SetLastError = true)]
	public static extern int SHOpenFolderAndSelectItems(IntPtr intptr_0, int int_12, [MarshalAs(UnmanagedType.LPArray, SizeConst = 0)] IntPtr[] intptr_1, int int_13);

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr intptr_0, int int_12);

	[DllImport("user32.dll")]
	public static extern bool AnimateWindow(IntPtr intptr_0, int int_12, int int_13);

	[DllImport("user32.dll")]
	public static extern bool SetWindowPos(IntPtr intptr_0, IntPtr intptr_1, int int_12, int int_13, int int_14, int int_15, int int_16);

	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
	public static extern int SetWindowTheme(IntPtr intptr_0, string string_0, string string_1);

	[DllImport("user32.dll")]
	public static extern IntPtr SendMessage(IntPtr intptr_0, int int_12, int int_13, int int_14);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	public static extern IntPtr SendMessage_1(IntPtr intptr_0, int int_12, int int_13, ref GStruct5 gstruct5_0);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	public static extern IntPtr SendMessage_2(IntPtr intptr_0, int int_12, IntPtr intptr_1, ref LV_GROUP lv_GROUP_0);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	public static extern IntPtr SendMessage_3(IntPtr intptr_0, int int_12, IntPtr intptr_1, ref GStruct0 gstruct0_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr BeginUpdateResource(string string_0, bool bool_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool UpdateResource(IntPtr intptr_0, int int_12, int int_13, short short_0, byte[] byte_0, int int_14);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool EndUpdateResource(IntPtr intptr_0, bool bool_0);

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void S9nZlLJ4vb6hktCantx()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool BOkVUgJgh3CFB1YSoQp()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool FCndYfJYtJBJFFh5QKh()
	{
		return true;
	}
}
