using Fawry_Ecommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Entites.Products
{
    public class ExpirableShippableProduct : Product, IShippment
    {
        public DateTime ExpiryDate { get; }
        public double Weight { get; }
        public string GetName()
        {
            return Name;
        }

        public double GetWeight()
        {
            return Weight;
        }
        public ExpirableShippableProduct(string name, double price, int quantity, DateTime expiryDate, double weight)
        : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
            Weight = weight;
        }
        public override bool IsExpired() => DateTime.Now > ExpiryDate;
        public override bool RequiresShipping()
        {
            return true;
        }
    }
}
