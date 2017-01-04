using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;
using UnitTestProject1.Samples;

namespace UnitTestProject1 {
    
    [TestClass]
    public class RgbColorTests {

        [TestMethod]
        public void Base() {
            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                Assert.AreEqual(sample.Hex, sample.Base.ToHex(), sample.Name);
                Assert.AreEqual(sample.Hex, sample.Rgb.ToHex(), sample.Name);
            }
        }
        
        [TestMethod]
        public void ToHex() {
            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                RgbColor color = sample.Rgb;
                Assert.AreEqual(sample.Hex, color.ToHex(), sample.Name);
            }
        }

        [TestMethod]
        public void ToHsl() {
            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                Assert.AreEqual(sample.HslText, sample.Rgb.ToHsl().ToString(), sample.Name);
            }
        }

        [TestMethod]
        public void ToCmyk() {
            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                Assert.AreEqual(sample.CmykText, sample.Rgb.ToCmyk().ToString(), sample.Name);
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

            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                Assert.AreEqual(sample.RgbCss, RgbColor.Parse(sample.Hex).ToCss(), sample.Name);
            }

        }

        [TestMethod]
        public void TryParse() {

            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                RgbColor color1;
                Assert.AreEqual(true, RgbColor.TryParse(sample.Hex, out color1));
                Assert.AreEqual(sample.RgbCss, color1.ToCss(), sample.Name);
            }

            foreach (HtmlColorSample sample in HtmlColorSample.All) {
                RgbColor color1;
                Assert.AreEqual(false, RgbColor.TryParse(sample.Name, out color1));
            }

        }

    }

}