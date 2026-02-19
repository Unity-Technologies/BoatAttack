# 가상환경 활성화 스크립트 (PowerShell)

Set-Location $PSScriptRoot

if (-not (Test-Path "venv")) {
    Write-Host "오류: 가상환경이 존재하지 않습니다." -ForegroundColor Red
    Write-Host "먼저 setup_venv.ps1을 실행하여 가상환경을 생성하세요." -ForegroundColor Yellow
    exit 1
}

& "venv\Scripts\Activate.ps1"

Write-Host "가상환경이 활성화되었습니다." -ForegroundColor Green
Write-Host ""

