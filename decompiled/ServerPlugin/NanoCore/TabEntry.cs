using System.Windows.Forms;

namespace NanoCore;

public sealed class TabEntry
{
	/// <summary>
	///  The category name for the entry.
	///  </summary>
	public string CategoryName { get; set; }

	public string Name { get; set; }

	/// <summary>
	///  The category icon for the entry.
	///  </summary>
	public string Icon { get; set; }

	public Control UserControl { get; set; }

	/// <summary>
	///  Delegate to be invoked when the tab state has changed.
	///  </summary>
	public TabStateChangedDelegate StateChangedCallback { get; set; }
}
