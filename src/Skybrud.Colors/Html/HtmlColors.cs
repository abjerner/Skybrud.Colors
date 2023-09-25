#pragma warning disable 1591

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Skybrud.Colors.Html;

/// <summary>
/// Static class will all HTML colors.
/// </summary>
public static class HtmlColors {

    public static readonly RgbColor AliceBlue = new(240, 248, 255);

    public static readonly RgbColor AntiqueWhite = new(250, 235, 215);

    public static readonly RgbColor Aqua = new(0, 255, 255);

    public static readonly RgbColor Aquamarine = new(127, 255, 212);

    public static readonly RgbColor Azure = new(240, 255, 255);

    public static readonly RgbColor Beige = new(245, 245, 220);

    public static readonly RgbColor Bisque = new(255, 228, 196);

    public static readonly RgbColor Black = new(0, 0, 0);

    public static readonly RgbColor BlanchedAlmond = new(255, 235, 205);

    public static readonly RgbColor Blue = new(0, 0, 255);

    public static readonly RgbColor BlueViolet = new(138, 43, 226);

    public static readonly RgbColor Brown = new(165, 42, 42);

    public static readonly RgbColor BurlyWood = new(222, 184, 135);

    public static readonly RgbColor CadetBlue = new(95, 158, 160);

    public static readonly RgbColor Chartreuse = new(127, 255, 0);

    public static readonly RgbColor Chocolate = new(210, 105, 30);

    public static readonly RgbColor Coral = new(255, 127, 80);

    public static readonly RgbColor CornflowerBlue = new(100, 149, 237);

    public static readonly RgbColor Cornsilk = new(255, 248, 220);

    public static readonly RgbColor Crimson = new(220, 20, 60);

    public static readonly RgbColor Cyan = new(0, 255, 255);

    public static readonly RgbColor DarkBlue = new(0, 0, 139);

    public static readonly RgbColor DarkCyan = new(0, 139, 139);

    public static readonly RgbColor DarkGoldenrod = new(184, 134, 11);

    public static readonly RgbColor DarkGray = new(169, 169, 169);

    public static readonly RgbColor DarkGreen = new(0, 100, 0);

    public static readonly RgbColor DarkKhaki = new(189, 183, 107);

    public static readonly RgbColor DarkMagenta = new(139, 0, 139);

    public static readonly RgbColor DarkOliveGreen = new(85, 107, 47);

    public static readonly RgbColor DarkOrange = new(255, 140, 0);

    public static readonly RgbColor DarkOrchid = new(153, 50, 204);

    public static readonly RgbColor DarkRed = new(139, 0, 0);

    public static readonly RgbColor DarkSalmon = new(233, 150, 122);

    public static readonly RgbColor DarkSeaGreen = new(143, 188, 139);

    public static readonly RgbColor DarkSlateBlue = new(72, 61, 139);

    public static readonly RgbColor DarkSlateGray = new(47, 79, 79);

    public static readonly RgbColor DarkTurquoise = new(0, 206, 209);

    public static readonly RgbColor DarkViolet = new(148, 0, 211);

    public static readonly RgbColor DeepPink = new(255, 20, 147);

    public static readonly RgbColor DeepSkyBlue = new(0, 191, 255);

    public static readonly RgbColor DimGray = new(105, 105, 105);

    public static readonly RgbColor DodgerBlue = new(30, 144, 255);

    public static readonly RgbColor FireBrick = new(178, 34, 34);

    public static readonly RgbColor FloralWhite = new(255, 250, 240);

    public static readonly RgbColor ForestGreen = new(34, 139, 34);

    public static readonly RgbColor Fuchsia = new(255, 0, 255);

    public static readonly RgbColor Gainsboro = new(220, 220, 220);

    public static readonly RgbColor GhostWhite = new(248, 248, 255);

    public static readonly RgbColor Gold = new(255, 215, 0);

    public static readonly RgbColor Goldenrod = new(218, 165, 32);

    public static readonly RgbColor Gray = new(128, 128, 128);

    public static readonly RgbColor Green = new(0, 128, 0);

    public static readonly RgbColor GreenYellow = new(173, 255, 47);

    public static readonly RgbColor HoneyDew = new(240, 255, 240);

