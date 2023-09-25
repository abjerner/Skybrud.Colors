namespace Skybrud.Colors;

/// <summary>
/// Enum class indicating the HEX output format - eg. <see cref="Rgb"/> or <see cref="Rgba"/>.
/// </summary>
public enum HexFormat {

    /// <summary>
    /// Indicates that the format should automatically be determined. If the color is fully opaque, the format will be <c>#RRGGBB</c>; otherwise <c>#RRGGBBAA</c>.
    /// </summary>
    Auto,

    /// <summary>
    /// Indicates that the format should be <c>#RRGGBB</c>.
    /// </summary>
    Rgb,

    /// <summary>
    /// Indicates that the format should be <c>#RRGGBBAA</c>.
    /// </summary>
    Rgba

}