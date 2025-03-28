namespace ReplacingConditionalLogicWithPolymorphism
{
    public class WebMoneyFactory : IFactory<IPaymentSystem>
    {
        public IPaymentSystem Create() =>
            new WebMoneySystem();
    }
}
