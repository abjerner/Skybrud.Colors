using System;

namespace Skybrud.Colors.Wcag;

/// <summary>
/// Static helper class for various WCAG calculations.
/// </summary>
[Obsolete("Use 'WcagUtils' class instead.")]
public class WcagHelpers {

    /// <summary>
    /// Calculates the relative luminance of a given <paramref name="color"/> as specified by the WCAG 2.0 specification.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>The relative luminance.</returns>
    /// <see>
    ///     <cref>https://www.w3.org/TR/WCAG20/#relativeluminancedef</cref>
    /// </see>
    [Obsolete("Use 'WcagUtils.GetRelativeLuminance' method instead.")]
    public static double GetRelativeLuminance(RgbColor color) {

        // Get the RGB as values from 0-1
        double[] rgb = {
            color.R / 255d,
            color.G / 255d,
            color.B / 255d
        };

        // Because it says so on the website :D
        for (int i = 0; i < rgb.Length; i++) {
            if (rgb[i] <= 0.03928) {
                rgb[i] = rgb[i] / 12.92;
            } else {
                rgb[i] = Math.Pow(((rgb[i] + 0.055) / 1.055), 2.4);
            }
        }

        // Calculate and return the relative luminance
        return (rgb[0] * 0.2126) + (rgb[1] * 0.7152) + (rgb[2] * 0.0722);

    }

    /// <summary>
    /// Calculates the constrast ratio of to given colors as specified by the WCAG 2.0 specification.
    /// </summary>
    /// <param name="color1">The first color.</param>
    /// <param name="color2">The second color.</param>
    /// <returns>The constrast ratio.</returns>
    /// <see>
    ///     <cref>https://www.w3.org/TR/WCAG20/#contrast-ratiodef</cref>
    /// </see>
    [Obsolete("Use 'WcagUtils.GetContrastRatio' method instead.")]
    public static double GetContrastRatio(RgbColor color1, RgbColor color2) {

        // Calulate the relative lumancy of both colors
        double l1 = GetRelativeLuminance(color1);
        double l2 = GetRelativeLuminance(color2);

        // Calculate the ratio
        double ratio = (l1 + 0.05) / (l2 + 0.05);

        // Invert the ratio if necessary
        if (l2 > l1) ratio = 1 / ratio;

        // Calucate and return the contrast ratio
        return ratio;

    }

}