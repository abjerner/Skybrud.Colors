using System.Collections.Generic;
using System.Collections.ObjectModel;

#pragma warning disable CS1591

namespace Skybrud.Colors.Html;

public static class HtmlColorGroups {

    public static readonly IReadOnlyList<RgbColor> Red = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.IndianRed,
        HtmlColors.LightCoral,
        HtmlColors.Salmon,
        HtmlColors.DarkSalmon,
        HtmlColors.LightSalmon,
        HtmlColors.Crimson,
        HtmlColors.Red,
        HtmlColors.FireBrick,
        HtmlColors.DarkRed
    });

    public static readonly IReadOnlyList<RgbColor> Pink = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.Pink,
        HtmlColors.LightPink,
        HtmlColors.HotPink,
        HtmlColors.DeepPink,
        HtmlColors.MediumVioletRed,
        HtmlColors.PaleVioletRed
    });

    public static readonly IReadOnlyList<RgbColor> Orange = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.LightSalmon,
        HtmlColors.Coral,
        HtmlColors.Tomato,
        HtmlColors.OrangeRed,
        HtmlColors.DarkOrange,
        HtmlColors.Orange
    });

    public static readonly IReadOnlyList<RgbColor> Yellow = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.Gold,
        HtmlColors.Yellow,
        HtmlColors.LightYellow,
        HtmlColors.LemonChiffon,
        HtmlColors.LightGoldenrodYellow,
        HtmlColors.PapayaWhip,
        HtmlColors.Moccasin,
        HtmlColors.PeachPuff,
        HtmlColors.PaleGoldenrod,
        HtmlColors.Khaki,
        HtmlColors.DarkKhaki
    });

    public static readonly IReadOnlyList<RgbColor> Purple = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.Lavender,
        HtmlColors.Thistle,
        HtmlColors.Plum,
        HtmlColors.Violet,
        HtmlColors.Orchid,
        HtmlColors.Fuchsia,
        HtmlColors.Magenta,
        HtmlColors.MediumOrchid,
        HtmlColors.MediumPurple,
        HtmlColors.RebeccaPurple,
        HtmlColors.BlueViolet,
        HtmlColors.DarkViolet,
        HtmlColors.DarkOrchid,
        HtmlColors.DarkMagenta,
        HtmlColors.Purple,
        HtmlColors.Indigo,
        HtmlColors.SlateBlue,
        HtmlColors.DarkSlateBlue,
        HtmlColors.MediumSlateBlue
    });

    public static readonly IReadOnlyList<RgbColor> Green = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.GreenYellow,
        HtmlColors.Chartreuse,
        HtmlColors.LawnGreen,
        HtmlColors.Lime,
        HtmlColors.LimeGreen,
        HtmlColors.PaleGreen,
        HtmlColors.LightGreen,
        HtmlColors.MediumSpringGreen,
        HtmlColors.SpringGreen,
        HtmlColors.MediumSeaGreen,
        HtmlColors.SeaGreen,
        HtmlColors.ForestGreen,
        HtmlColors.Green,
        HtmlColors.DarkGreen,
        HtmlColors.YellowGreen,
        HtmlColors.OliveDrab,
        HtmlColors.Olive,
        HtmlColors.DarkOliveGreen,
        HtmlColors.MediumAquamarine,
        HtmlColors.DarkSeaGreen,
        HtmlColors.LightSeaGreen,
        HtmlColors.DarkCyan,
        HtmlColors.Teal
    });

    public static readonly IReadOnlyList<RgbColor> Blue = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.Aqua,
        HtmlColors.Cyan,
        HtmlColors.LightCyan,
        HtmlColors.PaleTurquoise,
        HtmlColors.Aquamarine,
        HtmlColors.Turquoise,
        HtmlColors.MediumTurquoise,
        HtmlColors.DarkTurquoise,
        HtmlColors.CadetBlue,
        HtmlColors.SteelBlue,
        HtmlColors.LightSteelBlue,
        HtmlColors.PowderBlue,
        HtmlColors.LightBlue,
        HtmlColors.SkyBlue,
        HtmlColors.LightSkyBlue,
        HtmlColors.DeepSkyBlue,
        HtmlColors.DodgerBlue,
        HtmlColors.CornflowerBlue,
        HtmlColors.MediumSlateBlue,
        HtmlColors.RoyalBlue,
        HtmlColors.Blue,
        HtmlColors.MediumBlue,
        HtmlColors.DarkBlue,
        HtmlColors.Navy,
        HtmlColors.MidnightBlue
    });

    public static readonly IReadOnlyList<RgbColor> Brown = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.Cornsilk,
        HtmlColors.BlanchedAlmond,
        HtmlColors.Bisque,
        HtmlColors.NavajoWhite,
        HtmlColors.Wheat,
        HtmlColors.BurlyWood,
        HtmlColors.Tan,
        HtmlColors.RosyBrown,
        HtmlColors.SandyBrown,
        HtmlColors.Goldenrod,
        HtmlColors.DarkGoldenrod,
        HtmlColors.Peru,
        HtmlColors.Chocolate,
        HtmlColors.SaddleBrown,
        HtmlColors.Sienna,
        HtmlColors.Brown,
        HtmlColors.Maroon
    });

    public static readonly IReadOnlyList<RgbColor> White = new ReadOnlyCollection<RgbColor>(new List<RgbColor>() {
        HtmlColors.White,
        HtmlColors.Snow,
        HtmlColors.HoneyDew,
        HtmlColors.MintCream,
        HtmlColors.Azure,
        HtmlColors.AliceBlue,
        HtmlColors.GhostWhite,
        HtmlColors.WhiteSmoke,
        HtmlColors.SeaShell,
        HtmlColors.Beige,
        HtmlColors.OldLace,
        HtmlColors.FloralWhite,
        HtmlColors.Ivory,
        HtmlColors.AntiqueWhite,
        HtmlColors.Linen,
        HtmlColors.LavenderBlush,
        HtmlColors.MistyRose
    });

    public static readonly IReadOnlyList<RgbColor> Gray = new ReadOnlyCollection<RgbColor>(new List<RgbColor> {
        HtmlColors.Gainsboro,
        HtmlColors.LightGray,
        HtmlColors.Silver,
        HtmlColors.DarkGray,
        HtmlColors.Gray,
        HtmlColors.DimGray,
        HtmlColors.LightSlateGray,
        HtmlColors.SlateGray,
        HtmlColors.DarkSlateGray,
        HtmlColors.Black
    });

}