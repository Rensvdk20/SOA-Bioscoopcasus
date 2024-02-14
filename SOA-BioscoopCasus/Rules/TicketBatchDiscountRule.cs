using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Rules
{
    // On weekends, non-students pay full price, unless the order consist of 6 or more tickets
    public class TicketBatchDiscountRule : ITicketPriceRule
    {
        private const decimal DISCOUNT = 0.9M;
        private const int DISCOUNT_TICKET_AMOUNT = 6;


        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order)
        {
            return ticket.IsWeekend() && !order.isStudentOrder() && order.getTickets().Count() >= DISCOUNT_TICKET_AMOUNT ? currentPrice * DISCOUNT : currentPrice;
        }
    }
}
