using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_IoC
{
    public class ServiceLocator
    {
        public static IOrderSaver OrderSaver { get; set; }

        public static IOrderSaver GetOrderSaver()
        {
            if (OrderSaver == null)
            {
                OrderSaver = new OrderDatabase();
            }

            return OrderSaver;
        }
    }
}
