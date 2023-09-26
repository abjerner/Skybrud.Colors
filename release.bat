@echo off
dotnet build src/Skybrud.Colors --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget