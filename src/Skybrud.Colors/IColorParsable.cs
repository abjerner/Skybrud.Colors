using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Colors;

/// <summary>
/// Interface describing a parseable <see cref="IColor"/>.
/// </summary>
/// <typeparam name="TColor"></typeparam>
public interface IColorParsable<TColor> : IColor where TColor : IColor<TColor> {

#if NET7_0_OR_GREATER

    /// <summary>
    /// Parses the specified <paramref name="input"/> string into an instance of <typeparamref name="TColor"/>.
    /// </summary>
    /// <param name="input">The input string to be parsed.</param>
    /// <returns>An instance of <typeparamref name="TColor"/> representing the parsed color.</returns>
    static abstract TColor Parse(string input);

    /// <summary>
    /// Attempts to parse the specified <paramref name="input"/> string into a corresponding <typeparamref name="TColor"/> instance.
    /// </summary>
    /// <param name="input">The input string to be parsed.</param>
    /// <param name="result">When this method returns, holds the parsed <typeparamref name="TColor"/> instance if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
    static abstract bool TryParse(string input, [NotNullWhen(true)] out TColor? result);

    /// <summary>
    /// Converts the specified <paramref name="color"/> to <typeparamref name="TColor"/>.
    /// </summary>
    /// <param name="color">The color to be converted.</param>
    /// <returns>An instance of <typeparamref name="TColor"/>.</returns>
    static abstract TColor FromColor(IColor color);

#endif

}