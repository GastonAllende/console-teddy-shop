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
        List<Order> orderList = new List<Order>();
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
        public void removePlacedOrder()
        {
            Console.WriteLine("Please provide us the following details");
            Console.Write("Customer number: ");
            string searchcustomer = Console.ReadLine();

            List<Order> viewCustomerOrder = orderList.FindAll(x => x.customerId == searchcustomer);
            

            foreach (Order list in viewCustomerOrder)
            {
                Console.WriteLine("Customer with number: {0} have ordered {1} items of {2}", list.customerId, list.Quantity, list.skuOrder);
            }

            Console.WriteLine("\nSelect the item to change your order");

            try
            {
                Console.Write("Item number: ");
                int selectItemNumber = Convert.ToInt32(Console.ReadLine());
                Order changeCustomerOrder = orderList.Find(x => x.customerId == searchcustomer && x.skuOrder == selectItemNumber);
                Product removePlacedOrder = storage.Find(x => x.Sku == selectItemNumber);
                Console.WriteLine("Would you like to cancel the entire order or just change the quantity?, which is now: {0}: ", changeCustomerOrder.Quantity);
                Console.Write("Quantity to remove from order: ");
                int selectQuantity = Int32.Parse(Console.ReadLine());


                if (Convert.ToInt32(selectQuantity) >= removePlacedOrder.Quantity)
                {
                    removePlacedOrder.Quantity = removePlacedOrder.Quantity + Convert.ToInt32(selectQuantity);
                    if (removePlacedOrder.Quantity == 0)
                    {
                        viewCustomerOrder.RemoveAll(x => x.customerId == searchcustomer);

                        Console.WriteLine("The whole order was successfully removed");
                    }
                    else if (removePlacedOrder.Quantity > 0)
                    {
                        Console.WriteLine("Part of the order was removed, you still have {0} left", removePlacedOrder.Quantity);
                    }
                }
                else
                {
                    Console.WriteLine("You didn't have that many items to begin with");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad Format");
                // System.Console.ReadKey();
            }


        }
        public void registerNewCustomer()
        {
            CustomerClass ManualCustomerRegistration = new CustomerClass();
            string systemInput = "0";

            while (systemInput != "9")
            {
                try
                { 
                Console.WriteLine("Please folow instructions below");
                Console.Write("Firstname: ");
                ManualCustomerRegistration.FirstName = Console.ReadLine();
                Console.Write("Lastname: ");
                ManualCustomerRegistration.LastName = Console.ReadLine();
                Console.Write("Address : ");
                ManualCustomerRegistration.HomeAddress = Console.ReadLine();
                Console.Write("ZipCode: ");
                ManualCustomerRegistration.HomeZipCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Social security number : ");
                ManualCustomerRegistration.SSN = Console.ReadLine();
                ManualCustomerRegistration.CustomerNo = ManualCustomerRegistration.SSN;

                Console.WriteLine("\nYou have provided the following details, would you like to add the customer?\n");

                Console.Write("Y/N : ");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    listCustomers.Add(ManualCustomerRegistration);

                    Console.WriteLine("Customer: {0} was added, press any key to go back", ManualCustomerRegistration.FirstName);
                    Console.ReadLine();
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
            catch (FormatException)
            {
                Console.WriteLine("Invalid number, please press any key and fill out the form again");
                System.Console.ReadKey();
            }

        }


        }
        public void placeCustomerOrder()
        {
            Order registerOrderForCustomer = new Order();
            CustomerClass customerOrder = new CustomerClass();

            Console.WriteLine("Currently, we have these items in stock. Write down the items sku number to begin a purchase ");
            foreach(Product items in storage)
            {
                Console.WriteLine("Item number: {0} - Name: {1} - Price: {2} - Quantity: {3} ", items.Sku, items.ItemName, items.Price, items.Quantity);
            }
            try
            {
                Console.Write("\n\nItem number: ");
                int userInputsku = Convert.ToInt32(Console.ReadLine());
                Console.Write("Customer number: ");
                string userInputCustomer = Console.ReadLine();

                Product productSearch = storage.Find(x => x.Sku == userInputsku && x.Quantity > 0);
                CustomerClass customerSearch = listCustomers.Find(x => x.CustomerNo == userInputCustomer);

                if (customerSearch.CustomerNo != null && productSearch.Quantity > 0)
                {
                    Console.WriteLine("Number of found items: {0}, how many would you like to purchase?", productSearch.Quantity);
                    Console.Write("# ");
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

                        Console.WriteLine("Congratulations! your order was successfully processed");



                    }
                    else if (productSearch.Quantity < Convert.ToInt32(NoOfPurchaseOrders))
                    {
                        Console.WriteLine("We don't have that many {0}", productSearch.ItemName);

                    }
                    else if (customerSearch.CustomerNo != null)
                    {
                        Console.WriteLine("Did not find a customer by the provided id in our system, please register customer first");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, try again");
                    }
                }
                else if(customerSearch.CustomerNo == null && productSearch.Quantity > 0)
                {
                    Console.WriteLine("No customer found");
                }
                else if(productSearch.Quantity == 0 && customerSearch.CustomerNo != null)
                {
                    Console.WriteLine("Out of {0}, please order!", Convert.ToString(productSearch));
                }
                else 
                {
                    Console.WriteLine("Sorry, nothing matches our database! ");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number, please press any key and fill out the form again");
            }
            Console.ReadLine();
        }
        public void viewCustomerOrder()
        {

            Console.WriteLine("[1] Search for a customer order");
            Console.WriteLine("[2] View all orders");
            Console.WriteLine("[9] Exit");
            String userViewOrdersInput = Console.ReadLine();
            while (userViewOrdersInput != "9")
            {
                if (userViewOrdersInput == "1")
                {
                    Console.Write("Please provide a customerNo: ");
                    string userCustomerSearchValue = Console.ReadLine();
                    List<Order> viewCustomerOrder = orderList.FindAll(x => x.customerId == userCustomerSearchValue);

                    foreach (Order list in viewCustomerOrder)
                    {
                        Console.WriteLine("Customer with number: {0} have ordered {1} items of {2}", list.customerId, list.Quantity, list.skuOrder);
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    userViewOrdersInput = "9";

                }
                else if (userViewOrdersInput == "2")
                {
                    foreach (Order list in orderList)
                    {
                        Console.WriteLine("Customer with number: {0} have ordered {1} items of {2}", list.customerId, list.Quantity, list.skuOrder);

                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    userViewOrdersInput = "9";

                }

            }

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

            Product spidermanTeddy = new Product(111, "spiderman teddy", 22, 12);
            storage.Add(spidermanTeddy);

            Product hulkTeddy = new Product(112, "hulk teddy", 22, 12);
            storage.Add(hulkTeddy);

            Product batman = new Product(113, "Batman collectable", 220, 4);
            storage.Add(batman);

            Console.WriteLine("added");
        }

        static void Write(IEnumerator<CustomerClass> e)
        {
            while (e.MoveNext()) 
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
            while (e.MoveNext()) 
            {
                Product value = e.Current;
                Console.WriteLine(value.ItemName);
                Console.WriteLine(value.Quantity);
            }
        }
    }
}