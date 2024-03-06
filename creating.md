---
order: 1
---

# Creating new color values

**Skybrud.Colors** supports a number of color models. You can see the support color models below:

## CMY

CMY consists of *cyan*, *magenta*, and *yellow*, and it's represented by the <code type="Skybrud.Colors.CmyColor, Skybrud.Colors">CmyColor</code> class:

```cshtml
@using Skybrud.Colors

@{

    // Initialize the color
    CmyColor cmy = new CmyColor(100, 100, 50);

    // Outputs "CMY: 100, 100, 50"
    <pre>@cmy</pre>

}
```

## CMYK

CMYK consists of *cyan*, *magenta*, *yellow* and *key*, and it's represented by the <code type="Skybrud.Colors.CmykColor, Skybrud.Colors">CmykColor</code> class:

```cshtml
@using Skybrud.Colors

@{

    // Initialize the color
    CmykColor cmyk = new CmykColor(100, 100, 0, 50);

    // Outputs "CMYK: 100, 100, 0, 50"
    <pre>@cmyk</pre>

}
```

## HSL

HSL consists of *hue*, *saturation* and *lightness*, and it's represented by the <code type="Skybrud.Colors.HslColor, Skybrud.Colors">HslColor</code> class:

```cshtml
@using Skybrud.Colors

@{

    // Initialize the color
    HslColor hsl = new HslColor(240, 100, 25);

    // Outputs "HSL: 240, 100, 25"
    <pre>@hsl</pre>

}
```

## RGB

RGB consists of for *red*, *green* and *blue*, and it's represented by the <code type="Skybrud.Colors.RgbColor, Skybrud.Colors">RgbColor</code> class:

```cshtml
@using Skybrud.Colors
@using Skybrud.Colors.Html

@{

    // Get a reference to a blue color
    RgbColor blue = HtmlColors.Blue;

    // Outputs "RGB: 0, 0, 255"
    <pre>@blue</pre>

    // Get a reference to a blue color
    RgbColor red = HtmlColors.Red;

    // Outputs "RGB: 255, 0, 0"
    <pre>@red</pre>

}
```