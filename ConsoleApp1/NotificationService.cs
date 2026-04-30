using System;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Сервис уведомлений (подсистема)
    /// </summary>
    public class NotificationService
    {
        public void SendOrderConfirmation(string email, string orderId, string productName)
        {
            Console.WriteLine($"[Уведомления] Отправка подтверждения на email: {email}...");
            Console.WriteLine($"[Уведомления] Письмо отправлено: \"Ваш заказ #{orderId} ({productName}) принят в обработку.\"");
        }

        public void SendShippingNotification(string email, string orderId)
        {
            Console.WriteLine($"[Уведомления] Отправка уведомления о доставке на email: {email}...");
            Console.WriteLine($"[Уведомления] Письмо отправлено: \"Ваш заказ #{orderId} передан в службу доставки.\"");
        }
    }
}