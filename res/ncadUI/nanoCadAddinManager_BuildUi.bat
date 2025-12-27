:: Сборка всего конфига (для NBIMs)
call "..\..\3rdparty\ncad_UI_creator_60\NC_UI_Creator_App.exe" "nanoCadAddinManagerCommands.xml"

:: Замена иконок в папке с библиотекой 
copy iconBase.ico "..\..\CadAddinManager\Resources\AddInManagerManual.ico"  /Y
copy iconBase.ico "..\..\CadAddinManager\Resources\AddInManagerFaceLess.ico"  /Y
copy iconBase.ico "..\..\CadAddinManager\Resources\AddinManagerDockPanel.ico"  /Y

:: Копирование файлоав адаптации меню

xcopy nanoCadAddinManager.package "..\..\CadAddinManager" /Y /I
xcopy nanoCadAddinManagerUi* "..\..\CadAddinManager" /Y /I

pause
