using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.States
{
    public class CreatedState : IOrderState
    {
        private readonly IOrder _order;

        public CreatedState(Order order)
        {
            _order = order;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _order.GetTickets().Add(ticket);
        }

        public void SubmitOrder()
        {
            this._order.SubmitOrder();
            this._order.SetState(this._order.GetReservedState());
        }

        public void PayOrder()
        {
            Console.WriteLine("Order moet eerst worden ingediend voordat er betaald kan worden.");
        }

        public void CancelOrder()
        {
            this._order.CancelOrder();
            this._order.SetState(this._order.GetCancelledState());
        }
    }
}
