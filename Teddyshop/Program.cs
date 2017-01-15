
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Teddyshop
{
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

    class Program
    {
        static void Main(string[] args)
        {
            MainProg prog = new MainProg();
            prog.Run();
        }
    }

 
    

    public class MainProg
    {
        private BusinessSystemClass<CustomerClass> BusinessSystem;
        public void Run()
        {
            BusinessSystem = new BusinessSystemClass<CustomerClass>();
            BusinessSystem.InitiateCustomerBase();
            BusinessSystem.initiateProducts();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[A] Add new product");
                Console.WriteLine("[P] Change price for one product");
                Console.WriteLine("[B] Show all registered byers in system");
                Console.WriteLine("[S] Storage - Change number of products in storage");
                Console.WriteLine("[R] Register a new customer (name, adress)"); //registerNewCustomer()
                Console.WriteLine("[N] Add a new order for a customer");
                Console.WriteLine("[C] Change a current order (amount of products)");
                Console.WriteLine("[O] Show all orders for a customer");
                Console.WriteLine("[Q] Quit (cancel) a order");
                Console.WriteLine("[X] Exit program");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key.ToString().ToUpper())
                {
                    case "A":
                        // call the method addNewProduct
                        //addNewProduct();
                       
                        break;
                    case "P":
                        // call the method changePriceProduct()
                        //changePriceProduct();
                        break;
                    case "S":
                        // call the method changeNumberOfProducts()
                        //changeNumberOfProducts();
                        break;
                    case "R":
                        // call the method registerNewCustomer()
                        BusinessSystem.registerNewCustomer();
                        break;
                    case "N":
                        // call the method addNewOrderCustomer()
                        //addNewOrderCustomer();
                        BusinessSystem.placeCustomerOrder();
                        break;
                    case "B":
                        // call the method addNewOrderCustomer()
                        //addNewOrderCustomer();
                        BusinessSystem.customersInSystem();
                        break;
                    case "C":
                        // call the method changeCurrentOrder()
                        //changeCurrentOrder();
                        break;
                    case "O":
                        // call the method showAllOrdersCustomer()
                        //showAllOrdersCustomer;
                        break;
                    case "Q":
                        // call the method cancelOrder()
                        //cancelOrder();
                        break;
                    case "X":
                        // Exit program
                        return;
                    default:
                        // I dont care what the user choose...
                        break;
                }
            }
        }
    }
}





   
   