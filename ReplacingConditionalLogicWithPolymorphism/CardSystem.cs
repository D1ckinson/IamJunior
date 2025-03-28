namespace ReplacingConditionalLogicWithPolymorphism
{
    public class CardSystem : IPaymentSystem
    {
        public CardSystem()
        {
            Name = "Card";
        }

        public string Name { get; }

        public void TransferToPaymentPage() =>
            Console.WriteLine("Вызов API банка эмиттера карты Card...");
    }
}
