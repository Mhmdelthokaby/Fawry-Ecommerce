using Fawry_Ecommerce.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Entites.Cart_Aggregate
{
    public class Cart
    {
        private List<CartItem> items = new();

        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
                throw new Exception($"Only {product.Quantity} of {product.Name} available.");

            items.Add(new CartItem(product, quantity));
        }

        public List<CartItem> Items => items;

        public bool IsEmpty => !items.Any();
    }
}
