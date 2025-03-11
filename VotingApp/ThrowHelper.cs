using System.Runtime.CompilerServices;

namespace VotingApp
{
    public static class ThrowHelper
    {
        public static void ThrowIfLessThan<T>(this T argument, T limit, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : IComparable<T> =>
            ArgumentOutOfRangeException.ThrowIfLessThan(argument, limit, name);

        public static void ThrowIfNull<T>(this T argument, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : class =>
            ArgumentNullException.ThrowIfNull(argument, name);

        public static void ThrowIfEmpty(this string argument, [CallerArgumentExpression(nameof(argument))] string? name = null) =>
            ArgumentException.ThrowIfNullOrWhiteSpace(argument, name);
    }
}
