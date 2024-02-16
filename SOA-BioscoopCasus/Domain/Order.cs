
using SOA_BioscoopCasus.Interfaces;
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
        private IOrderState _currentState; // Huidige staat van de order

        public Order(int orderNr, bool isStudentOrder, IEnumerable<ITicketPriceRule> ticketPriceRule, IExportStrategy exportStrategy)
        {
            this._orderNr = orderNr;
            this._isStudentOrder = isStudentOrder;
            this._ticketPriceRules = ticketPriceRule;
            this._exportStrategy = exportStrategy;
            this.SetState(new CreatedState(this)); // Begint in de "Created" staat
        }

        public void SetState(IOrderState newState)
        {
            // Hier moet nog een SetState methode worden geïmplementeerd.
            // Gezien we een lineare volgorde hebben (aanmaken, annuleren/reserveren, betalen) hebben we geen previousState nodig.
            // Ik weet dus niet hoe we dit moeten implementeren.
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
    }
}