    public static readonly RgbColor HotPink = new(255, 105, 180);

    public static readonly RgbColor IndianRed = new(205, 92, 92);

    public static readonly RgbColor Indigo = new(75, 0, 130);

    public static readonly RgbColor Ivory = new(255, 255, 240);

    public static readonly RgbColor Khaki = new(240, 230, 140);

    public static readonly RgbColor Lavender = new(230, 230, 250);

    public static readonly RgbColor LavenderBlush = new(255, 240, 245);

    public static readonly RgbColor LawnGreen = new(124, 252, 0);

    public static readonly RgbColor LemonChiffon = new(255, 250, 205);

    public static readonly RgbColor LightBlue = new(173, 216, 230);

    public static readonly RgbColor LightCoral = new(240, 128, 128);

    public static readonly RgbColor LightCyan = new(224, 255, 255);

    public static readonly RgbColor LightGoldenrodYellow = new(250, 250, 210);

    public static readonly RgbColor LightGray = new(211, 211, 211);

    public static readonly RgbColor LightGreen = new(144, 238, 144);

    public static readonly RgbColor LightPink = new(255, 182, 193);

    public static readonly RgbColor LightSalmon = new(255, 160, 122);

    public static readonly RgbColor LightSeaGreen = new(32, 178, 170);

    public static readonly RgbColor LightSkyBlue = new(135, 206, 250);

    public static readonly RgbColor LightSlateGray = new(119, 136, 153);

    public static readonly RgbColor LightSteelBlue = new(176, 196, 222);

    public static readonly RgbColor LightYellow = new(255, 255, 224);

    public static readonly RgbColor Lime = new(0, 255, 0);

    public static readonly RgbColor LimeGreen = new(50, 205, 50);

    public static readonly RgbColor Linen = new(250, 240, 230);

    public static readonly RgbColor Magenta = new(255, 0, 255);

    public static readonly RgbColor Maroon = new(128, 0, 0);

    public static readonly RgbColor MediumAquamarine = new(102, 205, 170);

    public static readonly RgbColor MediumBlue = new(0, 0, 205);

    public static readonly RgbColor MediumOrchid = new(186, 85, 211);

    public static readonly RgbColor MediumPurple = new(147, 112, 219);

    public static readonly RgbColor MediumSeaGreen = new(60, 179, 113);

    public static readonly RgbColor MediumSlateBlue = new(123, 104, 238);

    public static readonly RgbColor MediumSpringGreen = new(0, 250, 154);

    public static readonly RgbColor MediumTurquoise = new(72, 209, 204);

    public static readonly RgbColor MediumVioletRed = new(199, 21, 133);

    public static readonly RgbColor MidnightBlue = new(25, 25, 112);

    public static readonly RgbColor MintCream = new(245, 255, 250);

    public static readonly RgbColor MistyRose = new(255, 228, 225);

    public static readonly RgbColor Moccasin = new(255, 228, 181);

    public static readonly RgbColor NavajoWhite = new(255, 222, 173);

    public static readonly RgbColor Navy = new(0, 0, 128);

    public static readonly RgbColor OldLace = new(253, 245, 230);

    public static readonly RgbColor Olive = new(128, 128, 0);

    public static readonly RgbColor OliveDrab = new(107, 142, 35);

    public static readonly RgbColor Orange = new(255, 165, 0);

    public static readonly RgbColor OrangeRed = new(255, 69, 0);

    public static readonly RgbColor Orchid = new(218, 112, 214);

    public static readonly RgbColor PaleGoldenrod = new(238, 232, 170);

    public static readonly RgbColor PaleGreen = new(152, 251, 152);

    public static readonly RgbColor PaleTurquoise = new(175, 238, 238);

    public static readonly RgbColor PaleVioletRed = new(219, 112, 147);

    public static readonly RgbColor PapayaWhip = new(255, 239, 213);

    public static readonly RgbColor PeachPuff = new(255, 218, 185);

    public static readonly RgbColor Peru = new(205, 133, 63);

    public static readonly RgbColor Pink = new(255, 192, 203);

    public static readonly RgbColor Plum = new(221, 160, 221);

    public static readonly RgbColor PowderBlue = new(176, 224, 230);

