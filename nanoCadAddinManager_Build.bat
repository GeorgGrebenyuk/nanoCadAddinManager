REM Step 1: Autobuild solution in Release-mode
set VSVER=[17.0^,18.0^)

::Edit path if VS 2022 is installed on other path
::call "C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvarsall.bat" x64


::Build nanoCadAddinManager
::devenv AddInManager.sln /Build "Release N21|Any CPU"
::devenv AddInManager.sln /Build "Release N22|Any CPU"
::devenv AddInManager.sln /Build "Release N23|Any CPU"
::devenv AddInManager.sln /Build "Release N24|Any CPU"
::devenv AddInManager.sln /Build "Release N25|Any CPU"


::ZIP release
del "nanoCadAddinManager_21.zip"
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_21.zip" "CadAddinManager\bin\Release N21"
del "nanoCadAddinManager_22.zip"
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_22.zip" "CadAddinManager\bin\Release N22"
del "nanoCadAddinManager_23.zip"
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_23.zip" "CadAddinManager\bin\Release N23"
del "nanoCadAddinManager_24.zip"
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_24.zip" "CadAddinManager\bin\Release N24"
del "nanoCadAddinManager_25.zip"
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_25.zip" "CadAddinManager\bin\Release N25"

pause
::@endlocal
::@exit /B 1
