namespace NanoCore.ClientPluginHost;

/// <summary>
///  Provides access to the client application.
///  </summary>
public interface IClientAppHost
{
	void Restart();

	/// <summary>
	///  Gracefully shuts down the client.
	///  </summary>
	void Shutdown();

	void DisableProtection();

	/// <summary>
	///  Restores any protection mechanisms previously disabled by a call to <see cref="M:NanoCore.ClientPluginHost.IClientAppHost.DisableProtection" />.
	///  </summary>
	void RestoreProtection();

	void Uninstall();
}
