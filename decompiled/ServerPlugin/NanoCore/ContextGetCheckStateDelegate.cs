using System.Windows.Forms;

namespace NanoCore;

/// <summary>
///  Represents the method that is called when the server is requesting a context menu item's check state.
///  </summary>
/// <param name="clients">The selected clients to query the check state from.</param>
/// <returns></returns>
public delegate CheckState ContextGetCheckStateDelegate(IClient[] clients);
