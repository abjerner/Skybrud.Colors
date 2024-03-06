# HTML



## Color names

HTML and CSS describe a list of color names that may be used instead of HEX values or similar. The HTML colors are also available in **Skybrud.Colors** via the static <code type="Skybrud.Colors.Html.HtmlColors, Skybrud.Colors">HtmlColors</code> class.

The example below shows how to reference a blue and a red color respectively:

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

You can see the [**`HtmlColors`**](https://github.com/abjerner/Skybrud.Colors/blob/v1/main/src/Skybrud.Colors/Html/HtmlColors.cs) for a list of all supported color names.



## Color groups

The <code type="Skybrud.Colors.Html.HtmlColorGroups, Skybrud.Colors">HtmlColorGroups</code> class also describes various groups - eg. `HtmlColorGroups.Blue` contains 25 colors that can best described as being blue, and `HtmlColorGroups.Red` contains 9 colors that can best be described as being red:

```cshtml
@using Skybrud.Colors
@using Skybrud.Colors.Html

<h2>Blue</h2>
<ul>
    @foreach (RgbColor color in HtmlColorGroups.Blue) {
        <pre>@color</pre>
    }
</ul>

<h2>Red</h2>
<ul>
    @foreach (RgbColor color in HtmlColorGroups.Red) {
        <pre>@color</pre>
    }
</ul>
```

The color groups are as following:

- `HtmlColorGroups.Red`
- `HtmlColorGroups.Pink`
- `HtmlColorGroups.Orange`
- `HtmlColorGroups.Yellow`
- `HtmlColorGroups.Purple`
- `HtmlColorGroups.Green`
- `HtmlColorGroups.Blue`
- `HtmlColorGroups.Brown`
- `HtmlColorGroups.White`
- `HtmlColorGroups.Gray`