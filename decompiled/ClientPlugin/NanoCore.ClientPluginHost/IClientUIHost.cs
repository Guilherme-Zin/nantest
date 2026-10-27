namespace NanoCore.ClientPluginHost;

public interface IClientUIHost
{
	/// <summary>
	///  Invokes the specified method on the UI thread.
	///  </summary>
	/// <param name="method">A <see cref="T:NanoCore.ClientInvokeDelegate" /> to be invoked.</param>
	/// <param name="state">A state object to be passed to the specified method.</param>
	void Invoke(ClientInvokeDelegate method, object state);
}
