namespace NanoCore;

/// <summary>
///  Represents a connection list column entry.
///  </summary>
public sealed class ColumnEntry
{
	/// <summary>
	///  The name of the column.
	///  </summary>
	public string Name { get; set; }

	public string Icon { get; set; }

	/// <summary>
	///  The default width of the column.
	///  </summary>
	public int Width { get; set; }

	public bool AllowGrouping { get; set; }
}
