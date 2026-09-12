# restore-nuget.ps1
# Restaura los paquetes NuGet del proyecto ProyectoFinal a partir de packages.config
# Correr desde "Developer PowerShell for VS" parado en la raíz del repo
# (donde está el .sln)

$ErrorActionPreference = "Stop"

# --- 1. Ubicar el .sln ---
$sln = Get-ChildItem -Path . -Filter *.sln -File | Select-Object -First 1
if (-not $sln) {
    Write-Host "No encontre ningun archivo .sln en esta carpeta." -ForegroundColor Red
    Write-Host "Parate en la raiz del repo (C:\Codigo\C#\ProyectoFinal) y volve a correr el script." -ForegroundColor Yellow
    exit 1
}
Write-Host "Solucion encontrada: $($sln.Name)" -ForegroundColor Cyan

# --- 2. Ubicar o descargar nuget.exe ---
$nugetPath = Join-Path $PSScriptRoot "nuget.exe"

$nugetCmd = Get-Command nuget.exe -ErrorAction SilentlyContinue
if ($nugetCmd) {
    $nugetPath = $nugetCmd.Source
    Write-Host "Usando nuget.exe existente en PATH: $nugetPath" -ForegroundColor Cyan
}
elseif (Test-Path $nugetPath) {
    Write-Host "Usando nuget.exe local: $nugetPath" -ForegroundColor Cyan
}
else {
    Write-Host "No se encontro nuget.exe. Descargando la ultima version..." -ForegroundColor Yellow
    $url = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
    try {
        Invoke-WebRequest -Uri $url -OutFile $nugetPath -UseBasicParsing
        Write-Host "nuget.exe descargado en: $nugetPath" -ForegroundColor Green
    }
    catch {
        Write-Host "No se pudo descargar nuget.exe. Revisa tu conexion a internet." -ForegroundColor Red
        Write-Host $_.Exception.Message -ForegroundColor Red
        exit 1
    }
}

# --- 3. Restaurar paquetes ---
Write-Host "`nRestaurando paquetes NuGet para $($sln.Name)..." -ForegroundColor Cyan
& $nugetPath restore $sln.FullName

if ($LASTEXITCODE -ne 0) {
    Write-Host "`nEl restore fallo (codigo $LASTEXITCODE)." -ForegroundColor Red
    Write-Host "Revisa el mensaje de arriba. Causas comunes:" -ForegroundColor Yellow
    Write-Host "  - No tenes conexion a internet o el feed de NuGet.org esta bloqueado"
    Write-Host "  - Falta el archivo nuget.config con la fuente de paquetes configurada"
    exit 1
}

Write-Host "`nRestore completado con exito." -ForegroundColor Green
Write-Host "Ahora abri la solucion en Visual Studio y compila (Ctrl+Shift+B)." -ForegroundColor Green

# --- 4. Chequeo rapido: avisar si falta la carpeta packages/ ---
$packagesDir = Join-Path (Split-Path $sln.FullName) "packages"
if (Test-Path $packagesDir) {
    $count = (Get-ChildItem $packagesDir -Directory).Count
    Write-Host "`nCarpeta 'packages/' encontrada con $count paquetes instalados." -ForegroundColor Cyan
} else {
    Write-Host "`nOJO: no se genero la carpeta 'packages/'. Revisa si el proyecto usa PackageReference en vez de packages.config." -ForegroundColor Yellow
}
