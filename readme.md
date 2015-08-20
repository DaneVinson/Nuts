## Nuts - A Example Application to Explore Deployment with Squirrel
#### Purpose
The intent of Nuts is to act as a sample application to perform exploration of various deployment scenarios using [Squirrel](https://github.com/Squirrel/Squirrel.Windows).
#### Setup
- Update the PackageUrl app setting in the app.config file located in the Nuts project with the location you wish to put your deployment packages.
- Build the solution.
- Build the .nupkg file using the Nuts.nuspec file located in solution root.
- From Visual Studio Package Manager Console: "squirrel -releasify {path to .nupkg file}"
- The previous Squirrel command will generate a Releases sub-folder under your solution folder. Copy its contents to the location specified in the app.config PackageUrl app setting.
- Run setup.exe to install Nuts.