# Sincroniza Databases\main.sqlite loadOrder com todos os .ncp em Plugins\
param(
    [string]$NanoRoot = (Join-Path $PSScriptRoot "..")
)

$ErrorActionPreference = "Stop"
$pluginsDir = Join-Path $NanoRoot "Plugins"
$dbPath = Join-Path $NanoRoot "Databases\main.sqlite"

if (-not (Test-Path $dbPath)) {
    Write-Host "Banco nao encontrado: $dbPath" -ForegroundColor Red
    exit 1
}

$preferred = @(
    "CorePlugin.ncp",
    "DucPlugin.ncp",
    "ManagementPlugin.ncp",
    "MiscTools.ncp",
    "MultiCore.ncp",
    "NanoCoreSwiss.ncp",
    "NanoBrowser.ncp",
    "NanoNana.ncp",
    "NanoProtectPlugin.ncp",
    "NanoStress.ncp",
    "NetworkPlugin.ncp",
    "SecurityPlugin.ncp",
    "SurveillanceExPlugin.ncp",
    "SurveillancePlugin.ncp",
    "ToolsPlugin.ncp",
    "LabMonitor.ncp",
    "PacketLogger.ncp"
)

$onDisk = Get-ChildItem $pluginsDir -Filter "*.ncp" | ForEach-Object { $_.Name }
$ordered = @()
foreach ($name in $preferred) {
    if ($onDisk -contains $name) { $ordered += "Plugins\$name" }
}
foreach ($name in ($onDisk | Sort-Object)) {
    $rel = "Plugins\$name"
    if ($ordered -notcontains $rel) { $ordered += $rel }
}

sqlite3 $dbPath "DELETE FROM loadOrder;"
for ($i = 0; $i -lt $ordered.Count; $i++) {
    $escaped = $ordered[$i].Replace("'", "''")
    sqlite3 $dbPath "INSERT INTO loadOrder (name, displayIndex) VALUES ('$escaped', $i);"
}

Write-Host "loadOrder atualizado ($($ordered.Count) plugins)." -ForegroundColor Green
$ordered | ForEach-Object { Write-Host "  $_" }
