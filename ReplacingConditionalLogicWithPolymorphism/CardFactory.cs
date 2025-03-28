namespace ReplacingConditionalLogicWithPolymorphism
{
    public class CardFactory : IFactory<IPaymentSystem>
    {
        public IPaymentSystem Create() =>
            new CardSystem();
    }
}
