using System.Globalization;
using System.Text.RegularExpressions;

namespace Skybrud.Colors {

    internal static class RegexExtensions {

        public static bool IsMatch(this Regex regex, string input, out Match match) {
            match = regex.Match(input);
            return match.Success;
        }

        public static bool IsMatch(this Regex regex, string input, out byte result1, out byte result2, out byte result3) {

            result1 = 0;
            result2 = 0;
            result3 = 0;

            Match match = regex.Match(input);
            if (!match.Success) return false;

            if (!byte.TryParse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result1)) return false;
            if (!byte.TryParse(match.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result2)) return false;
            if (!byte.TryParse(match.Groups[3].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result3)) return false;

            return true;

        }

        public static bool IsMatch(this Regex regex, string input, out byte result1, out byte result2, out byte result3, out byte result4) {

            result1 = 0;
            result2 = 0;
            result3 = 0;
            result4 = 0;

            Match match = regex.Match(input);
            if (!match.Success) return false;

            if (!byte.TryParse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result1)) return false;
            if (!byte.TryParse(match.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result2)) return false;
            if (!byte.TryParse(match.Groups[3].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result3)) return false;
            if (!byte.TryParse(match.Groups[4].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result4)) return false;

            return true;

        }

        public static bool IsMatch(this Regex regex, string input, out double result1, out double result2, out double result3) {

            result1 = 0;
            result2 = 0;
            result3 = 0;

            Match match = regex.Match(input);
            if (!match.Success) return false;

            if (!double.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result1)) return false;
            if (!double.TryParse(match.Groups[2].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result2)) return false;
            if (!double.TryParse(match.Groups[3].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result3)) return false;

            return true;

        }

        public static bool IsMatch(this Regex regex, string input, out double result1, out double result2, out double result3, out double result4) {

            result1 = 0;
            result2 = 0;
            result3 = 0;
            result4 = 0;

            Match match = regex.Match(input);
            if (!match.Success) return false;

            if (!double.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result1)) return false;
            if (!double.TryParse(match.Groups[2].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result2)) return false;
            if (!double.TryParse(match.Groups[3].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result3)) return false;
            if (!double.TryParse(match.Groups[4].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result4)) return false;

            return true;

        }

        public static bool IsMatch(this Regex regex, string input, out int result1, out int result2, out int result3) {

            result1 = 0;
            result2 = 0;
            result3 = 0;

            Match match = regex.Match(input);
            if (!match.Success) return false;

            if (!int.TryParse(match.Groups[1].Value, default, CultureInfo.InvariantCulture, out result1)) return false;
            if (!int.TryParse(match.Groups[2].Value, default, CultureInfo.InvariantCulture, out result2)) return false;
            if (!int.TryParse(match.Groups[3].Value, default, CultureInfo.InvariantCulture, out result3)) return false;

            return true;

        }

    }

}