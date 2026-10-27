using System;

namespace NanoCore;

/// <summary>
///  Represents a file transfer between a client and the server.
///  </summary>
public interface IFileTransfer
{
	/// <summary>
	///  Gets the unique identifier for this file transfer.
	///  </summary>
	/// <value>The unique identifier.</value>
	/// <returns></returns>
	Guid Id { get; }

	IClient Client { get; }

	/// <summary>
	///  Gets the remote client's file path for this file transfer.
	///  </summary>
	/// <value>The remote file path.</value>
	/// <returns></returns>
	string ClientFileName { get; }

	string ServerFileName { get; }

	/// <summary>
	///  Gets a value indicating whether or not the file transfer is waiting for file information.
	///  </summary>
	/// <value>The value indicating whether or not the file transfer is initializing.</value>
	/// <returns></returns>
	bool Initializing { get; }

	FileTransferDirection Direction { get; }

	/// <summary>
	///  Get the current status of this file transfer.
	///  </summary>
	/// <value>The current file transfer status.</value>
	/// <returns></returns>
	FileTransferStatus Status { get; }

	long FileSize { get; }

	/// <summary>
	///  Gets the number of bytes that have been transferred.
	///  </summary>
	/// <value>The number of bytes that have been transferred.</value>
	/// <returns></returns>
	long BytesTransferred { get; }

	int BytesPerSecond { get; }

	/// <summary>
	///  Gets the estimated time remaining for the file transfer.
	///  </summary>
	/// <value>The estimated time remaining.</value>
	/// <returns></returns>
	TimeSpan TimeRemaining { get; }

	bool Persistent { get; set; }

	/// <summary>
	///  Gets or sets the current priority of the file transfer, higher priority transfers will be processed before lower priority transfers.
	///  </summary>
	/// <value>The current priority of the file transfer.</value>
	/// <returns></returns>
	FileTransferPriority Priority { get; set; }

	object State { get; set; }
}
