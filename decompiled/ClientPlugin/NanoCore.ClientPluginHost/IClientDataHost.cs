namespace NanoCore.ClientPluginHost;

public interface IClientDataHost
{
	/// <summary>
	///  Gets shared variables.
	///  </summary>
	/// <value>
	///  Shared variables.
	///  </value>
	IClientNameObjectCollection Variables { get; }

	IClientNameObjectCollection ClientSettings { get; }

	/// <summary>
	///  Gets builder settings.
	///  </summary>
	/// <value>
	///  Builder settings.
	///  </value>
	IClientReadOnlyNameObjectCollection BuilderSettings { get; }
}
