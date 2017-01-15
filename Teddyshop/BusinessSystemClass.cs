using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Teddyshop
{
    class BusinessSystemClass<T> where T : CustomerClass
    {
        List<CustomerClass> listCustomers = new List<CustomerClass>();
        List<Product> storage = new List<Product>();

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


        public void customersInSystem()
        {

            List<CustomerClass>.Enumerator e = listCustomers.GetEnumerator(); //Loop through and send all the vehicles in the garage
            Write(e);
            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine();

        }
        public void registerNewCustomer()
        {
            CustomerClass ManualCustomerRegistration = new CustomerClass();
            string systemInput = "0";

            while (systemInput != "9")
            {
                Console.WriteLine("Please folow instructions below");
                Console.Write("Firstname: ");
                ManualCustomerRegistration.FirstName = Console.ReadLine();
                Console.Write("Lastname: ");
                ManualCustomerRegistration.LastName = Console.ReadLine();
                Console.Write("Address : ");
                ManualCustomerRegistration.HomeAddress = Console.ReadLine();
                Console.Write("ZipCode: ");
                ManualCustomerRegistration.HomeZipCode = Int32.Parse(Console.ReadLine());
                Console.Write("Social security number : ");
                ManualCustomerRegistration.SSN = Int32.Parse(Console.ReadLine());
                ManualCustomerRegistration.CustomerNo = Console.ReadLine();

                Console.WriteLine("\n You have provided the following details, would you like to add the customer?\n");

                Console.Write("Y/N");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    listCustomers.Add(ManualCustomerRegistration);

                    Console.WriteLine("Customer: {0} was added", ManualCustomerRegistration.FirstName);
                    systemInput = "9";

                }
                else if (answer.ToLower() == "n")
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
        public void placeCustomerOrder()
        {
            Order registerOrderForCustomer = new Order();
            List<Order> orderList = new List<Order>();
          

            Console.Write("Sku#: ");
            string userInputsku = Console.ReadLine();
            Console.Write("Cus#: ");
            string userInputCustomer = Console.ReadLine();

            Product productSearch = storage.Find(x => x.Sku == userInputsku && x.Quantity > 0);
            CustomerClass customerSearch = listCustomers.Find(x => x.CustomerNo == userInputCustomer);



            Console.WriteLine("Number of found items: {0}, how many would you like to purchase?", productSearch.Quantity);
            String NoOfPurchaseOrders = Console.ReadLine();

            if (customerSearch.CustomerNo != null && productSearch.Quantity >= Convert.ToInt32(NoOfPurchaseOrders))
            {

                Console.WriteLine(" {0} - ItemNo: {1} - Quantity: {2}", customerSearch.FirstName, productSearch.Sku, productSearch.Quantity);

                registerOrderForCustomer.customerId = customerSearch.CustomerNo;
                registerOrderForCustomer.skuOrder = productSearch.Sku;
                registerOrderForCustomer.Quantity = registerOrderForCustomer.Quantity + Convert.ToInt32(NoOfPurchaseOrders);
                orderList.Add(registerOrderForCustomer);
                productSearch.Quantity = productSearch.Quantity - Convert.ToInt32(NoOfPurchaseOrders);

                Order orders = orderList.Find(x => x.skuOrder == userInputsku);
                Console.WriteLine(" {0} - ItemNo: {1} - Quantity: {2}", customerSearch.FirstName, productSearch.Sku, productSearch.Quantity);
                Console.WriteLine("Order:  {0} - ItemNo: {1} - Quantity: {2}", orders.customerId, orders.skuOrder, orders.Quantity);

               

            }
            else if (productSearch.Quantity < Convert.ToInt32(NoOfPurchaseOrders))
            {
                Console.WriteLine("We don't have that many {0}", productSearch.ItemName);
                
            }
            else if (NoOfPurchaseOrders == null)
            {
                Console.WriteLine("Out of {0}, please order!", Convert.ToString(productSearch));
            }
            else if (customerSearch.CustomerNo == null)
            {
                Console.WriteLine("Did not find a customer by the provided id in our system, please register customer first");
            }
            else
            {
                Console.WriteLine("Something went wrong, try again");
            }
            Console.ReadLine();
        }
        /*     public void registerAProduct()
             {


                 try
                 {
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

             } */
        public void initiateProducts()
        {

            Product spidermanTeddy = new Product("333", "spiderman teddy", 22, 12);
            storage.Add(spidermanTeddy);

            Product hulkTeddy = new Product("334", "hulk teddy", 22, 12);
            storage.Add(hulkTeddy);

            Console.WriteLine("added");
        }

        static void Write(IEnumerator<CustomerClass> e)
        {
            while (e.MoveNext()) //initiating enumerator to print all the vehicles in garage. MoveNext is a built in function that iterates the results.
            {
                CustomerClass value = e.Current;
                Console.WriteLine(value.FirstName);
                Console.WriteLine(value.LastName);
                Console.WriteLine(value.CustomerNo);
                Console.WriteLine(value.HomeAddress);
            }


        }

        static void WriteProduct(IEnumerator<Product> e)
        {
            while (e.MoveNext()) //initiating enumerator to print all the vehicles in garage. MoveNext is a built in function that iterates the results.
            {
                Product value = e.Current;
                Console.WriteLine(value.ItemName);
                Console.WriteLine(value.Quantity);
            }
        }
    }
}