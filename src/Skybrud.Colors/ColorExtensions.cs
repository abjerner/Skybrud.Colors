using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Skybrud.Colors {

    /// <summary>
    /// Various extensions methods for <see cref="IColor"/>.
    /// </summary>
    public static class ColorExtensions {

        /// <summary>
        /// Increases the saturation of a color in the HSL color space by an absolute amount.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">A percentage.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Saturate(this IColor color, [ValueRange(0, 100)] float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Increase the saturation by the specified percent
            double saturation = hsl.Saturation + percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, Math.Min(1, saturation), hsl.Lightness, hsl.Alpha);

        }

        /// <summary>
        /// Decreases the saturation of a color in the HSL color space by an absolute amount.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">A percentage.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Desaturate(this IColor color, [ValueRange(0, 100)] float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Decrease the saturation by the specified percent
            double saturation = hsl.Saturation - percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, Math.Max(0, saturation), hsl.Lightness, hsl.Alpha);

        }

        /// <summary>
        /// Increases the darkness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">The amount of darkness (specified in percent) that should be added to the color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Darken(this IColor color, [ValueRange(0, 100)] float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Increase the darkness by the specified percent
            double lightness = hsl.Lightness - percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, hsl.Saturation, Math.Min(1, lightness), hsl.Alpha);

        }

        /// <summary>
        /// Increases the lightness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">The amount of lightness (specified in percent) that should be added to the color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Lighten(this IColor color, [ValueRange(0, 100)] float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Increase the lightness by the specified percent
            double lightness = hsl.Lightness + percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, hsl.Saturation, Math.Max(0, lightness), hsl.Alpha);

        }

        /// <summary>
        /// Returns the inverted color.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Invert(this IColor color) {
            RgbColor rgb = color as RgbColor ?? color.ToRgb();
            return new RgbColor(~rgb.Red, ~rgb.Green, ~rgb.Blue, rgb.Alpha);
        }

        /// <summary>
        /// Rotate the hue angle of the specified <paramref name="color"/>.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="degrees">The amount of degrees to rotate.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        /// <see>
        ///     <cref>https://lesscss.org/functions/#color-operations-spin</cref>
        /// </see>
        public static IColor Spin(this IColor color, int degrees) {

            // Make sure we have the color as HSL
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Convert from decimal to degrees and add the specified degrees
            double hueeeee = hsl.Hue * 360 + degrees;

            // Handle overflow and underflow
            while (hueeeee > 360) hueeeee -= 360;
            while (hueeeee < 0) hueeeee += 360;

            // Convert back to decimals
            double hueDecimals = hueeeee / 360d;

            // Return the result
            return new HslColor(hueDecimals, hsl.Saturation, hsl.Lightness, hsl.Alpha);

        }

        /// <summary>
        /// Removes all saturation from a color in the HSL color space.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Greyscale(this IColor color) {
            return Desaturate(color, 100);
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of <see cref="CmyColor"/>.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <returns>A collection of <see cref="CmyColor"/>.</returns>
        public static IEnumerable<CmyColor> ToCmy(this IEnumerable<IColor> colors) {
            return colors.Select(x => x.ToCmy());
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of <see cref="CmykColor"/>.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <returns>A collection of <see cref="CmykColor"/>.</returns>
        public static IEnumerable<CmykColor> ToCmyk(this IEnumerable<IColor> colors) {
            return colors.Select(x => x.ToCmyk());
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of <see cref="HslColor"/>.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <returns>A collection of <see cref="HslColor"/>.</returns>
        public static IEnumerable<HslColor> ToHsl(this IEnumerable<IColor> colors) {
            return colors.Select(x => x.ToHsl());
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of <see cref="HsvColor"/>.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <returns>A collection of <see cref="HsvColor"/>.</returns>
        public static IEnumerable<HsvColor> ToHsv(this IEnumerable<IColor> colors) {
            return colors.Select(x => x.ToHsv());
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <returns>A collection of <see cref="RgbColor"/>.</returns>
        public static IEnumerable<RgbColor> ToRgb(this IEnumerable<IColor> colors) {
            return colors.Select(x => x.ToRgb());
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of HEX colors.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <returns>A collection of the HEX colors.</returns>
        public static IEnumerable<string> ToHex(this IEnumerable<IColor> colors) {
            return colors.Select(color => color.ToHex());
        }

        /// <summary>
        /// Converts the specified collection of <paramref name="colors"/> to a corresponding collection of HEX colors,
        /// according to <paramref name="format"/>.
        /// </summary>
        /// <param name="colors">The colors to be converted.</param>
        /// <param name="format">The HEX format.</param>
        /// <returns>A collection of the HEX colors.</returns>
        public static IEnumerable<string> ToHex(this IEnumerable<IColor> colors, HexFormat format) {
            return colors.Select(color => color.ToHex(format));
        }

    }

}