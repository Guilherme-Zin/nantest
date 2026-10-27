using System;

namespace NanoCore.ClientPluginHost;

/// <summary>
///  Provides access to client logging.
///  </summary>
public interface IClientLoggingHost
{
	/// <summary>
	///  Logs a client message.
	///  </summary>
	/// <param name="message">The message to be logged.</param>
	void LogClientMessage(string message);

	void LogClientException(Exception ex, string site);
}
