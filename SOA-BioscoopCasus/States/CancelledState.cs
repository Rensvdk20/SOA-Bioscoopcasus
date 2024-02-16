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
            throw new InvalidOperationException("Geannuleerde order kan niet worden aangepast.");
        }

        public void SubmitOrder()
        {
            throw new InvalidOperationException("Geannuleerde order kan niet worden ingediend.");
        }

        public void PayOrder()
        {
            throw new InvalidOperationException("Geannuleerde order kan niet worden betaald.");
        }

        public void CancelOrder()
        {
            throw new InvalidOperationException("Order is al geannuleerd.");
        }
    }
}
