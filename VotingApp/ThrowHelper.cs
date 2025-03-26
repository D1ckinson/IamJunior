using System.Runtime.CompilerServices;

namespace VotingApp
{
    public static class ThrowHelper
    {
        public static void ThrowIfNull<T>(this T? argument, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : class =>
            ArgumentNullException.ThrowIfNull(argument, name);

        public static void ThrowIfNull(this bool argument, [CallerArgumentExpression(nameof(argument))] string? name = null) =>
            ArgumentNullException.ThrowIfNull(argument, name);

        public static void ThrowIfEmpty(this string? argument, [CallerArgumentExpression(nameof(argument))] string? name = null) =>
            ArgumentException.ThrowIfNullOrWhiteSpace(argument, name);

        public static void ThrowIfNotEqual(this int argument, int value)
        {
            if (Equals(argument, value) == false)
                throw new ArgumentNotEqualException(value);
        }
    }
}
