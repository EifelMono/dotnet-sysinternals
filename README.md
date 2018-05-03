# dotnet-sysinternals

[![AppVeyor build status][appveyor-badge]](https://ci.appveyor.com/project/EifelMono/dotnet-sysinternals/branch/master)

[appveyor-badge]: https://img.shields.io/appveyor/ci/EifelMono/dotnet-sysinternals/master.svg?label=appveyor&style=flat-square


[![NuGet][main-nuget-badge]][main-nuget]

[main-nuget]: https://www.nuget.org/packages/dotnet-sysinternals/
[main-nuget-badge]: https://img.shields.io/nuget/v/dotnet-sysinterals.svg?style=flat-square&label=nuget

dotnet-sysinternals starts the selected sysinternals program.

This tool inculdes sysinternals Download Sysinternals Suite from February 13, 2018 from 
https://docs.microsoft.com/en-us/sysinternals/downloads/sysinternals-suite

This tool works only on windows

On Windows you can insert dotnet-sysinternals also in the address line.

## Install
```
dotnet tool install dotnet-sysinternals -g
```

## Requirements

[2.1.300-preview2](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview2) .NET Core SDK or newer
Section "Global Tools"

How to check the installed dotnet version
```
dotnet --version
```

## Install .........

### from NuGet.org

```
dotnet tool install dotnet-sysinternals -g
```
This downloads dotnet-sysinternals from NuGet.org

### local after the build

You can also clone the repo and run the cakebuiild build.ps1 or build.sh batch file.<br>
This will install the dotnet-sysinternals from the new build without NuGet.org.

## Uninstall

Goto your personal folder

* Windows
```
cd %userprofile%
```
* Mac and Linux
```
cd ~
``` 
Then goto the folder .dotnet/tools

```
cd .dotnet/tools
```
Here you find the program starter which you can delete.

```
cd .dotnet/tools/.storage
```
Here you find the real program which you can delete.

Or use the dotnet uninstall programm
```
dotnet tool uninstall dotnet-sysinternals -g
```

Or use the cakebuild batch file build.sh or build.ps1 with the target uninstall
```
./build.ps1 -target=uninstall
or
./build.sh -target=uninstall
```

