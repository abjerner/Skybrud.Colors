using System;
using JetBrains.Annotations;

namespace Skybrud.Colors {
    
    /// <summary>
    /// Class representing a color in the <strong>HSLA</strong> color model. HSL stands for <em>hue</em>,
    /// <em>saturation</em>, and <em>lightness</em>.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/HSL_and_HSV</cref>
    /// </see>
    public class HslaColor : HslColor, IAlphaColor {

        private float _alpha;

        #region Properties

        /// <summary>
        /// Gets tor sets the opacity as a number between <c>0.0</c> (fully transparent) and <c>1.0</c> (fully opaque).
        /// </summary>
        [ValueRange(0, 1)]
        public float Alpha {
            get => _alpha;
            set => _alpha = ColorUtils.Clamp(value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new HSL color with the specified <paramref name="hue"/>, <paramref name="saturation"/>, <paramref name="saturation"/> and <paramref name="alpha"/>.
        /// </summary>
        /// <param name="hue">The hue value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="saturation">The saturation value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="lightness">The lightness value of the HSL color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
        public HslaColor([ValueRange(0, 1)] double hue, [ValueRange(0, 1)] double saturation, [ValueRange(0, 1)] double lightness, [ValueRange(0, 1)] float alpha) : base(hue, saturation, lightness) {
            Alpha = ColorUtils.Clamp(alpha);
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Converts the HSLA color to a HSLA color.
        /// </summary>
        /// <returns>An instance of <see cref="HslaColor"/>.</returns>
        public override HslaColor ToHsla() {
            return new HslaColor(Hue, Saturation, Lightness, 1);
        }

        /// <summary>
        /// Converts the HSLA color to a RGBA color.
        /// </summary>
        /// <returns>An instance of <see cref="RgbaColor"/>.</returns>
        public override RgbaColor ToRgba() {
            ColorUtils.HslToRgb(this, out int red, out int green, out int blue);
            return new RgbaColor(red, green, blue, Alpha);
        }

        /// <summary>
        /// Returns the CSS representation of the color. The color will be expressed as <code>hsla(0, 0%, 0%, 0.5)</code>.
        /// </summary>
        /// <returns>The CSS representation of the color.</returns>
        public override string ToCss() {
            return $"hsla({Math.Round(H * 360):0}, {Math.Round(S * 100):0}%, {Math.Round(L * 100):0}%, {Alpha})";
        }

        /// <summary>
        /// Returns a string representation of the HSL color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return $"HSLA: {Math.Round(H * 360)}, {Math.Round(S * 100)}, {Math.Round(L * 100)}, {Math.Round(Alpha * 100)}";
        }

        #endregion

    }

}