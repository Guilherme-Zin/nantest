namespace NanoCore;

public interface ISQLReader
{
	/// <summary>
	///  Retrieves the column with the specified name.
	///  </summary>
	/// <value>
	///  The column's value.
	///  </value>
	object Item { get; }

	object Item { get; }

	/// <summary>
	///  Advances the reader to the next record.
	///  </summary>
	/// <returns></returns>
	bool NextRecord();

	bool NextResultSet();

	/// <summary>
	///  Closes the reader and releases any resources associated with it.
	///  </summary>
	void Close();
}
