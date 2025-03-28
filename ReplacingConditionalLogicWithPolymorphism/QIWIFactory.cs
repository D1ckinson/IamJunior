namespace ReplacingConditionalLogicWithPolymorphism
{
    public class QIWIFactory : IFactory<IPaymentSystem>
    {
        public IPaymentSystem Create() =>
            new QIWISystem();
    }
}
