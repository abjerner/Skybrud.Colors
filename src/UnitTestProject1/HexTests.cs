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

    }

}