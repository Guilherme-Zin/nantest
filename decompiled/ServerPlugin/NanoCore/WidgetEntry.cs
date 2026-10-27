using System.Windows.Forms;

namespace NanoCore;

public sealed class WidgetEntry
{
	public string Name { get; set; }

	/// <summary>
	/// 	<c>True</c> to prevent hiding the widget; otherwise, <c>false</c>.
	///  </summary>
	public bool Locked { get; set; }

	public Control UserControl { get; set; }

	/// <summary>
	///  Delegate to be invoked when the widget state has changed.
	///  </summary>
	public TabStateChangedDelegate StateChangedCallback { get; set; }
}
