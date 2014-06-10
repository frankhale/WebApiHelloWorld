WebApiHelloWorld
================

A little F# hello,world for learning ASP.NET Web API

NOTE: This uses the pure F# Web API template and now that I've synced
with this repo on another computer I've noticed that the nuget package
restore is broken because the FsWebAddRegistryEntiries nuget package 
cannot be found. This package does not exist in the Nuget Gallery. I
did find a reference to it here. This is not cool because I don't want
to ship nuget packages in my Git repo. I may have to make a compromise
on this particular one.

https://github.com/fsharp/FSharpCommunityTemplates/tree/master/VisualStudio/FsWebAddRegistryEntiries_NuGet

WORKAROUND:

Copy the package from the folder MissingNugetPackages to the packages folder.

10 June 2014