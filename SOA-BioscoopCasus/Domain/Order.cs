
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Observer;
using SOA_BioscoopCasus.States;

namespace SOA_BioscoopCasus.Domain
{
    public class Order : IOrder
    {
        private readonly int _orderNr;
        private readonly bool _isStudentOrder;
        private readonly List<MovieTicket> _tickets = new List<MovieTicket>();
        private readonly IEnumerable<ITicketPriceRule> _ticketPriceRules = new List<ITicketPriceRule>();
        private readonly IExportStrategy _exportStrategy;
        private IOrderState _currentState; // Current state of the order
        private Observable _observable = new Observable();

        public Order(int orderNr, bool isStudentOrder, IEnumerable<ITicketPriceRule> ticketPriceRule, IExportStrategy exportStrategy)
        {
            this._orderNr = orderNr;
            this._isStudentOrder = isStudentOrder;
            this._ticketPriceRules = ticketPriceRule;
            this._exportStrategy = exportStrategy;
            this._currentState = new CreatedState(this , _observable); // Start in the "Created" state
        }

        public void SetState(IOrderState newState)
        {
            this._currentState = newState;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            this._currentState.AddSeatReservation(ticket);
        }

        public int GetOrderNr()
        {
            return this._orderNr;
        }

        public List<MovieTicket> GetTickets()
        {
            return this._tickets;
        }

        public bool IsStudentOrder()
        {
            return this._isStudentOrder;
        }

        public decimal CalculatePrice()
        {
            decimal total = decimal.Zero;

            for (int i = 0; i < _tickets.Count; i++)
            {
                MovieTicket ticket = _tickets[i];
                decimal ticketPrice = ticket.GetPrice();

                foreach (var pricingRule in this._ticketPriceRules)
                {
                    if (ticketPrice > Decimal.Zero)
                        ticketPrice = pricingRule.CalculateNewPrice(ticketPrice, i + 1, ticket, this);
                }

                total += ticketPrice;
            }

            return total;
        }

        public void SubmitOrder()
        {
            this._currentState.SubmitOrder();
        }

        public void PayOrder()
        {
            this._currentState.PayOrder();
        }

        public void CancelOrder()
        {
            this._currentState.CancelOrder();
        }

        public void Export()
        {
            this._exportStrategy.export(this);
        }

        public IOrderState GetCurrentState()
        {
            return this._currentState;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _observable.Subscribe(subscriber);
        }
    }
}
