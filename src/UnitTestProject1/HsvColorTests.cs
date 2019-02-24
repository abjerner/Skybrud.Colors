using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;
using UnitTestProject1.Samples;

namespace UnitTestProject1 {
    
    [TestClass]
    public class HsvColorTests {

        [TestMethod]
        public void ToHsl() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double h = sample.Hsv.Hue / 360d;
                double s = sample.Hsv.Saturation;
                double v = sample.Hsv.Value;

                HsvColor hsv = new HsvColor(h, s, v);

                double h1 = sample.Hsl.Hue / 360d;
                double s1 = sample.Hsl.Saturation;
                double l1 = sample.Hsl.Lightness;

                ColorUtils.HsvToHsl(h, s, v, out double h2, out double s2, out double l2);
                Assert.AreEqual(h1.ToString("N2"), h2.ToString("N2"), "#1 H (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), s2.ToString("N2"), "#1 S (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), l2.ToString("N2"), "#1 L (" + sample.Name + ")");

                HslColor hsv1 = ColorUtils.HsvToHsl(h, s, v);
                Assert.AreEqual(h1.ToString("N2"), hsv1.Hue.ToString("N2"), "#2 H (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsv1.Saturation.ToString("N2"), "#2 S (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsv1.Lightness.ToString("N2"), "#2 L (" + sample.Name + ")");

                HslColor hsv2 = ColorUtils.HsvToHsl(hsv);
                Assert.AreEqual(h1.ToString("N2"), hsv2.Hue.ToString("N2"), "#3 H (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsv2.Saturation.ToString("N2"), "#3 S (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsv2.Lightness.ToString("N2"), "#3 L (" + sample.Name + ")");

                HslColor hsv3 = hsv.ToHsl();
                Assert.AreEqual(h1.ToString("N2"), hsv3.Hue.ToString("N2"), "#4 H (" + sample.Name + ")");
                Assert.AreEqual(s1.ToString("N2"), hsv3.Saturation.ToString("N2"), "#4 S (" + sample.Name + ")");
                Assert.AreEqual(l1.ToString("N2"), hsv3.Lightness.ToString("N2"), "#4 L (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToRgb() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double h = sample.Hsl.Hue / 360d;
                double s = sample.Hsl.Saturation;
                double l = sample.Hsl.Lightness;

                HslColor hsl = new HslColor(h, s, l);

                int r1 = sample.Rgb.Red;
                int g1 = sample.Rgb.Green;
                int b1 = sample.Rgb.Blue;

                ColorUtils.HslToRgb(h, s, l, out int r2, out int g2, out int b2);
                Assert.AreEqual(r1.ToString("N2"), r2.ToString("N2"), "#1 R (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N2"), g2.ToString("N2"), "#1 G (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N2"), b2.ToString("N2"), "#1 B (" + sample.Name + ")");

                RgbColor rgb1 = ColorUtils.HslToRgb(h, s, l);
                Assert.AreEqual(r1.ToString("N2"), rgb1.Red.ToString("N2"), "#2 R (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N2"), rgb1.Green.ToString("N2"), "#2 G (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N2"), rgb1.Blue.ToString("N2"), "#2 B (" + sample.Name + ")");

