using Checkout_Item.IService;
using Checkout_Item.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Checkout_Item.Service
{
    public class Checkout : ICheckout
    {
        private List<Product> items;
        private Dictionary<char, int> itemCounts;

        public Checkout(List<Product> items)
        {
            this.items = items;
            this.itemCounts = new Dictionary<char, int>();
        }

        public void Scan(string product)
        {
            if (product.Length != 1)
                throw new Exception("Invalid product");

            char sku = char.ToUpper(product[0]);
            var foundItem = items.Find(i => i.SKU == sku);
            if (foundItem == null)
                throw new ArgumentException($"Product '{sku}' not found in pricing list");

            if (!itemCounts.ContainsKey(sku))
                itemCounts[sku] = 0;

            itemCounts[sku]++;
        }

        public int GetTotalPrice()
        {
            int finalAmount = 0;


            foreach (var ic in itemCounts)
            {
                char sku = ic.Key;
                int selectedQuantity = ic.Value;

                var product = items.Where(i => i.SKU == sku).FirstOrDefault();

                if (product.OfferRate != null)
                {
                    finalAmount = finalAmount + calculateOfferRate(product, selectedQuantity);
                }
                else
                {
                    finalAmount += selectedQuantity * product.UnitPrice;
                }
            }

            return finalAmount;
        }

        public int calculateOfferRate(Product product,int selectedQuantity)
        {
            var specialCount = product.OfferRate.Count;
            var OfferPriceValue = product.OfferRate.Price;

            int specialDealCount = selectedQuantity / specialCount;
            int remainingCount = selectedQuantity % specialCount;

            return  (specialDealCount * OfferPriceValue) + (remainingCount * product.UnitPrice);

        }
    }
}
