namespace NanoCore;

public interface IBuildEventArgs
{
	string FileName { get; }

	/// <summary>
	/// 	<c>True</c> if the build process is running in the background; otherwise, <c>false</c>.
	///  </summary>
	bool Background { get; }

	bool Cancel { get; set; }

	/// <summary>
	///  The reason provided for canceling the build operation.
	///  </summary>
	string CancelReason { get; set; }
}
