using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Observer;

namespace SOA_BioscoopCasus.States
{
    public class PaidState : IOrderState
    {
        private readonly IOrder _order;
        private readonly Observable _observable;

        public PaidState(IOrder order, Observable observable)
        {
            _order = order;
            _observable = observable;
            _observable.NotifySubscribers("Order is betaald.");
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
