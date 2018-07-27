using System;

namespace Skybrud.Colors {

    /// <summary>
    /// Utility class with static methods for various color calculations.
    /// </summary>
    public static class ColorUtils {

        #region CMY -> CMYK

        /// <summary>
        /// Converts a <strong>CMY</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="cyan">The cyan in the CMY color.</param>
        /// <param name="magenta">The magenta in the CMY color.</param>
        /// <param name="yellow">The yellow in the CMY color.</param>
        /// <param name="c">The cyan in the CMYM color.</param>
        /// <param name="m">The magenta in the CMYM color.</param>
        /// <param name="y">The yellow in the CMYM color.</param>
        /// <param name="k">The key in the CMYM color.</param>
        public static void CmyToCmyk(double cyan, double magenta, double yellow, out double c, out double m, out double y, out double k) {

            double key = 1;

            if (cyan < key) key = cyan;
            if (magenta < key) key = magenta;
            if (yellow < key) key = yellow;
            
            if (Math.Abs(key - 1d) < Double.Epsilon) {
                c = 0;
                m = 0;
                y = 0;
            } else {
                c = (cyan - key) / (1d - key);
                m = (magenta - key) / (1d - key);
                y = (yellow - key) / (1d - key);
            }
            
            k = key;

        }

        /// <summary>
        /// Converts a <strong>CMY</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="cyan">The cyan in the CMY color.</param>
        /// <param name="magenta">The magenta in the CMY color.</param>
        /// <param name="yellow">The yellow in the CMY color.</param>
        /// <returns>An instance of <see cref="CmykColor"/> representing the CMYK color.</returns>
        public static CmykColor CmyToCmyk(double cyan, double magenta, double yellow) {
            CmyToCmyk(cyan, magenta, yellow, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        #endregion

        #region RGB -> CMY

                /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        public static void RgbToCmy(int red, int green, int blue, out double c, out double m, out double y) {
            c = 1 - (red / 255d);
            m = 1 - (green / 255d);
            y = 1 - (blue / 255d);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        public static void RgbToCmy(double red, double green, double blue, out double c, out double m, out double y) {
            c = 1 - (red / 255d);
            m = 1 - (green / 255d);
            y = 1 - (blue / 255d);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="red">The red in the RGB color.</param>
        /// <param name="green">The green in the RGB color.</param>
        /// <param name="blue">The blue in the RGB color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the CMY color.</returns>
        public static CmyColor RgbToCmy(double red, double green, double blue) {
            double c = 1 - (red / 255d);
            double m = 1 - (green / 255d);
            double y = 1 - (blue / 255d);
            return new CmyColor(c, m, y);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        public static void RgbToCmy(RgbColor rgb, out double c, out double m, out double y) {
            RgbToCmy(rgb.Red, rgb.Green, rgb.Blue, out c, out m, out y);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the CMY color.</returns>
        public static CmyColor RgbToCmy(RgbColor rgb) {
            return RgbToCmy(rgb.Red, rgb.Green, rgb.Blue);
        }

        #endregion

        #region RGB -> CMYK

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        /// <param name="c">The cyan of the CMYK color.</param>
        /// <param name="m">The magenta of the CMYK color.</param>
        /// <param name="y">The yellow of the CMYK color.</param>
        /// <param name="k">The key of the CMYK color.</param>
        public static void RgbToCmyk(int red, int green, int blue, out double c, out double m, out double y, out double k) {
            RgbToCmy(red, green, blue, out double cyan, out double magenta, out double yellow);
            CmyToCmyk(cyan, magenta, yellow, out c, out m, out y, out k);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        /// <param name="c">The cyan of the CMYK color.</param>
        /// <param name="m">The magenta of the CMYK color.</param>
        /// <param name="y">The yellow of the CMYK color.</param>
        /// <param name="k">The key of the CMYK color.</param>
        public static void RgbToCmyk(double red, double green, double blue, out double c, out double m, out double y, out double k) {
            RgbToCmy(red, green, blue, out double cyan, out double magenta, out double yellow);
            CmyToCmyk(cyan, magenta, yellow, out c, out m, out y, out k);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        /// <returns>An instance of <see cref="CmykColor"/> representing the CMYK color.</returns>
        public static CmykColor RgbToCmyk(double red, double green, double blue) {
            RgbToCmy(red, green, blue, out double cyan, out double magenta, out double yellow);
            CmyToCmyk(cyan, magenta, yellow, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <param name="c">The cyan of the CMYK color.</param>
        /// <param name="m">The magenta of the CMYK color.</param>
        /// <param name="y">The yellow of the CMYK color.</param>
        /// <param name="k">The key of the CMYK color.</param>
        public static void RgbToCmyk(RgbColor rgb, out double c, out double m, out double y, out double k) {
            RgbToCmyk(rgb.Red, rgb.Green, rgb.Blue, out c, out m, out y, out k);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <returns>An instance of <see cref="CmykColor"/> representing the CMYK color.</returns>
        public static CmykColor RgbToCmyk(RgbColor rgb) {
            return RgbToCmyk(rgb.Red, rgb.Green, rgb.Blue);
        }

        #endregion

    }

}