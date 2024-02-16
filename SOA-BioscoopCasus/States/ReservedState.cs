using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.States
{
    public class ReservedState : IOrderState
    {
        private readonly IOrder _order;

        public ReservedState(Order order)
        {
            _order = order;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            throw new InvalidOperationException("Order kan niet worden aangepast als deze al is gereserveerd.");
        }

        public void SubmitOrder()
        {
            throw new InvalidOperationException("Order is al gereserveerd.");
        }

        public void PayOrder()
        {
            this._order.PayOrder();
        }

        public void CancelOrder()
        {
            this._order.CancelOrder();
        }
    }
}
