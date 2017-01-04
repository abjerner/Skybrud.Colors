﻿using Skybrud.Colors;
using Skybrud.Colors.Html;

namespace UnitTestProject1.Samples {

    public class HtmlColorSample {

        public string Name { get; private set; }

        public RgbColor Base { get; private set; }

        public string Hex { get; private set; }

        public RgbColor Rgb { get; private set; }
        public string RgbText { get; private set; }
        public string RgbCss { get; private set; }

        public HslColor Hsl { get; private set; }
        public string HslText { get; private set; }
        public string HslCss { get; private set; }

        //public HsvColor Hsv { get; private set; }
        public string HsvText { get; private set; }

        public CmykColor Cmyk { get; private set; }
        public string CmykText { get; private set; }

        public static HtmlColorSample[] All = {
            new HtmlColorSample {
                Name = "AliceBlue",
                Base = HtmlColors.AliceBlue,
                Hex = "#f0f8ff",
                Rgb = new RgbColor(240, 248, 255),
                RgbText = "RGB: 240, 248, 255",
                RgbCss = "rgb(240, 248, 255)",
                Hsl = new HslColor(208, 100, 97),
                HslText = "HSL: 208, 100, 97",
                HslCss = "hsl(34, 78%, 91%)",
                HsvText = "HSV: 208, 6, 100",
                Cmyk = new CmykColor(6, 3, 0, 0),
                CmykText = "CMYK: 6, 3, 0, 0"
            },
            new HtmlColorSample {
                Name = "AntiqueWhite",
                Base = HtmlColors.AntiqueWhite,
                Hex = "#faebd7",
                Rgb = new RgbColor(250, 235, 215),
                RgbText = "RGB: 250, 235, 215",
                RgbCss = "rgb(250, 235, 215)",
                Hsl = new HslColor(34, 78, 91),
                HslText = "HSL: 34, 78, 91",
                HslCss = "hsl(34, 78%, 91%)",
                HsvText = "HSV: 34, 14, 98",
                Cmyk = new CmykColor(0, 6, 14, 2),
                CmykText = "CMYK: 0, 6, 14, 2"
            },
            new HtmlColorSample {
                Name = "Aqua",
                Base = HtmlColors.Aqua,
                Hex = "#00ffff",
                Rgb = new RgbColor(0, 255, 255),
                RgbText = "RGB: 0, 255, 255",
                RgbCss = "rgb(0, 255, 255)",
                Hsl = new HslColor(180, 100, 50),
                HslText = "HSL: 180, 100, 50",
                HslCss = "hsl(180, 100%, 50%)",
                HsvText = "HSV: 180, 100, 100",
                Cmyk = new CmykColor(100, 0, 0, 0),
                CmykText = "CMYK: 100, 0, 0, 0"
            },
            new HtmlColorSample {
                Name = "Aquamarine",
                Base = HtmlColors.Aquamarine,
                Hex = "#7fffd4",
                Rgb = new RgbColor(127, 255, 212),
                RgbText = "RGB: 127, 255, 212",
                RgbCss = "rgb(127, 255, 212)",
                Hsl = new HslColor(160, 100, 75),
                HslText = "HSL: 160, 100, 75",
                HslCss = "hsl(160, 100%, 75%)",
                HsvText = "HSV: 160, 50, 100",
                Cmyk = new CmykColor(50, 0, 17, 0),
                CmykText = "CMYK: 50, 0, 17, 0"
            },
            new HtmlColorSample {
                Name = "Azure",
                Base = HtmlColors.Azure,
                Hex = "#f0ffff",
                Rgb = new RgbColor(240, 255, 255),
                RgbText = "RGB: 240, 255, 255",
                RgbCss = "rgb(240, 255, 255)",
                Hsl = new HslColor(180, 100, 97),
                HslText = "HSL: 180, 100, 97",
                HslCss = "hsl(180, 100%, 97%)",
                HsvText = "HSV: 180, 6, 100",
                Cmyk = new CmykColor(6, 0, 0, 0),
                CmykText = "CMYK: 6, 0, 0, 0"
            },
            //new HtmlColorSample { Name = "Beige", Hex = "#f5f5dc", Rgb = new [] { 245, 245, 220 }, Hsl = new [] { 60, 56, 91 } },
            //new HtmlColorSample { Name = "Bisque", Hex = "#ffe4c4", Rgb = new [] { 255, 228, 196 }, Hsl = new [] { 33, 100, 88 } },
            //new HtmlColorSample { Name = "Black", Hex = "#000000", Rgb = new [] { 0, 0, 0 }, Hsl = new [] { 0, 0, 0 } },
            //new HtmlColorSample { Name = "BlanchedAlmond", Hex = "#ffebcd", Rgb = new [] { 255, 235, 205 }, Hsl = new [] { 36, 100, 90 } },
            //new HtmlColorSample { Name = "Blue", Hex = "#0000ff", Rgb = new [] { 0, 0, 255 }, Hsl = new [] { 240, 100, 50 } },
            //new HtmlColorSample { Name = "BlueViolet", Hex = "#8a2be2", Rgb = new [] { 138, 43, 226 }, Hsl = new [] { 271, 76, 53 } },
            //new HtmlColorSample { Name = "Brown", Hex = "#a52a2a", Rgb = new [] { 165, 42, 42 }, Hsl = new [] { 0, 59, 41 } },
            //new HtmlColorSample { Name = "BurlyWood", Hex = "#deb887", Rgb = new [] { 222, 184, 135 }, Hsl = new [] { 34, 57, 70 } },
            //new HtmlColorSample { Name = "CadetBlue", Hex = "#5f9ea0", Rgb = new [] { 95, 158, 160 }, Hsl = new [] { 182, 25, 50 } },
            //new HtmlColorSample { Name = "Chartreuse", Hex = "#7fff00", Rgb = new [] { 127, 255, 0 }, Hsl = new [] { 90, 100, 50 } },
            //new HtmlColorSample { Name = "Chocolate", Hex = "#d2691e", Rgb = new [] { 210, 105, 30 }, Hsl = new [] { 25, 75, 47 } },
            //new HtmlColorSample { Name = "Coral", Hex = "#ff7f50", Rgb = new [] { 255, 127, 80 }, Hsl = new [] { 16, 100, 66 } },
            //new HtmlColorSample { Name = "CornflowerBlue", Hex = "#6495ed", Rgb = new [] { 100, 149, 237 }, Hsl = new [] { 219, 79, 66 } },
            //new HtmlColorSample { Name = "Cornsilk", Hex = "#fff8dc", Rgb = new [] { 255, 248, 220 }, Hsl = new [] { 48, 100, 93 } },
            //new HtmlColorSample { Name = "Crimson", Hex = "#dc143c", Rgb = new [] { 220, 20, 60 }, Hsl = new [] { 348, 83, 47 } },
            //new HtmlColorSample { Name = "Cyan", Hex = "#00ffff", Rgb = new [] { 0, 255, 255 }, Hsl = new [] { 180, 100, 50 } },
            //new HtmlColorSample { Name = "DarkBlue", Hex = "#00008b", Rgb = new [] { 0, 0, 139 }, Hsl = new [] { 240, 100, 27 } },
            //new HtmlColorSample { Name = "DarkCyan", Hex = "#008b8b", Rgb = new [] { 0, 139, 139 }, Hsl = new [] { 180, 100, 27 } },
            //new HtmlColorSample { Name = "DarkGoldenrod", Hex = "#b8860b", Rgb = new [] { 184, 134, 11 }, Hsl = new [] { 43, 89, 38 } },
            //new HtmlColorSample { Name = "DarkGray", Hex = "#a9a9a9", Rgb = new [] { 169, 169, 169 }, Hsl = new [] { 0, 0, 66 } },
            //new HtmlColorSample { Name = "DarkGreen", Hex = "#006400", Rgb = new [] { 0, 100, 0 }, Hsl = new [] { 120, 100, 20 } },
            //new HtmlColorSample { Name = "DarkKhaki", Hex = "#bdb76b", Rgb = new [] { 189, 183, 107 }, Hsl = new [] { 56, 38, 58 } },
            //new HtmlColorSample { Name = "DarkMagenta", Hex = "#8b008b", Rgb = new [] { 139, 0, 139 }, Hsl = new [] { 300, 100, 27 } },
            //new HtmlColorSample { Name = "DarkOliveGreen", Hex = "#556b2f", Rgb = new [] { 85, 107, 47 }, Hsl = new [] { 82, 39, 30 } },
            //new HtmlColorSample { Name = "DarkOrange", Hex = "#ff8c00", Rgb = new [] { 255, 140, 0 }, Hsl = new [] { 33, 100, 50 } },
            //new HtmlColorSample { Name = "DarkOrchid", Hex = "#9932cc", Rgb = new [] { 153, 50, 204 }, Hsl = new [] { 280, 61, 50 } },
            //new HtmlColorSample { Name = "DarkRed", Hex = "#8b0000", Rgb = new [] { 139, 0, 0 }, Hsl = new [] { 0, 100, 27 } },
            //new HtmlColorSample { Name = "DarkSalmon", Hex = "#e9967a", Rgb = new [] { 233, 150, 122 }, Hsl = new [] { 15, 72, 70 } },
            //new HtmlColorSample { Name = "DarkSeaGreen", Hex = "#8fbc8b", Rgb = new [] { 143, 188, 139 }, Hsl = new [] { 115, 27, 64 } },
            //new HtmlColorSample { Name = "DarkSlateBlue", Hex = "#483d8b", Rgb = new [] { 72, 61, 139 }, Hsl = new [] { 248, 39, 39 } },
            //new HtmlColorSample { Name = "DarkSlateGray", Hex = "#2f4f4f", Rgb = new [] { 47, 79, 79 }, Hsl = new [] { 180, 25, 25 } },
            //new HtmlColorSample { Name = "DarkTurquoise", Hex = "#00ced1", Rgb = new [] { 0, 206, 209 }, Hsl = new [] { 181, 100, 41 } },
            //new HtmlColorSample { Name = "DarkViolet", Hex = "#9400d3", Rgb = new [] { 148, 0, 211 }, Hsl = new [] { 282, 100, 41 } },
            //new HtmlColorSample { Name = "DeepPink", Hex = "#ff1493", Rgb = new [] { 255, 20, 147 }, Hsl = new [] { 328, 100, 54 } },
            //new HtmlColorSample { Name = "DeepSkyBlue", Hex = "#00bfff", Rgb = new [] { 0, 191, 255 }, Hsl = new [] { 195, 100, 50 } },
            //new HtmlColorSample { Name = "DimGray", Hex = "#696969", Rgb = new [] { 105, 105, 105 }, Hsl = new [] { 0, 0, 41 } },
            //new HtmlColorSample { Name = "DodgerBlue", Hex = "#1e90ff", Rgb = new [] { 30, 144, 255 }, Hsl = new [] { 210, 100, 56 } },
            //new HtmlColorSample { Name = "FireBrick", Hex = "#b22222", Rgb = new [] { 178, 34, 34 }, Hsl = new [] { 0, 68, 42 } },
            //new HtmlColorSample { Name = "FloralWhite", Hex = "#fffaf0", Rgb = new [] { 255, 250, 240 }, Hsl = new [] { 40, 100, 97 } },
            //new HtmlColorSample { Name = "ForestGreen", Hex = "#228b22", Rgb = new [] { 34, 139, 34 }, Hsl = new [] { 120, 61, 34 } },
            //new HtmlColorSample { Name = "Fuchsia", Hex = "#ff00ff", Rgb = new [] { 255, 0, 255 }, Hsl = new [] { 300, 100, 50 } },
            //new HtmlColorSample { Name = "Gainsboro", Hex = "#dcdcdc", Rgb = new [] { 220, 220, 220 }, Hsl = new [] { 0, 0, 86 } },
            //new HtmlColorSample { Name = "GhostWhite", Hex = "#f8f8ff", Rgb = new [] { 248, 248, 255 }, Hsl = new [] { 240, 100, 99 } },
            //new HtmlColorSample { Name = "Gold", Hex = "#ffd700", Rgb = new [] { 255, 215, 0 }, Hsl = new [] { 51, 100, 50 } },
            //new HtmlColorSample { Name = "Goldenrod", Hex = "#daa520", Rgb = new [] { 218, 165, 32 }, Hsl = new [] { 43, 74, 49 } },
            //new HtmlColorSample { Name = "Gray", Hex = "#808080", Rgb = new [] { 128, 128, 128 }, Hsl = new [] { 0, 0, 50 } },
            //new HtmlColorSample { Name = "Green", Hex = "#008000", Rgb = new [] { 0, 128, 0 }, Hsl = new [] { 120, 100, 25 } },
            //new HtmlColorSample { Name = "GreenYellow", Hex = "#adff2f", Rgb = new [] { 173, 255, 47 }, Hsl = new [] { 84, 100, 59 } },
            //new HtmlColorSample { Name = "HoneyDew", Hex = "#f0fff0", Rgb = new [] { 240, 255, 240 }, Hsl = new [] { 120, 100, 97 } },
            //new HtmlColorSample { Name = "HotPink", Hex = "#ff69b4", Rgb = new [] { 255, 105, 180 }, Hsl = new [] { 330, 100, 71 } },
            //new HtmlColorSample { Name = "IndianRed", Hex = "#cd5c5c", Rgb = new [] { 205, 92, 92 }, Hsl = new [] { 0, 53, 58 } },
            //new HtmlColorSample { Name = "Indigo", Hex = "#4b0082", Rgb = new [] { 75, 0, 130 }, Hsl = new [] { 275, 100, 25 } },
            //new HtmlColorSample { Name = "Ivory", Hex = "#fffff0", Rgb = new [] { 255, 255, 240 }, Hsl = new [] { 60, 100, 97 } },
            //new HtmlColorSample { Name = "Khaki", Hex = "#f0e68c", Rgb = new [] { 240, 230, 140 }, Hsl = new [] { 54, 77, 75 } },
            //new HtmlColorSample { Name = "Lavender", Hex = "#e6e6fa", Rgb = new [] { 230, 230, 250 }, Hsl = new [] { 240, 67, 94 } },
            //new HtmlColorSample { Name = "LavenderBlush", Hex = "#fff0f5", Rgb = new [] { 255, 240, 245 }, Hsl = new [] { 340, 100, 97 } },
            //new HtmlColorSample { Name = "LawnGreen", Hex = "#7cfc00", Rgb = new [] { 124, 252, 0 }, Hsl = new [] { 90, 100, 49 } },
            //new HtmlColorSample { Name = "LemonChiffon", Hex = "#fffacd", Rgb = new [] { 255, 250, 205 }, Hsl = new [] { 54, 100, 90 } },
            //new HtmlColorSample { Name = "LightBlue", Hex = "#add8e6", Rgb = new [] { 173, 216, 230 }, Hsl = new [] { 195, 53, 79 } },
            //new HtmlColorSample { Name = "LightCoral", Hex = "#f08080", Rgb = new [] { 240, 128, 128 }, Hsl = new [] { 0, 79, 72 } },
            //new HtmlColorSample { Name = "LightCyan", Hex = "#e0ffff", Rgb = new [] { 224, 255, 255 }, Hsl = new [] { 180, 100, 94 } },
            //new HtmlColorSample { Name = "LightGoldenrodYellow", Hex = "#fafad2", Rgb = new [] { 250, 250, 210 }, Hsl = new [] { 60, 80, 90 } },
            //new HtmlColorSample { Name = "LightGray", Hex = "#d3d3d3", Rgb = new [] { 211, 211, 211 }, Hsl = new [] { 0, 0, 83 } },
            //new HtmlColorSample { Name = "LightGreen", Hex = "#90ee90", Rgb = new [] { 144, 238, 144 }, Hsl = new [] { 120, 73, 75 } },
            //new HtmlColorSample { Name = "LightPink", Hex = "#ffb6c1", Rgb = new [] { 255, 182, 193 }, Hsl = new [] { 351, 100, 86 } },
            //new HtmlColorSample { Name = "LightSalmon", Hex = "#ffa07a", Rgb = new [] { 255, 160, 122 }, Hsl = new [] { 17, 100, 74 } },
            //new HtmlColorSample { Name = "LightSeaGreen", Hex = "#20b2aa", Rgb = new [] { 32, 178, 170 }, Hsl = new [] { 177, 70, 41 } },
            //new HtmlColorSample { Name = "LightSkyBlue", Hex = "#87cefa", Rgb = new [] { 135, 206, 250 }, Hsl = new [] { 203, 92, 75 } },
            //new HtmlColorSample { Name = "LightSlateGray", Hex = "#778899", Rgb = new [] { 119, 136, 153 }, Hsl = new [] { 210, 14, 53 } },
            //new HtmlColorSample { Name = "LightSteelBlue", Hex = "#b0c4de", Rgb = new [] { 176, 196, 222 }, Hsl = new [] { 214, 41, 78 } },
            //new HtmlColorSample { Name = "LightYellow", Hex = "#ffffe0", Rgb = new [] { 255, 255, 224 }, Hsl = new [] { 60, 100, 94 } },
            //new HtmlColorSample { Name = "Lime", Hex = "#00ff00", Rgb = new [] { 0, 255, 0 }, Hsl = new [] { 120, 100, 50 } },
            //new HtmlColorSample { Name = "LimeGreen", Hex = "#32cd32", Rgb = new [] { 50, 205, 50 }, Hsl = new [] { 120, 61, 50 } },
            //new HtmlColorSample { Name = "Linen", Hex = "#faf0e6", Rgb = new [] { 250, 240, 230 }, Hsl = new [] { 30, 67, 94 } },
            //new HtmlColorSample { Name = "Magenta", Hex = "#ff00ff", Rgb = new [] { 255, 0, 255 }, Hsl = new [] { 300, 100, 50 } },
            //new HtmlColorSample { Name = "Maroon", Hex = "#800000", Rgb = new [] { 128, 0, 0 }, Hsl = new [] { 0, 100, 25 } },
            //new HtmlColorSample { Name = "MediumAquamarine", Hex = "#66cdaa", Rgb = new [] { 102, 205, 170 }, Hsl = new [] { 160, 51, 60 } },
            //new HtmlColorSample { Name = "MediumBlue", Hex = "#0000cd", Rgb = new [] { 0, 0, 205 }, Hsl = new [] { 240, 100, 40 } },
            //new HtmlColorSample { Name = "MediumOrchid", Hex = "#ba55d3", Rgb = new [] { 186, 85, 211 }, Hsl = new [] { 288, 59, 58 } },
            //new HtmlColorSample { Name = "MediumPurple", Hex = "#9370db", Rgb = new [] { 147, 112, 219 }, Hsl = new [] { 260, 60, 65 } },
            //new HtmlColorSample { Name = "MediumSeaGreen", Hex = "#3cb371", Rgb = new [] { 60, 179, 113 }, Hsl = new [] { 147, 50, 47 } },
            //new HtmlColorSample { Name = "MediumSlateBlue", Hex = "#7b68ee", Rgb = new [] { 123, 104, 238 }, Hsl = new [] { 249, 80, 67 } },
            //new HtmlColorSample { Name = "MediumSpringGreen", Hex = "#00fa9a", Rgb = new [] { 0, 250, 154 }, Hsl = new [] { 157, 100, 49 } },
            //new HtmlColorSample { Name = "MediumTurquoise", Hex = "#48d1cc", Rgb = new [] { 72, 209, 204 }, Hsl = new [] { 178, 60, 55 } },
            //new HtmlColorSample { Name = "MediumVioletRed", Hex = "#c71585", Rgb = new [] { 199, 21, 133 }, Hsl = new [] { 322, 81, 43 } },
            //new HtmlColorSample { Name = "MidnightBlue", Hex = "#191970", Rgb = new [] { 25, 25, 112 }, Hsl = new [] { 240, 64, 27 } },
            //new HtmlColorSample { Name = "MintCream", Hex = "#f5fffa", Rgb = new [] { 245, 255, 250 }, Hsl = new [] { 150, 100, 98 } },
            //new HtmlColorSample { Name = "MistyRose", Hex = "#ffe4e1", Rgb = new [] { 255, 228, 225 }, Hsl = new [] { 6, 100, 94 } },
            //new HtmlColorSample { Name = "Moccasin", Hex = "#ffe4b5", Rgb = new [] { 255, 228, 181 }, Hsl = new [] { 38, 100, 85 } },
            //new HtmlColorSample { Name = "NavajoWhite", Hex = "#ffdead", Rgb = new [] { 255, 222, 173 }, Hsl = new [] { 36, 100, 84 } },
            //new HtmlColorSample { Name = "Navy", Hex = "#000080", Rgb = new [] { 0, 0, 128 }, Hsl = new [] { 240, 100, 25 } },
            //new HtmlColorSample { Name = "OldLace", Hex = "#fdf5e6", Rgb = new [] { 253, 245, 230 }, Hsl = new [] { 39, 85, 95 } },
            //new HtmlColorSample { Name = "Olive", Hex = "#808000", Rgb = new [] { 128, 128, 0 }, Hsl = new [] { 60, 100, 25 } },
            //new HtmlColorSample { Name = "OliveDrab", Hex = "#6b8e23", Rgb = new [] { 107, 142, 35 }, Hsl = new [] { 80, 60, 35 } },
            //new HtmlColorSample { Name = "Orange", Hex = "#ffa500", Rgb = new [] { 255, 165, 0 }, Hsl = new [] { 39, 100, 50 } },
            //new HtmlColorSample { Name = "OrangeRed", Hex = "#ff4500", Rgb = new [] { 255, 69, 0 }, Hsl = new [] { 16, 100, 50 } },
            //new HtmlColorSample { Name = "Orchid", Hex = "#da70d6", Rgb = new [] { 218, 112, 214 }, Hsl = new [] { 302, 59, 65 } },
            //new HtmlColorSample { Name = "PaleGoldenrod", Hex = "#eee8aa", Rgb = new [] { 238, 232, 170 }, Hsl = new [] { 55, 67, 80 } },
            //new HtmlColorSample { Name = "PaleGreen", Hex = "#98fb98", Rgb = new [] { 152, 251, 152 }, Hsl = new [] { 120, 93, 79 } },
            //new HtmlColorSample { Name = "PaleTurquoise", Hex = "#afeeee", Rgb = new [] { 175, 238, 238 }, Hsl = new [] { 180, 65, 81 } },
            //new HtmlColorSample { Name = "PaleVioletRed", Hex = "#db7093", Rgb = new [] { 219, 112, 147 }, Hsl = new [] { 340, 60, 65 } },
            //new HtmlColorSample { Name = "PapayaWhip", Hex = "#ffefd5", Rgb = new [] { 255, 239, 213 }, Hsl = new [] { 37, 100, 92 } },
            //new HtmlColorSample { Name = "PeachPuff", Hex = "#ffdab9", Rgb = new [] { 255, 218, 185 }, Hsl = new [] { 28, 100, 86 } },
            //new HtmlColorSample { Name = "Peru", Hex = "#cd853f", Rgb = new [] { 205, 133, 63 }, Hsl = new [] { 30, 59, 53 } },
            //new HtmlColorSample { Name = "Pink", Hex = "#ffc0cb", Rgb = new [] { 255, 192, 203 }, Hsl = new [] { 350, 100, 88 } },
            //new HtmlColorSample { Name = "Plum", Hex = "#dda0dd", Rgb = new [] { 221, 160, 221 }, Hsl = new [] { 300, 47, 75 } },
            //new HtmlColorSample { Name = "PowderBlue", Hex = "#b0e0e6", Rgb = new [] { 176, 224, 230 }, Hsl = new [] { 187, 52, 80 } },
            //new HtmlColorSample { Name = "Purple", Hex = "#800080", Rgb = new [] { 128, 0, 128 }, Hsl = new [] { 300, 100, 25 } },
            //new HtmlColorSample { Name = "RebeccaPurple", Hex = "#663399", Rgb = new [] { 102, 51, 153 }, Hsl = new [] { 270, 50, 40 } },
            //new HtmlColorSample { Name = "Red", Hex = "#ff0000", Rgb = new [] { 255, 0, 0 }, Hsl = new [] { 0, 100, 50 } },
            //new HtmlColorSample { Name = "RosyBrown", Hex = "#bc8f8f", Rgb = new [] { 188, 143, 143 }, Hsl = new [] { 0, 25, 65 } },
            //new HtmlColorSample { Name = "RoyalBlue", Hex = "#4169e1", Rgb = new [] { 65, 105, 225 }, Hsl = new [] { 225, 73, 57 } },
            //new HtmlColorSample { Name = "SaddleBrown", Hex = "#8b4513", Rgb = new [] { 139, 69, 19 }, Hsl = new [] { 25, 76, 31 } },
            //new HtmlColorSample { Name = "Salmon", Hex = "#fa8072", Rgb = new [] { 250, 128, 114 }, Hsl = new [] { 6, 93, 71 } },
            //new HtmlColorSample { Name = "SandyBrown", Hex = "#f4a460", Rgb = new [] { 244, 164, 96 }, Hsl = new [] { 28, 87, 67 } },
            //new HtmlColorSample { Name = "SeaGreen", Hex = "#2e8b57", Rgb = new [] { 46, 139, 87 }, Hsl = new [] { 146, 50, 36 } },
            //new HtmlColorSample { Name = "SeaShell", Hex = "#fff5ee", Rgb = new [] { 255, 245, 238 }, Hsl = new [] { 25, 100, 97 } },
            //new HtmlColorSample { Name = "Sienna", Hex = "#a0522d", Rgb = new [] { 160, 82, 45 }, Hsl = new [] { 19, 56, 40 } },
            //new HtmlColorSample { Name = "Silver", Hex = "#c0c0c0", Rgb = new [] { 192, 192, 192 }, Hsl = new [] { 0, 0, 75 } },
            //new HtmlColorSample { Name = "SkyBlue", Hex = "#87ceeb", Rgb = new [] { 135, 206, 235 }, Hsl = new [] { 197, 71, 73 } },
            //new HtmlColorSample { Name = "SlateBlue", Hex = "#6a5acd", Rgb = new [] { 106, 90, 205 }, Hsl = new [] { 248, 53, 58 } },
            //new HtmlColorSample { Name = "SlateGray", Hex = "#708090", Rgb = new [] { 112, 128, 144 }, Hsl = new [] { 210, 13, 50 } },
            //new HtmlColorSample { Name = "Snow", Hex = "#fffafa", Rgb = new [] { 255, 250, 250 }, Hsl = new [] { 0, 100, 99 } },
            //new HtmlColorSample { Name = "SpringGreen", Hex = "#00ff7f", Rgb = new [] { 0, 255, 127 }, Hsl = new [] { 150, 100, 50 } },
            //new HtmlColorSample { Name = "SteelBlue", Hex = "#4682b4", Rgb = new [] { 70, 130, 180 }, Hsl = new [] { 207, 44, 49 } },
            //new HtmlColorSample { Name = "Tan", Hex = "#d2b48c", Rgb = new [] { 210, 180, 140 }, Hsl = new [] { 34, 44, 69 } },
            //new HtmlColorSample { Name = "Teal", Hex = "#008080", Rgb = new [] { 0, 128, 128 }, Hsl = new [] { 180, 100, 25 } },
            //new HtmlColorSample { Name = "Thistle", Hex = "#d8bfd8", Rgb = new [] { 216, 191, 216 }, Hsl = new [] { 300, 24, 80 } },
            //new HtmlColorSample { Name = "Tomato", Hex = "#ff6347", Rgb = new [] { 255, 99, 71 }, Hsl = new [] { 9, 100, 64 } },
            //new HtmlColorSample { Name = "Turquoise", Hex = "#40e0d0", Rgb = new [] { 64, 224, 208 }, Hsl = new [] { 174, 72, 56 } },
            //new HtmlColorSample { Name = "Violet", Hex = "#ee82ee", Rgb = new [] { 238, 130, 238 }, Hsl = new [] { 300, 76, 72 } },
            //new HtmlColorSample { Name = "Wheat", Hex = "#f5deb3", Rgb = new [] { 245, 222, 179 }, Hsl = new [] { 39, 77, 83 } },
            //new HtmlColorSample { Name = "White", Hex = "#ffffff", Rgb = new [] { 255, 255, 255 }, Hsl = new [] { 0, 0, 100 } },
            //new HtmlColorSample { Name = "WhiteSmoke", Hex = "#f5f5f5", Rgb = new [] { 245, 245, 245 }, Hsl = new [] { 0, 0, 96 } },
            //new HtmlColorSample { Name = "Yellow", Hex = "#ffff00", Rgb = new [] { 255, 255, 0 }, Hsl = new [] { 60, 100, 50 } },
            //new HtmlColorSample { Name = "YellowGreen", Hex = "#9acd32", Rgb = new [] { 154, 205, 50 }, Hsl = new [] { 80, 61, 50 } }
        };

    }

}