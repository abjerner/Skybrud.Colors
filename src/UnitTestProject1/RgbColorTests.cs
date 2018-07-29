using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;
using UnitTestProject1.Samples;

namespace UnitTestProject1 {
    
    [TestClass]
    public class RgbColorTests {

        [TestMethod]
        public void Base() {
            foreach (HtmlColorSample sample in HtmlColorSamples.All) {
                Assert.AreEqual(sample.Hex, sample.Base.ToHex(), sample.Name);
            }
        }
        
        [TestMethod]
        public void ToHex() {
            foreach (HtmlColorSample sample in HtmlColorSamples.All) {
                RgbColor color = sample.Base;
                Assert.AreEqual(sample.Hex, color.ToHex(), sample.Name);
            }
        }

        [TestMethod]
        public void ToHsl() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                int r = sample.Rgb.Red;
                int g = sample.Rgb.Green;
                int b = sample.Rgb.Blue;

                RgbColor rgb = new RgbColor(r, g, b);

                double h1 = sample.Hsl.Hue / 360d;
                double s1 = sample.Hsl.Saturation / 100d;
                double l1 = sample.Hsl.Lightness / 100d;

                ColorUtils.RgbToHsl(r, g, b, out double h2, out double s2, out double l2);
                Assert.AreEqual(h1.ToString("N2"), h2.ToString("N2"), "#1 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), s2.ToString("N2"), "#1 Saturation (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), l2.ToString("N2"), "#1 Lightness (" + sample.Name + ")");

                HslColor hsl1 = ColorUtils.RgbToHsl(r, g, b);
                Assert.AreEqual(h1.ToString("N2"), hsl1.H.ToString("N2"), "#2 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsl1.S.ToString("N2"), "#2 Saturation (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsl1.L.ToString("N2"), "#2 Lightness (" + sample.Name + ")");

                HslColor hsl2 = ColorUtils.RgbToHsl(rgb);
                Assert.AreEqual(h1.ToString("N2"), hsl2.H.ToString("N2"), "#3 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsl2.S.ToString("N2"), "#3 Saturation (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsl2.L.ToString("N2"), "#3 Lightness (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToCmyk() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                int r = sample.Rgb.Red;
                int g = sample.Rgb.Green;
                int b = sample.Rgb.Blue;

                RgbColor rgb = new RgbColor(r, g, b);

                double c1 = sample.Cmyk.Cyan / 100d;
                double m1 = sample.Cmyk.Magenta / 100d;
                double y1 = sample.Cmyk.Yellow / 100d;
                double k1 = sample.Cmyk.Key / 100d;

                ColorUtils.RgbToCmyk(r, g, b, out double c2, out double m2, out double y2, out double k2);

                Assert.AreEqual(c1.ToString("N2"), c2.ToString("N2"), "#1 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), m2.ToString("N2"), "#1 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), y2.ToString("N2"), "#1 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), k2.ToString("N2"), "#1 K (" + sample.Name + ")");

                CmykColor cmyk1 = ColorUtils.RgbToCmyk(r, g, b);

                Assert.AreEqual(c1.ToString("N2"), cmyk1.C.ToString("N2"), "#2 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmyk1.M.ToString("N2"), "#2 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmyk1.Y.ToString("N2"), "#2 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), cmyk1.K.ToString("N2"), "#2 K (" + sample.Name + ")");

                ColorUtils.RgbToCmyk(rgb, out double c3, out double m3, out double y3, out double k3);

                Assert.AreEqual(c1.ToString("N2"), c3.ToString("N2"), "#3 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), m3.ToString("N2"), "#3 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), y3.ToString("N2"), "#3 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), k3.ToString("N2"), "#3 K (" + sample.Name + ")");

                CmykColor cmyk2 = ColorUtils.RgbToCmyk(rgb);

                Assert.AreEqual(c1.ToString("N2"), cmyk2.C.ToString("N2"), "#4 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmyk2.M.ToString("N2"), "#4 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmyk2.Y.ToString("N2"), "#4 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), cmyk2.K.ToString("N2"), "#4 K (" + sample.Name + ")");

            }

        }

        public void ToCmy() {

            var samples = new[] {
                new { R = 150, G = 200, B = 250, C = 0.411764705882353, M = 0.215686274509804, Y = 0.0196078431372549 },
                new { R = 143, G = 47, B = 168, C = 0.43921568627451, M = 0.815686274509804, Y = 0.341176470588235 },
                new { R = 90, G = 163, B = 96, C = 0.647058823529412, M = 0.36078431372549, Y = 0.623529411764706 }
            };

            int i = 1;

            foreach (var sample in samples) {

                RgbColor rgb = new RgbColor(sample.R, sample.G, sample.B);

                CmyColor cmy = rgb.ToCmy();

                Assert.AreEqual(sample.C, cmy.C, "Sample #" + i + " (C)");
                Assert.AreEqual(sample.M, cmy.M, "Sample #" + i + " (M)");
                Assert.AreEqual(sample.Y, cmy.Y, "Sample #" + i + " (Y)");
                Assert.AreEqual(rgb.ToHex(), cmy.ToRgb().ToHex(), "Sample #" + i + " (HEX)");

                i++;

            }

        }

        [TestMethod]
        public void Parse() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {
                Assert.AreEqual(sample.Rgb.Css, RgbColor.Parse(sample.Hex).ToCss(), sample.Name);
            }

        }

        [TestMethod]
        public void TryParse() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {
                RgbColor color1;
                Assert.AreEqual(true, RgbColor.TryParse(sample.Hex, out color1));
                Assert.AreEqual(sample.Rgb.Css, color1.ToCss(), sample.Name);
            }

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {
                RgbColor color1;
                Assert.AreEqual(false, RgbColor.TryParse(sample.Name, out color1));
            }

        }

    }

}