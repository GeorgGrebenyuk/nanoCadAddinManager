# nanoCAD Add-in Manager

![Platform](https://img.shields.io/badge/platform-Windows-lightgray.svg) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

## Summary

Current project is a fork of `CadAddinManager` (https://github.com/chuongmep/CadAddinManager ) for nanoCAD

Russian's text read at [Readme_RU.md](./Readme_RU.md).

![AddinManager](pic/Addin.png)

Usually, when developing and debugging an addin with **nanoCAD** API, user has to close & re-open **nanoCAD**  each time
he/she modifies the addin code and wants to re-compile. But with **Add-In Manager**, user can modify and run the Addin.
directly without closing & re-opening **nanoCAD** again and again. As an alternative, you can use [Hot Reload](https://docs.microsoft.com/en-us/visualstudio/debugger/hot-reload?view=vs-2022) to speed it. But try this project it will be faster with any Addin.

- [x] [Revit Add-In Manager](https://github.com/chuongmep/RevitAddInManager)

- [x] [Navis Add-In Manager](https://github.com/chuongmep/NavisAddInManager)

- [x] [Cad Add-In Manager](https://github.com/chuongmep/CadAddInManager)

Some feature include:

- A newbie can create a new Add-in and explore **nanoCAD** easy with Add-in manager.

- Add-in tester(use Debug Nnd Trace to test your add-in).

- **Debug / Trace** : Support Show result use [Debug](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debug?view=net-6.0) or [Trace](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.trace?view=net-6.0) to show result in nanoCAD.

- Add-in manager
  
  - AddInManager Manual : Use for normal process load/unload addin
  - AddInManager Faceless : use for load last process before addin without UI

- Allow user know whether plugin can load successfully or not.

- <kbd>F5</kbd> - Load fresh plugin don't need load again.

- <kbd>F1</kbd> - Go link open source report some error,bug or feature request.

- <kbd>Delete</kbd> - Quick remove by use right click or use from keyboard.

- <kbd>Crt + MouseWheel</kbd> - Zoom in/out by use mouse wheel in command plugin.

- <kbd>Arrow Up</kbd> - Move from TreeView to search.

- <kbd>Arrow Down</kbd> - Move from search to TreeView.

- <kbd>Esc</kbd> - Quick Close Add-in Manager.

- <kbd>Enter</kbd> - Quick Run Execute a command selected in Add-in Manager.
  
  ## Add-In Manager

![](pic/AddinManager.gif)

### Command

- [x] AddInManagerManual
- [x] AddInManagerFaceless

Execute a command easily  :

1. Create a class library use .NET

2. Add library nanoCAD .NET API

3. Create a command, example:
   
   ```cs
   [CommandMethod("DoSomething")]
   public void Execute()
   {
       // do some thing code here
   }
   ```
   
   4.Load To Add-in Manager.
   
   5.Double click to run command.
   
   6.Use faceless when you change code or rebuild.

### Lisp Function

Execute a Lisp Function easily  :

1. Create a class library use .NET

2. Add library nanoCAD API

3. Create a Lisp Function, example:
   
   ```cs
    [LispFunction("DisplayFullName")]
    public static void DisplayFullName(ResultBuffer rbArgs)
    {
        if (rbArgs != null)
        {
            string strVal1 = "";
            string strVal2 = "";
            int nCnt = 0;
            foreach (TypedValue rb in rbArgs)
            {
                if (rb.TypeCode == (int) HostMgd.Runtime.LispDataType.Text)
                {
                    switch (nCnt)
                    {
                        case 0:
                            strVal1 = rb.Value.ToString();
                            break;
                        case 1:
                            strVal2 = rb.Value.ToString();
                            break;
                    }
                    nCnt = nCnt + 1;
                }
            }
            Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nName: " + strVal1 + " " + strVal2);
            MessageBox.Show("Updated");
        }
    }
   ```
   
   4.Load To Add-in Manager.

5.Use Reload when you change code or rebuild.

~6.Run Lisp Function [example](https://github.com/chuongmep/CadAddinManager/blob/9982d2a2b32591f508c0ce0e55e0d636ba38092c/Test/FunctionLispTest.cs#L9-L34) : `(displayfullname "First" "Last") `~

### Trace/Debug

- [x] Show/Hide result inside Dockpanel Autocad and Civil3D.
- [x] Show Result history inside CadAddinManager.
- [x] Clear Result.
- [x] Show Result by color.

A sample command to execute:

```csharp
using System.Diagnostics;
using Teigha.Runtime;
public class DebugTraceTest
{
    [CommandMethod("DebugTraceTest")]
    public void Action()
    {
        //Trace or Debug Something
        Trace.WriteLine($"Warning: This is a warning");
        Trace.WriteLine($"Error: This is a error");
        Trace.WriteLine($"Add: This is a add");
        Trace.WriteLine($"Modify: This is a modify");
        Trace.WriteLine($"Delete: This is a delete");
    }
}
```

![](pic/DockPanelOutput.png)

## Installation

Please follow last Release Nt section [Release](https://github.com/GeorgGrebenyuk/nanoCadAddinManager/releases/latest)

Support nanoCAD Version : 21, 22, 23, 24, 25

---

## Authors and changing from ChuongHo's original version (CadAddinManager)

Originally implemented by [ChuongHo](https://github.com/chuongmep) with platform **WPF** and add more feature to fit
with the progressive development of modern technology. His focus is to work smarter and achieve the most effective
practices to enhance data utilization and digital collaboration among AEC parties.

Ported to nanoCAD by [GeorgGrebenyuk](https://github.com/GeorgGrebenyuk). There were next changings:

- replacing Autodesk.AutoCAD's NuGet's packages to nanoCAD with other versions;
- replacing namespaces from AutoCAD to nanoCAD;
- project `CadAddinManager` was renamed to `nanoCadAddinManager`;
- delete `App.cs` from `CadAddinManager`, because there are no analogue in nanoCAD as `AutoCAD.Windows`;
- menu for nanoCAD was generated with the my [auxiliary library](https://github.com/GeorgGrebenyuk/ncad_UI_creator) and was integrated to project `CadAddinManager` as copying files to TargetDir;
- script `posybuild.ps1` was deleted, because in nanoCAD there are no analogue `shared-folder` for apps;
- editing this ReadMe to nanoCAD's specific;
- adding a CustomAttribute.IsResolved checking to `AssemLoader.ResolveDuplicateMethod`, because for some unloaded assemblies (for nanoCAD) it will getting to error;
- creation a safe-version of method `AddInManagerViewModel.ClearCommandClick()`. Original version's will create a Fatal error in nanoCAD;
- redefinition of procedure `AddInManagerViewModel.LoadCommandClick` to prevent Fatal error, if some method from library_1 will call some method2 from library_2. You will lost possibility to update second libraries via that's CadAddinManager until reloading nanoCAD;

---

## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see
the [License](License.md) file for full details.

---

## Credits

### From base CadAddinManager

- Credit to [Chuongmep](https://github.com/chuongmep)
- Credit to [icons8.com](https://icons8.com) for the Cad Add-in Manager icons.
- Credit to [Nice3point](https://github.com/Nice3point) for the CI/CD template.

### New

- Credit to [GeorgGrebenyuk](https://github.com/GeorgGrebenyuk) for porting to nanoCAD

## Known Issues

- If XAML not showed in VS 2022 on `net6.0+` add the local `System.Runtime.dll` and `PresentationFramework.dll` libraries to csproj;
- If you getting an error in nanoCAD 

```log
AddInManagerManual - AddInManagerManualMono.Cecil.AssemblyResolutionException: Failed to resolve assembly: 'hostdbmgd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' ...
at CadAddinManager.Model.AssemLoader.ResolveDuplicateMethod(String originalFilePath) in CadAddinManager\Model\AssemLoader.cs:line 109 ...
```

you need copy needing reference versions of nanoCAD's .API libraries to TargetDir;

## Learning Resources

- <a href="https://developer.nanocad.ru/redmine/projects/ncadsdk/boards" target="_blank">nanoCAD Developer Club (RU)</a>
- <a href="https://developer.nanocad.com/redmine/projects/ncadsdk/boards" target="_blank">nanoCAD Developer Club (RU)</a>

## TODO

- Edit the projects `Installer`, `Build` to nanoCAD's specific (now building only with script `nanoCadAddinManager_Build.bat`);
- Add support two and more loaded assemblies in CAD (?);