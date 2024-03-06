using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout_Item.Models
{
    public class OfferRate
    {
        public int Count { get; }
        public int Price { get; }

        public OfferRate(int count, int price)
        {
            Count = count;
            Price = price;
        }
    }
}
