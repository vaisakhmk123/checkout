using Checkout_Item.IService;
using Checkout_Item.Models;
using Checkout_Item.Service;
using System;
using System.Collections.Generic;
using static Checkout_Item.Program;

namespace Checkout_Item
{
    public class Program
    {
    
        static void Main(string[] args)
        {
            List<Product> items = new List<Product>
        {
            new Product('A', 50, new OfferRate(3, 130)),
            new Product('B', 30, new OfferRate(2, 45)),
            new Product('C', 20),
            new Product('D', 15)
        };

            Checkout checkoutObj = new Checkout(items);
            Console.WriteLine("\nEnter items to buy (press Enter after each product, press Enter twice to complete):");
            while (true)
            {
                Console.Write("Scan item (single character ): ");
                string item = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(item))
                    break;

                try
                {
                    checkoutObj.Scan(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int totalPrice = checkoutObj.GetTotalPrice();
            Console.WriteLine($"\nTotal price: {totalPrice}");

        }
    }

  
}
