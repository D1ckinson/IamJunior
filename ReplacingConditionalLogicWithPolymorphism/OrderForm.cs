namespace ReplacingConditionalLogicWithPolymorphism
{
    public class OrderForm
    {
        private readonly FactoryBroker _factoryBroker;

        public OrderForm(FactoryBroker factoryBroker)
        {
            factoryBroker.ThrowIfNull();
            _factoryBroker = factoryBroker;
        }

        public string? ShowForm()
        {
            Console.WriteLine("Мы принимаем:");
            IEnumerable<string> names = _factoryBroker.GetAvailableSystems();

            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine("Какое системой вы хотите совершить оплату?");

            return Console.ReadLine();
        }
    }
}
