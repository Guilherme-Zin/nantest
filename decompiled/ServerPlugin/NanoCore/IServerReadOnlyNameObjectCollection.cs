using System.Collections.Generic;

namespace NanoCore;

public interface IServerReadOnlyNameObjectCollection
{
	/// <summary>
	///  Determines if an entry with the provided name currently exists.
	///  </summary>
	/// <param name="name">Name of the entry.</param>
	/// <returns></returns>
	bool EntryExists(string name);

	KeyValuePair<string, object>[] GetEntries();

	/// <summary>
	///  Gets the value of an entry.
	///  </summary>
	/// <param name="name">Name of the entry.</param>
	/// <param name="defaultValue">Fall back value in case the specified item does not exist.</param>
	/// <returns></returns>
	object GetValue(string name, object defaultValue);
}
