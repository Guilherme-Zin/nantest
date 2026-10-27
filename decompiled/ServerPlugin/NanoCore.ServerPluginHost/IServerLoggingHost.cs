using System;

namespace NanoCore.ServerPluginHost;

public interface IServerLoggingHost
{
	void LogServerMessage(LogColor logColor, string message);

	/// <summary>
	///  Logs a server exception.
	///  </summary>
	/// <param name="ex">The exception to be logged.</param>
	/// <param name="site">The site or method name in which the exception occurred.</param>
	void LogServerException(Exception ex, string site);

	void LogBuilderMessage(LogColor logColor, string message);

	/// <summary>
	///  Logs a builder exception.
	///  </summary>
	/// <param name="ex">The exception to be logged.</param>
	/// <param name="site">The site or method name in which the exception occurred.</param>
	void LogBuilderException(Exception ex, string site);
}
