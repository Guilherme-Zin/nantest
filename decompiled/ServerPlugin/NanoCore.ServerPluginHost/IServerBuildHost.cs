namespace NanoCore.ServerPluginHost;

/// <summary>
///  Provides access to the stub builder.
///  </summary>
public interface IServerBuildHost
{
	void Compile(string fileName, bool background);
}
