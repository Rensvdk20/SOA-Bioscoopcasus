using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Observer;

namespace SOA_BioscoopCasus.States
{
    public class CreatedState : IOrderState
    {
        private readonly IOrder _order;
        private readonly Observable _observable;

        public CreatedState(IOrder order, Observable observable)
        {
            _order = order;
            _observable = observable;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _order.GetTickets().Add(ticket);
        }

        public void SubmitOrder()
        {
            this._order.SetState(new ReservedState(_order, _observable));
        }

        public void PayOrder()
        {
            Console.WriteLine("Order moet eerst worden ingediend voordat er betaald kan worden.");
        }

        public void CancelOrder()
        {
            this._order.SetState(new CancelledState(_order, _observable));
        }
    }
}
