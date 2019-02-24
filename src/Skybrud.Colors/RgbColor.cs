using System;

namespace Skybrud.Colors {

    /// <summary>
    /// Class representing a color in the <strong>RGB</strong> color model. RGB stands for <em>red</em>,
    /// <em>green</em>, and <em>blue</em>.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/RGB_color_model</cref>
    /// </see>
    public class RgbColor : IColor {

        #region Properties

        /// <summary>
        /// Gets the amount of red in the color, specified as a value between <c>0</c> and <c>255</c>.
        /// </summary>
        public byte Red { get; set; }

        /// <summary>
        /// Gets the amount of green in the color, specified as a value between <c>0</c> and <c>255</c>.
        /// </summary>
        public byte Green { get; set; }

        /// <summary>
        /// Gets the amount of blue in the color, specified as a value between <c>0</c> and <c>255</c>.
        /// </summary>
        public byte Blue { get; set; }

        /// <summary>
        /// Alias of <see cref="Red"/>.
        /// </summary>
        public byte R => Red;

        /// <summary>
        /// Alias of <see cref="Green"/>.
        /// </summary>
        public byte G => Green;

        /// <summary>
        /// Alias of <see cref="Blue"/>.
        /// </summary>
        public byte B => Blue;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new color with default values.
        /// </summary>
        public RgbColor() { }

        /// <summary>
        /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        public RgbColor(byte red, byte green, byte blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        public RgbColor(int red, int green, int blue) {
            Red = (byte) red;
            Green = (byte) green;
            Blue = (byte) blue;
        }

        /// <summary>
        /// Initializes a new new color based on the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <c>0</c> and <c>255</c>.</param>
        public RgbColor(double red, double green, double blue) {
            Red = (byte) Math.Round(red);
            Green = (byte) Math.Round(green);
            Blue = (byte) Math.Round(blue);
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Returns a new <see cref="RgbColor"/> with the same color as specified by the <see cref="Red"/>,
        /// <see cref="Green"/> and <see cref="Blue"/> properties.
        /// </summary>
        /// <returns>A new instance of <see cref="RgbColor"/>.</returns>
        public virtual RgbColor ToRgb() {
            return new RgbColor(Red, Green, Blue);
        }

        /// <summary>
        /// Converts the RGB color to a RGBA color.
        /// </summary>
        /// <returns>An instance of <see cref="RgbaColor"/>.</returns>
        public virtual RgbaColor ToRgba() {
            return new RgbaColor(R, G, B, 1);
        }

        /// <summary>
        /// Converts the RGB color to an HSL color.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public virtual HslColor ToHsl() {
            return ColorUtils.RgbToHsl(this);
        }

        /// <summary>
        /// Converts the RGB color to an HSV color.
        /// </summary>
        /// <returns>An instance of <see cref="HsvColor"/>.</returns>
        public virtual HsvColor ToHsv() {
            return ColorUtils.RgbToHsv(this);
        }

        /// <summary>
        /// Converts the RGB color to a CMY color.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public virtual CmyColor ToCmy() {
            return ColorUtils.RgbToCmy(this);
        }

        /// <summary>
        /// Converts the RGB color to a CMYK color.
        /// </summary>
        /// <returns>An instance of <see cref="CmykColor"/>.</returns>
        public virtual CmykColor ToCmyk() {
            return ColorUtils.RgbToCmyk(this);
        }

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>A HEX string representing the color.</returns>
        public virtual string ToHex() {
            return "#" + Red.ToString("x").PadLeft(2, '0') + Green.ToString("x").PadLeft(2, '0') + Blue.ToString("x").PadLeft(2, '0');
        }

        /// <summary>
        /// Returns the CSS representation of the color. The color will be expressed as <code>rgb(0, 0, 0)</code>.
        /// </summary>
        /// <returns>The CSS representation of the color.</returns>
        public virtual string ToCss() {
            return "rgb(" + Red + ", " + Green + ", " + Blue + ")";
        }

        /// <summary>
        /// Increases the darkness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="percent">The amount of darkness (specified in percent) that should be added to the color.</param>
        /// <returns>A new instance of <see cref="IColor"/>.</returns>
        public IColor Darken(float percent) {
            return ToHsl().Darken(percent);
        }

        /// <summary>
        /// Increases the lightness of the color based on the specified <paramref name="percent"/>.
        /// </summary>
        /// <param name="percent">The amount of lightness (specified in percent) that should be added to the color.</param>
        /// <returns>A new instance of <see cref="IColor"/>.</returns>
        public IColor Lighten(float percent) {
            return ToHsl().Lighten(percent);
        }

        /// <summary>
        /// Returns a string representation of the RGB color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return $"RGB: {Red}, {Green}, {Blue}";
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="str">The string representing the color.</param>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public static RgbColor Parse(string str) {
            return ColorHelpers.Parse(str).ToRgb();
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="str">The input string to be parsed.</param>
        /// <param name="color">An instance of <see cref="RgbColor"/>.</param>
        /// <returns><c>true</c> if <paramref name="str"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string str, out RgbColor color) {

            color = null;

            // Attempt to parse the input string
            if (!ColorHelpers.TryParse(str, out IColor result)) return false;

            // Convert the color to RGB
            color = result.ToRgb();
            return true;

        }

        #endregion

    }

}