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
            var orderForm = new OrderForm();
            var paymentHandler = new PaymentHandler();

            var systemId = orderForm.ShowForm();

            if (systemId == "QIWI")
                Console.WriteLine("Перевод на страницу QIWI...");
            else if (systemId == "WebMoney")
                Console.WriteLine("Вызов API WebMoney...");
            else if (systemId == "Card")
                Console.WriteLine("Вызов API банка эмиттера карты Card...");

            paymentHandler.ShowPaymentResult(systemId);
        }
    }

    public class OrderForm
    {
        public string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");

            //симуляция веб интерфейса
            Console.WriteLine("Какое системой вы хотите совершить оплату?");

            return Console.ReadLine();
        }
    }

    public class PaymentHandler
    {
        public void ShowPaymentResult(string systemId)
        {
            Console.WriteLine($"Вы оплатили с помощью {systemId}");

            if (systemId == "QIWI")
                Console.WriteLine("Проверка платежа через QIWI...");
            else if (systemId == "WebMoney")
                Console.WriteLine("Проверка платежа через WebMoney...");
            else if (systemId == "Card")
                Console.WriteLine("Проверка платежа через Card...");

            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class PaymentSystem : IPaymentSystem
    {
        public PaymentSystem(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Pay()
        {
            Console.WriteLine();
        }
    }

    public interface IPaymentSystem
    {
        public string Name { get; }
        public void Pay();
    }
}
