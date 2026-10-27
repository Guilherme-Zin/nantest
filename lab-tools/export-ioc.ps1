# Exporta IOCs e eventos do server.log para JSON (analise forense no lab).
param(
    [string]$LogPath = (Join-Path $PSScriptRoot "..\server.log"),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\LabAnalysis\ioc-export.json")
)

$analysisDir = Split-Path $OutputPath -Parent
New-Item -ItemType Directory -Force -Path $analysisDir | Out-Null

if (-not (Test-Path $LogPath)) {
    Write-Host "Log nao encontrado: $LogPath"
    exit 1
}

$lines = Get-Content $LogPath
$events = @()
$ports = @()
$plugins = @()
$errors = @()

foreach ($line in $lines) {
    if ($line -match 'listening on port (\d+)') {
        $ports += [int]$Matches[1]
    }
    if ($line -match "Found plugin '([^']+)'") {
        $plugins += $Matches[1]
    }
    if ($line -match 'Failed to open plugin|obsolete|Exception') {
        $errors += $line.Trim()
    }
    if ($line -match 'Server has begun|Loading plugin|Connected to exchange|Writing server settings') {
        $events += @{
            type = 'server_event'
            raw  = $line.Trim()
        }
    }
}

$report = [ordered]@{
    exportedAt    = (Get-Date).ToString('o')
    sourceLog     = (Resolve-Path $LogPath).Path
    listeningPorts = ($ports | Select-Object -Unique | Sort-Object)
    loadedPlugins  = ($plugins | Select-Object -Unique)
    errorCount     = $errors.Count
    recentErrors   = ($errors | Select-Object -Last 20)
    eventSample    = ($events | Select-Object -Last 30)
}

$report | ConvertTo-Json -Depth 6 | Set-Content -Path $OutputPath -Encoding UTF8
Write-Host "Exportado: $OutputPath"
