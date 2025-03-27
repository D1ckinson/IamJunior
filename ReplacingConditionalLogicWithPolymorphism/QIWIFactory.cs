namespace ReplacingConditionalLogicWithPolymorphism
{
    public class QIWIFactory : IFactory<PaymentSystem>
    {
        private readonly string _name = "QIWI";

        public PaymentSystem Create()
        {
            PaymentHandler paymentHandler = new(_name, "Проверка платежа через QIWI...");

            return new(_name, "Перевод на страницу QIWI...", paymentHandler);
        }
    }
}
