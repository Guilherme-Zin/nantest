namespace NanoCore.ServerPlugin;

public interface IServerNetwork
{
	void ClientStateChanged(IClient client, bool connected);

	/// <summary>
	///  Called when a packet has been received from a client.
	///  </summary>
	/// <param name="client">The client that has sent the data.</param>
	/// <param name="pipeName">Name of the pipe.</param>
	/// <param name="params">Parameters received from the client.</param>
	void ClientReadPacket(IClient client, string pipeName, object[] @params);

	void ClientPipeCreated(IClient client, string pipeName);

	/// <summary>
	///  Called when a connection pipe has been closed.
	///  </summary>
	/// <param name="client">The client which has closed a pipe.</param>
	/// <param name="pipeName">Name of the pipe.</param>
	void ClientPipeClosed(IClient client, string pipeName);

	void ListenerStateChanged(IListener listener);

	/// <summary>
	///  Called when a listener has failed to listen.
	///  </summary>
	/// <param name="listener">The listener which has failed to listen.</param>
	void ListenerFailed(IListener listener);

	void ListenerAdded(IListener listener);

	/// <summary>
	///  Called when a listener has been removed.
	///  </summary>
	/// <param name="listener">The listener which has has been removed.</param>
	void ListenerRemoved(IListener listener);
}
