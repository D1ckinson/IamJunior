namespace ReplacingConditionalLogicWithPolymorphism
{
    public class OrderForm
    {
        private readonly IEnumerable<string> _availableSystems;

        public OrderForm(IEnumerable<string> availableSystems)
        {
            availableSystems.ThrowIfNull();
            _availableSystems = availableSystems;
        }

        public string? ShowForm()
        {
            Console.WriteLine("Мы принимаем:");

            foreach (string name in _availableSystems)
                Console.WriteLine(name);

            Console.WriteLine("Какое системой вы хотите совершить оплату?");

            return Console.ReadLine();
        }
    }
}
