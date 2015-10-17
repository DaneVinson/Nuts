## Nuts - Reference application for the exploration of Squirrel deployments
#### In a Nutshell
The intent of Nuts is to act as a sample application for the exploration of deployment scenarios using [Squirrel](https://github.com/Squirrel/Squirrel.Windows). To utilize Nuts you should understand Squirrel as outlined in the [project documentation](https://github.com/Squirrel/Squirrel.Windows/tree/master/docs). Optionally you may want to read Gregor Suttie's [excellent blog post](http://gregorsuttie.com/2015/04/27/squirrel-replace-clickonce-the-easy-way/).
#### Quick Start
1. Update the PackageUrl app setting in the app.config file located in the Nuts project with the location you wish to put your deployment packages. This value can be any valid local disk, UNC or URI path.
1. Restore NuGet packages and build the solution.
1. Generate a .nupkg file using the Nuts.nuspec file located in solution root.
1. From Visual Studio Package Manager Console: "squirrel -releasify {path to .nupkg file}"
1. The previous Squirrel command will generate a Releases sub-folder under your solution folder. Copy its contents to the location specified in the app.config PackageUrl app setting.
1. Run any copy of setup.exe to install Nuts.