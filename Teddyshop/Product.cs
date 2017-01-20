using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{
     public  class Product
    {
        //  Properties             
        public int Sku { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        /*
            Constructor() 
            @param int sku  - item sku
            @param string itemName - item name
            @param int price - item price
            @param int quantity - item quantity
            
        */

        public Product(int sku, string itemName, int price, int quantity)
        {
            this.Sku = sku;
            this.ItemName = itemName;
            this.Price = price;
            this.Quantity = quantity;
        }

          public override string ToString()
            {
                return "Product Sku: " + Sku + ", Name: " + ItemName + " Product price: " + Price + ", Quantity : " + Quantity;
            }
            
    }

}
