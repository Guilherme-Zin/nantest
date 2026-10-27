namespace NanoCore;

public sealed class ContextEntry
{
	/// <summary>
	///  The name of the context menu item.
	///  </summary>
	public string Name { get; set; }

	public string Icon { get; set; }

	/// <summary>
	///  The child context menu items of this item.
	///  </summary>
	public ContextEntry[] Children { get; set; }

	public ContextClickedDelegate ClickedCallback { get; set; }

	/// <summary>
	///  Delegate to be invoked when querying the check state of the item. If this is set the context menu item will act as a checkbox instead of a button.
	///  </summary>
	public ContextGetCheckStateDelegate GetCheckStateCallback { get; set; }
}
