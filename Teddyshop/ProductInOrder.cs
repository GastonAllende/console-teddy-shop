using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{
    public class ProductsInOrder
    {
        public Product product { get; set; }
        public int productQuantity { get; set; }

        public ProductsInOrder(Product p, int pq)
        {
            product = p;
            productQuantity = pq;
        }
    }
}
