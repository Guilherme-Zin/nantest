using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IconDirEntry
{
	public byte Width;

	public byte Height;

	public byte ColorCount;

	public byte Reserved;

	public short Planes;

	public short BitCount;

	public int Size;

	public int ImageOffset;
}
