using System;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Сервис управления складом (подсистема)
    /// </summary>
    public class InventoryService
    {
        public bool CheckAvailability(string productName, int quantity)
        {
            Console.WriteLine($"[Склад] Проверка наличия товара \"{productName}\" в количестве {quantity}...");

            // Имитация проверки (всегда доступно, кроме "ExpensiveItem")
            bool available = productName != "ExpensiveItem";

            if (available)
                Console.WriteLine($"[Склад] Товар \"{productName}\" доступен в нужном количестве.");
            else
                Console.WriteLine($"[Склад] Товар \"{productName}\" отсутствует на складе!");

            return available;
        }

        public void ReserveItem(string productName, int quantity)
        {
            Console.WriteLine($"[Склад] Резервирование товара \"{productName}\" ({quantity} шт.)...");
            Console.WriteLine($"[Склад] Товар \"{productName}\" успешно зарезервирован.");
        }
    }
}