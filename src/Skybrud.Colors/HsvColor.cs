﻿using JetBrains.Annotations;

namespace Skybrud.Colors;

/// <summary>
/// Class representing a color in the <strong>HSV</strong> (<strong>h</strong>ue, <strong>s</strong>aturation, <strong>v</strong>alue) color model.
///
/// HSV is sometimes also referred to as <strong>HSB</strong> (<strong>h</strong>ue, <strong>s</strong>aturation, <strong>b</strong>rightness).
/// </summary>
public class HsvColor : ColorBase {

    private double _hue;
    private double _saturation;
    private double _value;

    #region Properties

    /// <summary>
    /// Gets the hue as a number between <c>0</c> and <c>1</c>. For the hue as the degrees of a circle, simply multiply by <c>360</c>.
    /// </summary>
    [ValueRange(0, 1)]
    public double Hue {
        get => _hue;
        set => _hue = ColorUtils.Clamp(value);
    }

    /// <summary>
    /// Gets the saturation as a number between <c>0</c> and <c>1</c>. For the saturation as percent, simply multiply by <c>100</c>.
    /// </summary>
    [ValueRange(0, 1)]
    public double Saturation {
        get => _saturation;
        set => _saturation = ColorUtils.Clamp(value);
    }

    /// <summary>
    /// Gets the value as a number between <c>0</c> and <c>1</c>. For the value as percent, simply multiply by <c>100</c>.
    /// </summary>
    [ValueRange(0, 1)]
    public double Value {
        get => _value;
        set => _value = ColorUtils.Clamp(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/>.
    /// </summary>
    /// <param name="hue">The hue of the HSV color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
    /// <param name="saturation">The saturation of the HSV color, specified as a decimal number between <c>1</c> and <c>0</c>.</param>
    /// <param name="value">The value of the HSV color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
    public HsvColor([ValueRange(0, 1)] double hue, [ValueRange(0, 1)] double saturation, [ValueRange(0, 1)] double value) {
        Hue = ColorUtils.Clamp(hue);
        Saturation = ColorUtils.Clamp(saturation);
        Value = ColorUtils.Clamp(value);
    }

    /// <summary>
    /// Initializes a new <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/>.
    /// </summary>
    /// <param name="hue">The hue of the HSV color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
    /// <param name="saturation">The saturation of the HSV color, specified as a decimal number between <c>1</c> and <c>0</c>.</param>
    /// <param name="value">The value of the HSV color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    public HsvColor([ValueRange(0, 1)] double hue, [ValueRange(0, 1)] double saturation, [ValueRange(0, 1)] double value, [ValueRange(0, 1)] double alpha) : base(alpha) {
        Hue = ColorUtils.Clamp(hue);
        Saturation = ColorUtils.Clamp(saturation);
        Value = ColorUtils.Clamp(value);
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Converts the HSV color to a CMY color.
    /// </summary>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public override CmyColor ToCmy() {
        return ToRgb().ToCmy();
    }

    /// <summary>
    /// Converts the HSV color to a CMYK color.
    /// </summary>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    public override CmykColor ToCmyk() {
        return ToRgb().ToCmyk();
    }

    /// <summary>
    /// Converts the HSV color to a HSL color.
    /// </summary>
    /// <returns>An instance of <see cref="HslColor"/>.</returns>
    public override HslColor ToHsl() {
        ColorUtils.HsvToHsl(Hue, Saturation, Value, out double hh, out double ss, out double ll);
        return new HslColor(hh, ss, ll, Alpha);
    }

    /// <summary>
    /// Converts the HSV color to a HSV color.
    /// </summary>
    /// <returns>An instance of <see cref="HsvColor"/>.</returns>
    public override HsvColor ToHsv() {
        return new HsvColor(Hue, Saturation, Value, Alpha);
    }

    /// <summary>
    /// Converts the HSV color to a RGB color.
    /// </summary>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    public override RgbColor ToRgb() {
        return ColorUtils.HsvToRgb(this);
    }

    /// <summary>
    /// Returns the CSS representation of the color. Since the CSS specification doesn't support HSV colors, this
    /// method will simply return <c>null</c>.
    /// </summary>
    /// <returns><c>null</c> as the CSS specification doesn't support HSV colors.</returns>
    public override string ToCss() {
        return null;
    }

    #endregion

}