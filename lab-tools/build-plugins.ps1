# Compila os plugins de laboratorio (DLL → .ncp)
$ErrorActionPreference = "Stop"
$base = Split-Path $PSScriptRoot -Parent
$msbuild = "$env:WINDIR\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

if (-not (Test-Path $msbuild)) {
    Write-Host "MSBuild nao encontrado."
    exit 1
}

# 1) Compila os projetos C# → DLL
$projects = @(
    @{ Name = "LabMonitor"; Project = "lab-plugins\LabMonitor\LabMonitor.csproj" },
    @{ Name = "PacketLogger"; Project = "lab-plugins\PacketLogger\PacketLogger.csproj" }
)

New-Item -ItemType Directory -Force -Path (Join-Path $base "LabAnalysis") | Out-Null
New-Item -ItemType Directory -Force -Path (Join-Path $base "lab-plugins\output") | Out-Null

foreach ($proj in $projects) {
    $projPath = Join-Path $base $proj.Project
    Write-Host "Compilando $($proj.Name)..." -ForegroundColor Cyan
    & $msbuild $projPath /p:Configuration=Release /v:minimal 2>&1 | Out-Null

    $dll = Join-Path $base "lab-plugins\$($proj.Name)\bin\Release\$($proj.Name).dll"
    if (Test-Path $dll) {
        Copy-Item $dll (Join-Path $base "lab-plugins\output\$($proj.Name).dll") -Force
        Write-Host "  DLL: $($proj.Name).dll" -ForegroundColor Green
    } else {
        Write-Host "  FALHOU: DLL nao encontrada em $dll" -ForegroundColor Red
        exit 1
    }
}

# 2) Compila o NcpPackager (se necessario)
$packager = Join-Path $base "lab-tools\NcpPackager\NcpPackager.exe"
if (-not (Test-Path $packager)) {
    Write-Host "Compilando NcpPackager..." -ForegroundColor Cyan
    $csc = "$env:WINDIR\Microsoft.NET\Framework\v4.0.30319\csc.exe"
    & $csc /reference:"System.Security.dll" /out:$packager /target:exe /platform:x86 (Join-Path $base "lab-tools\NcpPackager\Program.cs") 2>&1 | Out-Null
}

if (-not (Test-Path $packager)) {
    Write-Host "FALHOU: NcpPackager nao compilado" -ForegroundColor Red
    exit 1
}

# 3) Gera os .ncp
Write-Host "`nGerando .ncp..." -ForegroundColor Cyan
$plugins = @(
    @{ Name = "Lab Monitor"; Dll = "LabMonitor.dll" },
    @{ Name = "Packet Logger"; Dll = "PacketLogger.dll" }
)

$password = "lab"
$pluginsDir = Join-Path $base "Plugins"

foreach ($plugin in $plugins) {
    $dllFile = Join-Path $base "lab-plugins\output\$($plugin.Dll)"
    $ncpFile = Join-Path $pluginsDir "$($plugin.Dll -replace '\.dll$','').ncp"

    & $packager $dllFile $ncpFile --name $plugin.Name --password $password

    if ($LASTEXITCODE -eq 0 -and (Test-Path $ncpFile)) {
        Write-Host "  .ncp: $($plugin.Name)" -ForegroundColor Green
    } else {
        Write-Host "  FALHOU: $($plugin.Name)" -ForegroundColor Red
    }
}

Write-Host "`nSincronizando loadOrder..." -ForegroundColor Cyan
& (Join-Path $PSScriptRoot "sync-load-order.ps1") -NanoRoot $base

Write-Host "`nConcluido!" -ForegroundColor Cyan
Get-ChildItem (Join-Path $base "Plugins") -Filter "*.ncp" | Select-Object Name, Length
