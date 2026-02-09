@echo off
REM 가상환경 활성화 스크립트 (Windows Batch)

cd /d "%~dp0"

if not exist "venv" (
    echo 오류: 가상환경이 존재하지 않습니다.
    echo 먼저 setup_venv.bat을 실행하여 가상환경을 생성하세요.
    pause
    exit /b 1
)

call venv\Scripts\activate.bat

echo 가상환경이 활성화되었습니다.
echo.

