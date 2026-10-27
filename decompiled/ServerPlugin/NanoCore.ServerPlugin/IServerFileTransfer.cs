namespace NanoCore.ServerPlugin;

/// <summary>
///  Provides event callbacks for file transfers.
///  </summary>
public interface IServerFileTransfer
{
	void FileTransferStateChanged(IFileTransfer transfer);

	/// <summary>
	///  Called when a file transfer has been added.
	///  </summary>
	/// <param name="transfer">The <see cref="T:NanoCore.IFileTransfer" /> instance.</param>
	void FileTransferAdded(IFileTransfer transfer);

	void FileTransferRemoved(IFileTransfer transfer);
}
