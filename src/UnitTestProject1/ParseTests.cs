using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;

namespace UnitTestProject1 {

    [TestClass]
    public class ParseTests {

        [TestMethod]
        public void ParseHex1() {

            IColor color = ColorUtils.Parse("#ff4500");

            RgbColor rgb = color as RgbColor;

            Assert.IsNotNull(rgb);

            Assert.AreEqual("255", rgb.Red.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("69", rgb.Green.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("0", rgb.Blue.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("1.00", rgb.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void ParseHex2() {

            RgbColor rgb = RgbColor.Parse("#ff4500");

            Assert.IsNotNull(rgb);

            Assert.AreEqual("255", rgb.Red.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("69", rgb.Green.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("0", rgb.Blue.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("1.00", rgb.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void ParseHex3() {

            RgbColor rgb = RgbColor.Parse("#fff");

            Assert.IsNotNull(rgb);

            Assert.AreEqual("255", rgb.Red.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("255", rgb.Green.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("255", rgb.Blue.ToString("F0", CultureInfo.InvariantCulture));
            Assert.AreEqual("1.00", rgb.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void ParseHsl1() {

            IColor color = ColorUtils.Parse("hsl(178, 24%, 45%)");

            HslColor hsl = color as HslColor;

            Assert.IsNotNull(hsl);

            Assert.AreEqual("0.49", hsl.Hue.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.24", hsl.Saturation.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.45", hsl.Lightness.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("1.00", hsl.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void ParseHsl2() {

            HslColor hsl = HslColor.Parse("hsl(178, 24%, 45%)");

            Assert.IsNotNull(hsl);

            Assert.AreEqual("0.49", hsl.Hue.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.24", hsl.Saturation.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.45", hsl.Lightness.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("1.00", hsl.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void ParseHsla1() {

            IColor color = ColorUtils.Parse("hsla(120, 75%, 45%, 0.5)");

            HslColor hsl = color as HslColor;

            Assert.IsNotNull(hsl);

            Assert.AreEqual("0.33", hsl.Hue.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.75", hsl.Saturation.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.45", hsl.Lightness.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.50", hsl.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void ParseHsla2() {

            HslColor hsl = HslColor.Parse("hsla(120, 75%, 45%, 0.5)");

            Assert.IsNotNull(hsl);

            Assert.AreEqual("0.33", hsl.Hue.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.75", hsl.Saturation.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.45", hsl.Lightness.ToString("F2", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.50", hsl.Alpha.ToString("F2", CultureInfo.InvariantCulture));

        }

    }

}