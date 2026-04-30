using System;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Сервис платежей (подсистема)
    /// </summary>
    public class PaymentService
    {
        public bool ProcessPayment(string orderId, decimal amount)
        {
            Console.WriteLine($"[Платежи] Обработка платежа по заказу #{orderId} на сумму {amount:C}...");

            // Имитация обработки (всегда успешно)
            Console.WriteLine($"[Платежи] Платёж на сумму {amount:C} успешно обработан.");
            return true;
        }
    }
}