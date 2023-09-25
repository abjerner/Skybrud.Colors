using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Skybrud.Colors;

/// <summary>
/// Class representing a color in the <strong>CMYK</strong> color model. CMYK stands for <em>cyan</em>,
/// <em>magenta</em>, <em>yellow</em> and <em>key</em> (black).
/// </summary>
/// <see>
///     <cref>https://en.wikipedia.org/wiki/CMYK_color_model</cref>
/// </see>
public class CmykColor : ColorBase {

    private double _cyan;
    private double _magenta;
    private double _yellow;
    private double _key;

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
    /// Gets the amount of black (key) in the color.
    /// </summary>
    [ValueRange(0, 100)]
    public double Key {
        get => _key;
        set => _key = ColorUtils.Clamp(value, 0, 100);
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

    /// <summary>
    /// Alias of <see cref="Key"/>.
    /// </summary>
    [ValueRange(0, 100)]
    public double K {
        get => Key;
        set => Key = value;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new CMYK color based on the specified
    /// </summary>
    /// <param name="cyan">The amount of cyan in the color.</param>
    /// <param name="magenta">The amount of magenta in the color.</param>
    /// <param name="yellow">The amount of yellow in the color.</param>
    /// <param name="key">The amount of black (key) in the color.</param>
    public CmykColor([ValueRange(0, 100)] double cyan, [ValueRange(0, 100)] double magenta, [ValueRange(0, 100)] double yellow, [ValueRange(0, 100)] double key) {
        Cyan = cyan;
        Magenta = magenta;
        Yellow = yellow;
        Key = key;
    }

    /// <summary>
    /// Initializes a new CMYK color based on the specified
    /// </summary>
    /// <param name="cyan">The amount of cyan in the color.</param>
    /// <param name="magenta">The amount of magenta in the color.</param>
    /// <param name="yellow">The amount of yellow in the color.</param>
    /// <param name="key">The amount of black (key) in the color.</param>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    public CmykColor([ValueRange(0, 100)] double cyan, [ValueRange(0, 100)] double magenta, [ValueRange(0, 100)] double yellow, [ValueRange(0, 100)] double key, [ValueRange(0, 1)] double alpha) : base(alpha) {
        Cyan = cyan;
        Magenta = magenta;
        Yellow = yellow;
        Key = key;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns the CSS representation of the color. Since the CSS specification doesn't support CMYK colors, the CSS
    /// representation of the corresponding <see cref="RgbColor"/> will be returned instead.
    /// </summary>
    /// <returns>The CSS representation of the color.</returns>
    public override string ToCss() {
        return ToRgb().ToCss();
    }

    /// <summary>
    /// Converts the CMYK color to an instance of <see cref="RgbColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    public override RgbColor ToRgb() {
        return ToCmy().ToRgb();
    }

    /// <summary>
    /// Converts the CMYK color to an instance of <see cref="HslColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HslColor"/>.</returns>
    public override HslColor ToHsl() {
        return ToCmy().ToRgb().ToHsl();
    }

    /// <summary>
    /// Converts the CMYK color to an instance of <see cref="HsvColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HsvColor"/>.</returns>
    public override HsvColor ToHsv() {
        return ToCmy().ToRgb().ToHsv();
    }

    /// <summary>
    /// Converts the CMYK color to an instance of <see cref="CmyColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public override CmyColor ToCmy() {
        return ColorUtils.CmykToCmy(this);
    }

    /// <summary>
    /// Returns a new instance of the current CMYK color.
    /// </summary>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    public override CmykColor ToCmyk() {
        return new CmykColor(C, M, Y, K, Alpha);
    }

    /// <summary>
    /// Returns a string representation of the CMYK color.
    /// </summary>
    /// <returns>A string representing the color.</returns>
    public override string ToString() {
        return $"CMYK: {Math.Round(C * 100)}, {Math.Round(M * 100)}, {Math.Round(Y * 100)}, {Math.Round(K * 100)}";
    }

    #endregion


    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="input"/> string into an instance of <see cref="IColor"/>.
    /// </summary>
    /// <param name="input">The input string to be parsed.</param>
    /// <returns>An instance of <see cref="IColor"/>.</returns>
    public static CmykColor Parse(string input) {
        IColor color = ColorUtils.Parse(input);
        return color as CmykColor ?? color.ToCmyk();
    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="input"/> string into an instance of <see cref="IColor"/>.
    /// </summary>
    /// <param name="input">The input string to be parsed.</param>
    /// <param name="result">An instance of <see cref="IColor"/>.</param>
    /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(string input, [NotNullWhen(true)] out CmykColor? result) {

        if (ColorUtils.TryParse(input, out IColor? color)) {
            result = color as CmykColor ?? color.ToCmyk();
            return true;
        }

        result = null;
        return false;

    }

    /// <summary>
    /// Converts the specified <paramref name="color"/> to <see cref="CmykColor"/>.
    /// </summary>
    /// <param name="color">The color to be converted.</param>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    public static CmykColor FromColor(IColor color) {
        return color as CmykColor ?? color.ToCmyk();
    }

    #endregion

}