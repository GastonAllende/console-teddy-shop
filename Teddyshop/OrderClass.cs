using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{
    public class Order
    {

        static int countOrder = 1010;

        List<ProductsInOrder> productsinOrder = new List<ProductsInOrder>();
        public CustomerClass customerInOrder { get; set; }
        public int orderNr { get; set; }

        public Order(List<ProductsInOrder> productsToBuy, CustomerClass customer)
        {
            countOrder++;
            this.orderNr = countOrder;
            customerInOrder = customer;

            foreach (ProductsInOrder item in productsToBuy)
            {
                productsinOrder.Add(item);
            }
        }
       
        public List<ProductsInOrder> GetProductList()
        {
            return productsinOrder;
        }

    }
}


