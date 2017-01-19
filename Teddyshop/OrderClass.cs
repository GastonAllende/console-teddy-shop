using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{

        public class Order
        {
            public int skuOrder { get; set; }
            public string customerId { get; set; }
            public int Quantity { get; set; }

        public void transaction()
            {
                this.skuOrder = skuOrder;
                this.customerId = customerId;
                this.Quantity = Quantity;
    }

          

            }
        
 
}
