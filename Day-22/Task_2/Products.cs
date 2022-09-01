using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class Products:Iproducts
    {
        public int p_id { get; set; }
        public string p_name { get; set; }
        public int p_qty { get; set; }
        public int p_price { get; set; }
        public int c_id { get; set; }

        public bool checkQty(int qty)
        {
            if(qty > 20)
                return true;
            return false;
        }
    }
}
