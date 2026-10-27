namespace NanoCore.ServerPlugin;

/// <summary>
///  Provides event callbacks for settings and shared variables.
///  </summary>
public interface IServerData
{
	/// <summary>
	///  Called when a shared variable has been changed.
	///  </summary>
	/// <param name="name">Name of the variable.</param>
	void VariableChanged(string name);

	void ClientVariableChanged(IClient client, string name);

	/// <summary>
	///  Called when a server setting has been changed.
	///  </summary>
	/// <param name="name">Name of the setting.</param>
	void ServerSettingChanged(string name);

	void BuilderSettingChanged(string name);
}
