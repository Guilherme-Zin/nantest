using System.Windows.Forms;

namespace NanoCore;

public sealed class SettingEntry
{
	public string CategoryName { get; set; }

	/// <summary>
	///  The control used for the entry.
	///  </summary>
	public Control UserControl { get; set; }
}
