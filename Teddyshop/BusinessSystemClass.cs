using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Teddyshop
{
    public class BusinessSystemClass
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

        public void initiateProducts()
        {

            Product spidermanTeddy = new Product("spiderman teddy", 22, 100);
            storage.Add(spidermanTeddy);

            Product hulkTeddy = new Product("hulk teddy", 22, 100);
            storage.Add(hulkTeddy);

            Product batman = new Product("Batman collectable", 220, 100);
            storage.Add(batman);

            Console.WriteLine("added");
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

            List<ProductsInOrder> productsToBuy = new List<ProductsInOrder>();
            bool truish = true;

            do
            {
                Console.WriteLine(" -- Customers -- ");
                foreach (CustomerClass items in listCustomers)
                {
                    Console.WriteLine("Customer number: {0} - Firstname: {1} - Lastname: {2} -", items.CustomerNo, items.FirstName, items.LastName);
                }

                Console.WriteLine("Choose a customer or write Exit to return to: ");
                string userInputCustomer = Console.ReadLine();

                if (userInputCustomer.ToUpper() == "EXIT")
                {
                    truish = false;
                    return;
                }

                CustomerClass customerSearch = listCustomers.Find(x => x.CustomerNo == userInputCustomer);

                if (customerSearch != null)
                {

                    bool addItem = true;

                    do
                    {
                        try
                        {

                            bool haveProduct = false;
                            Console.WriteLine("Currently, we have these items in stock. Write down the items sku number to begin a purchase ");
                            foreach (Product items in storage)
                            {
                                Console.WriteLine("Item number: {0} - Name: {1} - Price: {2} - Quantity: {3} ", items.Sku, items.ItemName, items.Price, items.Quantity);
                            }

                            Console.Write("Choose a product by item number: ");
                            int userInputsku = Convert.ToInt32(Console.ReadLine());

                            Product productSearch = storage.Find(x => x.Sku == userInputsku);

                            foreach (ProductsInOrder items in productsToBuy)
                            {
                                if (items.product.Sku == userInputsku)
                                {
                                    Console.WriteLine("You already choosen that product");
                                    Console.ReadKey();
                                    haveProduct = true;
                                }
                            }

                            if (!haveProduct)
                            {
                                
                                if (productSearch != null)
                                {

                                    Console.WriteLine("Number of found items: {0}, how many would you like to purchase?", productSearch.Quantity);
                                    Console.Write("# ");
                                    int NoOfPurchaseOrders = Convert.ToInt32(Console.ReadLine());

                                    if (productSearch.Quantity >= NoOfPurchaseOrders && !String.IsNullOrEmpty(NoOfPurchaseOrders.ToString()))
                                    {

                                        ProductsInOrder newProduct = new ProductsInOrder(productSearch, NoOfPurchaseOrders);
                                        productsToBuy.Add(newProduct);
                                        productSearch.Quantity = productSearch.Quantity - NoOfPurchaseOrders;

                                        Console.WriteLine("Do you want to add a new product - Y/N");
                                        string inputYesOrNo = Console.ReadLine();

                                        if (inputYesOrNo.ToUpper() == "Y")
                                        {
                                            addItem = true;
                                        }
                                        else
                                        {
                                            Order order = new Order(productsToBuy, customerSearch);
                                            orderList.Add(order);
                                            Console.WriteLine("Congratulations! your order was successfully processed");
                                            Console.ReadKey();

                                            addItem = false;
                                            truish = false;
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Yo have choosen to many items");
                                        Console.ReadKey();
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("That item do not exist!");
                                    Console.ReadKey();
                                }

                            }
                            else
                            {
                                addItem = true;
                            }
                           
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Bad Format");
                            addItem = true;
                        }
                    } while (addItem);

                }
                else {
                    Console.WriteLine("That customer do not exist!");
                    Console.ReadKey();
                }

            } while (truish);

        }

        public void viewCustomerOrder()
        {

            Console.WriteLine(" -- Customers -- ");
            foreach (CustomerClass items in listCustomers)
            {
                Console.WriteLine("Customer number: {0} - Firstname: {1} - Lastname: {2} -", items.CustomerNo, items.FirstName, items.LastName);
            }


            Console.Write("Please provide a customerNo: ");
            string userCustomerSearchValue = Console.ReadLine();
            Console.WriteLine(userCustomerSearchValue);


            List<Order> viewCustomerOrder = orderList.FindAll(x => x.customerInOrder.CustomerNo == userCustomerSearchValue);


            if (viewCustomerOrder.Count != 0)
            {
                Console.WriteLine("Orders for customer with number:" + userCustomerSearchValue);

                foreach (Order list in viewCustomerOrder)
                {

                    Console.WriteLine(" -- Order -- " + list.orderNr);
                    foreach (ProductsInOrder items in list.GetProductList())
                    {
                        Console.WriteLine("You have {0} pieces of {1} with sku-nr {2} ", items.productQuantity, items.product.ItemName, items.product.Sku);
                    }

                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That Customer does not exist or does not have orders");
                Console.ReadKey();
            }

        }

        public void changeProductInOrder()
        {
            Console.WriteLine(" -- Customers -- ");
            foreach (CustomerClass items in listCustomers)
            {
                Console.WriteLine("Customer number: {0} - Firstname: {1} - Lastname: {2} -", items.CustomerNo, items.FirstName, items.LastName);
            }


            Console.Write("Please provide a customerNo: ");
            string userCustomerSearchValue = Console.ReadLine();
            Console.WriteLine(userCustomerSearchValue);

            List<Order> viewCustomerOrder = orderList.FindAll(x => x.customerInOrder.CustomerNo == userCustomerSearchValue);

            if (viewCustomerOrder.Count != 0)
            {
                Console.WriteLine("Orders for customer with number:" + userCustomerSearchValue);

                foreach (Order list in viewCustomerOrder)
                {

                    Console.WriteLine(" -- Order -- " + list.orderNr);
                    foreach (ProductsInOrder items in list.GetProductList())
                    {
                        Console.WriteLine("You have {0} pieces of {1} with sku-nr {2} ", items.productQuantity, items.product.ItemName, items.product.Sku);
                    }

                }

                Console.WriteLine("Please provide the order-nr of the order you want to change the product: ");
                Console.WriteLine("Order-nr#: ");
                int userInputOrderNr = int.Parse(Console.ReadLine());

                Order orderToChange = orderList.Find(x => x.orderNr == userInputOrderNr);

                if (orderToChange != null)
                {
                    List<ProductsInOrder> productsInOrder = orderToChange.GetProductList();

                    foreach (ProductsInOrder items in productsInOrder)
                    {
                        Console.WriteLine("Product number: {0} - Item name: {1} ", items.product.Sku, items.product.ItemName);
                        Console.WriteLine("Product quantity: {0}", items.productQuantity);

                    }

                    Console.WriteLine("Wish product to you want to change?");
                    Console.WriteLine("Product-nr#");

                    try
                    {
                        int productSkuNr = int.Parse(Console.ReadLine());

                        ProductsInOrder productSearch = productsInOrder.Find(x => x.product.Sku == productSkuNr);

                        if (productSearch != null)
                        {

                            Product getProductInStorage = storage.Find(x => x.Sku == productSkuNr);
                            bool changeQuantity = true;

                            do
                            {
                                try
                                {

                                    Console.WriteLine("New quantity");
                                    int productAdd = int.Parse(Console.ReadLine());

                                    int totalQuantity = getProductInStorage.Quantity + productSearch.productQuantity;

                                    if (productAdd <= totalQuantity)
                                    {
                                        getProductInStorage.Quantity = getProductInStorage.Quantity + productSearch.productQuantity;
                                        productSearch.productQuantity = productAdd;
                                        getProductInStorage.Quantity = getProductInStorage.Quantity - productAdd;
                                        changeQuantity = false;

                                        Console.WriteLine("Changes made to the product-nr {0}", productSearch.product.Sku);
                                    }
                                    else
                                    {
                                        Console.WriteLine("We dont have that much");
                                        changeQuantity = true;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Bad Format");
                                    changeQuantity = true;
                                }

                            } while (changeQuantity);
                        }
                        else
                        {
                            Console.WriteLine("That product dont exist in the order");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Bad Format");
                    }

                }
                else
                {
                    Console.WriteLine("That order does not exist");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That Customer does not exist or does not have orders");
                Console.ReadKey();
            }
        }

        public void cancelOrder()
        {
            Console.WriteLine(" -- Customers -- ");
            foreach (CustomerClass items in listCustomers)
            {
                Console.WriteLine("Customer number: {0} - Firstname: {1} - Lastname: {2} -", items.CustomerNo, items.FirstName, items.LastName);
            }


            Console.Write("Please provide a customerNo: ");
            string userCustomerSearchValue = Console.ReadLine();
            Console.WriteLine(userCustomerSearchValue);

            List<Order> viewCustomerOrder = orderList.FindAll(x => x.customerInOrder.CustomerNo == userCustomerSearchValue);

            if (viewCustomerOrder.Count != 0)
            {
                Console.WriteLine("Orders for customer with number: {0}", userCustomerSearchValue);

                foreach (Order list in viewCustomerOrder)
                {

                    Console.WriteLine(" -- Order -- " + list.orderNr);
                    foreach (ProductsInOrder items in list.GetProductList())
                    {
                        Console.WriteLine("You have {0} pieces of {1} with sku-nr {2} ", items.productQuantity, items.product.ItemName, items.product.Sku);
                    }

                }

                try
                {
                    Console.WriteLine("Please provide the order-nr of the order you want to cancel: ");
                    Console.WriteLine("#: ");
                    int userInputOrderNr = int.Parse(Console.ReadLine());

                    Order orderToRemove = orderList.Find(x => x.orderNr == userInputOrderNr);

                    if (orderToRemove != null)
                    {

                        foreach (ProductsInOrder items in orderToRemove.GetProductList())
                        {
                            Product productSearch = storage.Find(x => x.Sku == items.product.Sku);
                            productSearch.Quantity = productSearch.Quantity + items.productQuantity;
                        }

                        orderList.Remove(orderToRemove);
                        Console.WriteLine("The order was removed");

                    }
                    else
                    {
                        Console.WriteLine("No order with that number");
                    }



                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format");
                    Console.ReadKey();
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That customer has no orders");
                Console.ReadKey();
            }

        }

        public void addNewProduct()
        {
            bool continueAdd = true;
            do
            {
                try
                {
                    Console.WriteLine("Name of the product: ");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Price of the product: ");
                    int productPriceInt = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("How many products: ");
                    int productQuantityInt = Int32.Parse(Console.ReadLine());

                    Product newProduct = new Product(productName, productPriceInt, productQuantityInt);
                    storage.Add(newProduct);

                    Console.WriteLine("Do you want to add another product - Y/N");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "Y")
                    {
                        continueAdd = true; // Continue to add if the answer is yes = Y
                    }
                    else if (answer.ToUpper() == "N")
                    {
                        continueAdd = false;
                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format try again");
                    continueAdd = true;
                }

            } while (continueAdd);

        }

        public void changePriceProduct()
        {
            // show all the product in storage
            foreach (Product item in storage)
            {
                Console.WriteLine(item.ToString());
            }

            try
            {
                Console.WriteLine("Write sku-nr of the product you want to change the price");
                int skuInput = Int32.Parse(Console.ReadLine());

                Product ProductToChange = storage.Find(x => x.Sku == skuInput); // Find the product

                if (ProductToChange != null) // does the product exist if not dont to nothing
                {

                    Console.WriteLine("Write the new price");
                    int newPrice = Int32.Parse(Console.ReadLine());

                    ProductToChange.Price = newPrice;
                    Console.WriteLine("Change the price of {0}  with SKU-nr {1}", ProductToChange.ItemName, ProductToChange.Sku);
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("That product do not exist");
                    Console.ReadKey();
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Bad Format");
                Console.ReadKey();
            }
        }

        public void changeNumberOfProducts()
        {
            // show all the product in storage
            foreach (Product item in storage)
            {
                Console.WriteLine(item.ToString());
            }

            try
            {

                Console.WriteLine("Write sku-nr of the product you want to change the quantity");
                int skuInput = Int32.Parse(Console.ReadLine());

                Product ProductToChange = storage.Find(x => x.Sku == skuInput); // Find the product


                if (ProductToChange != null) // If the product not exist dont to nothing
                {

                    Console.WriteLine("The product ({0}){1} has a quantity of: {2}", ProductToChange.Sku, ProductToChange.ItemName, ProductToChange.Quantity);
                    Console.WriteLine("Write the new quantity for that product");
                    int newQuantity = Int32.Parse(Console.ReadLine());

                    ProductToChange.Quantity = newQuantity;

                    Console.WriteLine("Change the quantity of {0} with SKU-nr {1}", ProductToChange.ItemName, ProductToChange.Sku);
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("That product do not exist");
                    Console.ReadKey();
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Bad Format");
                Console.ReadKey();
            }
        }

    }
}