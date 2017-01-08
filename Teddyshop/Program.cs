using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Teddyshop
{
    class Program
    {
        

        static void Main(string[] args)
        {
            BusinessSystemClass<CustomerClass> BusinessSystem = new BusinessSystemClass<CustomerClass>();
            BusinessSystem.InitiateCustomerBase();
            Console.ReadLine();

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

}
