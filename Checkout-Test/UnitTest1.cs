using Checkout_Item.Models;
using Checkout_Item.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace Checkout_Test
{
    [TestFixture]
    public class Tests
    {
   
        [Test]
        public void GetToalAmount_by_specialoffer()
        {
            var items = new List<Product>
            {
                new Product('A', 50, new  OfferRate(3, 130)),
                new Product('B', 30, new OfferRate(2, 45)),
                new Product('C', 20),
            };

            var checkout = new Checkout(items);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var totalPrice = checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(130));
        }
    }
}