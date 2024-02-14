using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Rules
{
    public class TicketFreeRule: ITicketPriceRule
    {
        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order)
        {
            return (order.isStudentOrder() || !ticket.IsWeekend()) && ticketOrder % 2 == 0 ? decimal.Zero : currentPrice;
        }
    }
}
