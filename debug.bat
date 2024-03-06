@echo off
dotnet build src/Skybrud.Colors --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:\nuget