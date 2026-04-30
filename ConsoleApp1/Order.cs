using System;

namespace ConsoleApp1.Models
{
    /// <summary>
    /// Модель заказа
    /// </summary>
    public class Order
    {
        public string OrderId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal Price { get; }
        public string CustomerEmail { get; }
        public string ShippingAddress { get; }

        public Order(string orderId, string productName, int quantity, decimal price, string customerEmail, string shippingAddress)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            CustomerEmail = customerEmail;
            ShippingAddress = shippingAddress;
        }

        public decimal TotalAmount => Quantity * Price;

        public override string ToString()
        {
            return $"Заказ #{OrderId}: {ProductName} x{Quantity} = {TotalAmount:C}";
        }
    }
}