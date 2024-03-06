using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout_Item.IService
{
    public interface ICheckout
    {
      public  void Scan(string item);
      public  int GetTotalPrice();
    }
}
