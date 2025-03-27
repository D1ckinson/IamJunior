namespace ReplacingConditionalLogicWithPolymorphism
{
    public class PaymentSystem
    {
        private readonly string _transferText;
        private readonly PaymentHandler _paymentHandler;

        public PaymentSystem(string name, string transferText, PaymentHandler paymentHandler)
        {
            name.ThrowIfEmpty();
            transferText.ThrowIfEmpty();
            _paymentHandler.ThrowIfNull();

            Name = name;
            _transferText = transferText;
            _paymentHandler = paymentHandler;
        }

        public string Name { get; }

        public void TransferToPaymentPage() =>
            Console.WriteLine(_transferText);

        public void ShowPaymentResult() =>
            _paymentHandler.ShowPaymentResult();
    }
}
