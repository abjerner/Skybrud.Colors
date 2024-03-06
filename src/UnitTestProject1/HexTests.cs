using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;

namespace UnitTestProject1 {

    [TestClass]
    public class HexTests {

        [TestMethod]
        public void Opaque() {

            RgbColor rgb = new RgbColor(255, 255, 255, 1.0);

            Assert.AreEqual("#ffffff", rgb.ToHex(), "Auto, implicit");
            Assert.AreEqual("#ffffff", rgb.ToHex(HexFormat.Auto), "Auto, explicit");
            Assert.AreEqual("#ffffff", rgb.ToHex(HexFormat.Rgb), "Rgb, explicit");
            Assert.AreEqual("#ffffffff", rgb.ToHex(HexFormat.Rgba), "Rgba, explicit");

        }

        [TestMethod]
        public void FiftyFifty() {

            RgbColor rgb = new RgbColor(255, 255, 255, 0.5);

            Assert.AreEqual("#ffffff80", rgb.ToHex(), "Auto, implicit");
            Assert.AreEqual("#ffffff80", rgb.ToHex(HexFormat.Auto), "Auto, explicit");
            Assert.AreEqual("#ffffff", rgb.ToHex(HexFormat.Rgb), "Rgb, explicit");
            Assert.AreEqual("#ffffff80", rgb.ToHex(HexFormat.Rgba), "Rgba, explicit");

        }

        [TestMethod]
        public void Transparent() {

            RgbColor rgb = new RgbColor(255, 255, 255, 0.0);

            Assert.AreEqual("#ffffff00", rgb.ToHex(), "Auto, implicit");
            Assert.AreEqual("#ffffff00", rgb.ToHex(HexFormat.Auto), "Auto, explicit");
            Assert.AreEqual("#ffffff", rgb.ToHex(HexFormat.Rgb), "Rgb, explicit");
            Assert.AreEqual("#ffffff00", rgb.ToHex(HexFormat.Rgba), "Rgba, explicit");

        }

        [TestMethod]
        public void Parse() {

            var samples = new[] {
                new { Input = "#fff", Red = 255, Green = 255, Blue = 255, Alpha = "1.00" },
                new { Input = "#ffffff", Red = 255, Green = 255, Blue = 255, Alpha = "1.00" },
                new { Input = "#ffffffff", Red = 255, Green = 255, Blue = 255, Alpha = "1.00" },
                new { Input = "#ffffff80", Red = 255, Green = 255, Blue = 255, Alpha = "0.50" },
                new { Input = "#ffffff00", Red = 255, Green = 255, Blue = 255, Alpha = "0.00" },
                new { Input = "#FFF", Red = 255, Green = 255, Blue = 255, Alpha = "1.00" },
                new { Input = "#FFFFFF", Red = 255, Green = 255, Blue = 255, Alpha = "1.00" },
                new { Input = "#FFFFFFFF", Red = 255, Green = 255, Blue = 255, Alpha = "1.00" },
                new { Input = "#ECF1F4", Red = 236, Green = 241, Blue = 244, Alpha = "1.00" },
                new { Input = "#A9B3BA", Red = 169, Green = 179, Blue = 186, Alpha = "1.00" },
                new { Input = "#A58D42", Red = 165, Green = 141, Blue = 66, Alpha = "1.00" }
            };

            int n = 1;

            foreach (var sample in samples) {

                RgbColor result1 = ColorUtils.Parse(sample.Input).ToRgb();
                RgbColor result2 = ColorUtils.HexToRgb(sample.Input);
                RgbColor result3 = RgbColor.Parse(sample.Input);

                Assert.AreEqual(sample.Red, result1.Red, $"Color {n}: Red (ColorUtils.Parse)");
                Assert.AreEqual(sample.Green, result1.Green, $"Color {n}: Green (ColorUtils.Parse)");
                Assert.AreEqual(sample.Blue, result1.Blue, $"Color {n}: Blue (ColorUtils.Parse)");
                Assert.AreEqual(sample.Alpha, result1.Alpha.ToString("N2", CultureInfo.InvariantCulture), $"Color {n}: Alpha (ColorUtils.Parse)");

                Assert.AreEqual(sample.Red, result2.Red, $"Color {n}: Red (ColorUtils.HexToRgb)");
                Assert.AreEqual(sample.Green, result2.Green, $"Color {n}: Green (ColorUtils.HexToRgb)");
                Assert.AreEqual(sample.Blue, result2.Blue, $"Color {n}: Blue (ColorUtils.HexToRgb)");
                Assert.AreEqual(sample.Alpha, result2.Alpha.ToString("N2", CultureInfo.InvariantCulture), $"Color {n}: Alpha (ColorUtils.HexToRgb)");

                Assert.AreEqual(sample.Red, result3.Red, $"Color {n}: Red (ColorUtils.Parse)");
                Assert.AreEqual(sample.Green, result3.Green, $"Color {n}: Green (ColorUtils.Parse)");
                Assert.AreEqual(sample.Blue, result3.Blue, $"Color {n}: Blue (ColorUtils.Parse)");
                Assert.AreEqual(sample.Alpha, result3.Alpha.ToString("N2", CultureInfo.InvariantCulture), $"Color {n}: Alpha (ColorUtils.Parse)");

                n++;

            }

        }

    }

}