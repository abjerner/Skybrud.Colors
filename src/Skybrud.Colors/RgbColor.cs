using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using JetBrains.Annotations;

namespace Skybrud.Colors;

/// <summary>
/// Class representing a color in the <strong>RGB</strong> color model. RGB stands for <em>red</em>,
/// <em>green</em>, and <em>blue</em>.
/// </summary>
/// <see>
///     <cref>https://en.wikipedia.org/wiki/RGB_color_model</cref>
/// </see>
public class RgbColor : ColorBase<RgbColor>, IColorParsable<RgbColor> {

    #region Properties

    /// <summary>
    /// Sets the absolute opacity of a color. Can be applied to colors whether they already have an opacity value or not.
    /// </summary>
    /// <param name="percent">The amount of opacity (specified in percent) that should be set for the color.</param>
    /// <returns>The color resulting from the fade operation.</returns>
    public override RgbColor Fade([ValueRange(0, 100)] double percent) {
        return new RgbColor(Red, Green, Blue, percent / 100d);
    }

    /// <summary>
    /// Gets the amount of red in the color, specified as a value between <c>0</c> and <c>255</c>.
    /// </summary>
    [ValueRange(0, 255)]
    public byte Red { get; set; }

    /// <summary>
    /// Gets the amount of green in the color, specified as a value between <c>0</c> and <c>255</c>.
    /// </summary>
    [ValueRange(0, 255)]
    public byte Green { get; set; }

    /// <summary>
    /// Gets the amount of blue in the color, specified as a value between <c>0</c> and <c>255</c>.
    /// </summary>
    [ValueRange(0, 255)]
    public byte Blue { get; set; }

    /// <summary>
    /// Alias of <see cref="Red"/>.
    /// </summary>
    [ValueRange(0, 255)]
    public byte R => Red;

    /// <summary>
    /// Alias of <see cref="Green"/>.
    /// </summary>
    [ValueRange(0, 255)]
    public byte G => Green;

    /// <summary>
    /// Alias of <see cref="Blue"/>.
    /// </summary>
    [ValueRange(0, 255)]
    public byte B => Blue;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new color with default values.
    /// </summary>
    public RgbColor() { }

    /// <summary>
    /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/>.
    /// </summary>
    /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    public RgbColor([ValueRange(0, 255)] byte red, [ValueRange(0, 255)] byte green, [ValueRange(0, 255)] byte blue) {
        Red = red;
        Green = green;
        Blue = blue;
    }

    /// <summary>
    /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/>, <paramref name="blue"/> and <paramref name="alpha"/>.
    /// </summary>
    /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    public RgbColor([ValueRange(0, 255)] byte red, [ValueRange(0, 255)] byte green, [ValueRange(0, 255)] byte blue, [ValueRange(0, 1)] double alpha) : base(alpha) {
        Red = red;
        Green = green;
        Blue = blue;
    }

    /// <summary>
    /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/>.
    /// </summary>
    /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    public RgbColor([ValueRange(0, 255)] int red, [ValueRange(0, 255)] int green, [ValueRange(0, 255)] int blue) {
        Red = (byte) ColorUtils.Clamp(red, 0, 255);
        Green = (byte) ColorUtils.Clamp(green, 0, 255);
        Blue = (byte) ColorUtils.Clamp(blue, 0, 255);
    }

    /// <summary>
    /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/>, <paramref name="blue"/> and <paramref name="alpha"/>.
    /// </summary>
    /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    public RgbColor([ValueRange(0, 255)] int red, [ValueRange(0, 255)] int green, [ValueRange(0, 255)] int blue, [ValueRange(0, 1)] double alpha) : base(alpha) {
        Red = (byte) ColorUtils.Clamp(red, 0, 255);
        Green = (byte) ColorUtils.Clamp(green, 0, 255);
        Blue = (byte) ColorUtils.Clamp(blue, 0, 255);
    }

