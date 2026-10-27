using System;

namespace NanoCore.ServerPluginHost;

/// <summary>
///  Provides access to server networking.
///  </summary>
public interface IServerNetworkHost
{
	/// <summary>
	///  Returns an array of listeners.
	///  </summary>
	/// <value>
	///  The listeners.
	///  </value>
	IListener[] Listeners { get; }

	IListener AddListener(ushort port);

	/// <summary>
	///  Removes a listener from the server.
	///  </summary>
	/// <param name="port">The port of the <see cref="T:NanoCore.IListener" /> to remove.</param>
	void RemoveListener(ushort port);

	void EnableListener(ushort port);

	/// <summary>
	///  Disables a listener on the server.
	///  </summary>
	/// <param name="port">The port of the <see cref="T:NanoCore.IListener" /> to disable.</param>
	void DisableListener(ushort port);

	IClient[] GetClients();

	/// <summary>
	///  Finds a client by its unique Id.
	///  </summary>
	/// <param name="id">The client identifier.</param>
	/// <returns></returns>
	IClient FindClient(Guid id);

	void DisconnectClient(IClient client);

	/// <summary>
	///  Creates a connection pipe on the specified client.
	///  </summary>
	/// <param name="client">The client to create a pipe on.</param>
	/// <param name="pipeName">Name of the pipe.</param>
	void CreateClientPipe(IClient client, string pipeName);

	void CloseClientPipe(IClient client, string pipeName);

	/// <summary>
	///  Checks if a connection pipe exists.
	///  </summary>
	/// <param name="client">The client that owns the pipe.</param>
	/// <param name="pipeName">Name of the pipe.</param>
	bool ClientPipeExists(IClient client, string pipeName);

	void SendToClient(IClient client, string pipeName, bool compress, params object[] @params);
}
