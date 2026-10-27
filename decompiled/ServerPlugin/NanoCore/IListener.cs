namespace NanoCore;

public interface IListener
{
	/// <summary>
	///  Gets the port number that represents this <see cref="T:NanoCore.IListener" /> instance.
	///  </summary>
	/// <value>The port number.</value>
	ushort PortNumber { get; }

	int Connections { get; }

	/// <summary>
	///  Gets a value indicating the current status of the listener.
	///  </summary>
	/// <value>The current status of the listener.</value>
	ListenerStatus Status { get; }
}
