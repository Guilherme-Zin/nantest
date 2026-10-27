using System.Collections.Generic;

namespace NanoCore;

/// <summary>
///  Represents a collection of keys and values.
///  </summary>
public interface IClientNameObjectCollection
{
	bool EntryExists(string name);

	/// <summary>
	///  Gets all of the current entries.
	///  </summary>
	/// <returns></returns>
	KeyValuePair<string, object>[] GetEntries();

	object GetValue(string name, object defaultValue);

	/// <summary>
	///  Sets the value of an entry.
	///  </summary>
	/// <param name="name">Name of the entry.</param>
	/// <param name="value">Value to set for the entry.</param>
	void SetValue(string name, object value);

	void RemoveValue(string name);
}
