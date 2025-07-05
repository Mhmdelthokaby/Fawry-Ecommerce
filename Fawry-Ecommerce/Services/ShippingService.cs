using Fawry_Ecommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Services
{
    public static class ShippingService
    {
        public static void Ship(List<IShippment> items)
        {
            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0;
            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetName(),-15} {item.GetWeight() * 1000}g");
                totalWeight += item.GetWeight();
            }
            Console.WriteLine($"Total package weight {totalWeight}kg\n");
        }
    }
}
