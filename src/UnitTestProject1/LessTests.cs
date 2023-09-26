using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;

namespace UnitTestProject1 {

    [TestClass]
    public class LessTests {

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-saturate</cref>
        /// </see>
        [TestMethod]
        public void Saturate() {

            IColor input = ColorUtils.Parse("hsl(90, 80%, 50%)");

            IColor result = input.Saturate(20);

            Assert.AreEqual("#80ff00", result.ToHex());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-desaturate</cref>
        /// </see>
        [TestMethod]
        public void Desaturate() {

            IColor input = ColorUtils.Parse("hsl(90, 80%, 50%)");

            IColor result = input.Desaturate(20);

            Assert.AreEqual("#80cc33", result.ToHex());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-lighten</cref>
        /// </see>
        [TestMethod]
        public void Lighten() {

            IColor input = ColorUtils.Parse("hsl(90, 80%, 50%)");

            IColor result = input.Lighten(20);

            Assert.AreEqual("#b3f075", result.ToHex());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-darken</cref>
        /// </see>
        [TestMethod]
        public void Darken() {

            IColor input = ColorUtils.Parse("hsl(90, 80%, 50%)");

            IColor result = input.Darken(20);

            Assert.AreEqual("#4d8a0f", result.ToHex());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-fadein</cref>
        /// </see>
        [TestMethod]
        public void FadeIn() {

            IColor input = ColorUtils.Parse("hsla(90, 90%, 50%, 0.5)");

            IColor result = input.FadeIn(10).ToRgb();

            Assert.AreEqual("rgba(128, 242, 13, 0.6)", result.ToCss());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-fadeout</cref>
        /// </see>
        [TestMethod]
        public void FadeOut() {

            IColor input = ColorUtils.Parse("hsla(90, 90%, 50%, 0.5)");

            IColor result = input.FadeOut(10).ToRgb();

            Assert.AreEqual("rgba(128, 242, 13, 0.4)", result.ToCss());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-fade</cref>
        /// </see>
        [TestMethod]
        public void Fade() {

            IColor input = ColorUtils.Parse("hsl(90, 90%, 50%)");

            IColor result = input.Fade(10).ToRgb();

            Assert.AreEqual("rgba(128, 242, 13, 0.1)", result.ToCss());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-spin</cref>
        /// </see>
        [TestMethod]
        public void Spin() {

            IColor input = ColorUtils.Parse("hsl(10, 90%, 50%)");

            IColor result1 = input.Spin(+30);
            IColor result2 = input.Spin(-30);

            Assert.AreEqual("#f2a60d", result1.ToHex());
            Assert.AreEqual("#f20d59", result2.ToHex());

        }

        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-greyscale</cref>
        /// </see>
        [TestMethod]
        public void Greyscale() {

            IColor input = ColorUtils.Parse("hsl(90, 90%, 50%)");

            IColor result = input.Greyscale();

            Assert.AreEqual("#808080", result.ToHex());

        }

    }

}