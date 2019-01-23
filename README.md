# Xamarin.Forms.Toolkit

Xamarin.Forms.Toolkit ...

[![Gitter chat](https://badges.gitter.im/gitterHQ/gitter.png)](https://gitter.im/Xamarin.Forms.Toolkit)

## Build Status


## Sample App
Try out Xamarin.Forms.Toolkit on your device!


## Installation

Xamarin.Forms.Toolkit is available via:

* NuGet Official Releases: [![NuGet](https://img.shields.io/nuget/vpre/Xamarin.Forms.Toolkit.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.Forms.Toolkit)

## Documentation


## Supported Platforms

Xamarin.Forms Toolkit is focused on the following platforms:

* iOS (10+)
* Android (4.4+)
* UWP (Fall Creators Update+)

## API Documentation

The following cross-platform APIs are available in Xamarin.Forms.Toolkit:


## Contributing

Please read through our [Contribution Guide](CONTRIBUTING.md). We are not accepting new PRs for full features, however any [issue that is marked as `up for grabs`](https://github.com/Xamarin.Forms.Toolkit/issues?q=is%3Aissue+is%3Aopen+label%3A%22up+for+grabs%22) are open for community contributions. We encourage creating new issues for bugs found during usage that the team will triage. Additionally, we are open for code refactoring suggestions in PRs.

## Building Xamarin.Forms.Toolkit

Xamarin.Forms.Toolkit is built with the new SDK-style projects with multi-targeting enabled. This means that all code for iOS, Android, and UWP exist inside of the Xamarin.Forms.Toolkit project.

If building on Visual Studio 2017, you will need the following SDKs and workloads installed:

### Workloads need:

* Xamarin
* .NET Core
* UWP

### You will need the following SDKs

* Android 8.1 SDK Installed
* UWP 10.0.16299 SDK Installed

If using Visual Studio for Mac the project can be built at the command line with MSBuild. To change the project type that you are working with, simply edit Xamarin.Forms.Toolkit.csproj and modify the TargetFrameworks for only the project type you want to use.

To build through the command line, navigate to where Xamarin.Forms.Toolkit.csproj exists then run:

```csharp
msbuild /restore Xamarin.Forms.Toolkit.csproj
```

## FAQ

Here are some frequently asked questions about Xamarin.Forms.Toolkit, but be sure to read our full [FAQ on our Wiki](https://github.com/Xamarin.Forms.Toolkit/wiki#feature-faq).

## License

Please see the [License](LICENSE).
