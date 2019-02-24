namespace Skybrud.Colors {

    /// <summary>
    /// Interface representing a color as described by a color model - eg. <see cref="RgbColor"/> or <see cref="HslColor"/>.
    /// </summary>
    public interface IColor {

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>A HEX string representing the color.</returns>
        string ToHex();

        /// <summary>
        /// Returns the CSS representation of the color, or <code>null</code> if the CSS specification doesn't support the color model.
        /// </summary>
        /// <returns>Returns an instance of <see cref="System.String"/> with the CSS representation of the color.</returns>
        string ToCss();

        /// <summary>
        /// Converts the color to an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="RgbColor"/>.</returns>
        RgbColor ToRgb();

        /// <summary>
        /// Converts the color to an instance of <see cref="RgbaColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="RgbaColor"/>.</returns>
        RgbaColor ToRgba();

        /// <summary>
        /// Converts the color to an instance of <see cref="HslColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="HslColor"/>.</returns>
        HslColor ToHsl();

        /// <summary>
        /// Converts the color to an instance of <see cref="HslaColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="HslaColor"/>.</returns>
        HslaColor ToHsla();

        /// <summary>
        /// Converts the color to an instance of <see cref="HsvColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="HsvColor"/>.</returns>
        HsvColor ToHsv();

        /// <summary>
        /// Converts the color to an instance of <see cref="CmyColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="CmyColor"/>.</returns>
        CmyColor ToCmy();

        /// <summary>
        /// Converts the color to an instance of <see cref="CmykColor"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="CmykColor"/>.</returns>
        CmykColor ToCmyk();

    }

}