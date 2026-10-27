using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GStruct0
{
	public int int_0;

	public int int_1;

	[MarshalAs(UnmanagedType.LPWStr)]
	public string string_0;

	public IntPtr intptr_0;

	public int int_2;

	public int int_3;

	public IntPtr intptr_1;
}
