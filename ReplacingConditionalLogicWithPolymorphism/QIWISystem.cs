namespace ReplacingConditionalLogicWithPolymorphism
{
    public class QIWISystem : IPaymentSystem
    {
        public QIWISystem()
        {
            Name = "QIWI";
        }

        public string Name { get; }

        public void TransferToPaymentPage() =>
            Console.WriteLine("Перевод на страницу QIWI...");
    }
}
