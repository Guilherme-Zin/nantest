using System.Collections.Generic;

namespace NanoCore;

/// <summary>
///  Represents a ReadOnly collection of keys and values.
///  </summary>
public interface IClientReadOnlyNameObjectCollection
{
	bool EntryExists(string name);

	/// <summary>
	///  Gets all of the current entries.
	///  </summary>
	/// <returns></returns>
	KeyValuePair<string, object>[] GetEntries();

	object GetValue(string name, object defaultValue);
}
