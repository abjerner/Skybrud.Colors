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

            RgbColor rgb1 = RgbColor.Parse("#fff");
            RgbColor rgb2 = RgbColor.Parse("#ffffff");
            RgbColor rgb3 = RgbColor.Parse("#ffffffff");
            RgbColor rgb4 = RgbColor.Parse("#ffffff80");
            RgbColor rgb5 = RgbColor.Parse("#ffffff00");

            Assert.AreEqual(255, rgb1.Red, "Color 1: Red");
            Assert.AreEqual(255, rgb1.Green, "Color 1: Green");
            Assert.AreEqual(255, rgb1.Blue, "Color 1: Blue");
            Assert.AreEqual("1.00", rgb1.Alpha.ToString("N2"), "Color 1: Alpha");

            Assert.AreEqual(255, rgb2.Red, "Color 2: Red");
            Assert.AreEqual(255, rgb2.Green, "Color 2: Green");
            Assert.AreEqual(255, rgb2.Blue, "Color 2: Blue");
            Assert.AreEqual("1.00", rgb2.Alpha.ToString("N2"), "Color 2: Alpha");

            Assert.AreEqual(255, rgb3.Red, "Color 3: Red");
            Assert.AreEqual(255, rgb3.Green, "Color 3: Green");
            Assert.AreEqual(255, rgb3.Blue, "Color 3: Blue");
            Assert.AreEqual("1.00", rgb3.Alpha.ToString("N2"), "Color 3: Alpha");

            Assert.AreEqual(255, rgb4.Red, "Color 4: Red");
            Assert.AreEqual(255, rgb4.Green, "Color 4: Green");
            Assert.AreEqual(255, rgb4.Blue, "Color 4: Blue");
            Assert.AreEqual("0.50", rgb4.Alpha.ToString("N2"), "Color 4: Alpha");

            Assert.AreEqual(255, rgb5.Red, "Color 5: Red");
            Assert.AreEqual(255, rgb5.Green, "Color 5: Green");
            Assert.AreEqual(255, rgb5.Blue, "Color 5: Blue");
            Assert.AreEqual("0.00", rgb5.Alpha.ToString("N2"), "Color 5: Alpha");

        }

    }

}