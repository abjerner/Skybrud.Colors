using System;

namespace Skybrud.Colors
{

    /// <summary>
    /// Static helper methods for various color calculations.
    /// </summary>
    [Obsolete("Use 'ColorUtils'")]
    public static class ColorHelpers
    {
        #region Misc
        /// <summary>
        /// Returns the maximum value of <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The maximum value.</returns>
        [Obsolete("Use 'ColorUtils.Max()'")]
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
        [Obsolete("Use 'ColorUtils.Min()'")]
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
        [Obsolete("Use 'ColorUtils.Max()'")]
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
        [Obsolete("Use 'ColorUtils.Min()'")]
        public static float Min(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
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
        [Obsolete("Use 'ColorUtils()'")]
        public static void RgbToHslFloat(byte red, byte green, byte blue, out float hue, out float saturation, out float lightness)
        {
            ColorUtils.RgbToHslFloat(red, green, blue, out hue, out saturation, out lightness);
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
        [Obsolete("Use 'ColorUtils()'")]
        public static void RgbToHsl(byte red, byte green, byte blue, out double hue, out double saturation, out double lightness)
        {
            ColorUtils.RgbToHsl(red, green, blue, out hue, out saturation, out lightness);
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
        [Obsolete("Use 'ColorUtils.HslToRgb()'")]
        public static void HslToRgb(double hue, double saturation, double lightness, out int red, out int green, out int blue)
        {
             ColorUtils.HslToRgb(new HslColor(hue, saturation, lightness), out red,out green,out blue);
        }

        /// <summary>
        /// Converts the specified <see cref="HslColor"/> to a RGB color.
        /// </summary>
        /// <param name="hsl">The instance of <see cref="HslColor"/> to be converted.</param>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        [Obsolete("Use 'ColorUtils.HslToRgb()'")]
        public static void HslToRgb(HslColor hsl, out int red, out int green, out int blue)
        {
            ColorUtils.HslToRgb(hsl, out red, out green, out blue);
        }

        /// <summary>
        /// Converts an instance of <see cref="HslColor"/> to an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="hsl">The <see cref="HslColor"/> to be converted.</param>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        [Obsolete("Use 'ColorUtils.HslToRgb()'")]
        public static RgbColor HslToRgb(HslColor hsl)
        {
            return ColorUtils.HslToRgb(hsl);
        }
        
        #endregion

        #region Parsing Moved to ColorUtils

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="IColor"/>.
        /// </summary>
        /// <param name="str">The input string to be parsed.</param>
        /// <returns>An instance of <see cref="IColor"/>.</returns>
        [Obsolete("Use 'ColorUtils.Parse()'")]
        public static IColor Parse(string str)
        {
            return ColorUtils.Parse(str);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="IColor"/>.
        /// </summary>
        /// <param name="str">The input string to be parsed.</param>
        /// <param name="color">An instance of <see cref="IColor"/>.</param>
        /// <returns><c>true</c> if <paramref name="str"/> was converted successfully; otherwise, <c>false</c>.</returns>
        [Obsolete("Use 'ColorUtils.TryParse()'")]
        public static bool TryParse(string str, out IColor color)
        {
            return ColorUtils.TryParse(str, out color);
        }

        #endregion
    }

}