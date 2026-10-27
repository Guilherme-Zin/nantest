namespace NanoCore.ClientPluginHost;

public interface IClientNetworkHost
{
	/// <summary>
	///  Gets a value indicating whether the client is connected.
	///  </summary>
	/// <value>
	/// 	<c>True</c> if connected; otherwise, <c>false</c>.
	///  </value>
	bool Connected { get; }

	void ClosePipe(string pipeName);

	/// <summary>
	///  Checks if a connection pipe exists.
	///  </summary>
	/// <param name="pipeName">Name of the pipe.</param>
	bool PipeExists(string pipeName);

	void RebuildHostCache();

	/// <summary>
	///  Adds a host entry to the client's remote host cache.
	///  </summary>
	void AddHostEntry(string host);

	void Disconnect();

	/// <summary>
	///  Sends primitive values to the server.
	///  </summary>
	/// <param name="pipeName">Name of a pipe connection. This parameter can be null if no pipe is being used.</param>
	/// <param name="compress">Compresses packet data if <c>true</c>. Set to <c>true</c> unless <paramref name="params" /> contains data that has already been compressed.</param>
	/// <param name="params">Primitive values to send to the server.</param>
	void SendToServer(string pipeName, bool compress, params object[] @params);
}
