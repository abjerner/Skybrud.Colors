using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;

namespace UnitTestProject1 {

    [TestClass]
    public class AlphaConvertionTests {

        [TestMethod]
        public void CmyTo() {

            CmyColor cmy = new CmyColor(0.05882352941176472, 0.027450980392156876, 0, 0.5);

            Assert.AreEqual(0.5, cmy.ToCmy().Alpha, "To CMY");

            Assert.AreEqual(0.5, cmy.ToCmyk().Alpha, "To CMYK");

            Assert.AreEqual(0.5, cmy.ToHsl().Alpha, "To HSL");

            Assert.AreEqual(0.5, cmy.ToHsv().Alpha, "To HSV");

            Assert.AreEqual(0.5, cmy.ToRgb().Alpha, "To RGB");

        }

        [TestMethod]
        public void CmykTo() {

            CmykColor cmyk = new CmykColor(0.05882352941176472, 0.027450980392156876, 0, 0, 0.5);

            Assert.AreEqual(0.5, cmyk.ToCmy().Alpha, "To CMY");

            Assert.AreEqual(0.5, cmyk.ToCmyk().Alpha, "To CMYK");

            Assert.AreEqual(0.5, cmyk.ToHsl().Alpha, "To HSL");

            Assert.AreEqual(0.5, cmyk.ToHsv().Alpha, "To HSV");

            Assert.AreEqual(0.5, cmyk.ToRgb().Alpha, "To RGB");

        }

        [TestMethod]
        public void HslTo() {

            HslColor hsl = new HslColor(208, 1, 0.9705882370471954, 0.5);

            Assert.AreEqual(0.5, hsl.ToCmy().Alpha, "To CMY");

            Assert.AreEqual(0.5, hsl.ToCmyk().Alpha, "To CMYK");

            Assert.AreEqual(0.5, hsl.ToHsl().Alpha, "To HSL");

            Assert.AreEqual(0.5, hsl.ToHsv().Alpha, "To HSV");

            Assert.AreEqual(0.5, hsl.ToRgb().Alpha, "To RGB");

        }

        [TestMethod]
        public void HsvTo() {

            HsvColor hsv = new HsvColor(208, 0.05882352941176472, 1, 0.5);

            Assert.AreEqual(0.5, hsv.ToCmy().Alpha, "To CMY");

            Assert.AreEqual(0.5, hsv.ToCmyk().Alpha, "To CMYK");

            Assert.AreEqual(0.5, hsv.ToHsl().Alpha, "To HSL");

            Assert.AreEqual(0.5, hsv.ToHsv().Alpha, "To HSV");

            Assert.AreEqual(0.5, hsv.ToRgb().Alpha, "To RGB");

        }

        [TestMethod]
        public void RgbTo() {

            RgbColor rgb = new RgbColor(0, 0, 0, 0.5);

            Assert.AreEqual(0.5, rgb.ToCmy().Alpha, "To CMY");

            Assert.AreEqual(0.5, rgb.ToCmyk().Alpha, "To CMYK");

            Assert.AreEqual(0.5, rgb.ToHsl().Alpha, "To HSL");

            Assert.AreEqual(0.5, rgb.ToHsv().Alpha, "To HSV");

            Assert.AreEqual(0.5, rgb.ToRgb().Alpha, "To RGB");

        }

    }

}