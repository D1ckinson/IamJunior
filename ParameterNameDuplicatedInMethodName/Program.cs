using System.Numerics;
using System.Runtime.CompilerServices;

namespace ParameterNameDuplicatedInMethodName
{
    internal class Program
    {
        private readonly IEnumerable<string> _collection = [];

        private static void Main() { }

        public void Shoot(IDamageable damageable)
        {
            damageable.ThrowIfNull();
            damageable.GetDamage();
        }

        public string GetBy(int index)
        {
            index.ThrowIfNegative();

            int maxIndex = _collection.Count() - 1;
            index.ThrowIfGreaterThan(maxIndex);

            return _collection.ElementAt(index);
        }
    }

    public interface IDamageable
    {
        public void GetDamage();
    }

    public static class ThrowHelper
    {
        public static void ThrowIfNegative<T>(this T argument, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : INumberBase<T> =>
            ArgumentOutOfRangeException.ThrowIfNegative(argument, name);

        public static void ThrowIfGreaterThan<T>(this T argument, T value, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : IComparable<T> =>
            ArgumentOutOfRangeException.ThrowIfGreaterThan(argument, value, name);

        public static void ThrowIfNull<T>(this T argument, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : class =>
            ArgumentNullException.ThrowIfNull(argument, name);
    }
}
