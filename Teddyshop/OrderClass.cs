using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddyshop
{

        public class Order
        {
            public String skuOrder { get; set; }
            public String customerId { get; set; }
            public int Quantity { get; set; }

        public void transaction()
            {
                this.skuOrder = skuOrder;
                this.customerId = customerId;
                this.Quantity = Quantity;
    }

          

            }
        
 
}
