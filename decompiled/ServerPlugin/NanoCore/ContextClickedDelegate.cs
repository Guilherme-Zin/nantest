namespace NanoCore;

/// <summary>
///  Represents the method that is called when a context menu item has been clicked.
///  </summary>
/// <param name="clients">The selected clients to invoke the command on.</param>
/// <param name="checked"><c>True</c> if the command has been enabled; otherwise, <c>false</c>.</param>
public delegate void ContextClickedDelegate(IClient[] clients, bool @checked);
