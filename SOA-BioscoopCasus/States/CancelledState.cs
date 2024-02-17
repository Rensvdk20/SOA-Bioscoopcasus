using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.States
{
    public class CancelledState : IOrderState
    {
        private readonly IOrder _order;

        public CancelledState(Order order)
        {
            _order = order;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            Console.WriteLine("Geannuleerde order kan niet worden aangepast.");
        }

        public void SubmitOrder()
        {
            Console.WriteLine("Geannuleerde order kan niet worden ingediend.");
        }

        public void PayOrder()
        {
            Console.WriteLine("Geannuleerde order kan niet worden betaald.");
        }

        public void CancelOrder()
        {
            Console.WriteLine("Order is al geannuleerd.");
        }
    }
}
