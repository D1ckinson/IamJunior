using System.Runtime.CompilerServices;

namespace ReplacingConditionalLogicWithPolymorphism
{
    //Сейчас система не готова к расширению.
    //К сожалению при добавление нового способа оплаты,
    //нам нужно модифицировать все ифы которые совершают те или иные действия с разными системами.
    //Необходимо зафиксировать интерфейс платёжной системы и сокрыть
    //их многообразие под какой-ни будь сущностью. Например фабрикой (или фабричным методом).
    //Важное условие: пользователь вводит именно идентификатор платёжной системы.

    class Program
    {
        static void Main()
        {
            IReadOnlyList<IPaymentSystem> paymentSystems =
                [
                    new PaymentSystem("QIWI", "Перевод на страницу QIWI..."),
                    new PaymentSystem("WebMoney", "Вызов API WebMoney..."),
                    new PaymentSystem("Card", "Вызов API банка эмиттера карты Card..."),
                ];

            OrderForm orderForm = new(paymentSystems);
            PaymentHandler paymentHandler = new();

            orderForm.ShowForm();
            string? systemName = ReadInput();

            IPaymentSystem? paymentSystem = paymentSystems.FirstOrDefault(paymentSystem => paymentSystem.Name == systemName);


            if (systemName == "QIWI")
                Console.WriteLine("перевод на страницу QIWI...");
            else if (systemName == "WebMoney")
                Console.WriteLine("вызов api WebMoney...");
            else if (systemName == "card")
                Console.WriteLine("вызов API банка эмиттера карты Card...");

            paymentHandler.ShowPaymentResult(paymentSystem);
        }

        static string? ReadInput()
        {
            Console.WriteLine("Какое системой вы хотите совершить оплату?");

            return Console.ReadLine();
        }
    }

    public class OrderForm
    {
        private readonly IReadOnlyList<IPaymentSystem> _paymentSystems;

        public OrderForm(IReadOnlyList<IPaymentSystem> paymentSystems)
        {
            paymentSystems.ThrowIfNull();

            foreach (IPaymentSystem system in paymentSystems)
                system.ThrowIfNull();

            _paymentSystems = paymentSystems;
        }

        public void ShowForm()
        {
            Console.WriteLine("Мы принимаем:");

            foreach (IPaymentSystem system in _paymentSystems)
                Console.WriteLine(system.Name);
        }
    }

    public class PaymentHandler
    {


        public PaymentHandler()
        {
        }

        public void ShowPaymentResult(IPaymentSystem paymentSystem)
        {
            Console.WriteLine($"Вы оплатили с помощью {paymentSystem.Name}");

            if (paymentSystem.Name == "QIWI")
                Console.WriteLine("Проверка платежа через QIWI...");
            else if (paymentSystem.Name == "WebMoney")
                Console.WriteLine("Проверка платежа через WebMoney...");
            else if (paymentSystem.Name == "Card")
                Console.WriteLine("Проверка платежа через Card...");

            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class PaymentSystem : IPaymentSystem
    {
        private readonly string _confirmPay;

        public PaymentSystem(string name, string confirmPay)
        {
            name.ThrowIfEmpty();
            confirmPay.ThrowIfEmpty();

            Name = name;
            _confirmPay = confirmPay;
        }

        public string Name { get; }

        public void ConfirmPay() =>
            Console.WriteLine(_confirmPay);
    }

    public interface IPaymentSystem
    {
        public string Name { get; }
        public void ConfirmPay();
    }

    public static class ThrowHelper
    {
        public static void ThrowIfLessThan<T>(this T argument, T limit, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : IComparable<T> =>
            ArgumentOutOfRangeException.ThrowIfLessThan(argument, limit, name);

        public static void ThrowIfNull<T>(this T argument, [CallerArgumentExpression(nameof(argument))] string? name = null) where T : class =>
            ArgumentNullException.ThrowIfNull(argument, name);

        public static void ThrowIfEmpty(this string argument, [CallerArgumentExpression(nameof(argument))] string? name = null) =>
            ArgumentException.ThrowIfNullOrWhiteSpace(argument, name);
    }
}
