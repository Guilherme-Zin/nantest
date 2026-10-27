namespace NanoCore.ClientPlugin;

/// <summary>
///  Provides event callbacks from the client application.
///  </summary>
public interface IClientApp
{
	/// <summary>
	///  Called when a plugin is being uninstalled. Plugin should stop all work and perform clean up operations.
	///  </summary>
	void PluginUninstalling();

	void ClientUninstalling();
}
