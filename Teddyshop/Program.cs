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
            BusinessSystem.initiateProducts();
            BusinessSystem.placeCustomerOrder();

        }

    }


   
    }


