
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Teddyshop
{

    class CustomerClass
    {
        public string CustomerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public string Gender { get; set; }
        public string HomeAddress { get; set; }
        public int HomeZipCode { get; set; }



        public void customerClass(string customerNo)
        {
            this.CustomerNo = CustomerNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.HomeAddress = HomeAddress;
            this.HomeZipCode = HomeZipCode;
            this.SSN = SSN;

        }

    }

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

    class BusinessSystemClass<T> where T : CustomerClass
    {
        List<CustomerClass> listCustomers = new List<CustomerClass>();
        

        public void InitiateCustomerBase() //Initiating 10 random customers to the business system using slumpa.net API
        {

            int i = 0;

            while (i < 10)
            {

                string httpClient = new HttpClient().GetStringAsync("http://www.slumpa.net/api/").Result;
                JObject token = JObject.Parse(httpClient);
                CustomerClass NewPerson = new CustomerClass();
                NewPerson.FirstName = (string)token["name"];
                NewPerson.LastName = (string)token["lastname"];
                NewPerson.CustomerNo = (string)token["ssn"];
              
                listCustomers.Add(NewPerson);
                i++; 

            }
        }


        public void customersInSystem() //list all current customers 
        {

            List<CustomerClass>.Enumerator e = listCustomers.GetEnumerator();
            Write(e);

        }
        public void registerNewCustomer()
        {
            CustomerClass ManualCustomerRegistration = new CustomerClass();
            string systemInput = "0";

            while(systemInput != "9")
            {
                Console.WriteLine("Please folow instructions below");
                Console.Write("Firstname: ");
                ManualCustomerRegistration.FirstName =  Console.ReadLine();
                Console.Write("Lastname: ");
                ManualCustomerRegistration.LastName = Console.ReadLine();
                Console.Write("Address : ");
                ManualCustomerRegistration.HomeAddress = Console.ReadLine();
                Console.Write("ZipCode: ");
                ManualCustomerRegistration.HomeZipCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Social security number : ");
                ManualCustomerRegistration.SSN = Convert.ToInt32(Console.ReadLine());
                ManualCustomerRegistration.CustomerNo = Console.ReadLine();

                Console.WriteLine("\n You have provided the following details, would you like to add the customer?\n");

                Console.Write("Y/N");
                string answer = Console.ReadLine();

                if(answer.ToLower() == "y")
                {
                    listCustomers.Add(ManualCustomerRegistration);

                    Console.WriteLine("Customer: {0} was added", ManualCustomerRegistration.FirstName);

                }
                else if(answer.ToLower() == "n")
                {
                    Console.WriteLine("Customer registration was dismissed");
                    systemInput = "9";
                }
                else
                {
                    Console.WriteLine("Please select either Y or N");
                } 
            }

        }

        static void Write(IEnumerator<CustomerClass> e)
        {
            while (e.MoveNext()) //initiating enumerator to print all the customers in the system. MoveNext is a built in function that iterates the results.
            {
                CustomerClass value = e.Current;
                Console.WriteLine(value.FirstName);
                Console.WriteLine(value.LastName);
                Console.WriteLine(value.CustomerNo);
                Console.WriteLine(value.HomeAddress);
            }



        }
    }

    public class MainProg
    {
        private BusinessSystemClass<CustomerClass> BusinessSystem;
        public void Run()
        {
            BusinessSystem = new BusinessSystemClass<CustomerClass>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[A] Add new product");
                Console.WriteLine("[P] Change price for one product");
                Console.WriteLine("[S] Storage - Change number of products in storage");
                Console.WriteLine("[R] Registrate a new customer (name, adress)"); //registerNewCustomer()
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





   
   