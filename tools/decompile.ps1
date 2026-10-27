# Descompila os binarios principais do NanoCore com ILSpy (ilspycmd).
# Requer .NET 8+ runtime: https://dotnet.microsoft.com/download/dotnet/8.0

$ErrorActionPreference = "Stop"
$Base = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
if (-not (Test-Path (Join-Path $Base "NanoCore.exe"))) {
    $Base = Split-Path $PSScriptRoot -Parent
}

$IlSpyCmd = Join-Path $PSScriptRoot "ilspycmd_pkg\tools\net8.0\any\ilspycmd.dll"
$OutRoot = Join-Path $Base "decompiled"

if (-not (Test-Path $IlSpyCmd)) {
    Write-Host "ilspycmd nao encontrado. Execute primeiro o setup de ferramentas."
    exit 1
}

$Targets = @(
    @{ Name = "NanoCore";       File = "NanoCore.exe" },
    @{ Name = "ServerPlugin";   File = "ServerPlugin.dll" },
    @{ Name = "ClientPlugin";   File = "ClientPlugin.dll" },
    @{ Name = "PluginCompiler"; File = "PluginCompiler.exe" }
)

New-Item -ItemType Directory -Force -Path $OutRoot | Out-Null

foreach ($target in $Targets) {
    $input = Join-Path $Base $target.File
    $output = Join-Path $OutRoot $target.Name
    Write-Host "Descompilando $($target.File) -> $output"
    dotnet $IlSpyCmd -p -o $output $input
}

Write-Host "Concluido. Codigo em: $OutRoot"
