namespace ReplacingConditionalLogicWithPolymorphism
{
    public class PaymentHandler
    {
        private readonly string _systemName;
        private readonly string _handleText;

        public PaymentHandler(string systemName, string handleText)
        {
            systemName.ThrowIfNull();
            handleText.ThrowIfNull();

            _systemName = systemName;
            _handleText = handleText;
        }

        public void ShowPaymentResult() =>
            Console.WriteLine($"Вы оплатили с помощью {_systemName}\n{_handleText}\nОплата прошла успешно!");
    }
}
