$ErrorActionPreference = "Stop"
$base = Split-Path $PSScriptRoot -Parent
$dotnet = Join-Path $base "tools\dotnet-sdk\dotnet.exe"
$toolDir = Join-Path $base "tools\sqlite-inspect"

if (-not (Test-Path (Join-Path $toolDir "sqlite-inspect.csproj"))) {
    New-Item -ItemType Directory -Force -Path $toolDir | Out-Null
    @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.Data.Sqlite" Version="8.0.0" />
  </ItemGroup>
</Project>
'@ | Set-Content -Path (Join-Path $toolDir "sqlite-inspect.csproj")
    @'
using System;
using System.IO;
using Microsoft.Data.Sqlite;

var basePath = args.Length > 0 ? args[0] : ".";
foreach (var db in new[] { "core", "main", "network", "geolocation" })
{
    var path = Path.Combine(basePath, "Databases", db + ".sqlite");
    if (!File.Exists(path))
    {
        Console.WriteLine("MISSING " + path);
        continue;
    }

    Console.WriteLine();
    Console.WriteLine("=== " + db + ".sqlite ===");
    using var conn = new SqliteConnection("Data Source=" + path);
    conn.Open();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = "SELECT name, sql FROM sqlite_master WHERE type='table' ORDER BY name";
    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine("TABLE " + reader.GetString(0));
        if (!reader.IsDBNull(1))
        {
            Console.WriteLine(reader.GetString(1));
        }
    }
}
'@ | Set-Content -Path (Join-Path $toolDir "Program.cs") -Encoding UTF8
}

& $dotnet run --project (Join-Path $toolDir "sqlite-inspect.csproj") -- $base
