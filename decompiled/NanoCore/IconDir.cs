using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IconDir
{
	public short Reserved;

	public short Type;

	public short Count;
}
