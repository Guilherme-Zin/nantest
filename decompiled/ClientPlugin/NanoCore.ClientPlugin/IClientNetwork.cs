namespace NanoCore.ClientPlugin;

/// <summary>
///  Provides event callbacks for connection states and network transfer.
///  </summary>
public interface IClientNetwork
{
	/// <summary>
	///  Called when a packet has been received from the server.
	///  </summary>
	/// <param name="pipeName">Name of the connection pipe or null if no pipe is being used.</param>
	/// <param name="params">Parameters received from the server.</param>
	void ReadPacket(string pipeName, object[] @params);

	void PipeCreated(string pipeName);

	/// <summary>
	///  Called when a connection pipe has been closed.
	///  </summary>
	/// <param name="pipeName">Name of the pipe.</param>
	void PipeClosed(string pipeName);

	void ConnectionStateChanged(bool connected);

	/// <summary>
	///  Called when the client connection to the server has failed.
	///  </summary>
	/// <param name="host">Remote server host name.</param>
	/// <param name="port">Remote server port number.</param>
	void ConnectionFailed(string host, ushort port);

	void BuildingHostCache();
}
