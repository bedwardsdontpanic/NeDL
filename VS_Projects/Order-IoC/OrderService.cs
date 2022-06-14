using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_IoC
{
    public class OrderService
    {
        private IOrderSaver orderSaver;


        public OrderService(IOrderSaver orderSaver)
        {
            this.orderSaver = orderSaver;
        }

        public OrderService()
        {
            this.orderSaver = new OrderDatabase();
        }

        public void AcceptOrder(Order order)
        {
            //Domain logic such as validation

            orderSaver.SaveOrder(order);
        }


    }
}
