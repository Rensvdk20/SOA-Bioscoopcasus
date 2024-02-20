using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Behaviours
{
    public class PlainTextExport : IExportStrategy
    {
        public void export(Order order)
        {
            Console.WriteLine($"Order Number: {order.GetOrderNr()}");
            foreach (MovieTicket ticket in order.GetTickets())
            {
                Console.WriteLine($"Ticket: {ticket.toString()}");
            }
        }
    }
}
