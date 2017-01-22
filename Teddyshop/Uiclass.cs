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
                Console.WriteLine("[0] Exit program");
                Console.WriteLine("[1] Add new product");
                Console.WriteLine("[2] Change price for one product");  //product()
                Console.WriteLine("[3] Storage - Change number of products in storage");
                Console.WriteLine("[4] Register a new customer (name, adress)"); //registerNewCustomer()
                Console.WriteLine("[5] Add a new order for a customer");
                Console.WriteLine("[6] Change a current order (amount of products)");
                Console.WriteLine("[7] Show all orders for a customer");
                Console.WriteLine("[8] Quit (cancel) a order");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        // Exit program
                        return;

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
                        BusinessSystem.placeCustomerOrder();
                        break;

                    case "6":
                        // call the method changeCurrentOrder()
                        BusinessSystem.changeProductInOrder();
                        break;

                    case "7":
                        // call the method showAllOrdersCustomer()
                        BusinessSystem.viewCustomerOrder();
                        break;

                    case "8":
                        // call the method cancelOrder()
                        BusinessSystem.cancelOrder();
                        break;

                    default:
                        // I dont care what the user choose...
                        break;
                }
            } while (!input.Equals("0"));
        }

    }
}
