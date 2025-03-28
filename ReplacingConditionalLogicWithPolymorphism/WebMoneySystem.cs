namespace ReplacingConditionalLogicWithPolymorphism
{
    public class WebMoneySystem : IPaymentSystem
    {
        public WebMoneySystem()
        {
            Name = "WebMoney";
        }

        public string Name { get; }

        public void TransferToPaymentPage() =>
            Console.WriteLine("Вызов API WebMoney...");
    }
}
