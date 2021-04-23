using System;
using System.Text;
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

            if (color is IAlphaColor) {

                // Make sure that the color is in the HSLA color space
                HslaColor hsla = color as HslaColor ?? color.ToHsla();

                // Increase the saturation by the specified percent
                double saturation = hsla.Saturation + percent / 100f;

                // Return a new HSLA color
                return new HslaColor(hsla.Hue, Math.Min(1, saturation), hsla.Lightness, hsla.Alpha);

            } else {

                // Make sure that the color is in the HSL color space
                HslColor hsl = color as HslColor ?? color.ToHsl();

                // Increase the saturation by the specified percent
                double saturation = hsl.Saturation + percent / 100f;

                // Return a new HSL color
                return new HslColor(hsl.Hue, Math.Min(1, saturation), hsl.Lightness);

            }

        }

        /// <summary>
        /// Decreases the saturation of a color in the HSL color space by an absolute amount.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">A percentage.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Desaturate(this IColor color, [ValueRange(0, 100)] float percent) {

            if (color is IAlphaColor) {

                // Make sure that the color is in the HSLA color space
                HslaColor hsla = color as HslaColor ?? color.ToHsla();

                // Decrease the saturation by the specified percent
                double saturation = hsla.Saturation - percent / 100f;

                // Return a new HSLA color
                return new HslaColor(hsla.Hue, Math.Max(0, saturation), hsla.Lightness, hsla.Alpha);

            } else {

                // Make sure that the color is in the HSL color space
                HslColor hsl = color as HslColor ?? color.ToHsl();

                // Decrease the saturation by the specified percent
                double saturation = hsl.Saturation - percent / 100f;

                // Return a new HSL color
                return new HslColor(hsl.Hue, Math.Max(0, saturation), hsl.Lightness);

            }

        }

        /// <summary>
        /// Increases the darkness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">The amount of darkness (specified in percent) that should be added to the color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Darken(this IColor color, [ValueRange(0, 100)] float percent) {

            if (color is IAlphaColor) {

                // Make sure that the color is in the HSLA color space
                HslaColor hsla = color as HslaColor ?? color.ToHsla();

                // Increase the darkness by the specified percent
                double lightness = hsla.Lightness - percent / 100f;

                // Return a new HSLA color
                return new HslaColor(hsla.Hue, hsla.Saturation, Math.Min(1, lightness), hsla.Alpha);

            } else {

                // Make sure that the color is in the HSL color space
                HslColor hsl = color as HslColor ?? color.ToHsl();

                // Increase the darkness by the specified percent
                double lightness = hsl.Lightness - percent / 100f;

                // Return a new HSL color
                return new HslColor(hsl.Hue, hsl.Saturation, Math.Min(1, lightness));

            }

        }

        /// <summary>
        /// Increases the lightness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">The amount of lightness (specified in percent) that should be added to the color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Lighten(this IColor color, [ValueRange(0, 100)] float percent) {

            if (color is IAlphaColor) {

                // Make sure that the color is in the HSLa color space
                HslaColor hsla = color as HslaColor ?? color.ToHsla();

                // Increase the lightness by the specified percent
                double lightness = hsla.Lightness + percent / 100f;

                // Return a new HSLA color
                return new HslaColor(hsla.Hue, hsla.Saturation, Math.Max(0, lightness), hsla.Alpha);

            } else {

                // Make sure that the color is in the HSL color space
                HslColor hsl = color as HslColor ?? color.ToHsl();

                // Increase the lightness by the specified percent
                double lightness = hsl.Lightness + percent / 100f;

                // Return a new HSL color
                return new HslColor(hsl.Hue, hsl.Saturation, Math.Max(0, lightness));

            }

        }

        /// <summary>
        /// Returns the inverted color.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Invert(this IColor color) {

            switch (color) {

                case IAlphaColor alpha:

                    RgbaColor rgba = alpha as RgbaColor ?? alpha.ToRgba();

                    return new RgbaColor(~rgba.R, ~rgba.G, ~rgba.B, rgba.Alpha);

                default:

                    RgbColor rgb = color as RgbColor ?? color.ToRgb();

                    return new RgbColor(~rgb.Red, ~rgb.Green, ~rgb.Blue);

            }


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
            return new HslColor(hueDecimals, hsl.Saturation, hsl.Lightness);

        }

        /// <summary>
        /// Removes all saturation from a color in the HSL color space.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Greyscale(this IColor color) {
            return Desaturate(color, 100);
        }

    }

}