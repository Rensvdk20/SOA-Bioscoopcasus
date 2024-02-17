using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.States
{
    public class PaidState : IOrderState
    {
        private readonly IOrder _order;

        public PaidState(Order order)
        {
            _order = order;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            Console.WriteLine("Order kan niet worden aangepast nadat deze is betaald.");
        }

        public void SubmitOrder()
        {
            Console.WriteLine("Order is al betaald.");
        }

        public void PayOrder()
        {
            Console.WriteLine("Order is al betaald.");
        }

        public void CancelOrder()
        {
            Console.WriteLine("Order kan niet worden geannuleerd nadat deze is betaald.");
        }
    }
}
