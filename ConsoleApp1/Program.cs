using System;
using ConsoleApp1.Facade;
using ConsoleApp1.Models;
using ConsoleApp1.Facade;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА №1. ЗАДАНИЕ №2 ===\n");
            Console.WriteLine("Шаблон проектирования: Фасад (Facade)\n");
            Console.WriteLine("Демонстрация оформления заказа в интернет-магазине\n");

            // Создаём фасад — клиент работает ТОЛЬКО с ним
            OrderFacade orderFacade = new OrderFacade();

            // Демонстрация 1: Успешный заказ
            Console.WriteLine("\n══════════════════════════════════════════");
            Console.WriteLine("   ДЕМОНСТРАЦИЯ 1: Успешный заказ");
            Console.WriteLine("══════════════════════════════════════════\n");

            Order order1 = new Order(
                orderId: "1001",
                productName: "Ноутбук",
                quantity: 2,
                price: 45000m,
                customerEmail: "customer@email.com",
                shippingAddress: "г. Москва, ул. Ленина, д. 1 "
            );

            Console.WriteLine($"Создан заказ: {order1}");
            bool result1 = orderFacade.PlaceOrder(order1);
            Console.WriteLine($"Итог: заказ оформлен = {result1}");

            // Демонстрация 2: Неудачный заказ (товар отсутствует)
            Console.WriteLine("\n══════════════════════════════════════════");
            Console.WriteLine("   ДЕМОНСТРАЦИЯ 2: Товар отсутствует");
            Console.WriteLine("══════════════════════════════════════════\n");

            Order order2 = new Order(
                orderId: "1002",
                productName: "ExpensiveItem",  // Этот товар "отсутствует" на складе
                quantity: 1,
                price: 100000m,
                customerEmail: "vip@email.com",
                shippingAddress: "г. СПб, Невский пр., д. 10"
            );

            Console.WriteLine($"Создан заказ: {order2}");
            bool result2 = orderFacade.PlaceOrder(order2);
            Console.WriteLine($"Итог: заказ оформлен = {result2}");

            // Демонстрация 3: Ещё один успешный заказ
            Console.WriteLine("\n══════════════════════════════════════════");
            Console.WriteLine("   ДЕМОНСТРАЦИЯ 3: Ещё один заказ");
            Console.WriteLine("══════════════════════════════════════════\n");

            Order order3 = new Order(
                orderId: "1003",
                productName: "Клавиатура",
                quantity: 3,
                price: 2500m,
                customerEmail: "office@email.com",
                shippingAddress: "г. Казань, ул. Баумана, д. 5"
            );

            Console.WriteLine($"Создан заказ: {order3}");
            bool result3 = orderFacade.PlaceOrder(order3);
            Console.WriteLine($"Итог: заказ оформлен = {result3}");

            // Вывод: клиентский код простой и не зависит от подсистем
            Console.WriteLine("\n=== ВЫВОД ===");
            Console.WriteLine("Клиентский код работает ТОЛЬКО с OrderFacade.");
            Console.WriteLine("Все детали (склад, платежи, доставка, уведомления) скрыты за фасадом.");
            Console.WriteLine("Клиент не знает о существовании InventoryService, PaymentService и т.д.");

            Console.ReadKey();
        }
    }
}