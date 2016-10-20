using System;

namespace Skybrud.Colors {

    /// <summary>
    /// Static helper methods for various color calculations.
    /// </summary>
    public static class ColorHelpers {

        /// <summary>
        /// Returns the maximum value of <code>a</code>, <code>b</code> and <code>c</code>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>Returns the maximum value.</returns>
        public static double Max(double a, double b, double c) {
            return Math.Max(a, Math.Max(b, c));
        }

        /// <summary>
        /// Returns the minimum value of <code>a</code>, <code>b</code> and <code>c</code>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>Returns the minimum value.</returns>
        public static double Min(double a, double b, double c) {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Returns the maximum value of <code>a</code>, <code>b</code> and <code>c</code>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>Returns the maximum value.</returns>
        public static float Max(float a, float b, float c) {
            return Math.Max(a, Math.Max(b, c));
        }

        /// <summary>
        /// Returns the minimum value of <code>a</code>, <code>b</code> and <code>c</code>.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>Returns the minimum value.</returns>
        public static float Min(float a, float b, float c) {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        public static void RgbToHslFloat(byte red, byte green, byte blue, out float hue, out float saturation, out float lightness) {

            // Convert to values from 0-1 (linear)
            float r = red / 255f;
            float g = green / 255f;
            float b = blue / 255f;

            // Get the maximum and minimum values
            float max = Max(r, g, b);
            float min = Min(r, g, b);

            // Calculate the lightness
            lightness = (max + min) / 2f;

            // Calculate the saturation
            saturation = 0;
            if (Math.Abs(max - min) > Double.Epsilon) {
                if (lightness < 0.5) {
                    saturation = (max - min) / (max + min);
                } else {
                    saturation = (max - min) / (2.0f - max - min);
                }
            }

            // Calculate the hue
            hue = 0;
            if (Math.Abs(r - max) < Double.Epsilon) {
                hue = (g - b) / (max - min);
            } else if (Math.Abs(g - max) < Double.Epsilon) {
                hue = 2.0f + (b - r) / (max - min);
            } else if (Math.Abs(b - max) < Double.Epsilon) {
                hue = 4.0f + (r - g) / (max - min);
            }

            // Convert the hue to degrees
            hue = hue * 60;

            // Make sure hue is a positive number
            if (hue < 0.0) hue += 360;

            // Convert the hue back to a decimal
            hue = hue / 360f;

            // Make sure hue is not NaN
            if (Single.IsNaN(hue)) hue = 0;

        }

        /// <summary>
        /// Converts a RGB color to an HSL color.
        /// </summary>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        public static void RgbToHsl(byte red, byte green, byte blue, out double hue, out double saturation, out double lightness) {

            // Convert to values from 0-1 (linear)
            double r = red / 255d;
            double g = green / 255d;
            double b = blue / 255d;

            // Get the maximum and minimum values
            double max = Max(r, g, b);
            double min = Min(r, g, b);

            // Calculate the lightness
            lightness = (max + min) / 2d;

            // Calculate the saturation
            saturation = 0;
            if (Math.Abs(max - min) > Double.Epsilon) {
                if (lightness < 0.5) {
                    saturation = (max - min) / (max + min);
                } else {
                    saturation = (max - min) / (2.0d - max - min);
                }
            }

            // Calculate the hue
            hue = 0;
            if (Math.Abs(r - max) < Double.Epsilon) {
                hue = (g - b) / (max - min);
            } else if (Math.Abs(g - max) < Double.Epsilon) {
                hue = 2.0d + (b - r) / (max - min);
            } else if (Math.Abs(b - max) < Double.Epsilon) {
                hue = 4.0d + (r - g) / (max - min);
            }

            // Convert the hue to degrees
            hue = hue * 60;

            // Make sure hue is a positive number
            if (hue < 0.0) hue += 360;

            // Convert the hue back to a decimal
            hue = hue / 360.0;

            // Make sure hue is not NaN
            if (Double.IsNaN(hue)) hue = 0;

        }

        /// <summary>
        /// Converts an HSL color to a RGB color.
        /// </summary>
        /// <param name="hue">The amount of hue in the HSL color.</param>
        /// <param name="saturation">The amount of saturation in the HSL color.</param>
        /// <param name="lightness">The amount of lightness in the HSL color.</param>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        public static void HslToRgb(double hue, double saturation, double lightness, out int red, out int green, out int blue) {
            RgbColor color = HslToRgb(new HslColor(hue, saturation, lightness));
            red = color.Red;
            green = color.Green;
            blue = color.Blue;
        }


