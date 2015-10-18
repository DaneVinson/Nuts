## Nuts - Reference application for the exploration of Squirrel deployments ##
## In a Nutshell ##
The intent of Nuts is to act as a reference application for the exploration of deployment scenarios using [Squirrel](https://github.com/Squirrel/Squirrel.Windows). To utilize Nuts you should understand Squirrel as outlined in the [project documentation](https://github.com/Squirrel/Squirrel.Windows/tree/master/docs). Additionally, you may wish to read Gregor Suttie's excellent blog post [Squirrel – replace ClickOnce the easy way](http://gregorsuttie.com/2015/04/27/squirrel-replace-clickonce-the-easy-way/).
## Quick Start ##
1. Update the `PackageUrl` app setting in the app.config file located in the Nuts project with the location you wish to put your deployment packages. This value can be any valid local disk, UNC or URL path.
1. Open the solution, restore NuGet packages and build with Debug configuration.
1. Generate a `.nupkg` file using the `Nuts.nuspec` file located in solution root.
1. Open Visual Studio Package Manager Console and enter `squirrel -releasify {path to .nupkg}`
1. The `releasify` command will generate a `Releases` sub-folder under your solution folder. That folder will contain one or more `.nupkg` files, `setup.exe` and a file named `RELEASES`. Copy `.nupkg` files and `RELEASES` the location specified by the `PackageUrl` app setting.
1. Run any copy of `setup.exe` to install Nuts.

## Web Hosting ##
Hosting Squirrel deployments across the web is fairly simple but there are a couple of gotchas to attend to. 

While Squirrel leverages NuGet heavily, your generated Squirrel deployments (`.nupkg` and `RELEASES` files) are not themselves NuGet packages so don't try exposing them through a NuGet feed. Simply host Squirrel deployment files exactly as you would any other web resource and set the `PackageUrl` app setting with the URL of their root location.

Ensure your web server has following two necessary MIME type mappings (example from `web.config`). The first maps `.nupkg` files to zip. The second maps files without extension to plain text. The second mapping is required to expose the Squirrel generated file `RELEASES` to reads from a client.

    <system.webServer>
        <staticContent>
            <mimeMap fileExtension=".nupkg" mimeType="application/zip" />
            <mimeMap fileExtension="." mimeType="text/plain" />
        </staticContent>
    </system.webServer>
