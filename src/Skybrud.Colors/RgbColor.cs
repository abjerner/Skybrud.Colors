﻿using System;

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
        /// Gets the amount of red in the color, specified as a value between <code>0</code> and <code>255</code>.
        /// </summary>
        public byte Red { get; set; }

        /// <summary>
        /// Gets the amount of green in the color, specified as a value between <code>0</code> and <code>255</code>.
        /// </summary>
        public byte Green { get; set; }

        /// <summary>
        /// Gets the amount of blue in the color, specified as a value between <code>0</code> and <code>255</code>.
        /// </summary>
        public byte Blue { get; set; }

        /// <summary>
        /// Alias of <see cref="Red"/>.
        /// </summary>
        public byte R {
            get { return Red; }
        }

        /// <summary>
        /// Alias of <see cref="Green"/>.
        /// </summary>
        public byte G {
            get { return Green; }
        }

        /// <summary>
        /// Alias of <see cref="Blue"/>.
        /// </summary>
        public byte B {
            get { return Blue; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new color with default values.
        /// </summary>
        public RgbColor() { }

        /// <summary>
        /// Initializes a new new color based on the specified <code>red</code>, <code>green</code> and <code>blue</code>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        public RgbColor(byte red, byte green, byte blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Initializes a new new color based on the specified <code>red</code>, <code>green</code> and <code>blue</code>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        public RgbColor(int red, int green, int blue) {
            Red = (byte) red;
            Green = (byte) green;
            Blue = (byte) blue;
        }

        /// <summary>
        /// Initializes a new new color based on the specified <code>red</code>, <code>green</code> and <code>blue</code>.
        /// </summary>
        /// <param name="red">The amount of red in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        /// <param name="green">The amount of green in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        /// <param name="blue">The amount of blue in the color, represented by a value between <code>0</code> and <code>255</code>.</param>
        public RgbColor(double red, double green, double blue) {
            Red = (byte) Math.Round(red);
            Green = (byte) Math.Round(green);
            Blue = (byte) Math.Round(blue);
        }

        #endregion

        #region Members
        
        /// <summary>
        /// Returns a new <see cref="RgbColor"/> with the same color as specified by the <see cref="Red"/>,
        /// <see cref="Green"/> and <see cref="Blue"/> properties.
        /// </summary>
        /// <returns>Returns a new instance of <see cref="RgbColor"/>.</returns>
        public RgbColor ToRgb() {
            return new RgbColor(Red, Green, Blue);
        }

        /// <summary>
        /// Converts the RGB color to an HSL color.
        /// </summary>
        /// <returns>Returns an instance of <see cref="HslColor"/>.</returns>
        public HslColor ToHsl() {

            double hue;
            double saturation;
            double lightness;
            ColorHelpers.RgbToHsl(Red, Green, Blue, out hue, out saturation, out lightness);

            return new HslColor(hue, saturation, lightness);

        }

        /// <summary>
        /// Converts the RGB color to a CMY color.
        /// </summary>
        /// <returns>Returns an instance of <see cref="CmyColor"/>.</returns>
        public CmyColor ToCmy() {
            double c = 1 - (R / 255d);
            double m = 1 - (G / 255d);
            double y = 1 - (B / 255d);
            return new CmyColor(c, m, y);
        }

        /// <summary>
        /// Converts the RGB color to a CMYK color.
        /// </summary>
        /// <returns>Returns an instance of <see cref="CmykColor"/>.</returns>
        public CmykColor ToCmyk() {
            return ToCmy().ToCmyk();
        }

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>Returns a HEX string representing the color.</returns>
        public string ToHex() {
            return "#" + Red.ToString("x").PadLeft(2, '0') + Green.ToString("x").PadLeft(2, '0') + Blue.ToString("x").PadLeft(2, '0');
        }

        /// <summary>
        /// Returns the CSS representation of the color. The color will be expressed as <code>rgb(0, 0, 0)</code>.
        /// </summary>
        /// <returns>Returns the CSS representation of the color.</returns>
        public string ToCss() {
            return "rgb(" + Red + ", " + Green + ", " + Blue + ")";
        }

        /// <summary>
        /// Increases the darkness of the color based on the specified <code>percent</code>.
        /// </summary>
        /// <param name="percent">The amount of darkness (specified in percent) that should be added to the color.</param>
        /// <returns>Returns a new instance of <see cref="IColor"/>.</returns>
        public IColor Darken(float percent) {
            return ToHsl().Darken(percent);
        }

        /// <summary>
        /// Increases the lightness of the color based on the specified <code>percent</code>.
        /// </summary>
        /// <param name="percent">The amount of lightness (specified in percent) that should be added to the color.</param>
        /// <returns>Returns a new instance of <see cref="IColor"/>.</returns>
        public IColor Lighten(float percent) {
            return ToHsl().Lighten(percent);
        }

        /// <summary>
        /// Returns a string representation of the RGB color.
        /// </summary>
        /// <returns>Returns a string representing the color.</returns>
        public override string ToString() {
            return String.Format("RGB: {0}, {1}, {2}", Red, Green, Blue);
        }

        #endregion

    }

}