namespace NanoCore;

/// <summary>
///  Represents a toast notification action.
///  </summary>
public sealed class NotificationAction
{
	/// <summary>
	///  Name of the action to be executed.
	///  </summary>
	public string Name { get; set; }

	public NotificationDelegate Callback { get; set; }
}
