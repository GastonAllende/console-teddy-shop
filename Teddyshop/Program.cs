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
              BusinessSystemClass BusinessSystem = new BusinessSystemClass();
              Uiclass.Run(BusinessSystem);
        }
    }
}
