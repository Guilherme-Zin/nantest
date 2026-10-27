namespace NanoCore.ClientPlugin;

public interface IClientData
{
	void VariableChanged(string name);

	/// <summary>
	///  Called when a client setting has been changed.
	///  </summary>
	/// <param name="name">Name of the setting.</param>
	void ClientSettingChanged(string name);
}
