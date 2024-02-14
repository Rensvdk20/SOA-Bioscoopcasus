
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Domain
{
    public class Order
    {
        private readonly int _orderNr;
        private readonly bool _isStudentOrder;
        private readonly List<MovieTicket> _tickets = new List<MovieTicket>();
        private readonly IEnumerable<ITicketPriceRule> _ticketPriceRules = new List<ITicketPriceRule>();
        private readonly IExportStrategy _exportStrategy;

        public Order(int orderNr, bool isStudentOrder, IEnumerable<ITicketPriceRule> ticketPriceRule, IExportStrategy exportStrategy)
        {
            this._orderNr = orderNr;
            this._isStudentOrder = isStudentOrder;
            this._ticketPriceRules = ticketPriceRule;
            this._exportStrategy = exportStrategy;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            this._tickets.Add(ticket);
        }

        public int getOrderNr()
        {
            return this._orderNr;
        }

        public List<MovieTicket> getTickets()
        {
            return this._tickets;
        }

        public bool isStudentOrder()
        {
            return this._isStudentOrder;
        }

        public decimal calculatePrice()
        {
            decimal total = decimal.Zero;

            for (int i = 0; i < _tickets.Count; i++)
            {
                MovieTicket ticket = _tickets[i];
                decimal ticketPrice = ticket.getPrice();

                foreach (var pricingRule in this._ticketPriceRules)
                {
                    if (ticketPrice > Decimal.Zero)
                        ticketPrice = pricingRule.CalculateNewPrice(ticketPrice, i + 1, ticket, this);
                }

                total += ticketPrice;
            }

            return total;
        }

        public void export()
        {
            this._exportStrategy.export(this);
        }
    }
}
