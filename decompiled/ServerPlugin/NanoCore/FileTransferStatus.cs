namespace NanoCore;

/// <summary>
///  Indicates the status of a file transfer.
///  </summary>
public enum FileTransferStatus : byte
{
	/// <summary>
	///  Indicates that the file transfer is active.
	///  </summary>
	Active,
	Queued,
	/// <summary>
	///  Indicates that the file transfer is paused.
	///  </summary>
	Paused,
	Canceled,
	/// <summary>
	///  Indicates that the file transfer has failed.
	///  </summary>
	Failed,
	Completed
}
