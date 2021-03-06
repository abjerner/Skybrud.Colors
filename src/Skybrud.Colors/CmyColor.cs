﻿using System;
using JetBrains.Annotations;

namespace Skybrud.Colors {
    
    /// <summary>
    /// Class representing a color in the <strong>CMY</strong> color model. CMY stands for <em>cyan</em>,
    /// <em>magenta</em>, and <em>yellow</em>. CMY colors are closely related to <see cref="CmykColor"/>.
    /// </summary>
    public class CmyColor : IColor {

        private double _cyan;
        private double _magenta;
        private double _yellow;

        #region Properties

        /// <summary>
        /// Gets or sets the amount of cyan in the color.
        /// </summary>
        [ValueRange(0, 100)]
        public double Cyan {
            get => _cyan;
            set => _cyan = ColorUtils.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Gets or sets the amount of magenta in the color.
        /// </summary>
        [ValueRange(0, 100)]
        public double Magenta {
            get => _magenta;
            set => _magenta = ColorUtils.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Gets or sets the amount of yellow in the color.
        /// </summary>
        [ValueRange(0, 100)]
        public double Yellow {
            get => _yellow;
            set => _yellow = ColorUtils.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Alias of <see cref="Cyan"/>.
        /// </summary>
        [ValueRange(0, 100)]
        public double C {
            get => Cyan;
            set => Cyan = value;
        }

        /// <summary>
        /// Alias of <see cref="Magenta"/>.
        /// </summary>
        [ValueRange(0, 100)]
        public double M {
            get => Magenta;
            set => Magenta = value;
        }

        /// <summary>
        /// Alias of <see cref="Yellow"/>.
        /// </summary>
        [ValueRange(0, 100)]
        public double Y {
            get => Yellow;
            set => Yellow = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new CMY color based on the specified 
        /// </summary>
        /// <param name="cyan">The amount of cyan in the color.</param>
        /// <param name="magenta">The amount of magenta in the color.</param>
        /// <param name="yellow">The amount of yellow in the color.</param>
        public CmyColor([ValueRange(0, 100)] double cyan, [ValueRange(0, 100)] double magenta, [ValueRange(0, 100)] double yellow) {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns the HEX representation of the color.
        /// </summary>
        /// <returns>Returns a HEX string representing the color.</returns>
        public string ToHex() {
            return ToRgb().ToHex();
        }

        /// <summary>
        /// Returns the CSS representation of the color. Since the CSS specification doesn't support CMY colors, this
        /// method will simply return <c>null</c>.
        /// </summary>
        /// <returns><c>null</c> as the CSS specification doesn't support CMY colors.</returns>
        public string ToCss() {
            return null;
        }

        /// <summary>
        /// Converts the CMY color to an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="RgbColor"/>.</returns>
        public RgbColor ToRgb() {
            double r = (1 - C) * 255d;
            double g = (1 - M) * 255d;
            double b = (1 - Y) * 255d;
            return new RgbColor(r, g, b);
        }

        /// <summary>
        /// Converts the CMY color to an instance of <see cref="RgbaColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="RgbaColor"/>.</returns>
        public RgbaColor ToRgba() {
            double r = (1 - C) * 255d;
            double g = (1 - M) * 255d;
            double b = (1 - Y) * 255d;
            return new RgbaColor(r, g, b, 1);
        }

        /// <summary>
        /// Converts the CMY color to an instance of <see cref="HslColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public HslColor ToHsl() {
            return ToRgb().ToHsl();
        }

        /// <summary>
        /// Converts the CMY color to an instance of <see cref="HslaColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HslaColor"/>.</returns>
        public HslaColor ToHsla() {
            return ToRgb().ToHsla();
        }

        /// <summary>
        /// Converts the CMY color to an instance of <see cref="HsvColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HsvColor"/>.</returns>
        public HsvColor ToHsv() {
            return ToRgb().ToHsv();
        }

        /// <summary>
        /// Returns a new instance of the current CMY color.
        /// </summary>
        /// <returns>An instance of <see cref="CmyColor"/>.</returns>
        public CmyColor ToCmy() {
            return new CmyColor(C, M, Y);
        }

        /// <summary>
        /// Converts the CMY color to an instance of <see cref="CmykColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="CmykColor"/>.</returns>
        public CmykColor ToCmyk() {

            double key = 1;

            double c;
            double m;
            double y;

            if (C < key) key = C;
            if (M < key) key = M;
            if (Y < key) key = Y;
            
            if (Math.Abs(key - 1d) < double.Epsilon) { //Black
                c = 0;
                m = 0;
                y = 0;
            } else {
                c = (C - key) / (1d - key);
                m = (M - key) / (1d - key);
                y = (Y - key) / (1d - key);
            }
            
            double k = key;

            return new CmykColor(c, m, y, k);

        }

        /// <summary>
        /// Returns a string representation of the CMY color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return $"CMY: {Math.Round(C * 100)}, {Math.Round(M * 100)}, {Math.Round(Y * 100)}";
        }

        #endregion

    }

}