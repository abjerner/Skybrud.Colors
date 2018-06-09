using System;

namespace Skybrud.Colors {
    
    /// <summary>
    /// Class representing a color in the <strong>CMY</strong> color model. CMY stands for <em>cyan</em>,
    /// <em>magenta</em>, and <em>yellow</em>. CMY colors are closely related to <see cref="CmykColor"/>.
    /// </summary>
    public class CmyColor : IColor {

        #region Properties

        /// <summary>
        /// Gets the amount of cyan in the color.
        /// </summary>
        public double C { get; private set; }

        /// <summary>
        /// Gets the amount of magenta in the color.
        /// </summary>
        public double M { get; private set; }

        /// <summary>
        /// Gets the amount of yellow in the color.
        /// </summary>
        public double Y { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new CMY color based on the specified 
        /// </summary>
        /// <param name="cyan">The amount of cyan in the color.</param>
        /// <param name="magenta">The amount of magenta in the color.</param>
        /// <param name="yellow">The amount of yellow in the color.</param>
        public CmyColor(double cyan, double magenta, double yellow) {
            C = cyan;
            M = magenta;
            Y = yellow;
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
        /// Converts the CMY color to an instance of <see cref="HslColor"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HslColor"/>.</returns>
        public HslColor ToHsl() {
            return ToRgb().ToHsl();
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
            
            if (Math.Abs(key - 1d) < Double.Epsilon) { //Black
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
        /// <returns>Returns a new instance of <see cref="IColor"/>.</returns>
        public IColor Lighten(float percent) {
            return ToHsl().Lighten(percent);
        }

        /// <summary>
        /// Returns a string representation of the CMY color.
        /// </summary>
        /// <returns>A string representing the color.</returns>
        public override string ToString() {
            return String.Format("CMY: {0}, {1}, {2}",
                Math.Round(C * 100),
                Math.Round(M * 100),
                Math.Round(Y * 100)
            );
        }

        #endregion

    }

}