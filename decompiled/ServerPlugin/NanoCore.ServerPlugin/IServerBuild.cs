namespace NanoCore.ServerPlugin;

/// <summary>
///  Provides event callbacks for client build operations.
///  </summary>
public interface IServerBuild
{
	/// <summary>
	///  Called before the build operation begins.
	///  </summary>
	/// <param name="e">The <see cref="T:NanoCore.IBuildEventArgs" /> instance containing the event data.</param>
	void PreBuild(IBuildEventArgs e);

	void PostBuild(IBuildEventArgs e);
}
