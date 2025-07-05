using Fawry_Ecommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Entites.Products
{
    public class ShippableProduct : Product, IShippment
    {
        public ShippableProduct(string name, double price, int quantity, double weight)
        : base(name, price, quantity)
        {
            Weight = weight;
        }


        public double Weight { get; }

        public string GetName()
        {
            return Name;
        }

        public double GetWeight()
        {
            return Weight;
        }

        public override bool IsExpired()
        {
            return false;
        }

        public override bool RequiresShipping()
        {
            return true;
        }
    }
}
