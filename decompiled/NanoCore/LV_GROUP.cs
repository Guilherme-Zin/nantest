using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LV_GROUP
{
	public int Size;

	public int Mask;

	[MarshalAs(UnmanagedType.LPWStr)]
	public string Header;

	public IntPtr HeaderLength;

	[MarshalAs(UnmanagedType.LPWStr)]
	public string Footer;

	public int FooterLength;

	public int GroupId;

	public int StateMask;

	public int State;

	public IntPtr Align;
}