    /// <summary>
    /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/>.
    /// </summary>
    /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    public RgbColor([ValueRange(0, 255)] double red, [ValueRange(0, 255)] double green, [ValueRange(0, 255)] double blue) {
        Red = (byte) Math.Round(ColorUtils.Clamp(red, 0, 255));
        Green = (byte) Math.Round(ColorUtils.Clamp(green, 0, 255));
        Blue = (byte) Math.Round(ColorUtils.Clamp(blue, 0, 255));
    }

    /// <summary>
    /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/>, <paramref name="blue"/> and <paramref name="alpha"/>.
    /// </summary>
    /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    public RgbColor([ValueRange(0, 255)] double red, [ValueRange(0, 255)] double green, [ValueRange(0, 255)] double blue, [ValueRange(0, 1)] double alpha) : base(alpha) {
        Red = (byte) Math.Round(ColorUtils.Clamp(red, 0, 255));
        Green = (byte) Math.Round(ColorUtils.Clamp(green, 0, 255));
        Blue = (byte) Math.Round(ColorUtils.Clamp(blue, 0, 255));
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="RgbColor"/> with the same color as specified by the <see cref="Red"/>,
    /// <see cref="Green"/> and <see cref="Blue"/> properties.
    /// </summary>
    /// <returns>A new instance of <see cref="RgbColor"/>.</returns>
    public override RgbColor ToRgb() {
        return new RgbColor(Red, Green, Blue, Alpha);
    }

    /// <summary>
    /// Converts the RGB color to an HSL color.
    /// </summary>
    /// <returns>An instance of <see cref="HslColor"/>.</returns>
    public override HslColor ToHsl() {
        return ColorUtils.RgbToHsl(this);
    }

    /// <summary>
    /// Converts the RGB color to an HSV color.
    /// </summary>
    /// <returns>An instance of <see cref="HsvColor"/>.</returns>
    public override HsvColor ToHsv() {
        return ColorUtils.RgbToHsv(this);
    }

    /// <summary>
    /// Converts the RGB color to a CMY color.
    /// </summary>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public override CmyColor ToCmy() {
        return ColorUtils.RgbToCmy(this);
    }

    /// <summary>
    /// Converts the RGB color to a CMYK color.
    /// </summary>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    public override CmykColor ToCmyk() {
        return ColorUtils.RgbToCmyk(this);
    }

    /// <summary>
    /// Returns the CSS representation of the color. The color will be expressed as <code>rgb(0, 0, 0)</code>.
    /// </summary>
    /// <returns>The CSS representation of the color.</returns>
    public override string ToCss() {
        return string.Format(CultureInfo.InvariantCulture, Alpha < 1 ? "rgba({0}, {1}, {2}, {3})" : "rgb({0}, {1}, {2})", Red, Green, Blue, Alpha);
    }

    /// <summary>
    /// Returns a string representation of the RGB color.
    /// </summary>
    /// <returns>A string representing the color.</returns>
    public override string ToString() {
        return string.Format(CultureInfo.InvariantCulture, Alpha < 1 ? "RGBA: {0}, {1}, {2}, {3}%" : "RGB: {0}, {1}, {2}", Red, Green, Blue, Alpha * 100);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="str"/> into an instance of <see cref="RgbColor"/>.
    /// </summary>
    /// <param name="str">The string representing the color.</param>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    public static RgbColor Parse(string str) {
        return ColorUtils.Parse(str).ToRgb();
    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="RgbColor"/>.
    /// </summary>
    /// <param name="str">The input string to be parsed.</param>
    /// <param name="color">An instance of <see cref="RgbColor"/>.</param>
    /// <returns><c>true</c> if <paramref name="str"/> was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(string str, [NotNullWhen(true)] out RgbColor? color) {

        color = null;

        // Attempt to parse the input string
        if (!ColorUtils.TryParse(str, out IColor? result)) return false;

        // Convert the color to RGB
        color = result as RgbColor ?? result.ToRgb();
        return true;

    }

    /// <summary>
    /// Converts the specified <paramref name="color"/> to <see cref="RgbColor"/>.
    /// </summary>
    /// <param name="color">The color to be converted.</param>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    public static RgbColor FromColor(IColor color) {
        return color as RgbColor ?? color.ToRgb();
    }

    #endregion

}