using System;
using System.IO;
using Microsoft.Data.Sqlite;
var basePath = args.Length>0?args[0]: ".";
foreach(var db in new[]{"core","main","network","geolocation"}){
 var path = Path.Combine(basePath, "Databases", db+".sqlite");
 if(!File.Exists(path)){Console.WriteLine($"MISSING {path}"); continue;}
 Console.WriteLine($"\n=== {db}.sqlite ===");
 using var conn = new SqliteConnection($"Data Source={path}");
 conn.Open();
 using var cmd = conn.CreateCommand();
 cmd.CommandText = "SELECT name, sql FROM sqlite_master WHERE type='table' ORDER BY name";
 using var r = cmd.ExecuteReader();
 while(r.Read()){ Console.WriteLine($"TABLE {r.GetString(0)}"); if(!r.IsDBNull(1)) Console.WriteLine(r.GetString(1)); }
}
