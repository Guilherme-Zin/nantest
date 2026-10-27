namespace NanoCore.ServerPluginHost;

public interface IServerDatabaseHost
{
	/// <summary>
	///  Creates an SQLite database.
	///  </summary>
	/// <param name="databaseName">Name of the database.</param>
	void CreateDatabase(string databaseName);

	void DeleteDatabase(string databaseName);

	/// <summary>
	///  Determines whether or not a database exists.
	///  </summary>
	/// <param name="databaseName">Name of the database.</param>
	/// <returns></returns>
	bool DatabaseExists(string databaseName);

	bool TableExists(string databaseName, string tableName);

	/// <summary>
	///  Executes a standard SQLite query.
	///  </summary>
	/// <param name="databaseName">Name of the database.</param>
	/// <param name="query">An SQLite query string.</param>
	/// <returns></returns>
	ISQLReader ExecuteQuery(string databaseName, string query);

	object ExecuteScalar(string databaseName, string query);

	/// <summary>
	///  Executes an SQLite non-query.
	///  </summary>
	/// <param name="databaseName">Name of the database.</param>
	/// <param name="query">An SQLite query string.</param>
	/// <returns></returns>
	int ExecuteNonQuery(string databaseName, string query);

	string EscapeSQLParam(string param);

	/// <summary>
	///  Escapes an SQLite query string.
	///  </summary>
	/// <param name="query">A formatted SQLite query string.</param>
	/// <param name="params">The parameters to escape and format.</param>
	/// <returns></returns>
	string EscapeSQLQuery(string query, params object[] @params);
}
