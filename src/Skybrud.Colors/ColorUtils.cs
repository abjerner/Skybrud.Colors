using System;

namespace Skybrud.Colors {

    /// <summary>
    /// Utility class with static methods for various color calculations.
    /// </summary>
    public static class ColorUtils {

        #region Misc

        /// <summary>
        /// Returns the maximum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The maximum value.</returns>
        public static double Max(double a, double b, double c) {
            return Math.Max(a, Math.Max(b, c));
        }

        /// <summary>
        /// Returns the minimum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The minimum value.</returns>
        public static double Min(double a, double b, double c) {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Returns the maximum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The maximum value.</returns>
        public static float Max(float a, float b, float c) {
            return Math.Max(a, Math.Max(b, c));
        }

        /// <summary>
        /// Returns the minimum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The minimum value.</returns>
        public static float Min(float a, float b, float c) {
            return Math.Min(a, Math.Min(b, c));
        }

        #endregion

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

        #region RGB -> HSL

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        public static void RgbToHsl(byte red, byte green, byte blue, out double hue, out double saturation, out double lightness) {
            int r = red;
            int g = green;
            int b = blue;
            RgbToHsl(r, g, b, out hue, out saturation, out lightness);
        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        public static void RgbToHsl(int red, int green, int blue, out double hue, out double saturation, out double lightness) {

            // Convert to values from 0-1 (linear)
            double r = red / 255d;
            double g = green / 255d;
            double b = blue / 255d;

            // Get the maximum and minimum values
            double max = Max(r, g, b);
            double min = Min(r, g, b);

            // Calculate the lightness
            lightness = (max + min) / 2d;

            // Calculate the saturation
            saturation = 0;
            if (Math.Abs(max - min) > Double.Epsilon) {
                if (lightness < 0.5) {
                    saturation = (max - min) / (max + min);
                } else {
                    saturation = (max - min) / (2.0d - max - min);
                }
            }

            // Calculate the hue
            hue = 0;
            if (Math.Abs(r - max) < Double.Epsilon) {
                hue = (g - b) / (max - min);
            } else if (Math.Abs(g - max) < Double.Epsilon) {
                hue = 2.0d + (b - r) / (max - min);
            } else if (Math.Abs(b - max) < Double.Epsilon) {
                hue = 4.0d + (r - g) / (max - min);
            }

            // Convert the hue to degrees
            hue = hue * 60;

            // Make sure hue is a positive number
            if (hue < 0.0) hue += 360;

            // Convert the hue back to a decimal
            hue = hue / 360.0;

            // Make sure hue is not NaN
            if (Double.IsNaN(hue)) hue = 0;

        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <returns>An instance of <see cref="HslColor"/> representing the </returns>
        public static HslColor RgbToHsl(int red, int green, int blue) {
            RgbToHsl(red, green, blue, out double h, out double s, out double l);
            return new HslColor(h, s, l);
        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <returns>An instance of <see cref="HslColor"/> representing the </returns>
        public static HslColor RgbToHsl(RgbColor rgb) {
            RgbToHsl(rgb.Red, rgb.Green, rgb.Blue, out double h, out double s, out double l);
            return new HslColor(h, s, l);
        }

        #endregion

    }

}