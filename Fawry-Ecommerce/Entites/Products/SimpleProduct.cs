﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Ecommerce.Entites.Products
{
    public class SimpleProduct : Product
    {
        public SimpleProduct(string name, double price, int quantity) : base(name, price, quantity)
        {
        }

        public override bool IsExpired()
        {
            return false;
        }

        public override bool RequiresShipping()
        {
            return false;
        }
    }
}
