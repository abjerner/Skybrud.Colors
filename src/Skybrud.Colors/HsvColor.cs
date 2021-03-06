﻿using JetBrains.Annotations;

namespace Skybrud.Colors {

    /// <summary>
    /// Class representing a color in the <strong>HSV</strong> (<strong>h</strong>ue, <strong>s</strong>aturation, <strong>v</strong>alue) color model. 
    /// 
    /// HSV is sometimes also referred to as <strong>HSB</strong> (<strong>h</strong>ue, <strong>s</strong>aturation, <strong>b</strong>rightness).
    /// </summary>
    public class HsvColor : IColor {

        private double _hue;
        private double _saturation;
        private double _value;

        #region Properties

        /// <summary>
        /// Gets the hue as a number between <c>0</c> and <c>1</c>. For the hue as the degrees of a circle, simply multiply by <c>360</c>.
        /// </summary>
        [ValueRange(0, 1)] 
        public double Hue {
            get => _hue;
            set => _hue = ColorUtils.Clamp(value);
        }

        /// <summary>
        /// Gets the saturation as a number between <c>0</c> and <c>1</c>. For the saturation as percent, simply multiply by <c>100</c>.
        /// </summary>
        [ValueRange(0, 1)]
        public double Saturation {
            get => _saturation;
            set => _saturation = ColorUtils.Clamp(value);
        }

        /// <summary>
        /// Gets the value as a number between <c>0</c> and <c>1</c>. For the value as percent, simply multiply by <c>100</c>.
        /// </summary>
        [ValueRange(0, 1)]
        public double Value {
            get => _value;
            set => _value = ColorUtils.Clamp(value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new <strong>HSV</strong> color with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="hue">The hue of the HSV color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        /// <param name="saturation">The saturation of the HSV color, specified as a decimal number between <c>1</c> and <c>0</c>.</param>
        /// <param name="value">The value of the HSV color, specified as a decimal number between <c>0</c> and <c>1</c>.</param>
        public HsvColor([ValueRange(0, 1)] double hue, [ValueRange(0, 1)] double saturation, [ValueRange(0, 1)] double value) {
            Hue = ColorUtils.Clamp(hue);
            Saturation = ColorUtils.Clamp(saturation);
            Value = ColorUtils.Clamp(value);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Converts the HSV color to a CMY color.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public CmyColor ToCmy() {
            return ToRgb().ToCmy();
        }

        /// <summary>
        /// Converts the HSV color to a CMYK color.
        /// </summary>
        /// <returns>An instance of <see cref="CmykColor"/>.</returns>
        public CmykColor ToCmyk() {
            return ToRgb().ToCmyk();
        }

        /// <summary>
        /// Converts the HSV color to a HSL color.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public HslColor ToHsl() {
            ColorUtils.HsvToHsl(Hue, Saturation, Value, out double hh, out double ss, out double ll);
            return new HslColor(hh, ss, ll);
        }

        /// <summary>
        /// Converts the HSV color to a HSLA color.
        /// </summary>
        /// <returns>An instance of <see cref="HslaColor"/>.</returns>
        public HslaColor ToHsla() {
            ColorUtils.HsvToHsl(Hue, Saturation, Value, out double hh, out double ss, out double ll);
            return new HslaColor(hh, ss, ll, 1);
        }

        /// <summary>
        /// Converts the HSV color to a HSV color.
        /// </summary>
        /// <returns>An instance of <see cref="HsvColor"/>.</returns>
        public HsvColor ToHsv() {
            return new HsvColor(Hue, Saturation, Value);
        }

        /// <summary>
        /// Converts the HSV color to a RGB color.
        /// </summary>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public RgbColor ToRgb() {
            return ColorUtils.HsvToRgb(this);
        }

        /// <summary>
        /// Converts the HSV color to a RGBA color.
        /// </summary>
        /// <returns>An instance of <see cref="RgbaColor"/>.</returns>
        public RgbaColor ToRgba() {
            return ColorUtils.HsvToRgba(this);
        }

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>A HEX string representing the color.</returns>
        public string ToHex() {
            return ToRgb().ToHex();
        }

        /// <summary>
        /// Returns the CSS representation of the color. Since the CSS specification doesn't support HSV colors, this
        /// method will simply return <c>null</c>.
        /// </summary>
        /// <returns><c>null</c> as the CSS specification doesn't support HSV colors.</returns>
        public string ToCss() {
            return null;
        }

        #endregion

    }

}