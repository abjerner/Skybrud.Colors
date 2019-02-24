using System;
using System.Globalization;

namespace Skybrud.Colors {

    /// <summary>
    /// Class representing a color in the <strong>RGBA</strong> color model. RGBA stands for <em>red</em>,
    /// <em>green</em>, <em>blue</em> and <em>alpha</em>.
    /// </summary>
    public class RgbaColor : RgbColor, IAlphaColor {

        #region Properties

        /// <summary>
        /// Gets tor sets the opacity as a number between <c>0.0</c> (fully transparent) and <c>1.0</c> (fully opaque).
        /// </summary>
        public float Alpha { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new color with default values.
        /// </summary>
        public RgbaColor() { }

        /// <summary>
        /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/>, <paramref name="blue"/> and <paramref name="alpha"/>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
        public RgbaColor(byte red, byte green, byte blue, float alpha) {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        /// <summary>
        /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/>, <paramref name="blue"/> and <paramref name="alpha"/>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
        public RgbaColor(int red, int green, int blue, float alpha) {
            Red = (byte) red;
            Green = (byte) green;
            Blue = (byte) blue;
            Alpha = alpha;
        }

        /// <summary>
        /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/>, <paramref name="blue"/> and <paramref name="alpha"/>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="alpha">The amount of opacity, represented by a value between <c>0</c> and <c>1</c>.</param>
        public RgbaColor(double red, double green, double blue, float alpha) {
            Red = (byte) Math.Round(red);
            Green = (byte) Math.Round(green);
            Blue = (byte) Math.Round(blue);
            Alpha = alpha;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="RgbaColor"/> with the same color as specified by the <see cref="RgbColor.Red"/>,
        /// <see cref="RgbColor.Green"/>, <see cref="RgbColor.Blue"/> and <see cref="Alpha"/> properties.
        /// </summary>
        /// <returns>A new instance of <see cref="RgbColor"/>.</returns>
        public override RgbaColor ToRgba() {
            return new RgbaColor(Red, Green, Blue, Alpha);
        }

        /// <summary>
        /// Returns the CSS representation of the color. The color will be expressed as <c>rgba(0, 0, 0, 1)</c>.
        /// </summary>
        /// <returns>The CSS representation of the color.</returns>
        public override string ToCss() {
            return String.Format(CultureInfo.InvariantCulture, "rgba({0}, {1}, {2}, {3})", Red, Green, Blue, Alpha);
        }

        /// <summary>
        /// Returns a string representation of the RGBA color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return String.Format(CultureInfo.InvariantCulture, "RBGA: {0}, {1}, {2}, {3}", Red, Green, Blue, Alpha);
        }

        #endregion

    }

}