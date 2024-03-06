# WCAG

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
    double ratio = WcagUtils.GetContrastRatio(red, blue);

    <pre>WCAG ratio: @ratio</pre>

}
```