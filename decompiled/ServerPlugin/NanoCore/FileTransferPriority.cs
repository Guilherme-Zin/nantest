namespace NanoCore;

/// <summary>
///  Indicates the priority of a file transfer.
///  </summary>
public enum FileTransferPriority : byte
{
	Low,
	/// <summary>
	///  Indicates a medium priority file transfer.
	///  </summary>
	Medium,
	High
}
