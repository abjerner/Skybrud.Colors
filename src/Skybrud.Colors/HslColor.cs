using System;

namespace Skybrud.Colors {
    
    /// <summary>
    /// Class representing a color in the <strong>HSL</strong> color model. HSL stands for <em>hue</em>,
    /// <em>saturation</em>, and <em>lightness</em>.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/HSL_and_HSV</cref>
    /// </see>
    public class HslColor : IColor {

        #region Properties

        /// <summary>
        /// Gets the hue as a number between <c>0</c> and <c>1</c>. For the hue as the
        /// degrees of a circle, simply multiply by <c>360</c>.
        /// </summary>
        public double Hue { get; set; }

        /// <summary>
        /// Gets the saturation as a number between <c>0</c> and <c>1</c>. For the hue
        /// as percent, simply multiply by <c>100</c>.
        /// </summary>
        public double Saturation { get; set; }

        /// <summary>
        /// Gets the lightness as a number between <c>0</c> and <c>1</c>. For the hue
        /// as percent, simply multiply by <c>100</c>.
        /// </summary>
        public double Lightness { get; set; }

        /// <summary>
        /// Alias of <see cref="Hue"/>.
        /// </summary>
        public double H {
            get => Hue;
            set => Hue = value;
        }

        /// <summary>
        /// Alias of <see cref="Saturation"/>.
        /// </summary>
        public double S {
            get => Saturation;
            set => Saturation = value;
        }

        /// <summary>
        /// Alias of <see cref="Lightness"/>.
        /// </summary>
        public double L {
            get => Lightness;
            set => Lightness = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new HSL color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="saturation"/>.
        /// </summary>
        /// <param name="hue">The hue value of the HSL color, specified as a decimal number between <c>0</c> and <c>0</c>.</param>
        /// <param name="saturation">The saturation value of the HSL color, specified as a decimal number between <c>0</c> and <c>0</c>.</param>
        /// <param name="lightness">The lightness value of the HSL color, specified as a decimal number between <c>0</c> and <c>0</c>.</param>
        public HslColor(double hue, double saturation, double lightness) {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Converts the HSL color to a RGB color.
        /// </summary>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public RgbColor ToRgb() {
            return ColorHelpers.HslToRgb(this);
        }

        /// <summary>
        /// Returns a new <see cref="HslColor"/> with the same color as specified by the <see cref="Hue"/>,
        /// <see cref="Saturation"/> and <see cref="Lightness"/> properties.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public HslColor ToHsl() {
            return new HslColor(Hue, Saturation, Lightness);
        }

        /// <summary>
        /// Converts the HSL color to a CMY color.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public CmyColor ToCmy() {
            return ToRgb().ToCmy();
        }

        /// <summary>
        /// Converts the HSL color to a CMYK color.
        /// </summary>
        /// <returns>An instance of <see cref="CmykColor"/>.</returns>
        public CmykColor ToCmyk() {
            return ToRgb().ToCmyk();
        }

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>A HEX string representing the color.</returns>
        public string ToHex() {
            return ToRgb().ToHex();
        }

        /// <summary>
        /// Returns the CSS representation of the color. The color will be expressed as <code>hsl(0, 0%, 0%)</code>.
        /// </summary>
        /// <returns>The CSS representation of the color.</returns>
        public string ToCss() {
            return $"hsl({Math.Round(H * 360):0}, {Math.Round(S * 100):0}%, {Math.Round(L * 100):0}%)";
        }

        /// <summary>
        /// Returns a string representation of the HSL color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return $"HSL: {Math.Round(H * 360)}, {Math.Round(S * 100)}, {Math.Round(L * 100)}";
        }

        #endregion

    }

}