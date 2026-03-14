@echo off
SET "ProjectName=Zatka"
SET "LocalRepoPath=D:\Programming\nuget-local-repositories"

echo --------------------------------------------------
echo Creating NuGet Package for %ProjectName%...
echo --------------------------------------------------

:: 1. Create the package using the .vbproj file
:: -Prop Configuration=Release ensures it grabs the DLL from bin/Release
nuget pack %ProjectName%\%ProjectName%\%ProjectName%.csproj -Prop Configuration=Release;Authors="medmrt@gmail.com";Description="Zatka library"

IF %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] NuGet Pack failed!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo --------------------------------------------------
echo Moving package to Local Repository...
echo --------------------------------------------------

:: 2. Move the generated .nupkg to your local folder
:: /Y overwrites if the file already exists
move /Y *.nupkg "%LocalRepoPath%\"

echo.
echo SUCCESS: Package created and moved to %LocalRepoPath%
echo --------------------------------------------------
pause