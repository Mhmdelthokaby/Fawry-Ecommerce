using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Entites.Products
{
    public abstract class Product
    {
        protected Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; set; }
        public abstract bool IsExpired();
        public abstract bool RequiresShipping();
    }
}
