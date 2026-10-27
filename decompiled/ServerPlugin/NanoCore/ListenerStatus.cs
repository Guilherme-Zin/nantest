namespace NanoCore;

public enum ListenerStatus : byte
{
	/// <summary>
	///  Indicates that the listener is disabled.
	///  </summary>
	Disabled,
	Binding,
	/// <summary>
	///  Indicates that the listener is listening for connections.
	///  </summary>
	Listening,
	Failed,
	/// <summary>
	///  Indicates that the listener has been removed.
	///  </summary>
	Removed
}
