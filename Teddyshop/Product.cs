using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{
    public class Product
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
            Sku = sku;
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return "Product Sku: " + Sku + ", Name: " + ItemName;
        }

    }

}


/*

    MAKE A PRODUCT AND STORE IT IN THE STORAGE

     List<Product> storage = new List<Product>();

            try
            {

                Product spidermanTeddy = new Product(333, "spiderman teddy", 22, 12);
                Product hulkTeddy = new Product(333, "hulk teddy", 22, 12);
                storage.Add(spidermanTeddy);
                storage.Add(hulkTeddy);


                Console.WriteLine("Name of the product: ");
                string productName = Console.ReadLine();

                Console.WriteLine("Sku of the product: ");
                int productSkuInt = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Price of the product: ");
                int productPriceInt = Int32.Parse(Console.ReadLine());

                Console.WriteLine("How many products: ");
                int productQuantityInt = Int32.Parse(Console.ReadLine());

                Product newProduct = new Product(productSkuInt, productName, productPriceInt, productQuantityInt);
                storage.Add(newProduct);

            }
            catch (FormatException)
            {
                Console.WriteLine("Bad Format");
               // System.Console.ReadKey();
            }


            foreach (Product item in storage)
            {
                Console.WriteLine(item.ToString());
            }



*/




/*


 CHANGE THE PRICE OF A PRODUCT IN STORAGE


        Console.WriteLine("Write sku-nr of the product you want to change the price");
        int skuInput = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Write the new price");
        int newPrice = Int32.Parse(Console.ReadLine());


        foreach (Product item in storage)
        {
            if (item.Sku == skuInput)
            {
                Console.WriteLine("Find it");
                item.Price = newPrice; 
            }
        }







*/
