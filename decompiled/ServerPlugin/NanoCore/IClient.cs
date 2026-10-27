using System;
using System.Net;

namespace NanoCore;

public interface IClient
{
	Guid Id { get; }

	/// <summary>
	///  Gets the client's remote address and local port.
	///  </summary>
	/// <value>
	///  The IPEndPoint representing the clients remote address and local port.
	///  </value>
	IPEndPoint EndPoint { get; }

	IServerNameObjectCollection Variables { get; }

	/// <summary>
	///  Gets or sets a state object for the client.
	///  </summary>
	/// <value>
	///  The state object.
	///  </value>
	object State { get; set; }
}
