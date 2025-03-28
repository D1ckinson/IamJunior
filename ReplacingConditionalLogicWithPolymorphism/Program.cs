namespace ReplacingConditionalLogicWithPolymorphism
{
    class Program
    {
        static void Main()
        {
            FactoryBroker factoryBroker = new();
            OrderForm orderForm = new(factoryBroker.GetAvailableSystems());

            string? systemName = orderForm.ShowForm();
            systemName.ThrowIfEmpty();

            IFactory<IPaymentSystem> factory = factoryBroker.GiveFactory(systemName);

            PaymentHandler paymentHandler = new();
            paymentHandler.Handle(factory);
        }
    }
}
