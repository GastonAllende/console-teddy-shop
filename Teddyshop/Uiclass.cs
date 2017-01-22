using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{
    public class Uiclass
    {

        static public void Run(BusinessSystemClass BusinessSystem)
        {
            BusinessSystem.InitiateCustomerBase();
            BusinessSystem.initiateProducts();
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("[1] Add new product");
                Console.WriteLine("[2] Change price for one product");  //product()
                Console.WriteLine("[3] Storage - Change number of products in storage");
                Console.WriteLine("[4] Register a new customer (name, adress)"); //registerNewCustomer()
                Console.WriteLine("[5] Add a new order for a customer");
                Console.WriteLine("[6] Change/cancel an order (amount of products)");
                Console.WriteLine("[7] Show all orders for a customer");
                Console.WriteLine("[8] Show all customers in system");
                Console.WriteLine("[9] Exit program");

                input = Console.ReadLine();

                //ConsoleKeyInfo key = Console.ReadKey();

                //switch (key.Key.ToString().ToUpper())
                switch (input)
                {
                    case "1":
                        // call the method addNewProduct
                        BusinessSystem.addNewProduct();
                        break;

                    case "2":
                        // call the method changePriceProduct()
                        BusinessSystem.changePriceProduct();
                        break;

                    case "3":
                        // call the method changeNumberOfProducts()
                        BusinessSystem.changeNumberOfProducts();
                        break;

                    case "4":
                        // call the method registerNewCustomer()
                        BusinessSystem.registerNewCustomer();
                        break;

                    case "5":
                        // call the method addNewOrderCustomer()
                        //addNewOrderCustomer();
                        BusinessSystem.placeCustomerOrder();
                        break;

                    case "6":
                        // call the method changeCurrentOrder()
                        //changeCurrentOrder();
                        BusinessSystem.removePlacedOrder();
                        break;

                    case "7":
                        // call the method showAllOrdersCustomer()
                        //showAllOrdersCustomer;
                        BusinessSystem.viewCustomerOrder();
                        break;

                    case "8":
                        BusinessSystem.customersInSystem();
                        break;



                    case "9":
                        // Exit program
                        return;

                    default:
                        // I dont care what the user choose...
                        break;
                }
            } while (!input.Equals("0"));
        }

    }
}