    public static readonly RgbColor Purple = new(128, 0, 128);

    public static readonly RgbColor RebeccaPurple = new(102, 51, 153);

    public static readonly RgbColor Red = new(255, 0, 0);

    public static readonly RgbColor RosyBrown = new(188, 143, 143);

    public static readonly RgbColor RoyalBlue = new(65, 105, 225);

    public static readonly RgbColor SaddleBrown = new(139, 69, 19);

    public static readonly RgbColor Salmon = new(250, 128, 114);

    public static readonly RgbColor SandyBrown = new(244, 164, 96);

    public static readonly RgbColor SeaGreen = new(46, 139, 87);

    public static readonly RgbColor SeaShell = new(255, 245, 238);

    public static readonly RgbColor Sienna = new(160, 82, 45);

    public static readonly RgbColor Silver = new(192, 192, 192);

    public static readonly RgbColor SkyBlue = new(135, 206, 235);

    public static readonly RgbColor SlateBlue = new(106, 90, 205);

    public static readonly RgbColor SlateGray = new(112, 128, 144);

    public static readonly RgbColor Snow = new(255, 250, 250);

    public static readonly RgbColor SpringGreen = new(0, 255, 127);

    public static readonly RgbColor SteelBlue = new(70, 130, 180);

    public static readonly RgbColor Tan = new(210, 180, 140);

    public static readonly RgbColor Teal = new(0, 128, 128);

    public static readonly RgbColor Thistle = new(216, 191, 216);

    public static readonly RgbColor Tomato = new(255, 99, 71);

    public static readonly RgbColor Turquoise = new(64, 224, 208);

    public static readonly RgbColor Violet = new(238, 130, 238);

    public static readonly RgbColor Wheat = new(245, 222, 179);

    public static readonly RgbColor White = new(255, 255, 255);

    public static readonly RgbColor WhiteSmoke = new(245, 245, 245);

    public static readonly RgbColor Yellow = new(255, 255, 0);

    public static readonly RgbColor YellowGreen = new(154, 205, 50);

    public static readonly IReadOnlyDictionary<string, RgbColor> All;

