# Skybrud.Colors

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/abjerner/Skybrud.Colors/blob/v1/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/Skybrud.Colors.svg)](https://www.nuget.org/packages/Skybrud.Colors)
[![NuGet](https://img.shields.io/nuget/dt/Skybrud.Colors.svg)](https://www.nuget.org/packages/Skybrud.Colors)
[![Skybrud.Colors at packages.limbo.works](https://img.shields.io/badge/limbo-packages-blue)](https://packages.limbo.works/skybrud.colors/)

**Skybrud.Colors** is a small library for working with various color models, currently supporting RGB, CMY, CMYK and HSL. The library features converters for converting back and forth between the supported color models.

<br /><br />

## Installation

Install the package via [**NuGet**](https://www.nuget.org/packages/Skybrud.Colors). To install the package, you can use either .NET CLI:

```
dotnet add package Skybrud.Colors
```

or the NuGet Package Manager:

```
Install-Package Skybrud.Colors
```

<br /><br />

## Usage

Initialize a new `RgbColor` instance and convert to various string formats and other color models:

```cshtml
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

```cshtml
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

Get a list of hex colors representing gradient steps between two hex colors:


```cshtml
@using Skybrud.Colors

@{
    //Get gradient colors Blue to Red
    var colors = Skybrud.Colors.ColorUtils.GetGradientColorsHexCodes("#0000ff", "#ff0000", 10); 
   
        <div>Start: #0000ff | End: #ff0000</div>  
        @foreach (var color in colors)
        {
            <div style="background-color: @color;">@color</div>
        }    
}
```

   
[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Colors
[GitHubRelease]: https://github.com/abjerner/Skybrud.Colors/releases/latest
[Changelog]: https://github.com/abjerner/Skybrud.Colors/releases
[Issues]: https://github.com/abjerner/Skybrud.Colors/issues
