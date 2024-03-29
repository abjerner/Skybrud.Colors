﻿using System;
using JetBrains.Annotations;

namespace Skybrud.Colors;

/// <summary>
/// Abstract class representing a color.
/// </summary>
public abstract class ColorBase<TColor> : IColor<TColor> where TColor : IColor, IColor<TColor> {

    private double _alpha;

    #region Properties

    /// <summary>
    /// Gets tor sets the opacity as a number between <c>0.0</c> (fully transparent) and <c>1.0</c> (fully opaque).
    /// </summary>
    [ValueRange(0, 1)]
    public double Alpha {
        get => _alpha;
        internal set => _alpha = Clamp(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with <see cref="Alpha"/> set to <c>1</c>.
    /// </summary>
    protected ColorBase() {
        Alpha = 1;
    }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="alpha"/>.
    /// </summary>
    /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
    protected ColorBase(double alpha) {
        Alpha = alpha;
    }

    #endregion

    #region Member methods

    IColor IColor.Copy() {
        return Copy();
    }

    /// <summary>
    /// Returns a copy of the color.
    /// </summary>
    /// <returns>An instance of <typeparamref name="TColor"/> representing the copy.</returns>
    public virtual TColor Copy() {
        return Fade(Alpha * 100d);
    }

    IColor IColor.Fade(double percent) {
        return Fade(percent);
    }

    /// <summary>
    /// Sets the absolute opacity of a color. Can be applied to colors whether they already have an opacity value or not.
    /// </summary>
    /// <param name="percent">The amount of opacity (specified in percent) that should be set for the color.</param>
    /// <returns>The color resulting from the fade operation.</returns>
    public abstract TColor Fade([ValueRange(0, 100)] double percent);

    /// <summary>
    /// Returns the CSS representation of the color, or <c>null</c> if the CSS specification doesn't support the color model.
    /// </summary>
    /// <returns>An instance of <see cref="string"/> with the CSS representation of the color.</returns>
    public abstract string ToCss();

    /// <summary>
    /// Converts the color to an instance of <see cref="RgbColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    public abstract RgbColor ToRgb();

    /// <summary>
    /// Converts the color to an instance of <see cref="HslColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HslColor"/>.</returns>
    public abstract HslColor ToHsl();

    /// <summary>
    /// Converts the color to an instance of <see cref="HsvColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HsvColor"/>.</returns>
    public abstract HsvColor ToHsv();

    /// <summary>
    /// Converts the color to an instance of <see cref="CmyColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    public abstract CmyColor ToCmy();

    /// <summary>
    /// Converts the color to an instance of <see cref="CmykColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    public abstract CmykColor ToCmyk();

    /// <summary>
    /// Returns the HEX representation of the color.
    /// </summary>
    /// <returns>A HEX string representing the color.</returns>
    public virtual string ToHex() {
        return ToHex(HexFormat.Auto);
    }

    /// <summary>
    /// Returns the HEX representation of the color, accoding to the specified <paramref name="format"/>.
    /// </summary>
    /// <param name="format">The HEX format.</param>
    /// <returns>A HEX string representing the color.</returns>
    public virtual string ToHex(HexFormat format) {
        return ColorUtils.ToHex(this, format);
    }

    /// <summary>
    /// Clamps the <paramref name="value"/> to a value between <c>0</c> and <c>1</c> (both inclusive).
    /// </summary>
    /// <param name="value">The input value.</param>
    /// <returns>A value between <c>0</c> and <c>1</c>.</returns>
    protected double Clamp(double value) {
        return Clamp(value, 0, 1);
    }

    /// <summary>
    /// Clamps the <paramref name="value"/> to a value between <paramref name="min"/> and <paramref name="max"/> (both inclusive).
    /// </summary>
    /// <param name="value">The input value.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <returns>A value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    protected double Clamp(double value, double min, double max) {
        return Math.Min(max, Math.Max(min, value));
    }

    #endregion

}