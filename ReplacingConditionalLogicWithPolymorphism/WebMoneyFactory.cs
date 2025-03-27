namespace ReplacingConditionalLogicWithPolymorphism
{
    public class WebMoneyFactory : IFactory<PaymentSystem>
    {
        private readonly string _name = "WebMoney";

        public PaymentSystem Create()
        {
            PaymentHandler paymentHandler = new(_name, "Проверка платежа через WebMoney...");

            return new(_name, "Вызов API WebMoney...", paymentHandler);
        }
    }
}
