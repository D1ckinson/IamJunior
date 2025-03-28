namespace ReplacingConditionalLogicWithPolymorphism
{
    public class PaymentHandler
    {
        public void Handle(IFactory<IPaymentSystem> factory)
        {
            factory.ThrowIfNull();

            IPaymentSystem paymentSystem = factory.Create();
            paymentSystem.TransferToPaymentPage();

            ShowPaymentResult(paymentSystem.Name);
        }

        private void ShowPaymentResult(string systemName) =>
            Console.WriteLine($"Вы оплатили с помощью {systemName}\nПроверка платежа через {systemName}...\nОплата прошла успешно!");
    }
}
