using System;
using JetBrains.Annotations;

namespace Skybrud.Colors {
    
    /// <summary>
    /// Class representing a color in the <strong>HSL</strong> color model. HSL stands for <em>hue</em>,
    /// <em>saturation</em>, and <em>lightness</em>.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/HSL_and_HSV</cref>
    /// </see>
    public class HslColor : ColorBase {

        private double _hue;
        private double _saturation;
        private double _lightness;

        #region Properties

        /// <summary>
        /// Gets or sets the hue as a number between <c>0</c> and <c>1</c>. For the hue as the degrees of a circle, simply multiply by <c>360</c>.
        /// </summary>
        [ValueRange(0, 1)]
        public double Hue {
            get => _hue;
            set => _hue = ColorUtils.Clamp(value);
        }

        /// <summary>
        /// Gets or sets the saturation as a number between <c>0</c> and <c>1</c>. For the hue as percent, simply multiply by <c>100</c>.
        /// </summary>
        [ValueRange(0, 1)]
        public double Saturation {
            get => _saturation;
            set => _saturation = ColorUtils.Clamp(value);
        }

        /// <summary>
        /// Gets or sets the lightness as a number between <c>0</c> and <c>1</c>. For the hue as percent, simply multiply by <c>100</c>.
        /// </summary>
        [ValueRange(0, 1)]
        public double Lightness {
            get => _lightness;
            set => _lightness = ColorUtils.Clamp(value);
        }

        /// <summary>
        /// Alias of <see cref="Hue"/>.
        /// </summary>
        [ValueRange(0, 1)]
        public double H {
            get => Hue;
            set => Hue = value;
        }

        /// <summary>
        /// Alias of <see cref="Saturation"/>.
        /// </summary>
        [ValueRange(0, 1)]
        public double S {
            get => Saturation;
            set => Saturation = value;
        }

        /// <summary>
        /// Alias of <see cref="Lightness"/>.
        /// </summary>
        [ValueRange(0, 1)]
        public double L {
            get => Lightness;
            set => Lightness = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new HSL color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="saturation"/>.
        /// </summary>
        /// <param name="hue">The hue value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="saturation">The saturation value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="lightness">The lightness value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        public HslColor([ValueRange(0, 1)] double hue, [ValueRange(0, 1)] double saturation, [ValueRange(0, 1)] double lightness) {
            Hue = ColorUtils.Clamp(hue);
            Saturation = ColorUtils.Clamp(saturation);
            Lightness = ColorUtils.Clamp(lightness);
        }

        /// <summary>
        /// Initializes a new HSL color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="saturation"/>.
        /// </summary>
        /// <param name="hue">The hue value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="saturation">The saturation value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="lightness">The lightness value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
        public HslColor([ValueRange(0, 1)] double hue, [ValueRange(0, 1)] double saturation, [ValueRange(0, 1)] double lightness, [ValueRange(0, 1)] double alpha) : base(alpha) {
            Hue = ColorUtils.Clamp(hue);
            Saturation = ColorUtils.Clamp(saturation);
            Lightness = ColorUtils.Clamp(lightness);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Converts the HSL color to a RGB color.
        /// </summary>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public override RgbColor ToRgb() {
            return ColorUtils.HslToRgb(this);
        }

        /// <summary>
        /// Converts the HSL color to a HSL color.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public override HslColor ToHsl() {
            return new HslColor(Hue, Saturation, Lightness, Alpha);
        }

        /// <summary>
        /// Converts the HSL color to a HSV color.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public override HsvColor ToHsv() {
            return ColorUtils.HslToHsv(this);
        }

        /// <summary>
        /// Converts the HSL color to a CMY color.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public override CmyColor ToCmy() {
            return ToRgb().ToCmy();
        }

        /// <summary>
        /// Converts the HSL color to a CMYK color.
        /// </summary>
        /// <returns>An instance of <see cref="CmykColor"/>.</returns>
        public override CmykColor ToCmyk() {
            return ToRgb().ToCmyk();
        }

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>A HEX string representing the color.</returns>
        public override string ToHex() {
            return ToRgb().ToHex();
        }

        /// <summary>
        /// Returns the CSS representation of the color. The color will be expressed as <code>hsl(0, 0%, 0%)</code>.
        /// </summary>
        /// <returns>The CSS representation of the color.</returns>
        public override string ToCss() {
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

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="HslColor"/>.
        /// </summary>
        /// <param name="str">The string representing the color.</param>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public static HslColor Parse(string str) {
            IColor color = ColorUtils.Parse(str);
            return color as HslColor ?? color.ToHsl();
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="HslColor"/>.
        /// </summary>
        /// <param name="str">The input string to be parsed.</param>
        /// <param name="color">An instance of <see cref="HslColor"/>.</param>
        /// <returns><c>true</c> if <paramref name="str"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string str, out HslColor color) {

            color = null;

            // Attempt to parse the input string
            if (ColorUtils.TryParse(str, out IColor result) == false) return false;

            // Convert the color to HSL
            color = result as HslColor ?? result.ToHsl();
            return true;

        }

        #endregion

    }

}