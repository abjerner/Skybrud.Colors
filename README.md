# Skybrud.Colors

Skybrud.Colors is a small library for working with various color models, currently supporting RGB, CMY, CMYK and HSL. The library features converters for converting back and forth between the supported color models.

## Installation

To install Skybrud.Colors, pick one of the methods below:

1. [**NuGet Package**][NuGetPackage]  
   Install the NuGet package in your Visual Studio project. Makes updating easy.
   
2. [**ZIP file**][GitHubRelease]  
   Grab a ZIP file of the latest release; unzip and move `Skybrud.Colors.dll` for your target framework to the bin directory of your project.
   
   

## Usage

Initialize a new `RgbColor` instance and convert to various string formats and other color models:

```csharp
@using Skybrud.Colors
@{


    RgbColor navy = new RgbColor(0, 0, 128);

    // Convert to HEX -> #000080
    string hex = navy.ToHex();
    <pre>@hex</pre>

    // Convert to CSS -> rgb(0, 0, 128)
    string css = navy.ToCss();
    <pre>@css</pre>

    // Convert to HSL -> HSL: 240, 100, 25
    HslColor hsl = navy.ToHsl();
    <pre>@hsl</pre>

    // Convert to CMY -> CMY: 100, 100, 50
    CmyColor cmy = navy.ToCmy();
    <pre>@cmy</pre>

    // Convert to CMYK -> CMYK: 100, 100, 0, 50
    CmykColor cmyk = navy.ToCmyk();
    <pre>@cmyk</pre>

}
```

Get the WCAG contrast ratio between two instances of `RgbColor`:

```csharp
@using Skybrud.Colors
@using Skybrud.Colors.Html
@using Skybrud.Colors.Wcag
@{

    // Get colors from the constants in the "HtmlColors" class
    RgbColor red = HtmlColors.Red;
    RgbColor blue = HtmlColors.Blue;
  
    // Calculate the WCAG contrast ratio
    double ratio = WcagHelpers.GetContrastRatio(red, blue);

    <pre>WCAG ratio: @ratio</pre>

}
```




   
[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Colors
[GitHubRelease]: https://github.com/abjerner/Skybrud.Colors/releases/latest
[Changelog]: https://github.com/abjerner/Skybrud.Colors/releases
[Issues]: https://github.com/abjerner/Skybrud.Colors/issues
