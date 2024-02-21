using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Observer;

namespace SOA_BioscoopCasus.States
{
    public class ReservedState : IOrderState
    {
        private readonly IOrder _order;
        private readonly Observable _observable;

        public ReservedState(IOrder order, Observable observable)
        {
            _order = order;
            _observable = observable;
            _observable.NotifySubscribers("Order is gereserveerd.");
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            Console.WriteLine("Order kan niet worden aangepast als deze al is gereserveerd.");
        }

        public void SubmitOrder()
        {
            Console.WriteLine("Order is al gereserveerd.");
        }

        public void PayOrder()
        {
            this._order.SetState(new PaidState(_order, _observable));
        }

        public void CancelOrder()
        {
            this._order.SetState(new CancelledState(_order, _observable));
        }
    }
}
