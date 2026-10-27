namespace NanoCore.ServerPluginHost;

/// <summary>
///  Provides access to settings and shared variables.
///  </summary>
public interface IServerDataHost
{
	IServerNameObjectCollection Variables { get; }

	/// <summary>
	///  Gets server settings.
	///  </summary>
	/// <value>
	///  Server settings.
	///  </value>
	IServerNameObjectCollection ServerSettings { get; }

	IServerNameObjectCollection BuilderSettings { get; }
}
