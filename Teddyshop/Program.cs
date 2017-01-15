using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Teddyshop
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            //Console.ReadLine();
            MainProg prog = new MainProg();
            prog.Run();
        }
    }

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
                ManualCustomerRegistration.HomeZipCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Social security number : ");
                ManualCustomerRegistration.SSN = Convert.ToInt32(Console.ReadLine());
                ManualCustomerRegistration.CustomerNo = Console.ReadLine();

                Console.WriteLine("\n You have provided the following details, would you like to add the customer?\n");

                Console.Write("Y/N");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    listCustomers.Add(ManualCustomerRegistration);

                    Console.WriteLine("Customer: {0} was added", ManualCustomerRegistration.FirstName);

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


    class MainProg
    {
        public BusinessSystemClass<CustomerClass> BusinessSystem; //Deklareread för åtkomst för alla klasser
        public void Run()
        {
            BusinessSystem = new BusinessSystemClass<CustomerClass>();
            BusinessSystem.InitiateCustomerBase();
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("[1] Add new product");
                Console.WriteLine("[2] Change price for one product");  //product()
                Console.WriteLine("[3] Storage - Change number of products in storage");
                Console.WriteLine("[4] Registrate a new customer (name, adress)"); //registerNewCustomer()
                Console.WriteLine("[5] Add a new order for a customer");
                Console.WriteLine("[6] Change a current order (amount of products)");
                Console.WriteLine("[7] Show all orders for a customer");
                Console.WriteLine("[8] Quit (cancel) a order");
                Console.WriteLine("[9] Exit program");

                input = Console.ReadLine();

                //ConsoleKeyInfo key = Console.ReadKey();

                //switch (key.Key.ToString().ToUpper())
                switch(input)
                {
                    case "1":
                        // call the method addNewProduct
                        //addNewProduct();
                        break;

                    case "2":
                        // call the method changePriceProduct()
                        //changePriceProduct();
                        break;

                    case "3":
                        // call the method changeNumberOfProducts()
                        //changeNumberOfProducts();
                        break;

                    case "4":
                        // call the method registerNewCustomer()
                        BusinessSystem.registerNewCustomer();
                        break;

                    case "5":
                        // call the method addNewOrderCustomer()
                        //addNewOrderCustomer();
                        break;

                    case "6":
                        // call the method changeCurrentOrder()
                        //changeCurrentOrder();
                        break;

                    case "7":
                        // call the method showAllOrdersCustomer()
                        //showAllOrdersCustomer;
                        break;

                    case "8":
                        // call the method cancelOrder()
                        //cancelOrder();
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
