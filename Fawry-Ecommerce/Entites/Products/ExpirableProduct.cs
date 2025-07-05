using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Entites.Products
{
    public class ExpirableProduct : Product
    {
        public DateTime ExpiryDate { get; }

        public ExpirableProduct(string name, double price, int quantity, DateTime expiryDate)
        : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override bool IsExpired()
        {
            return true;
        }

        public override bool RequiresShipping()
        {
            return false;
        }
    }
}
