using System.Runtime.CompilerServices;

namespace ParameterNameDuplicatedInMethodName
{
    internal class Program
    {
        private const int MinusOne = -1;

        private static void Main() { }

        public void Shoot(Player player)
        {
            player.ThrowIfNull();
        }

        public string FindIndex(IEnumerable<int> collection, int number)
        {
            collection.ThrowIfNull();

            for (int i = 0; i < collection.Count(); i++)
            {
                if (collection.ElementAt(i) == number)
                    return i.ToString();
            }

            return MinusOne.ToString();
        }
    }

    public class Player { }

    public static class ThrowHelper
    {
        public static void ThrowIfNull<T>(this T argument, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : class =>
            ArgumentNullException.ThrowIfNull(argument, name);
    }
}
