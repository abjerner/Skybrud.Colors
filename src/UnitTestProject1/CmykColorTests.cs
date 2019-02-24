using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;
using UnitTestProject1.Samples;

namespace UnitTestProject1 {
    
    [TestClass]
    public class CmykColorTests {

        [TestMethod]
        public void ToCmy() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double c = sample.Cmyk.Cyan;
                double m = sample.Cmyk.Magenta;
                double y = sample.Cmyk.Yellow;
                double k = sample.Cmyk.Key;

                CmykColor cmyk = new CmykColor(c, m, y, k);

                double c1 = sample.Cmy.Cyan;
                double m1 = sample.Cmy.Magenta;
                double y1 = sample.Cmy.Yellow;

                ColorUtils.CmykToCmy(c, m, y, k, out double c2, out double m2, out double y2);
                Assert.AreEqual(c1.ToString("N8"), c2.ToString("N8"), "#1 Cyan (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N8"), m2.ToString("N8"), "#1 Magenta (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N8"), y2.ToString("N8"), "#1 Yellow (" + sample.Name + ")");

                CmyColor cmyk1 = ColorUtils.CmykToCmy(c, m, y, k);
                Assert.AreEqual(c1.ToString("N8"), cmyk1.Cyan.ToString("N8"), "#2 Cyan (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N8"), cmyk1.Magenta.ToString("N8"), "#2 Magenta (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N8"), cmyk1.Yellow.ToString("N8"), "#2 Yellow (" + sample.Name + ")");

                CmyColor cmyk2 = ColorUtils.CmykToCmy(cmyk);
                Assert.AreEqual(c1.ToString("N8"), cmyk2.Cyan.ToString("N8"), "#3 Cyan (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N8"), cmyk2.Magenta.ToString("N8"), "#3 Magenta (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N8"), cmyk2.Yellow.ToString("N8"), "#3 Yellow (" + sample.Name + ")");

                CmyColor cmyk3 = cmyk.ToCmy();
                Assert.AreEqual(c1.ToString("N8"), cmyk3.Cyan.ToString("N8"), "#3 Cyan (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N8"), cmyk3.Magenta.ToString("N8"), "#3 Magenta (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N8"), cmyk3.Yellow.ToString("N8"), "#3 Yellow (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToHsl() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double c = sample.Cmyk.Cyan;
                double m = sample.Cmyk.Magenta;
                double y = sample.Cmyk.Yellow;
                double k = sample.Cmyk.Key;

                CmykColor cmyk = new CmykColor(c, m, y, k);

                double h1 = sample.Hsl.Hue / 360;
                double s1 = sample.Hsl.Saturation;
                double l1 = sample.Hsl.Lightness;
                
                HslColor hsl3 = cmyk.ToHsl();
                Assert.AreEqual(h1.ToString("N2"), hsl3.Hue.ToString("N2"), "#3 Hue (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsl3.Saturation.ToString("N2"), "#3 Saturation (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsl3.Lightness.ToString("N2"), "#3 Lightness (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToRgb() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double c = sample.Cmyk.Cyan;
                double m = sample.Cmyk.Magenta;
                double y = sample.Cmyk.Yellow;
                double k = sample.Cmyk.Key;

                CmykColor cmyk = new CmykColor(c, m, y, k);

                int r1 = sample.Rgb.Red;
                int g1 = sample.Rgb.Green;
                int b1 = sample.Rgb.Blue;

                ColorUtils.CmykToRgb(c, m, y, k, out byte r2, out byte g2, out byte b2);
                Assert.AreEqual(r1.ToString("N8"), r2.ToString("N8"), "#1 Red (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N8"), g2.ToString("N8"), "#1 Green (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N8"), b2.ToString("N8"), "#1 Blue (" + sample.Name + ")");

                RgbColor rgb1 = ColorUtils.CmykToRgb(c, m, y, k);
                Assert.AreEqual(r1.ToString("N8"), rgb1.Red.ToString("N8"), "#2 Red (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N8"), rgb1.Green.ToString("N8"), "#2 Green (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N8"), rgb1.Blue.ToString("N8"), "#2 Blue (" + sample.Name + ")");

                RgbColor rgb2 = ColorUtils.CmykToRgb(cmyk);
                Assert.AreEqual(r1.ToString("N8"), rgb2.Red.ToString("N8"), "#3 Red (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N8"), rgb2.Green.ToString("N8"), "#3 Green (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N8"), rgb2.Blue.ToString("N8"), "#3 Blue (" + sample.Name + ")");

                RgbColor rgb3 = cmyk.ToRgb();
                Assert.AreEqual(r1.ToString("N8"), rgb3.Red.ToString("N8"), "#3 Red (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N8"), rgb3.Green.ToString("N8"), "#3 Green (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N8"), rgb3.Blue.ToString("N8"), "#3 Blue (" + sample.Name + ")");

            }

        }

    }

}