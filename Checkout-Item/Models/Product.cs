using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout_Item.Models
{
    public class Product
    {
      
            public char SKU { get; set; }
            public int UnitPrice { get; set; }
            public OfferRate OfferRate { get; set; }

            public Product(char sku, int unitPrice, OfferRate  offerRate= null)
            {
                SKU = sku;
                UnitPrice = unitPrice;
                OfferRate = offerRate;
            }
       

    }
}
