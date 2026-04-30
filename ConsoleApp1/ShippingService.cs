using System;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Сервис доставки (подсистема)
    /// </summary>
    public class ShippingService
    {
        public string CreateShippingLabel(string orderId, string address)
        {
            Console.WriteLine($"[Доставка] Создание этикетки для заказа #{orderId}...");

            string label = $@"
╔══════════════════════════════════════╗
║        ЭТИКЕТКА ДОСТАВКИ             ║
╠══════════════════════════════════════╣
║ Заказ: #{orderId}                         ║
║ Адрес: {address}  ║
║ Срок: 3-5 рабочих дней               ║
╚══════════════════════════════════════╝";

            return label;
        }

        public void PrintLabel(string label)
        {
            Console.WriteLine($"[Доставка] Печать этикетки...");
            Console.WriteLine(label);
        }
    }
}