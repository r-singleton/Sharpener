// The Sharpener project and Facefire license this file to you under the MIT license.

using Sharpener.Types.Strings;
using Sharpener.Types.Strings.Interfaces;

namespace Sharpener.Extensions;

/// <summary>
/// Extensions for strings.
/// </summary>
public static class StringExtensions
{
    /// <inheritdoc cref="IStringComparer.NoCase"/>
    public static IStringComparer NoCase(this string source) => new CaseStringComparer(source, true);

    /// <inheritdoc cref="IStringComparer.Case"/>
    public static IStringComparer Case(this string source) => new CaseStringComparer(source, false);

    /// <inheritdoc cref="IStringComparer.Current"/>
    public static IStringComparer Current(this string source) => new CultureStringComparer(source, StringComparison.CurrentCulture);

    /// <inheritdoc cref="IStringComparer.Invariant"/>
    public static IStringComparer Invariant(this string source) => new CultureStringComparer(source, StringComparison.InvariantCulture);

    /// <inheritdoc cref="IStringComparer.Ordinal"/>
    public static IStringComparer Ordinal(this string source) => new CultureStringComparer(source, StringComparison.Ordinal);
}
