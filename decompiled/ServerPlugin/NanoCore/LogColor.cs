namespace NanoCore;

/// <summary>
///  Indicates the color of a log entry.
///  </summary>
public enum LogColor : byte
{
	/// <summary>
	///  Indicates a standard log entry.
	///  </summary>
	Normal,
	Warning,
	/// <summary>
	///  Indicates an error log entry.
	///  </summary>
	Error,
	Information
}
