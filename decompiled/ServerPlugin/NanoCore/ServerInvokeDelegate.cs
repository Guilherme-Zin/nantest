namespace NanoCore;

/// <summary>
///  Represents the method that is called in the servers's thread context.
///  </summary>
/// <param name="state">State object passed to the method when invoked.</param>
public delegate void ServerInvokeDelegate(object state);
