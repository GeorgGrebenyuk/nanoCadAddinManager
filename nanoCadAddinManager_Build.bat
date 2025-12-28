REM Step 1: Autobuild solution in Release-mode
set VSVER=[17.0^,18.0^)

::Edit path if VS 2022 is installed on other path
call "C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvarsall.bat" x64


::Build nanoCadAddinManager
devenv AddInManager.sln /Build "Release N21|Any CPU"
devenv AddInManager.sln /Build "Release N22|Any CPU"
devenv AddInManager.sln /Build "Release N23|Any CPU"
devenv AddInManager.sln /Build "Release N24|Any CPU"
devenv AddInManager.sln /Build "Release N25|Any CPU"

:: nanoCAD 21
del "nanoCadAddinManager_21.zip"
rmdir "nanoCadAddinManager_21"
xcopy "bin\Release N21\*.*" "nanoCadAddinManager_21" /Y /I /E
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_21.zip" "nanoCadAddinManager_21"
rmdir "nanoCadAddinManager_21" /S /Q

:: nanoCAD 22
del "nanoCadAddinManager_22.zip"
rmdir "nanoCadAddinManager_22"
xcopy "bin\Release N22\*.*" "nanoCadAddinManager_22" /Y /I /E
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_22.zip" "nanoCadAddinManager_22"
rmdir "nanoCadAddinManager_22" /S /Q

:: nanoCAD 23
del "nanoCadAddinManager_23.zip"
rmdir "nanoCadAddinManager_23"
xcopy "bin\Release N23\*.*" "nanoCadAddinManager_23" /Y /I /E
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_23.zip" "nanoCadAddinManager_23"
rmdir "nanoCadAddinManager_23" /S /Q

:: nanoCAD 24
del "nanoCadAddinManager_24.zip"
rmdir "nanoCadAddinManager_24"
xcopy "bin\Release N24\*.*" "nanoCadAddinManager_24" /Y /I /E
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_24.zip" "nanoCadAddinManager_24"
rmdir "nanoCadAddinManager_24" /S /Q

:: nanoCAD 25
del "nanoCadAddinManager_25.zip"
rmdir "nanoCadAddinManager_25"
xcopy "bin\Release N25\*.*" "nanoCadAddinManager_25" /Y /I /E
"C:\Program Files\7-Zip\7z" a -tzip "nanoCadAddinManager_25.zip" "nanoCadAddinManager_25"
rmdir "nanoCadAddinManager_25" /S /Q


pause
::@endlocal
::@exit /B 1
