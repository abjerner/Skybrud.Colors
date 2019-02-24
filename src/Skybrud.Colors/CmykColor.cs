using System;

namespace Skybrud.Colors {

    /// <summary>
    /// Class representing a color in the <strong>CMYK</strong> color model. CMYK stands for <em>cyan</em>,
    /// <em>magenta</em>, <em>yellow</em> and <em>key</em> (black).
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/CMYK_color_model</cref>
    /// </see>
    public class CmykColor : IColor {

        #region Properties

        /// <summary>
        /// Gets the amount of cyan in the color.
        /// </summary>
        public double Cyan { get; set; }

        /// <summary>
        /// Gets the amount of magenta in the color.
        /// </summary>
        public double Magenta { get; set; }

        /// <summary>
        /// Gets the amount of yellow in the color.
        /// </summary>
        public double Yellow { get; set; }

        /// <summary>
        /// Gets the amount of black (key) in the color.
        /// </summary>
        public double Key { get; set; }

        /// <summary>
        /// Alias of <see cref="Cyan"/>.
        /// </summary>
        public double C {
            get => Cyan;
            set => Cyan = value;
        }

        /// <summary>
        /// Alias of <see cref="Magenta"/>.
        /// </summary>
        public double M {
            get => Magenta;
            set => Magenta = value;
        }

        /// <summary>
        /// Alias of <see cref="Yellow"/>.
        /// </summary>
        public double Y {
            get => Yellow;
            set => Yellow = value;
        }

        /// <summary>
        /// Alias of <see cref="Key"/>.
        /// </summary>
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
        public CmykColor(double cyan, double magenta, double yellow, double key) {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Key = key;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>A HEX string representing the color.</returns>
        public string ToHex() {
            return ToCmy().ToRgb().ToHex();
        }

        /// <summary>
        /// Returns the CSS representation of the color. Since the CSS specification doesn't support CMYK colors, this
        /// method will simply return <c>null</c>.
        /// </summary>
        /// <returns><c>null</c> as the CSS specification doesn't support CMYK colors.</returns>
        public string ToCss() {
            return null;
        }

        /// <summary>
        /// Converts the CMYK color to an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public RgbColor ToRgb() {
            return ToCmy().ToRgb();
        }

        /// <summary>
        /// Converts the CMYK color to an instance of <see cref="RgbaColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="RgbaColor"/>.</returns>
        public RgbaColor ToRgba() {
            return ToCmy().ToRgba();
        }

        /// <summary>
        /// Converts the CMYK color to an instance of <see cref="HslColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public HslColor ToHsl() {
            return ToCmy().ToRgb().ToHsl();
        }

        /// <summary>
        /// Converts the CMYK color to an instance of <see cref="HslaColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HslaColor"/>.</returns>
        public HslaColor ToHsla() {
            return ToCmy().ToRgb().ToHsla();
        }

        /// <summary>
        /// Converts the CMYK color to an instance of <see cref="HsvColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HsvColor"/>.</returns>
        public HsvColor ToHsv() {
            return ToCmy().ToRgb().ToHsv();
        }

        /// <summary>
        /// Converts the CMYK color to an instance of <see cref="CmyColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public CmyColor ToCmy() {
            return ColorUtils.CmykToCmy(this);
        }

        /// <summary>
        /// Returns a new instance of the current CMYK color.
        /// </summary>
        /// <returns>An instance of <see cref="CmykColor"/>.</returns>
        public CmykColor ToCmyk() {
            return new CmykColor(C, M, Y, K);
        }

        /// <summary>
        /// Returns a string representation of the CMYK color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return $"CMYK: {Math.Round(C * 100)}, {Math.Round(M * 100)}, {Math.Round(Y * 100)}, {Math.Round(K * 100)}";
        }

        #endregion
    
    }

}