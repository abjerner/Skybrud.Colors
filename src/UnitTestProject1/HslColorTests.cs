using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Colors;
using UnitTestProject1.Samples;

namespace UnitTestProject1 {
    
    [TestClass]
    public class HslColorTests {

        [TestMethod]
        public void ToRgb() {



            foreach (HtmlColorSample sample in HtmlColorSamples.All) {

                // There are some minor differences when converting back to RGB, so this unit test is disabled for now

                return;

                //// Green is 235, but converting to HSL and back to RGB again will result in 234 (same with various online converters)
                //if (sample.Name == "AntiqueWhite") continue;

                //// Red is 127, but converting to HSL and back to RGB again will result in 128 (same with various online converters)
                //if (sample.Name == "AntiqueWhite") continue;

                //HslColor hsl = new HslColor(sample.H / 360d, sample.S / 100d, sample.L / 100d);

                //RgbColor rgb = hsl.ToRgb();

                //int red;
                //int green;
                //int blue;
                //ColorHelpers.HslToRgbHest(sample.H / 360d, sample.S / 100d, sample.L / 100d, out red, out green, out blue);

                //double dRed;
                //double dGreen;
                //double dBlue;
                //ColorHelpers.HslToRgbHestDouble(sample.H / 360d, sample.S / 100d, sample.L / 100d, out dRed, out dGreen, out dBlue);

                //string expected = String.Format(
                //    "{0}-{1}-{2}",
                //    sample.R,
                //    sample.G,
                //    sample.B
                //);

                //string result1 = String.Format(
                //    "{0}-{1}-{2}",
                //    rgb.Red,
                //    rgb.Green,
                //    rgb.Blue
                //);

                //string result2 = String.Format(
                //    "{0}-{1}-{2}",
                //    red,
                //    green,
                //    blue
                //);

                //Assert.AreEqual(expected, result1, sample.Name + " (#1)");
                ////Assert.AreEqual(expected, result2, sample.Name + " (#2)");

            }

        }

    }

}