    static HtmlColors() {

        Dictionary<string, RgbColor> dictionary = new(StringComparer.CurrentCultureIgnoreCase) {
            { "AliceBlue", AliceBlue },
            { "AntiqueWhite", AntiqueWhite },
            { "Aqua", Aqua },
            { "Aquamarine", Aquamarine },
            { "Azure", Azure },
            { "Beige", Beige },
            { "Bisque", Bisque },
            { "Black", Black },
            { "BlanchedAlmond", BlanchedAlmond },
            { "Blue", Blue },
            { "BlueViolet", BlueViolet },
            { "Brown", Brown },
            { "BurlyWood", BurlyWood },
            { "CadetBlue", CadetBlue },
            { "Chartreuse", Chartreuse },
            { "Chocolate", Chocolate },
            { "Coral", Coral },
            { "CornflowerBlue", CornflowerBlue },
            { "Cornsilk", Cornsilk },
            { "Crimson", Crimson },
            { "Cyan", Cyan },
            { "DarkBlue", DarkBlue },
            { "DarkCyan", DarkCyan },
            { "DarkGoldenrod", DarkGoldenrod },
            { "DarkGray", DarkGray },
            { "DarkGreen", DarkGreen },
            { "DarkKhaki", DarkKhaki },
            { "DarkMagenta", DarkMagenta },
            { "DarkOliveGreen", DarkOliveGreen },
            { "DarkOrange", DarkOrange },
            { "DarkOrchid", DarkOrchid },
            { "DarkRed", DarkRed },
            { "DarkSalmon", DarkSalmon },
            { "DarkSeaGreen", DarkSeaGreen },
            { "DarkSlateBlue", DarkSlateBlue },
            { "DarkSlateGray", DarkSlateGray },
            { "DarkTurquoise", DarkTurquoise },
            { "DarkViolet", DarkViolet },
            { "DeepPink", DeepPink },
            { "DeepSkyBlue", DeepSkyBlue },
            { "DimGray", DimGray },
            { "DodgerBlue", DodgerBlue },
            { "FireBrick", FireBrick },
            { "FloralWhite", FloralWhite },
            { "ForestGreen", ForestGreen },
            { "Fuchsia", Fuchsia },
            { "Gainsboro", Gainsboro },
            { "GhostWhite", GhostWhite },
            { "Gold", Gold },
            { "Goldenrod", Goldenrod },
            { "Gray", Gray },
            { "Green", Green },
            { "GreenYellow", GreenYellow },
            { "HoneyDew", HoneyDew },
            { "HotPink", HotPink },
            { "IndianRed", IndianRed },
            { "Indigo", Indigo },
            { "Ivory", Ivory },
            { "Khaki", Khaki },
            { "Lavender", Lavender },
            { "LavenderBlush", LavenderBlush },
            { "LawnGreen", LawnGreen },
            { "LemonChiffon", LemonChiffon },
            { "LightBlue", LightBlue },
            { "LightCoral", LightCoral },
            { "LightCyan", LightCyan },
            { "LightGoldenrodYellow", LightGoldenrodYellow },
            { "LightGray", LightGray },
            { "LightGreen", LightGreen },
            { "LightPink", LightPink },
            { "LightSalmon", LightSalmon },
            { "LightSeaGreen", LightSeaGreen },
            { "LightSkyBlue", LightSkyBlue },
            { "LightSlateGray", LightSlateGray },
            { "LightSteelBlue", LightSteelBlue },
            { "LightYellow", LightYellow },
            { "Lime", Lime },
            { "LimeGreen", LimeGreen },
            { "Linen", Linen },
            { "Magenta", Magenta },
            { "Maroon", Maroon },
            { "MediumAquamarine", MediumAquamarine },
            { "MediumBlue", MediumBlue },
            { "MediumOrchid", MediumOrchid },
            { "MediumPurple", MediumPurple },
            { "MediumSeaGreen", MediumSeaGreen },
            { "MediumSlateBlue", MediumSlateBlue },
            { "MediumSpringGreen", MediumSpringGreen },
            { "MediumTurquoise", MediumTurquoise },
            { "MediumVioletRed", MediumVioletRed },
            { "MidnightBlue", MidnightBlue },
            { "MintCream", MintCream },
            { "MistyRose", MistyRose },
            { "Moccasin", Moccasin },
            { "NavajoWhite", NavajoWhite },
            { "Navy", Navy },
            { "OldLace", OldLace },
            { "Olive", Olive },
            { "OliveDrab", OliveDrab },
            { "Orange", Orange },
            { "OrangeRed", OrangeRed },
            { "Orchid", Orchid },
            { "PaleGoldenrod", PaleGoldenrod },
            { "PaleGreen", PaleGreen },
            { "PaleTurquoise", PaleTurquoise },
            { "PaleVioletRed", PaleVioletRed },
            { "PapayaWhip", PapayaWhip },
            { "PeachPuff", PeachPuff },
            { "Peru", Peru },
            { "Pink", Pink },
            { "Plum", Plum },
            { "PowderBlue", PowderBlue },
            { "Purple", Purple },
            { "RebeccaPurple", RebeccaPurple },
            { "Red", Red },
            { "RosyBrown", RosyBrown },
            { "RoyalBlue", RoyalBlue },
            { "SaddleBrown", SaddleBrown },
            { "Salmon", Salmon },
            { "SandyBrown", SandyBrown },
            { "SeaGreen", SeaGreen },
            { "SeaShell", SeaShell },
            { "Sienna", Sienna },
            { "Silver", Silver },
            { "SkyBlue", SkyBlue },
            { "SlateBlue", SlateBlue },
            { "SlateGray", SlateGray },
            { "Snow", Snow },
            { "SpringGreen", SpringGreen },
            { "SteelBlue", SteelBlue },
            { "Tan", Tan },
            { "Teal", Teal },
            { "Thistle", Thistle },
            { "Tomato", Tomato },
            { "Turquoise", Turquoise },
            { "Violet", Violet },
            { "Wheat", Wheat },
            { "White", White },
            { "WhiteSmoke", WhiteSmoke },
            { "Yellow", Yellow },
            { "YellowGreen", YellowGreen }
        };

        All = new ReadOnlyDictionary<string, RgbColor>(dictionary);

    }

}