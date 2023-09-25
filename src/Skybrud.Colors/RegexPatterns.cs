using System.Text.RegularExpressions;

namespace Skybrud.Colors {

    internal static class RegexPatterns {

#if NETSTANDARD1_1
        internal static RegexOptions Compiled = RegexOptions.None;
#else
        internal static RegexOptions Compiled = RegexOptions.Compiled;
#endif

        internal static Regex Hex1 = new("^([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2})$", Compiled);

        internal static Regex Hex2 = new("^([0-9a-f]{1})([0-9a-f]{1})([0-9a-f]{1})$", Compiled);

        internal static Regex Hex3 = new("^([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2})$", Compiled);

        internal static Regex Hsl1 = new("^hsl\\(([0-9]+), ([0-9]+)%, ([0-9]+)%\\)$", Compiled | RegexOptions.IgnoreCase);

        internal static Regex Hsla1 = new("^hsla\\(([0-9]+), ([0-9]+)%, ([0-9]+)%, ([0-9\\.]+)\\)$", Compiled | RegexOptions.IgnoreCase);

        internal static Regex Cmyk1 = new("^cmyk\\(([0-9]\\.+),([0-9]\\.+),([0-9]\\.+),([0-9]\\.+)\\)$", Compiled | RegexOptions.IgnoreCase);

        internal static Regex Cmyk2 = new("^CMYK: ([0-9]\\.+), ([0-9]\\.+), ([0-9]\\.+), ([0-9]\\.+)\\)$", Compiled | RegexOptions.IgnoreCase);

        internal static Regex Rgb = new("^rgb\\(([0-9]+), ([0-9]+), ([0-9]+)\\)$", Compiled);

        internal static Regex Rgba = new("^rgba\\(([0-9]+), ([0-9]+), ([0-9]+), ([0-9\\.]+)\\)$", Compiled);

    }

}