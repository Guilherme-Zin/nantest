# Monitora server.log em tempo real e exibe eventos relevantes do laboratorio.
param(
    [string]$LogPath = (Join-Path $PSScriptRoot "..\server.log"),
    [int]$TailLines = 50
)

function Format-LabLine([string]$line) {
    if ($line -match 'Failed to open plugin|obsolete|Exception|listening on port|Connected to exchange|client connected|disconnect') {
        $color = switch -Regex ($line) {
            'Failed|obsolete|Exception' { 'Red' }
            'listening|Connected' { 'Green' }
            default { 'Yellow' }
        }
        Write-Host $line -ForegroundColor $color
    }
}

if (-not (Test-Path $LogPath)) {
    Write-Host "Log nao encontrado: $LogPath"
    exit 1
}

Write-Host "Monitorando: $LogPath"
Write-Host "Pressione Ctrl+C para parar.`n"

Get-Content $LogPath -Tail $TailLines | ForEach-Object { Format-LabLine $_ }

Get-Content $LogPath -Wait -Tail 0 | ForEach-Object { Format-LabLine $_ }
