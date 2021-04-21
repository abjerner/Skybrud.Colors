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
        public void FromHex()
        {
            foreach (HtmlColorSample sample in HtmlColorSamples.All)
            {
                string hex = sample.Hex;
                RgbColor colorTest = ColorHelpers.HexadecimalToRgb(hex);
                Assert.AreEqual(sample.Hex, colorTest.ToHex(), sample.Name);
                Assert.AreEqual(sample.Rgb.Red, colorTest.Red, sample.Name);
                Assert.AreEqual(sample.Rgb.Green, colorTest.Green, sample.Name);
                Assert.AreEqual(sample.Rgb.Blue, colorTest.Blue, sample.Name);
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
                double s1 = sample.Hsl.Saturation;
                double l1 = sample.Hsl.Lightness;

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

                HslColor hsl3 = rgb.ToHsl();
                Assert.AreEqual(h1.ToString("N2"), hsl3.H.ToString("N2"), "#4 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsl3.S.ToString("N2"), "#4 Saturation (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsl3.L.ToString("N2"), "#4 Lightness (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToHsv() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                int r = sample.Rgb.Red;
                int g = sample.Rgb.Green;
                int b = sample.Rgb.Blue;

                RgbColor rgb = new RgbColor(r, g, b);

                double h1 = sample.Hsv.Hue / 360d;
                double s1 = sample.Hsv.Saturation;
                double v1 = sample.Hsv.Value;

                ColorUtils.RgbToHsv(r, g, b, out double h2, out double s2, out double l2);
                Assert.AreEqual(h1.ToString("N2"), h2.ToString("N2"), "#1 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), s2.ToString("N2"), "#1 Saturation (" + sample.Name + ")");
                Assert.AreEqual(v1.ToString("N2"), l2.ToString("N2"), "#1 Value (" + sample.Name + ")");

                HsvColor hsv1 = ColorUtils.RgbToHsv(r, g, b);
                Assert.AreEqual(h1.ToString("N2"), hsv1.Hue.ToString("N2"), "#2 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsv1.Saturation.ToString("N2"), "#2 Saturation (" + sample.Name + ")");
                Assert.AreEqual(v1.ToString("N2"), hsv1.Value.ToString("N2"), "#2 Value (" + sample.Name + ")");

                HsvColor hsl2 = ColorUtils.RgbToHsv(rgb);
                Assert.AreEqual(h1.ToString("N2"), hsl2.Hue.ToString("N2"), "#3 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsl2.Saturation.ToString("N2"), "#3 Saturation (" + sample.Name + ")");
                Assert.AreEqual(v1.ToString("N2"), hsl2.Value.ToString("N2"), "#3 Value (" + sample.Name + ")");

                HsvColor hsl3 = rgb.ToHsv();
                Assert.AreEqual(h1.ToString("N2"), hsl3.Hue.ToString("N2"), "#4 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsl3.Saturation.ToString("N2"), "#4 Saturation (" + sample.Name + ")");
                Assert.AreEqual(v1.ToString("N2"), hsl3.Value.ToString("N2"), "#4 Value (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToCmy() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                if (sample.Cmy == null) continue;

                int r = sample.Rgb.Red;
                int g = sample.Rgb.Green;
                int b = sample.Rgb.Blue;

                RgbColor rgb = new RgbColor(r, g, b);

                double c1 = sample.Cmy.Cyan;
                double m1 = sample.Cmy.Magenta;
                double y1 = sample.Cmy.Yellow;

                ColorUtils.RgbToCmy(r, g, b, out double c2, out double m2, out double y2);
                Assert.AreEqual(c1.ToString("N2"), c2.ToString("N2"), "#1 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), m2.ToString("N2"), "#1 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), y2.ToString("N2"), "#1 Y (" + sample.Name + ")");

                CmyColor cmy1 = ColorUtils.RgbToCmy(r, g, b);
                Assert.AreEqual(c1.ToString("N2"), cmy1.C.ToString("N2"), "#2 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmy1.M.ToString("N2"), "#2 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmy1.Y.ToString("N2"), "#2 Y (" + sample.Name + ")");

                ColorUtils.RgbToCmy(rgb, out double c3, out double m3, out double y3);
                Assert.AreEqual(c1.ToString("N2"), c3.ToString("N2"), "#3 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), m3.ToString("N2"), "#3 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), y3.ToString("N2"), "#3 Y (" + sample.Name + ")");

                CmyColor cmy2 = ColorUtils.RgbToCmy(rgb);
                Assert.AreEqual(c1.ToString("N2"), cmy2.C.ToString("N2"), "#4 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmy2.M.ToString("N2"), "#4 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmy2.Y.ToString("N2"), "#4 Y (" + sample.Name + ")");

                CmyColor cmy3 = rgb.ToCmy();
                Assert.AreEqual(c1.ToString("N2"), cmy3.C.ToString("N2"), "#5 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmy3.M.ToString("N2"), "#5 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmy3.Y.ToString("N2"), "#5 Y (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToCmyk() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                int r = sample.Rgb.Red;
                int g = sample.Rgb.Green;
                int b = sample.Rgb.Blue;

                RgbColor rgb = new RgbColor(r, g, b);

                double c1 = sample.Cmyk.Cyan;
                double m1 = sample.Cmyk.Magenta;
                double y1 = sample.Cmyk.Yellow;
                double k1 = sample.Cmyk.Key;

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

                CmykColor cmyk3 = rgb.ToCmyk();
                Assert.AreEqual(c1.ToString("N2"), cmyk3.C.ToString("N2"), "#5 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmyk3.M.ToString("N2"), "#5 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmyk3.Y.ToString("N2"), "#5 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), cmyk3.K.ToString("N2"), "#5 K (" + sample.Name + ")");

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