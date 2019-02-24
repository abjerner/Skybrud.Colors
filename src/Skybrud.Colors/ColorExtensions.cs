using System;

namespace Skybrud.Colors {

    public static class ColorExtensions {

        /// <summary>
        /// Increases the saturation of a color in the HSL color space by an absolute amount.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">A percentage.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Saturate(this IColor color, float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Increase the saturation by the specified percent
            double saturation = hsl.Saturation + percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, Math.Min(1, saturation), hsl.Lightness);

        }

        /// <summary>
        /// Decreases the saturation of a color in the HSL color space by an absolute amount.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">A percentage.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Desaturate(this IColor color, float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Decrease the saturation by the specified percent
            double saturation = hsl.Saturation - percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, Math.Max(0, saturation), hsl.Lightness);

        }

        /// <summary>
        /// Increases the darkness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">The amount of darkness (specified in percent) that should be added to the color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Darken(this IColor color, float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Increase the darkness by the specified percent
            double lightness = hsl.Lightness - percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, hsl.Saturation, Math.Min(1, lightness));

        }

        /// <summary>
        /// Increases the lightness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <param name="percent">The amount of lightness (specified in percent) that should be added to the color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Lighten(this IColor color, float percent) {

            // Make sure that the color is in the HSL color space
            HslColor hsl = color as HslColor ?? color.ToHsl();

            // Increase the lightness by the specified percent
            double lightness = hsl.Lightness + percent / 100f;

            // Return a new HSL color
            return new HslColor(hsl.Hue, hsl.Saturation, Math.Max(0, lightness));

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
        /// Removes all saturation from a color in the HSL color space.
        /// </summary>
        /// <param name="color">The input color.</param>
        /// <returns>An instance of <see cref="IColor"/> representing the output color.</returns>
        public static IColor Greyscale(this RgbColor color) {
            return Desaturate(color, 100);
        }

    }

}