using System;

namespace NanoCore.ServerPluginHost;

/// <summary>
///  Provides access to file transfer functionality.
///  </summary>
public interface IServerFileTransferHost
{
	/// <summary>
	///  Gets an array of all file transfers belonging to a client.
	///  </summary>
	/// <returns></returns>
	IFileTransfer[] GetFileTransfers(IClient client);

	IFileTransfer FindFileTransfer(Guid id);

	/// <summary>
	///  Uploads a file to the remote client.
	///  </summary>
	/// <param name="client">The client to upload the file to.</param>
	/// <param name="clientFileName">The client file path.</param>
	/// <param name="serverFileName">The server file path.</param>
	/// <param name="state">The optional state object to assign to the file transfer.</param>
	void UploadFile(IClient client, string serverFileName, string clientFileName, object state);

	void DownloadFile(IClient client, string serverFileName, string clientFileName, object state);

	/// <summary>
	///  Starts or resumes a file transfer.
	///  </summary>
	/// <param name="id">The id of the <see cref="T:NanoCore.IFileTransfer" />.</param>
	void StartFileTransfer(Guid id);

	void PauseFileTransfer(Guid id);

	/// <summary>
	///  Cancels and removes a file transfer.
	///  </summary>
	/// <param name="id">The id of the <see cref="T:NanoCore.IFileTransfer" />.</param>
	void CancelFileTransfer(Guid id);

	void RestartFileTransfer(Guid id);
}
