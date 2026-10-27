using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct GroupDir
{
	public short Reserved;

	public short Type;

	public short Count;
}
