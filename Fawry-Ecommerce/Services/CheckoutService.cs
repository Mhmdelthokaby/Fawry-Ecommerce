using Fawry_Ecommerce.Entites;
using Fawry_Ecommerce.Entites.Cart_Aggregate;
using Fawry_Ecommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Services
{
    public static class CheckoutService
    {
        private const double ShippingFeePerItem = 10.0;

        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty) throw new Exception("Cart is empty.");

            var total = 0.0;
            var shippables = new List<IShippment>();
            foreach (var item in cart.Items)
            {
                if (item.Product.IsExpired())
                    throw new Exception($"{item.Product.Name} is expired.");

                if (item.Quantity > item.Product.Quantity)
                    throw new Exception($"{item.Product.Name} is out of stock.");

                total += item.TotalPrice;
                item.Product.Quantity -= item.Quantity;

                if (item.Product.RequiresShipping() && item.Product is IShippment shipItem)
                    shippables.Add(shipItem);
            }

            double shippingFees = shippables.Count * ShippingFeePerItem;
            double amount = total + shippingFees;

            if (customer.Balance < amount)
                throw new Exception("Insufficient balance.");

            customer.Balance -= amount;

            if (shippables.Any())
                ShippingService.Ship(shippables);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
                Console.WriteLine($"{item.Quantity}x {item.Product.Name,-10} {item.TotalPrice}");

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal         {total}");
            Console.WriteLine($"Shipping         {shippingFees}");
            Console.WriteLine($"Amount           {amount}");
            Console.WriteLine($"Balance left     {customer.Balance}\n");
        }
    }
}
