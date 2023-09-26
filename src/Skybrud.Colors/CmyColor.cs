using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Skybrud.Colors;

/// <summary>
/// Class representing a color in the <strong>CMY</strong> color model. CMY stands for <em>cyan</em>,
/// <em>magenta</em>, and <em>yellow</em>. CMY colors are closely related to <see cref="CmykColor"/>.
/// </summary>
public class CmyColor : ColorBase<CmyColor>, IColorParsable<CmyColor> {

    private double _cyan;
    private double _magenta;
    private double _yellow;

    #region Properties

    /// <summary>
    /// Gets or sets the amount of cyan in the color.
    /// </summary>
    [ValueRange(0, 100)]
    public double Cyan {
        get => _cyan;
        set => _cyan = ColorUtils.Clamp(value, 0, 100);
    }

    /// <summary>
    /// Gets or sets the amount of magenta in the color.
    /// </summary>
    [ValueRange(0, 100)]
    public double Magenta {
        get => _magenta;
        set => _magenta = ColorUtils.Clamp(value, 0, 100);
    }

    /// <summary>
    /// Gets or sets the amount of yellow in the color.
    /// </summary>
    [ValueRange(0, 100)]
    public double Yellow {
        get => _yellow;
        set => _yellow = ColorUtils.Clamp(value, 0, 100);
    }

    /// <summary>
    /// Alias of <see cref="Cyan"/>.
    /// </summary>
    [ValueRange(0, 100)]
    public double C {
        get => Cyan;
        set => Cyan = value;
    }

    /// <summary>
    /// Alias of <see cref="Magenta"/>.
    /// </summary>
    [ValueRange(0, 100)]
    public double M {
        get => Magenta;
        set => Magenta = value;
    }

    /// <summary>
    /// Alias of <see cref="Yellow"/>.
    /// </summary>
    [ValueRange(0, 100)]
    public double Y {
        get => Yellow;
        set => Yellow = value;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new CMY color based on the specified
    /// </summary>
    /// <param name="cyan">The amount of cyan in the color.</param>
    /// <param name="magenta">The amount of magenta in the color.</param>
    /// <param name="yellow">The amount of yellow in the color.</param>
    public CmyColor([ValueRange(0, 100)] double cyan, [ValueRange(0, 100)] double magenta, [ValueRange(0, 100)] double yellow) {
        Cyan = cyan;
        Magenta = magenta;
        Yellow = yellow;
    }

    /// <summary>
    /// Initializes a new CMY color based on the specified
    /// </summary>
    /// <param name="cyan">The amount of cyan in the color.</param>
    /// <param name="magenta">The amount of magenta in the color.</param>
    /// <param name="yellow">The amount of yellow in the color.</param>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    public CmyColor([ValueRange(0, 100)] double cyan, [ValueRange(0, 100)] double magenta, [ValueRange(0, 100)] double yellow, [ValueRange(0, 1)] double alpha) : base(alpha) {
        Cyan = cyan;
        Magenta = magenta;
        Yellow = yellow;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Sets the absolute opacity of a color. Can be applied to colors whether they already have an opacity value or not.
    /// </summary>
    /// <param name="percent">The amount of opacity (specified in percent) that should be set for the color.</param>
    /// <returns>The color resulting from the fade operation.</returns>
    public override CmyColor Fade([ValueRange(0, 100)] double percent) {
        return new CmyColor(Cyan, Magenta, Yellow, percent / 100d);
    }

    /// <summary>
    /// Returns the CSS representation of the color. Since the CSS specification doesn't support CMY colors, the CSS
    /// representation of the corresponding <see cref="RgbColor"/> will be returned instead.
    /// </summary>
    /// <returns>The CSS representation of the color.</returns>
    public override string ToCss() {
        return ToRgb().ToCss();
    }

    /// <summary>
    /// Converts the CMY color to an instance of <see cref="RgbColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    public override RgbColor ToRgb() {
        double r = (1 - C) * 255d;
        double g = (1 - M) * 255d;
        double b = (1 - Y) * 255d;
        return new RgbColor(r, g, b, Alpha);
    }

    /// <summary>
    /// Converts the CMY color to an instance of <see cref="HslColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HslColor"/>.</returns>
    public override HslColor ToHsl() {
        return ToRgb().ToHsl();
    }

    /// <summary>
    /// Converts the CMY color to an instance of <see cref="HsvColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HsvColor"/>.</returns>
    public override HsvColor ToHsv() {
        return ToRgb().ToHsv();
    }

    /// <summary>
    /// Returns a new instance of the current CMY color.
    /// </summary>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public override CmyColor ToCmy() {
        return new CmyColor(C, M, Y, Alpha);
    }

    /// <summary>
    /// Converts the CMY color to an instance of <see cref="CmykColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    public override CmykColor ToCmyk() {

        double key = 1;

        double c;
        double m;
        double y;

        if (C < key) key = C;
        if (M < key) key = M;
        if (Y < key) key = Y;

        if (Math.Abs(key - 1d) < double.Epsilon) { //Black
            c = 0;
            m = 0;
            y = 0;
        } else {
            c = (C - key) / (1d - key);
            m = (M - key) / (1d - key);
            y = (Y - key) / (1d - key);
        }

        double k = key;

        return new CmykColor(c, m, y, k, Alpha);

    }

    /// <summary>
    /// Returns a string representation of the CMY color.
    /// </summary>
    /// <returns>A string representing the color.</returns>
    public override string ToString() {
        return $"CMY: {Math.Round(C * 100)}, {Math.Round(M * 100)}, {Math.Round(Y * 100)}";
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="str"/> into an instance of <see cref="CmyColor"/>.
    /// </summary>
    /// <param name="str">The string representing the color.</param>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public static CmyColor Parse(string str) {
        IColor color = ColorUtils.Parse(str);
        return color as CmyColor ?? color.ToCmy();
    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="CmyColor"/>.
    /// </summary>
    /// <param name="str">The input string to be parsed.</param>
    /// <param name="color">An instance of <see cref="CmyColor"/>.</param>
    /// <returns><c>true</c> if <paramref name="str"/> was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(string str, [NotNullWhen(true)] out CmyColor? color) {

        color = null;

        // Attempt to parse the input string
        if (ColorUtils.TryParse(str, out IColor? result) == false) return false;

        // Convert the color to RGB
        color = result as CmyColor ?? result.ToCmy();
        return true;

    }

    /// <summary>
    /// Converts the specified <paramref name="color"/> to <see cref="CmyColor"/>.
    /// </summary>
    /// <param name="color">The color to be converted.</param>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public static CmyColor FromColor(IColor color) {
        return color as CmyColor ?? color.ToCmy();
    }

    #endregion

}