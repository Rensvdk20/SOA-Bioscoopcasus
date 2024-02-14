using SOA_BioscoopCasus.Domain;

namespace SOA_BioscoopCasus.Interfaces
{
    public interface ITicketPriceRule
    {
        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order);
    }
}
