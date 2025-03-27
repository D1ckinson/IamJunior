namespace ReplacingConditionalLogicWithPolymorphism
{
    class Program
    {
        static void Main()
        {
            FactoryBroker factoryBroker = new();
            OrderForm orderForm = new(factoryBroker);

            string? systemName = orderForm.ShowForm();
            systemName.ThrowIfEmpty();

            PaymentSystem paymentSystem = factoryBroker.Create(systemName);

            paymentSystem.TransferToPaymentPage();
            paymentSystem.ShowPaymentResult();
        }
    }
}
