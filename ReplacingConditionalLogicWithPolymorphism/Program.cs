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
            List<IPaymentSystem> paymentSystems =
                [
                    new PaymentSystem("QIWI", "Перевод на страницу QIWI..."),
                    new PaymentSystem("WebMoney", "Вызов API WebMoney..."),
                    new PaymentSystem("Card", "Вызов API банка эмиттера карты Card..."),
                ];

            List<string> paymentSystemsNames = [.. paymentSystems.Select(system => system.Name)];

            OrderForm orderForm = new(paymentSystemsNames);
            PaymentHandler paymentHandler = new();

            orderForm.ShowForm();
            string systemName = orderForm.ReadInput();

            IPaymentSystem? paymentSystem = paymentSystems.FirstOrDefault(paymentSystem => paymentSystem.Name == systemName);
            paymentSystem.ThrowIfNull();


            //if (systemName == "QIWI")
            //    Console.WriteLine("Перевод на страницу QIWI...");
            //else if (systemName == "WebMoney")
            //    Console.WriteLine("Вызов API WebMoney...");
            //else if (systemName == "Card")
            //    Console.WriteLine("Вызов API банка эмиттера карты Card...");

            paymentHandler.ShowPaymentResult(paymentSystem);
        }
    }

    public class OrderForm
    {
        private List<string> _paymentSystemsNames;

        public OrderForm(List<string> paymentSystemsNames)
        {
            paymentSystemsNames.ThrowIfNull();
            paymentSystemsNames.ForEach(name => name.ThrowIfEmpty());

            _paymentSystemsNames = paymentSystemsNames;
        }

        public void ShowForm()
        {
            Console.WriteLine("Мы принимаем:");
            _paymentSystemsNames.ForEach(Console.WriteLine);
        }

        public string ReadInput()
        {
            Console.WriteLine("Какое системой вы хотите совершить оплату?");

            string? input = Console.ReadLine();
            input.ThrowIfEmpty();

            return input;
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

            //if (paymentSystem == "QIWI")
            //    Console.WriteLine("Проверка платежа через QIWI...");
            //else if (paymentSystem == "WebMoney")
            //    Console.WriteLine("Проверка платежа через WebMoney...");
            //else if (paymentSystem == "Card")
            //    Console.WriteLine("Проверка платежа через Card...");

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
