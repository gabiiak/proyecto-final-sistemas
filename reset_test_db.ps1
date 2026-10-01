# Resetear la base de PRUEBA (TandGSystemTest) a los datos semilla.
# La base de desarrollo (TandGSystem) NO se toca.
#
# Uso:  .\reset_test_db.ps1
#
# El script migracion_sqlserver.sql es idempotente (borra y recrea las tablas),
# asi que resetear es simplemente volver a ejecutarlo contra TandGSystemTest.

$ErrorActionPreference = 'Stop'

$migracion = Join-Path $PSScriptRoot 'migracion_sqlserver.sql'

if (-not (Test-Path -LiteralPath $migracion)) {
    throw "No se encontro el script de migracion en $migracion"
}

Write-Host "Reseteando TandGSystemTest..." -ForegroundColor Cyan

& sqlcmd -S localhost -E -v BaseNombre="TandGSystemTest" -i $migracion -b

if ($LASTEXITCODE -ne 0) {
    throw "El script de migracion fallo (sqlcmd exit $LASTEXITCODE)"
}

Write-Host "Listo. TandGSystemTest quedo con los datos semilla." -ForegroundColor Green
