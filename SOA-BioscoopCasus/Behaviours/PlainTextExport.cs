using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Behaviours
{
    public class PlainTextExport : IExportStrategy
    {
        public void export(Order order)
        {
            Console.WriteLine($"Order Number: {order.getOrderNr()}");
            foreach (MovieTicket ticket in order.getTickets())
            {
                Console.WriteLine($"Ticket: {ticket.toString()}");
            }
        }
    }
}
