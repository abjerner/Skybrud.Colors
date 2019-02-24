using Skybrud.Colors;

namespace UnitTestProject1.Samples {

    public class HtmlColorSample {

        public string Name { get; }

        public RgbColor Base { get; }

        public string Hex { get; }

        public HtmlColorSampleRgb Rgb { get; }

        public HtmlColorSampleHsl Hsl { get; }

        public HtmlColorSampleHsv Hsv { get; }

        public HtmlColorSampleCmy Cmy { get; }

        public HtmlColorSampleCmyk Cmyk { get; }

        public HtmlColorSample(string name, RgbColor @base, string hex, HtmlColorSampleRgb rgb, HtmlColorSampleHsl hsl, HtmlColorSampleHsv hsv, HtmlColorSampleCmy cmy, HtmlColorSampleCmyk cmyk) {
            Name = name;
            Base = @base;
            Hex = hex;
            Rgb = rgb;
            Hsl = hsl;
            Hsv = hsv;
            Cmy = cmy;
            Cmyk = cmyk;
        }

        public HtmlColorSample(string name, RgbColor @base, string hex, HtmlColorSampleRgb rgb, HtmlColorSampleHsl hsl, HtmlColorSampleHsv hsv, HtmlColorSampleCmyk cmyk) {
            Name = name;
            Base = @base;
            Hex = hex;
            Rgb = rgb;
            Hsl = hsl;
            Hsv = hsv;
            Cmyk = cmyk;
        }

    }

}