                ColorUtils.HslToRgb(h, s, l, out int r3, out int g3, out int b3);
                Assert.AreEqual(r1.ToString("N2"), r3.ToString("N2"), "#2 R (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N2"), g3.ToString("N2"), "#2 G (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N2"), b3.ToString("N2"), "#2 B (" + sample.Name + ")");

                RgbColor rgb2 = ColorUtils.HslToRgb(hsl);
                Assert.AreEqual(r1.ToString("N2"), rgb2.Red.ToString("N2"), "#3 R (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N2"), rgb2.Green.ToString("N2"), "#3 G (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N2"), rgb2.Blue.ToString("N2"), "#3 B (" + sample.Name + ")");

                RgbColor rgb3 = ColorUtils.HslToRgb(hsl);
                Assert.AreEqual(r1.ToString("N2"), rgb3.Red.ToString("N2"), "#4 R (" + sample.Name + ")");
                Assert.AreEqual(g1.ToString("N2"), rgb3.Green.ToString("N2"), "#4 G (" + sample.Name + ")");
                Assert.AreEqual(b1.ToString("N2"), rgb3.Blue.ToString("N2"), "#4 B (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToCmy() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double h = sample.Hsv.Hue / 360d;
                double s = sample.Hsv.Saturation;
                double v = sample.Hsv.Value;

                HsvColor hsv = new HsvColor(h, s, v);

                double c1 = sample.Cmy.Cyan;
                double m1 = sample.Cmy.Magenta;
                double y1 = sample.Cmy.Yellow;

                ColorUtils.HsvToCmy(h, s, v, out double c2, out double m2, out double y2);
                Assert.AreEqual(c1.ToString("N2"), c2.ToString("N2"), "#1 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), m2.ToString("N2"), "#1 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), y2.ToString("N2"), "#1 Y (" + sample.Name + ")");

                CmyColor cmy1 = ColorUtils.HsvToCmy(h, s, v);
                Assert.AreEqual(c1.ToString("N2"), cmy1.C.ToString("N2"), "#2 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmy1.M.ToString("N2"), "#2 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmy1.Y.ToString("N2"), "#2 Y (" + sample.Name + ")");

                CmyColor cmy2 = ColorUtils.HsvToCmy(hsv);
                Assert.AreEqual(c1.ToString("N2"), cmy2.C.ToString("N2"), "#3 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmy2.M.ToString("N2"), "#3 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmy2.Y.ToString("N2"), "#3 Y (" + sample.Name + ")");

                CmyColor cmy3 = hsv.ToCmy();
                Assert.AreEqual(c1.ToString("N2"), cmy3.C.ToString("N2"), "#4 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmy3.M.ToString("N2"), "#4 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmy3.Y.ToString("N2"), "#4 Y (" + sample.Name + ")");

            }

        }

        [TestMethod]
        public void ToCmyk() {

            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                double h = sample.Hsv.Hue / 360d;
                double s = sample.Hsv.Saturation;
                double v = sample.Hsv.Value;

                HsvColor hsv = new HsvColor(h, s, v);

                double c1 = sample.Cmyk.Cyan;
                double m1 = sample.Cmyk.Magenta;
                double y1 = sample.Cmyk.Yellow;
                double k1 = sample.Cmyk.Key;

                ColorUtils.HsvToCmyk(h, s, v, out double c2, out double m2, out double y2, out double k2);
                Assert.AreEqual(c1.ToString("N2"), c2.ToString("N2"), "#1 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), m2.ToString("N2"), "#1 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), y2.ToString("N2"), "#1 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), k2.ToString("N2"), "#1 K (" + sample.Name + ")");

                CmykColor cmyk1 = ColorUtils.HsvToCmyk(h, s, v);
                Assert.AreEqual(c1.ToString("N2"), cmyk1.C.ToString("N2"), "#2 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmyk1.M.ToString("N2"), "#2 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmyk1.Y.ToString("N2"), "#2 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), cmyk1.K.ToString("N2"), "#2 K (" + sample.Name + ")");

                CmykColor cmyk2 = ColorUtils.HsvToCmyk(hsv);
                Assert.AreEqual(c1.ToString("N2"), cmyk2.C.ToString("N2"), "#3 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmyk2.M.ToString("N2"), "#3 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmyk2.Y.ToString("N2"), "#3 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), cmyk2.K.ToString("N2"), "#3 K (" + sample.Name + ")");

                CmykColor cmyk3 = hsv.ToCmyk();
                Assert.AreEqual(c1.ToString("N2"), cmyk3.C.ToString("N2"), "#4 C (" + sample.Name + ")");
                Assert.AreEqual(m1.ToString("N2"), cmyk3.M.ToString("N2"), "#4 M (" + sample.Name + ")");
                Assert.AreEqual(y1.ToString("N2"), cmyk3.Y.ToString("N2"), "#4 Y (" + sample.Name + ")");
                Assert.AreEqual(k1.ToString("N2"), cmyk3.K.ToString("N2"), "#4 K (" + sample.Name + ")");

            }

        }

    }

}