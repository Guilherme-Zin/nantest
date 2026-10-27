# Aplica perfis de plugin para ambiente de laboratorio.
param(
    [ValidateSet("rede", "ui-only", "completo-lab")]
    [string]$Profile = "completo-lab",
    [switch]$Apply
)

$base = Join-Path $PSScriptRoot ".."
$pluginsDir = Join-Path $base "Plugins"

$profiles = @{
    "rede" = @(
        "CorePlugin.ncp",
        "NetworkPlugin.ncp",
        "ToolsPlugin.ncp",
        "LabMonitor.ncp",
        "PacketLogger.ncp"
    )
    "ui-only" = @(
        "CorePlugin.ncp",
        "ManagementPlugin.ncp",
        "LabMonitor.ncp"
    )
    "completo-lab" = @(
        "CorePlugin.ncp",
        "DucPlugin.ncp",
        "ManagementPlugin.ncp",
        "MiscTools.ncp",
        "MultiCore.ncp",
        "NanoBrowser.ncp",
        "NanoCoreSwiss.ncp",
        "NanoNana.ncp",
        "NanoProtectPlugin.ncp",
        "NetworkPlugin.ncp",
        "SecurityPlugin.ncp",
        "ToolsPlugin.ncp",
        "LabMonitor.ncp",
        "PacketLogger.ncp"
    )
}

$selected = $profiles[$Profile]
Write-Host "Perfil: $Profile"
Write-Host "Plugins ativos:"
$selected | ForEach-Object { Write-Host "  - $_" }

if (-not $Apply) {
    Write-Host ""
    Write-Host "Simulacao apenas. Use -Apply para mover plugins extras para Plugins\_profiles\$Profile\"
    exit 0
}

$archive = Join-Path $pluginsDir "_profiles\$Profile"
New-Item -ItemType Directory -Force -Path $archive | Out-Null

Get-ChildItem $pluginsDir -Filter "*.ncp" | ForEach-Object {
    if ($selected -notcontains $_.Name) {
        $dest = Join-Path $archive $_.Name
        Write-Host "Arquivando $($_.Name)"
        Move-Item $_.FullName $dest -Force
    }
}

Write-Host "Perfil aplicado."
