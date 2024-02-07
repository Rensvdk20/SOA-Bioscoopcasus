using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Behaviours
{
    public class JsonExport: IExportStrategy
    {
        public void export(Order order)
        {
            Console.WriteLine(
                "{\n" +
                $"\u0020\u0020\"orderNr\": {order.getOrderNr()}, \n" +
                $"\u0020\u0020\"tickets\": ["
            );

            MovieTicket lastTicket = order.getTickets().Last();
            foreach (MovieTicket ticket in order.getTickets())
            {
                Console.WriteLine(
                    "\u0020\u0020\u0020\u0020{" +
                    $"\"ticket\": \"{ticket.toString()}\"" +
                    (ticket.Equals(lastTicket) ? "}" : "},")
                );
            }
            Console.WriteLine(
                "\u0020\u0020]\n" +
                "}"
            );
        }
    }
}
