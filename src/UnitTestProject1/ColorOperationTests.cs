using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;

namespace UnitTestProject1 {

    [TestClass]
    public class ColorOperationTests {

        [TestMethod]
        public void Saturize() {

            HslColor hsl = HslColor.Parse("hsl(90, 80%, 50%)");

            Assert.AreEqual("#80e619", hsl.ToHex());

            IColor result = hsl.Saturate(20);

            Assert.AreEqual("#80ff00", result.ToHex());
            Assert.AreEqual("hsl(90, 100%, 50%)", result.ToCss());

        }

        [TestMethod]
        public void Desaturize() {

            HslColor hsl = HslColor.Parse("hsl(90, 80%, 50%)");

            Assert.AreEqual("#80e619", hsl.ToHex());

            IColor result = hsl.Desaturate(20);

            Assert.AreEqual("#80cc33", result.ToHex());
            Assert.AreEqual("hsl(90, 60%, 50%)", result.ToCss());

        }

        [TestMethod]
        public void Ligthen() {

            HslColor hsl = HslColor.Parse("hsl(90, 80%, 50%)");

            Assert.AreEqual("#80e619", hsl.ToHex());

            IColor result = hsl.Lighten(20);

            Assert.AreEqual("#b3f075", result.ToHex());
            Assert.AreEqual("hsl(90, 80%, 70%)", result.ToCss());

        }

        [TestMethod]
        public void Darken() {

            HslColor hsl = HslColor.Parse("hsl(90, 80%, 50%)");

            Assert.AreEqual("#80e619", hsl.ToHex());

            IColor result = hsl.Darken(20);

            Assert.AreEqual("#4d8a0f", result.ToHex());
            Assert.AreEqual("hsl(90, 80%, 30%)", result.ToCss());

        }

        [TestMethod]
        public void Spin() {

            RgbColor origin = ColorUtils.HexToRgb("#f2330d");

            IColor result1 = origin.Spin(+30);
            IColor result2 = origin.Spin(-30);

            Assert.AreEqual("#f2a60d", result1.ToHex());
            Assert.AreEqual("#f20d59", result2.ToHex());

            IColor result3 = origin.Spin(+30 + 360);
            IColor result4 = origin.Spin(-30 - 360);

            Assert.AreEqual("#f2a60d", result3.ToHex());
            Assert.AreEqual("#f20d59", result4.ToHex());

        }

    }

}