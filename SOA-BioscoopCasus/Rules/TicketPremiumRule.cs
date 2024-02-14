using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Rules
{
    public class TicketPremiumRule: ITicketPriceRule
    {
        private const decimal SURCHARGE_STUDENTS = 2M;
        private const decimal SURCHARGE_NON_STUDENTS = 3M;

        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order)
        {
            if (!ticket.isPremiumTicket()) 
                return currentPrice;

            return currentPrice + (order.isStudentOrder() ? SURCHARGE_STUDENTS : SURCHARGE_NON_STUDENTS);
        }
    }
}
