using JetBrains.Annotations;

// ReSharper disable TypeParameterCanBeVariant

namespace Skybrud.Colors;

/// <summary>
/// Interface representing a color as described by a color model - eg. <see cref="RgbColor"/> or <see cref="HslColor"/>.
/// </summary>
public interface IColor {

    /// <summary>
    /// Gets or sets the opacity as a number between <c>0.0</c> (fully transparent) and <c>1.0</c> (fully opaque).
    /// </summary>
    double Alpha { get; }

    /// <summary>
    /// Returns a copy of the color.
    /// </summary>
    /// <returns>An instance of <see cref="IColor"/> representing the copy.</returns>
    IColor Copy();

    /// <summary>
    /// Sets the absolute opacity of a color. Can be applied to colors whether they already have an opacity value or not.
    /// </summary>
    /// <param name="percent">The amount of opacity (specified in percent) that should be set for the color.</param>
    /// <returns>The color resulting from the fade operation.</returns>
    IColor Fade([ValueRange(0, 100)] double percent);

    /// <summary>
    /// Returns the HEX representation of the color.
    /// </summary>
    /// <returns>A HEX string representing the color.</returns>
    string ToHex();

    /// <summary>
    /// Returns the HEX representation of the color, accoding to the specified <paramref name="format"/>.
    /// </summary>
    /// <param name="format">The HEX format.</param>
    /// <returns>A HEX string representing the color.</returns>
    string ToHex(HexFormat format);

    /// <summary>
    /// Returns the CSS representation of the color, or <c>null</c> if the CSS specification doesn't support the color model.
    /// </summary>
    /// <returns>An instance of <see cref="string"/> with the CSS representation of the color.</returns>
    string ToCss();

    /// <summary>
    /// Converts the color to an instance of <see cref="RgbColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="RgbColor"/>.</returns>
    RgbColor ToRgb();

    /// <summary>
    /// Converts the color to an instance of <see cref="HslColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HslColor"/>.</returns>
    HslColor ToHsl();

    /// <summary>
    /// Converts the color to an instance of <see cref="HsvColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="HsvColor"/>.</returns>
    HsvColor ToHsv();

    /// <summary>
    /// Converts the color to an instance of <see cref="CmyColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="CmyColor"/>.</returns>
    CmyColor ToCmy();

    /// <summary>
    /// Converts the color to an instance of <see cref="CmykColor"/>.
    /// </summary>
    /// <returns>An instance of <see cref="CmykColor"/>.</returns>
    CmykColor ToCmyk();

}

/// <summary>
/// Interface representing a color as described by a color model - eg. <see cref="RgbColor"/> or <see cref="HslColor"/>.
/// </summary>
public interface IColor<TColor> : IColor where TColor : IColor {

    /// <summary>
    /// Returns a copy of the color.
    /// </summary>
    /// <returns>An instance of <typeparamref name="TColor"/> representing the copy.</returns>
    new TColor Copy();

    /// <summary>
    /// Sets the absolute opacity of a color. Can be applied to colors whether they already have an opacity value or not.
    /// </summary>
    /// <param name="percent">The amount of opacity (specified in percent) that should be set for the color.</param>
    /// <returns>The color resulting from the fade operation.</returns>
    new TColor Fade([ValueRange(0, 100)] double percent);

}