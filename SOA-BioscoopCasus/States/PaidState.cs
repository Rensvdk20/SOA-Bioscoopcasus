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
            throw new InvalidOperationException("Order kan niet worden aangepast nadat deze is betaald.");
        }

        public void SubmitOrder()
        {
            throw new InvalidOperationException("Order is al betaald.");
        }

        public void PayOrder()
        {
            throw new InvalidOperationException("Order is al betaald.");
        }

        public void CancelOrder()
        {
            throw new InvalidOperationException("Order kan niet worden geannuleerd nadat deze is betaald.");
        }
    }
}
