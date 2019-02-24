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

    }

}