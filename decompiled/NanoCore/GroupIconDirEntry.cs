using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct GroupIconDirEntry
{
	public byte Width;

	public byte Height;

	public byte ColorCount;

	public byte Reserved;

	public short Planes;

	public short BitCount;

	public int Size;

	public short ID;
}
