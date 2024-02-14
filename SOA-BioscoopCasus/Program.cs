using SOA_BioscoopCasus.Behaviours;
using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Rules;

namespace SOA_BioscoopCasus
{
    class Program
    {
        static void Main()
        {
            IEnumerable<ITicketPriceRule> ticketPriceRules = new List<ITicketPriceRule>
            {
                new TicketBatchDiscountRule(),
                new TicketFreeRule(),
                new TicketPremiumRule()
            };

            Order order1 = new Order(1, true, ticketPriceRules, new JsonExport()); // 12 | Student met oneven aantal premium tickets
            order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
            order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 12), 1, 1, true));
            order1.export();

        }
    }
}
