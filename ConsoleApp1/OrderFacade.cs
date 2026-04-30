using System;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Facade
{
    /// <summary>
    /// Фасад для оформления заказа.
    /// Скрывает сложность взаимодействия с подсистемами.
    /// </summary>
    public class OrderFacade
    {
        private readonly InventoryService _inventory;
        private readonly PaymentService _payment;
        private readonly ShippingService _shipping;
        private readonly NotificationService _notification;

        public OrderFacade()
        {
            _inventory = new InventoryService();
            _payment = new PaymentService();
            _shipping = new ShippingService();
            _notification = new NotificationService();
        }

        /// <summary>
        /// Оформить заказ — единый метод, скрывающий всю сложность подсистемы.
        /// </summary>
        public bool PlaceOrder(Order order)
        {
            Console.WriteLine($"\n{new string('=', 50)}");
            Console.WriteLine($"НАЧАЛО ОФОРМЛЕНИЯ ЗАКАЗА #{order.OrderId}");
            Console.WriteLine($"{new string('=', 50)}\n");

            // Этап 1: Проверка наличия товара
            Console.WriteLine("--- Этап 1: Проверка наличия ---");
            if (!_inventory.CheckAvailability(order.ProductName, order.Quantity))
            {
                Console.WriteLine($"\n❌ Заказ #{order.OrderId} НЕ может быть оформлен: товар отсутствует.\n");
                return false;
            }

            // Этап 2: Резервирование товара
            Console.WriteLine("\n--- Этап 2: Резервирование ---");
            _inventory.ReserveItem(order.ProductName, order.Quantity);

            // Этап 3: Оформление платежа
            Console.WriteLine("\n--- Этап 3: Оформление платежа ---");
            bool paymentSuccess = _payment.ProcessPayment(order.OrderId, order.TotalAmount);
            if (!paymentSuccess)
            {
                Console.WriteLine($"\n❌ Заказ #{order.OrderId} НЕ оформлен: ошибка платежа.\n");
                return false;
            }

            // Этап 4: Создание и печать этикетки
            Console.WriteLine("\n--- Этап 4: Этикетка доставки ---");
            string label = _shipping.CreateShippingLabel(order.OrderId, order.ShippingAddress);
            _shipping.PrintLabel(label);

            // Этап 5: Отправка уведомлений
            Console.WriteLine("--- Этап 5: Уведомления ---");
            _notification.SendOrderConfirmation(order.CustomerEmail, order.OrderId, order.ProductName);
            _notification.SendShippingNotification(order.CustomerEmail, order.OrderId);

            Console.WriteLine($"\n{new string('=', 50)}");
            Console.WriteLine($"✅ ЗАКАЗ #{order.OrderId} УСПЕШНО ОФОРМЛЕН!");
            Console.WriteLine($"{new string('=', 50)}\n");

            return true;
        }
    }
}