        /// <summary>
        /// Converts the specified <see cref="HslColor"/> to a RGB color.
        /// </summary>
        /// <param name="hsl">The instance of <see cref="HslColor"/> to be converted.</param>
        /// <param name="red">The amount of red in the RGB color.</param>
        /// <param name="green">The amount of green in the RGB color.</param>
        /// <param name="blue">The amount of blue in the RGB color.</param>
        public static void HslToRgb(HslColor hsl, out int red, out int green, out int blue) {
            HslToRgb(hsl.Hue, hsl.Saturation, hsl.Lightness, out red, out green, out blue);
        }
        
        /// <summary>
        /// Converts an instance of <see cref="HslColor"/> to an instance of <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="hsl">The <see cref="HslColor"/> to be converted.</param>
        /// <returns>Returns an instance of <see cref="RgbColor"/>.</returns>
        public static RgbColor HslToRgb(HslColor hsl) {

            // TODO: Needs documentation/references

            double r = 0, g = 0, b = 0;
            if (Math.Abs(hsl.Lightness) > Double.Epsilon) {
                if (Math.Abs(hsl.Saturation) < Double.Epsilon) {
                    r = g = b = hsl.Lightness;
                } else {
                    double temp2 = GetTemp2(hsl);
                    double temp1 = 2.0 * hsl.Lightness - temp2;

                    r = GetColorComponent(temp1, temp2, hsl.Hue + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, hsl.Hue);
                    b = GetColorComponent(temp1, temp2, hsl.Hue - 1.0 / 3.0);
                }
            }
            
            // Convert from 0-1 to 0-255
            return new RgbColor(255 * r, 255 * g, 255 * b);
        
        }

        /// <summary>
        /// Calculates the color compoment for when converting a HSL color to a RGB color.
        /// </summary>
        /// <param name="temp1"></param>
        /// <param name="temp2"></param>
        /// <param name="temp3"></param>
        /// <returns>Returns the color component.</returns>
        private static double GetColorComponent(double temp1, double temp2, double temp3) {

            // TODO: Needs documentation/references
            
            temp3 = MoveIntoRange(temp3);
            if (temp3 < 1.0 / 6.0) return temp1 + (temp2 - temp1) * 6.0 * temp3;
            if (temp3 < 0.5) return temp2;
            if (temp3 < 2.0 / 3.0) return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            return temp1;
        
        }

        /// <summary>
        /// Method used internally for when converting a HSL color to a RGB color.
        /// </summary>
        private static double MoveIntoRange(double temp3) {

            // TODO: Needs documentation/references

            if (temp3 < 0.0) {
                temp3 += 1.0;
            } else if (temp3 > 1.0) {
                temp3 -= 1.0;
            }
                
            return temp3;
        
        }

        /// <summary>
        /// Method used internally for when converting a HSL color to a RGB color.
        /// </summary>
        private static double GetTemp2(HslColor hslColor) {

            // TODO: Needs documentation/references
            
            double temp2;

            if (hslColor.Lightness < 0.5) {
                temp2 = hslColor.Lightness * (1.0 + hslColor.Saturation);
            } else  {
                temp2 = hslColor.Lightness + hslColor.Saturation - (hslColor.Lightness * hslColor.Saturation);
            }
            
            return temp2;
        
        }

    }

}