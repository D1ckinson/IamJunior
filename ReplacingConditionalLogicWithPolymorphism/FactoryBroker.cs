﻿namespace ReplacingConditionalLogicWithPolymorphism
{
    public class FactoryBroker
    {
        private readonly Dictionary<string, IFactory<IPaymentSystem>> _factories;

        public FactoryBroker()
        {
            _factories = new()
            {
                ["QIWI"] = new QIWIFactory(),
                ["WebMoney"] = new WebMoneyFactory(),
                ["Card"] = new CardFactory()
            };
        }

        public IEnumerable<string> GetAvailableSystems() =>
            _factories.Keys;

        public IFactory<IPaymentSystem> GiveFactory(string paymentSystemName)
        {
            paymentSystemName.ThrowIfEmpty();

            if (_factories.ContainsKey(paymentSystemName) == false)
                throw new ArgumentException(paymentSystemName);

            return _factories[paymentSystemName];
        }
    }
}
