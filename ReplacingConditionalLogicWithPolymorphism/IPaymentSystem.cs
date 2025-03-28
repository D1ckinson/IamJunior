namespace ReplacingConditionalLogicWithPolymorphism
{
    public interface IPaymentSystem
    {
        public string Name { get; }

        public void TransferToPaymentPage();
    }
}
