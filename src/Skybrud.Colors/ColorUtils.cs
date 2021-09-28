namespace Skybrud.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Utility class with static methods for various color calculations.
    /// </summary>
    public static class ColorUtils
    {

        #region Misc

        /// <summary>
        /// Returns the maximum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The maximum value.</returns>
        public static double Max(double a, double b, double c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        /// <summary>
        /// Returns the minimum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The minimum value.</returns>
        public static double Min(double a, double b, double c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Returns the maximum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The maximum value.</returns>
        public static float Max(float a, float b, float c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        /// <summary>
        /// Returns the minimum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The minimum value.</returns>
        public static float Min(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Calculates the color compoment for when converting a HSL color to a RGB color.
        /// </summary>
        /// <param name="temp1"></param>
        /// <param name="temp2"></param>
        /// <param name="temp3"></param>
        /// <returns>The color component.</returns>
        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {

            // TODO: Needs documentation/references

            temp3 = MoveIntoRange(temp3);
            if (temp3 < 1.0 / 6.0) return temp1 + (temp2 - temp1) * 6.0 * temp3;
            if (temp3 < 0.5) return temp2;
            if (temp3 < 2.0 / 3.0) return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            return temp1;

        }

        /// <summary>
        /// Method used internally for when converting a HSL color to a RGB color.
        /// </summary>
        private static double MoveIntoRange(double temp3)
        {

            // TODO: Needs documentation/references

            if (temp3 < 0.0)
            {
                temp3 += 1.0;
            }
            else if (temp3 > 1.0)
            {
                temp3 -= 1.0;
            }

            return temp3;

        }

        /// <summary>
        /// Method used internally for when converting a HSL color to a RGB color.
        /// </summary>
        private static double GetTemp2(double saturation, double lightness)
        {

            // TODO: Needs documentation/references

            double temp2;

            if (lightness < 0.5)
            {
                temp2 = lightness * (1.0 + saturation);
            }
            else
            {
                temp2 = lightness + saturation - (lightness * saturation);
            }

            return temp2;

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
        public static void CmyToCmyk(double cyan, double magenta, double yellow, out double c, out double m, out double y, out double k)
        {

            double key = 1;

            if (cyan < key) key = cyan;
            if (magenta < key) key = magenta;
            if (yellow < key) key = yellow;

            if (Math.Abs(key - 1d) < Double.Epsilon)
            {
                c = 0;
                m = 0;
                y = 0;
            }
            else
            {
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
        public static CmykColor CmyToCmyk(double cyan, double magenta, double yellow)
        {
            CmyToCmyk(cyan, magenta, yellow, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        /// <summary>
        /// Converts a <strong>CMY</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="cmy">The CMY color.</param>
        /// <returns>An instance of <see cref="CmykColor"/> representing the CMYK color.</returns>
        public static CmykColor CmyToCmyk(CmyColor cmy)
        {
            CmyToCmyk(cmy.Cyan, cmy.Magenta, cmy.Yellow, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        #endregion

        #region CMY -> RGB

        public static void CmyToRgb(double cyan, double magenta, double yellow, out byte r, out byte g, out byte b)
        {
            r = Convert.ToByte((1 - cyan) * 255d);
            g = Convert.ToByte((1 - magenta) * 255d);
            b = Convert.ToByte((1 - yellow) * 255d);
        }

        public static RgbColor CmyToRgb(double cyan, double magenta, double yellow)
        {
            byte r = Convert.ToByte((1 - cyan) * 255d);
            byte g = Convert.ToByte((1 - magenta) * 255d);
            byte b = Convert.ToByte((1 - yellow) * 255d);
            return new RgbColor(r, g, b);
        }

        public static RgbColor CmyToRgb(CmyColor cmy)
        {
            return CmyToRgb(cmy.Cyan, cmy.Magenta, cmy.Yellow);
        }

        #endregion

        #region CMYK -> CMY

        /// <summary>
        /// Converts a <strong>CMYK</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="cyan">The cyan in the CMYK color.</param>
        /// <param name="magenta">The magenta in the CMYK color.</param>
        /// <param name="yellow">The yellow in the CMYK color.</param>
        /// <param name="key">The key in the CMYK color.</param>
        /// <param name="c">The cyan in the CMY color.</param>
        /// <param name="m">The magenta in the CMY color.</param>
        /// <param name="y">The yellow in the CMY color.</param>
        public static void CmykToCmy(double cyan, double magenta, double yellow, double key, out double c, out double m, out double y)
        {
            c = cyan * (1 - key) + key;
            m = magenta * (1 - key) + key;
            y = yellow * (1 - key) + key;
        }

        /// <summary>
        /// Converts a <strong>CMYK</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="cyan">The cyan in the CMYK color.</param>
        /// <param name="magenta">The magenta in the CMYK color.</param>
        /// <param name="yellow">The yellow in the CMYK color.</param>
        /// <param name="key">The key in the CMYK color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the CMY color.</returns>
        public static CmyColor CmykToCmy(double cyan, double magenta, double yellow, double key)
        {
            CmykToCmy(cyan, magenta, yellow, key, out double c, out double m, out double y);
            return new CmyColor(c, m, y);
        }

        /// <summary>
        /// Converts a <strong>CMYK</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="cmyk">The CMYK color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the CMY color.</returns>
        public static CmyColor CmykToCmy(CmykColor cmyk)
        {
            CmykToCmy(cmyk.Cyan, cmyk.Magenta, cmyk.Yellow, cmyk.Key, out double c, out double m, out double y);
            return new CmyColor(c, m, y);
        }

        #endregion

        #region CMYK -> RGB

        public static void CmykToRgb(double cyan, double magenta, double yellow, double key, out byte r, out byte g, out byte b)
        {
            CmykToCmy(cyan, magenta, yellow, key, out double c, out double m, out double y);
            CmyToRgb(c, m, y, out r, out g, out b);
        }

        public static RgbColor CmykToRgb(double cyan, double magenta, double yellow, double key)
        {
            CmykToCmy(cyan, magenta, yellow, key, out double c, out double m, out double y);
            CmyToRgb(c, m, y, out byte r, out byte g, out byte b);
            return new RgbColor(r, g, b);
        }

        public static RgbColor CmykToRgb(CmykColor cmyk)
        {
            return CmykToRgb(cmyk.Cyan, cmyk.Magenta, cmyk.Yellow, cmyk.Key);
        }

        #endregion

        #region HSL -> CMY

        /// <summary>
        /// Converts a <strong>HSL</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/> to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSL color.</param>
        /// <param name="saturation">The saturation of the HSL color.</param>
        /// <param name="lightness">The lightness of the HSL color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        public static void HslToCmy(double hue, double saturation, double lightness, out double c, out double m, out double y)
        {
            HslToRgb(hue, saturation, lightness, out int r, out int g, out int b);
            RgbToCmy(r, g, b, out c, out m, out y);
        }

        /// <summary>
        /// Converts a <strong>HSL</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/> to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSL color.</param>
        /// <param name="saturation">The saturation of the HSL color.</param>
        /// <param name="lightness">The lightness of the HSL color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmyColor HslToCmy(double hue, double saturation, double lightness)
        {
            HslToRgb(hue, saturation, lightness, out int r, out int g, out int b);
            RgbToCmy(r, g, b, out double c, out double m, out double y);
            return new CmyColor(c, m, y);
        }

        /// <summary>
        /// Converts a <strong>HSL</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="hsl">The HSL color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmyColor HslToCmy(HslColor hsl)
        {
            HslToRgb(hsl.Hue, hsl.Saturation, hsl.Lightness, out int r, out int g, out int b);
            RgbToCmy(r, g, b, out double c, out double m, out double y);
            return new CmyColor(c, m, y);
        }

        #endregion

        #region HSL -> CMYK

        /// <summary>
        /// Converts a <strong>HSL</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/> to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSL color.</param>
        /// <param name="saturation">The saturation of the HSL color.</param>
        /// <param name="lightness">The lightness of the HSL color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        /// <param name="k">The key of the CMY color.</param>
        public static void HslToCmyk(double hue, double saturation, double lightness, out double c, out double m, out double y, out double k)
        {
            HslToRgb(hue, saturation, lightness, out int r, out int g, out int b);
            RgbToCmyk(r, g, b, out c, out m, out y, out k);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/> to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSL color.</param>
        /// <param name="saturation">The saturation of the HSL color.</param>
        /// <param name="lightness">The lightness of the HSL color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmykColor HslToCmyk(double hue, double saturation, double lightness)
        {
            HslToRgb(hue, saturation, lightness, out int r, out int g, out int b);
            RgbToCmyk(r, g, b, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        /// <summary>
        /// Converts a <strong>HSL</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="hsl">The HSL color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmykColor HslToCmyk(HslColor hsl)
        {
            HslToRgb(hsl.Hue, hsl.Saturation, hsl.Lightness, out int r, out int g, out int b);
            RgbToCmyk(r, g, b, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        #endregion

        #region HSL -> HSV

        /// <summary>
        /// Converts a <strong>HSL</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/> to the corresponding <strong>HSV</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSL color.</param>
        /// <param name="saturation">The saturation of the HSL color.</param>
        /// <param name="lightness">The lightness of the HSL color.</param>
        /// <param name="h">The hue of the HSV color.</param>
        /// <param name="s">The saturation of the HSV color.</param>
        /// <param name="v">The value of the HSV color.</param>
        public static void HslToHsv(double hue, double saturation, double lightness, out double h, out double s, out double v)
        {

            // TODO: Needs documentation/references

            h = hue;
            lightness = lightness * 2;
            saturation = saturation * (lightness <= 1d ? lightness : 2d - lightness);
            v = (lightness + saturation) / 2d;
            s = (2d * saturation) / (lightness + saturation);

            if (Double.IsNaN(s)) s = 0;

        }

        /// <summary>
        /// Converts a <strong>HSL</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/> to the corresponding <strong>HSV</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSL color.</param>
        /// <param name="saturation">The saturation of the HSL color.</param>
        /// <param name="lightness">The lightness of the HSL color.</param>
        /// <returns>An instance of <see cref="HsvColor"/> representing the HSV color.</returns>
        public static HsvColor HslToHsv(double hue, double saturation, double lightness)
        {
            HslToHsv(hue, saturation, lightness, out double h, out double s, out double v);
            return new HsvColor(h, s, v);
        }

        /// <summary>
        /// Converts a <strong>HSL</strong> color to the corresponding <strong>HSV</strong> color.
        /// </summary>
        /// <param name="hsl">The HSL color.</param>
        /// <returns>An instance of <see cref="HsvColor"/> representing the HSV color.</returns>
        public static HsvColor HslToHsv(HslColor hsl)
        {
            HslToHsv(hsl.Hue, hsl.Saturation, hsl.Lightness, out double h, out double s, out double v);
            return new HsvColor(h, s, v);
        }

        #endregion

        #region HSL -> RGB

        /// <summary>
        /// Converts an HSL color to a RGB color.
        /// </summary>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        public static void HslToRgb(double hue, double saturation, double lightness, out int red, out int green, out int blue)
        {

            // TODO: Needs documentation/references

            double r = 0, g = 0, b = 0;
            if (Math.Abs(lightness) > Double.Epsilon)
            {
                if (Math.Abs(saturation) < Double.Epsilon)
                {
                    r = g = b = lightness;
                }
                else
                {
                    double temp2 = GetTemp2(saturation, lightness);
                    double temp1 = 2.0 * lightness - temp2;
                    r = GetColorComponent(temp1, temp2, hue + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, hue);
                    b = GetColorComponent(temp1, temp2, hue - 1.0 / 3.0);
                }
            }

            // Convert from 0-1 to 0-255
            red = (int)Math.Round(r * 255);
            green = (int)Math.Round(g * 255);
            blue = (int)Math.Round(b * 255);

        }

        /// <summary>
        /// Converts an HSL color to a RGB color.
        /// </summary>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        /// <returns>An instance of <see cref="RgbColor"/> representing the RGB color.</returns>
        public static RgbColor HslToRgb(double hue, double saturation, double lightness)
        {
            HslToRgb(hue, saturation, lightness, out int red, out int green, out int blue);
            return new RgbColor(red, green, blue);
        }

        /// <summary>
        /// Converts the specified <see cref="HslColor"/> to a RGB color.
        /// </summary>
        /// <param name="hsl">The instance of <see cref="HslColor"/> to be converted.</param>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        public static void HslToRgb(HslColor hsl, out int red, out int green, out int blue)
        {
            HslToRgb(hsl.Hue, hsl.Saturation, hsl.Lightness, out red, out green, out blue);
        }

        /// <summary>
        /// Converts an instance of <see cref="HslColor"/> to an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="hsl">The <see cref="HslColor"/> to be converted.</param>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public static RgbColor HslToRgb(HslColor hsl)
        {
            return HslToRgb(hsl.Hue, hsl.Saturation, hsl.Lightness);
        }

        #endregion

        #region HSL -> RGBA

        /// <summary>
        /// Converts an HSL color to a RGB color.
        /// </summary>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        /// <param name="red">The amount of red in the RGBA color.</param>
        /// <param name="green">The amount of green in the RGBA color.</param>
        /// <param name="blue">The amount of blue in the RGBA color.</param>
        /// <param name="alpha">The amount of opacity in the RGBA color.</param>
        public static void HslToRgba(double hue, double saturation, double lightness, out int red, out int green, out int blue, out float alpha)
        {
            HslToRgb(hue, saturation, lightness, out red, out green, out blue);
            alpha = 1;
        }

        /// <summary>
        /// Converts an HSL color to a RGBA color.
        /// </summary>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        /// <returns>An instance of <see cref="RgbaColor"/> representing the RGBA color.</returns>
        public static RgbaColor HslToRgba(double hue, double saturation, double lightness)
        {
            HslToRgba(hue, saturation, lightness, out int red, out int green, out int blue, out float alpha);
            return new RgbaColor(red, green, blue, alpha);
        }

        /// <summary>
        /// Converts the specified <see cref="HslColor"/> to a RGBA color.
        /// </summary>
        /// <param name="hsl">The instance of <see cref="HslColor"/> to be converted.</param>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <param name="alpha">The amount of opacity in the RGBA color.</param>
        public static void HslToRgba(HslColor hsl, out int red, out int green, out int blue, out float alpha)
        {
            HslToRgba(hsl.Hue, hsl.Saturation, hsl.Lightness, out red, out green, out blue, out alpha);
        }

        /// <summary>
        /// Converts an instance of <see cref="HslColor"/> to an instance of <see cref="RgbaColor"/>.
        /// </summary>
        /// <param name="hsl">The <see cref="HslColor"/> to be converted.</param>
        /// <returns>An instance of <see cref="RgbaColor"/>.</returns>
        public static RgbaColor HslToRgba(HslColor hsl)
        {
            return HslToRgba(hsl.Hue, hsl.Saturation, hsl.Lightness);
        }

        #endregion

        #region HSV -> CMY

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        public static void HsvToCmy(double hue, double saturation, double value, out double c, out double m, out double y)
        {
            HsvToRgb(hue, saturation, value, out int r, out int g, out int b);
            RgbToCmy(r, g, b, out c, out m, out y);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmyColor HsvToCmy(double hue, double saturation, double value)
        {
            HsvToRgb(hue, saturation, value, out int r, out int g, out int b);
            RgbToCmy(r, g, b, out double c, out double m, out double y);
            return new CmyColor(c, m, y);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="hsv">The HSV color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmyColor HsvToCmy(HsvColor hsv)
        {
            HsvToRgb(hsv.Hue, hsv.Saturation, hsv.Value, out int r, out int g, out int b);
            RgbToCmy(r, g, b, out double c, out double m, out double y);
            return new CmyColor(c, m, y);
        }

        #endregion

        #region HSV -> CMYK

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="c">The cyan of the CMY color.</param>
        /// <param name="m">The magenta of the CMY color.</param>
        /// <param name="y">The yellow of the CMY color.</param>
        /// <param name="k">The key of the CMY color.</param>
        public static void HsvToCmyk(double hue, double saturation, double value, out double c, out double m, out double y, out double k)
        {
            HsvToRgb(hue, saturation, value, out int r, out int g, out int b);
            RgbToCmyk(r, g, b, out c, out m, out y, out k);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmykColor HsvToCmyk(double hue, double saturation, double value)
        {
            HsvToRgb(hue, saturation, value, out int r, out int g, out int b);
            RgbToCmyk(r, g, b, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="hsv">The HSV color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the HSL color.</returns>
        public static CmykColor HsvToCmyk(HsvColor hsv)
        {
            HsvToRgb(hsv.Hue, hsv.Saturation, hsv.Value, out int r, out int g, out int b);
            RgbToCmyk(r, g, b, out double c, out double m, out double y, out double k);
            return new CmykColor(c, m, y, k);
        }

        #endregion

        #region HSV -> HSL

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>HSL</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="h">The hue of the HSL color.</param>
        /// <param name="s">The saturation of the HSL color.</param>
        /// <param name="l">The lightness of the HSL color.</param>
        public static void HsvToHsl(double hue, double saturation, double value, out double h, out double s, out double l)
        {

            // TODO: Needs documentation/references

            h = hue;
            l = (2d - saturation) * value;
            s = saturation * value;
            s = s / ((l <= 1) ? (l) : 2d - (l));

            if (Double.IsNaN(s))
            {
                s = 0;
            }

            l = l / 2f;

        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>HSL</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <returns>An instance of <see cref="HslColor"/> representing the HSL color.</returns>
        public static HslColor HsvToHsl(double hue, double saturation, double value)
        {
            HsvToHsl(hue, saturation, value, out double h, out double s, out double l);
            return new HslColor(h, s, l);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color to the corresponding <strong>HSL</strong> color.
        /// </summary>
        /// <param name="hsv">The HSV color.</param>
        /// <returns>An instance of <see cref="HslColor"/> representing the HSL color.</returns>
        public static HslColor HsvToHsl(HsvColor hsv)
        {
            HsvToHsl(hsv.Hue, hsv.Saturation, hsv.Value, out double h, out double s, out double l);
            return new HslColor(h, s, l);
        }

        #endregion

        #region HSV -> RGB

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        public static void HsvToRgb(double hue, double saturation, double value, out double red, out double green, out double blue)
        {

            // Convert from HSV to HSL
            HsvToHsl(hue, saturation, value, out double hh, out double ss, out double ll);

            // Convert from HSL to RGB
            HslToRgb(hh, ss, ll, out int r, out int g, out int b);
            // TODO: Calculate to "double" instead of "int"

            red = r;
            green = g;
            blue = b;

        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        public static void HsvToRgb(double hue, double saturation, double value, out int red, out int green, out int blue)
        {

            // Convert from HSV to HSL
            HsvToHsl(hue, saturation, value, out double hh, out double ss, out double ll);

            // Convert from HSL to RGB
            HslToRgb(hh, ss, ll, out red, out green, out blue);

        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <returns>An instance of <see cref="RgbColor"/> representing the RGB.</returns>
        public static RgbColor HsvToRgb(double hue, double saturation, double value)
        {
            HsvToRgb(hue, saturation, value, out double red, out double green, out double blue);
            return new RgbColor(red, green, blue);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hsv">The HSV color.</param>
        /// <returns>An instance of <see cref="RgbColor"/> representing the RGB color.</returns>
        public static RgbColor HsvToRgb(HsvColor hsv)
        {
            return HsvToRgb(hsv.Hue, hsv.Saturation, hsv.Value);
        }

        #endregion

        #region HSV -> RGBA

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>RGBA</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="red">The red of the RGBA color.</param>
        /// <param name="green">The green of the RGBA color.</param>
        /// <param name="blue">The blue of the RGBA color.</param>
        /// <param name="alpha">The amount of opacity in the RGBA color.</param>
        public static void HsvToRgba(double hue, double saturation, double value, out double red, out double green, out double blue, out float alpha)
        {

            // Convert from HSV to HSL
            HsvToHsl(hue, saturation, value, out double hh, out double ss, out double ll);

            // Convert from HSL to RGB
            HslToRgba(hh, ss, ll, out int r, out int g, out int b, out alpha);
            // TODO: Calculate to "double" instead of "int"

            red = r;
            green = g;
            blue = b;

        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>RGBA</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <param name="red">The red of the RGBA color.</param>
        /// <param name="green">The green of the RGBA color.</param>
        /// <param name="blue">The blue of the RGBA color.</param>
        /// <param name="alpha">The amount of opacity in the RGBA color.</param>
        public static void HsvToRgba(double hue, double saturation, double value, out int red, out int green, out int blue, out float alpha)
        {

            // Convert from HSV to HSL
            HsvToHsl(hue, saturation, value, out double hh, out double ss, out double ll);

            // Convert from HSL to RGBA
            HslToRgba(hh, ss, ll, out red, out green, out blue, out alpha);

        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/> to the corresponding <strong>RGBA</strong> color.
        /// </summary>
        /// <param name="hue">The hue of the HSV color.</param>
        /// <param name="saturation">The saturation of the HSV color.</param>
        /// <param name="value">The value of the HSV color.</param>
        /// <returns>An instance of <see cref="RgbaColor"/> representing the RGBA color.</returns>
        public static RgbaColor HsvToRgba(double hue, double saturation, double value)
        {
            HsvToRgba(hue, saturation, value, out double red, out double green, out double blue, out float aplha);
            return new RgbaColor(red, green, blue, aplha);
        }

        /// <summary>
        /// Converts a <strong>HSV</strong> color to the corresponding <strong>RGBA</strong> color.
        /// </summary>
        /// <param name="hsv">The HSV color.</param>
        /// <returns>An instance of <see cref="RgbaColor"/> representing the RGB color.</returns>
        public static RgbaColor HsvToRgba(HsvColor hsv)
        {
            return HsvToRgba(hsv.Hue, hsv.Saturation, hsv.Value);
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
        public static void RgbToCmy(int red, int green, int blue, out double c, out double m, out double y)
        {
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
        public static void RgbToCmy(double red, double green, double blue, out double c, out double m, out double y)
        {
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
        public static CmyColor RgbToCmy(double red, double green, double blue)
        {
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
        public static void RgbToCmy(RgbColor rgb, out double c, out double m, out double y)
        {
            RgbToCmy(rgb.Red, rgb.Green, rgb.Blue, out c, out m, out y);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMY</strong> color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <returns>An instance of <see cref="CmyColor"/> representing the CMY color.</returns>
        public static CmyColor RgbToCmy(RgbColor rgb)
        {
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
        public static void RgbToCmyk(int red, int green, int blue, out double c, out double m, out double y, out double k)
        {
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
        public static void RgbToCmyk(double red, double green, double blue, out double c, out double m, out double y, out double k)
        {
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
        public static CmykColor RgbToCmyk(double red, double green, double blue)
        {
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
        public static void RgbToCmyk(RgbColor rgb, out double c, out double m, out double y, out double k)
        {
            RgbToCmyk(rgb.Red, rgb.Green, rgb.Blue, out c, out m, out y, out k);
        }

        /// <summary>
        /// Converts a <strong>RGB</strong> color to the corresponding <strong>CMYK</strong> color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <returns>An instance of <see cref="CmykColor"/> representing the CMYK color.</returns>
        public static CmykColor RgbToCmyk(RgbColor rgb)
        {
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
        public static void RgbToHsl(byte red, byte green, byte blue, out double hue, out double saturation, out double lightness)
        {
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
        public static void RgbToHsl(int red, int green, int blue, out double hue, out double saturation, out double lightness)
        {

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
            if (Math.Abs(max - min) > Double.Epsilon)
            {
                if (lightness < 0.5)
                {
                    saturation = (max - min) / (max + min);
                }
                else
                {
                    saturation = (max - min) / (2.0d - max - min);
                }
            }

            // Calculate the hue
            hue = 0;
            if (Math.Abs(r - max) < Double.Epsilon)
            {
                hue = (g - b) / (max - min);
            }
            else if (Math.Abs(g - max) < Double.Epsilon)
            {
                hue = 2.0d + (b - r) / (max - min);
            }
            else if (Math.Abs(b - max) < Double.Epsilon)
            {
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
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        public static void RgbToHslFloat(byte red, byte green, byte blue, out float hue, out float saturation, out float lightness)
        {

            // Convert to values from 0-1 (linear)
            float r = red / 255f;
            float g = green / 255f;
            float b = blue / 255f;

            // Get the maximum and minimum values
            float max = Max(r, g, b);
            float min = Min(r, g, b);

            // Calculate the lightness
            lightness = (max + min) / 2f;

            // Calculate the saturation
            saturation = 0;
            if (Math.Abs(max - min) > Double.Epsilon)
            {
                if (lightness < 0.5)
                {
                    saturation = (max - min) / (max + min);
                }
                else
                {
                    saturation = (max - min) / (2.0f - max - min);
                }
            }

            // Calculate the hue
            hue = 0;
            if (Math.Abs(r - max) < Double.Epsilon)
            {
                hue = (g - b) / (max - min);
            }
            else if (Math.Abs(g - max) < Double.Epsilon)
            {
                hue = 2.0f + (b - r) / (max - min);
            }
            else if (Math.Abs(b - max) < Double.Epsilon)
            {
                hue = 4.0f + (r - g) / (max - min);
            }

            // Convert the hue to degrees
            hue = hue * 60;

            // Make sure hue is a positive number
            if (hue < 0.0) hue += 360;

            // Convert the hue back to a decimal
            hue = hue / 360f;

            // Make sure hue is not NaN
            if (Single.IsNaN(hue)) hue = 0;

        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <returns>An instance of <see cref="HslColor"/> representing the </returns>
        public static HslColor RgbToHsl(int red, int green, int blue)
        {
            RgbToHsl(red, green, blue, out double h, out double s, out double l);
            return new HslColor(h, s, l);
        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="rgb">The RGB color.</param>
        /// <returns>An instance of <see cref="HslColor"/> representing the </returns>
        public static HslColor RgbToHsl(RgbColor rgb)
        {
            RgbToHsl(rgb.Red, rgb.Green, rgb.Blue, out double h, out double s, out double l);
            return new HslColor(h, s, l);
        }

        #endregion

        #region RGB -> HSV

        public static void RgbToHsv(int red, int green, int blue, out double h, out double s, out double v)
        {
            RgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            HslToHsv(hue, saturation, lightness, out h, out s, out v);
        }

        public static HsvColor RgbToHsv(int red, int green, int blue)
        {
            RgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            HslToHsv(hue, saturation, lightness, out double h, out double s, out double v);
            return new HsvColor(h, s, v);
        }

        public static HsvColor RgbToHsv(RgbColor rgb)
        {
            RgbToHsl(rgb.Red, rgb.Green, rgb.Blue, out double hue, out double saturation, out double lightness);
            HslToHsv(hue, saturation, lightness, out double h, out double s, out double v);
            return new HsvColor(h, s, v);
        }

        #endregion

        #region HEX -> RGB

        /// <summary>
        /// Converts a <strong>HEX</strong> color with the specified <paramref name="hex"/> to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hex">The hex code of the color.</param>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        public static void HexToRgb(string hex, out double red, out double green, out double blue)
        {
            var rgb = HexToRgb(hex);
            red = rgb.Red;
            green = rgb.Green;
            blue = rgb.Blue;
        }

        /// <summary>
        /// Converts a <strong>HEX</strong> color with the specified <paramref name="hex"/> to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hex">The hex code of the color.</param>
        /// <param name="red">The red of the RGB color.</param>
        /// <param name="green">The green of the RGB color.</param>
        /// <param name="blue">The blue of the RGB color.</param>
        public static void HexToRgb(string hex, out int red, out int green, out int blue)
        {
            var rgb = HexToRgb(hex);
            red = rgb.Red;
            green = rgb.Green;
            blue = rgb.Blue;
        }

        /// <summary>
        /// Converts a <strong>HEX</strong> color with the specified <paramref name="hex"/> to the corresponding <strong>RGB</strong> color.
        /// </summary>
        /// <param name="hex">The hex code of the color.</param>
        /// <returns>An instance of <see cref="RgbColor"/> representing the RGB.</returns>
        public static RgbColor HexToRgb(string hex)
        {
            if (String.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException("hex");

            IColor color;
            if (TryParse(hex, out color)) return color as RgbColor;

            throw new FormatException("Not a valid Hexadecimal value.");
        }

        #endregion

        #region Parsing
        //Moved from ColorHelper

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="IColor"/>.
        /// </summary>
        /// <param name="str">The input string to be parsed.</param>
        /// <returns>An instance of <see cref="IColor"/>.</returns>
        public static IColor Parse(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("str");

            IColor color;
            if (TryParse(str, out color)) return color;

            throw new FormatException("Input string was not in a correct format.");

        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="IColor"/>.
        /// </summary>
        /// <param name="str">The input string to be parsed.</param>
        /// <param name="color">An instance of <see cref="IColor"/>.</param>
        /// <returns><c>true</c> if <paramref name="str"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string str, out IColor color)
        {

            color = null;

            // Return "false" if the string is empty
            if (String.IsNullOrWhiteSpace(str)) return false;

            // Strip a leading hashtag and convert to lowercase
            str = str.TrimStart('#').ToLower();

            // Time for some regex :D
            Match m1 = Regex.Match(str, "^([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2})$");
            Match m2 = Regex.Match(str, "^([0-9a-f]{1})([0-9a-f]{1})([0-9a-f]{1})$");

            Match m3 = Regex.Match(str, "^hsl\\(([0-9]+), ([0-9]+)%, ([0-9]+)%\\)$");

            if (m1.Success)
            {
                Byte.TryParse(m1.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte r);
                Byte.TryParse(m1.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte g);
                Byte.TryParse(m1.Groups[3].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte b);
                color = new RgbColor(r, g, b);
                return true;
            }

            if (m2.Success)
            {
                Byte.TryParse(m2.Groups[1].Value + m2.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte r);
                Byte.TryParse(m2.Groups[2].Value + m2.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte g);
                Byte.TryParse(m2.Groups[3].Value + m2.Groups[3].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte b);
                color = new RgbColor(r, g, b);
                return true;
            }

            if (m3.Success)
            {
                float h = Int32.Parse(m3.Groups[1].Value) / 360f;
                float s = Int32.Parse(m3.Groups[2].Value) / 100f;
                float l = Int32.Parse(m3.Groups[3].Value) / 100f;
                color = new HslColor(h, s, l);
                return true;
            }

            return false;

        }

        #endregion

        #region Groups of Colors

        /// <summary>
        /// Returns a list of IColors which represent even gradient steps between two colors.
        /// </summary>
        /// <param name="StartColor"></param>
        /// <param name="EndColor"></param>
        /// <param name="NumberofIntervals">Quantity of IColors to return</param>
        /// <returns>NOTE: The first color returned is identical to the StartColor,
        /// but the last color might not be identical to the EndColor, since the last color is calculated
        /// and rounding in the math used will affect the outcome slightly. </returns>
        public static IEnumerable<IColor> GetGradientColors(IColor StartColor, IColor EndColor, int NumberofIntervals)
        {
            int numberOfIntervals = NumberofIntervals;// - 2; //Start and End colors subtracted from total

            var colors = new List<IColor>();

            var rgb1 = StartColor.ToRgb();
            var rgb2 = EndColor.ToRgb();

            var interval_R = ((int)rgb2.R - (int)rgb1.R) / numberOfIntervals;
            var interval_G = ((int)rgb2.G - (int)rgb1.G) / numberOfIntervals;
            var interval_B = ((int)rgb2.B - (int)rgb1.B) / numberOfIntervals;

            var current_R = (int)rgb1.R;
            var current_G = (int)rgb1.G;
            var current_B = (int)rgb1.B;

            //First add StartColor
            //colors.Add(StartColor);

            for (var i = 1; i <= numberOfIntervals; i++)
            {
             
                var color = new RgbColor(current_R, current_G, current_B);
                colors.Add(color);

                //increment.
                current_R += interval_R;
                current_G += interval_G;
                current_B += interval_B;

            }

            //Finally add EndColor
           // colors.Add(EndColor);

            return colors;
        }

        /// <summary>
        /// Returns a list of Hex colors which represent even gradient steps between two provided Hex colors.
        /// </summary>
        /// <param name="StartColor"></param>
        /// <param name="EndColor"></param>
        /// <param name="NumberofIntervals">Quantity of colors to return</param>
        /// <returns>NOTE: The first color returned is identical to the StartColor,
        /// but the last color might not be identical to the EndColor, since the last color is calculated
        /// and rounding in the math used will affect the outcome slightly. </returns>
        public static IEnumerable<string> GetGradientColorsHexCodes(string StartColor, string EndColor, int NumberofIntervals)
        {
            var hexColors = new List<string>();

            var start = HexToRgb(StartColor);
            var end = HexToRgb(EndColor);

            var rgbColors = GetGradientColors(start, end, NumberofIntervals);

            foreach (var color in rgbColors)
            {
                hexColors.Add(color.ToHex());
            }

            return hexColors;
        }

        #endregion

    }

}