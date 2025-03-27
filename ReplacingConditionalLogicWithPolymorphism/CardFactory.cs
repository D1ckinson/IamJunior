namespace ReplacingConditionalLogicWithPolymorphism
{
    public class CardFactory : IFactory<PaymentSystem>
    {
        private readonly string _name = "Card";

        public PaymentSystem Create()
        {
            PaymentHandler paymentHandler = new(_name, "Проверка платежа через Card...");

            return new(_name, "Вызов API банка эмиттера карты Card...", paymentHandler);
        }
    }
}
