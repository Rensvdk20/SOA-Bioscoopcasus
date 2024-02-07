using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Domain
{
    public class Order
    {
        private readonly int orderNr;
        private readonly bool isStudentOrder;
        private readonly List<MovieTicket> tickets = new List<MovieTicket>();
        private IExportStrategy exportStrategy;

        public Order(int orderNr, bool isStudentOrder, IExportStrategy exportStrategy)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            this.exportStrategy = exportStrategy;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            this.tickets.Add(ticket);
        }

        public int getOrderNr()
        {
            return this.orderNr;
        }

        public List<MovieTicket> getTickets()
        {
            return this.tickets;
        }

        public decimal calculatePrice()
        {
            decimal totalPrice = 0;

            for (int i = 0; i < tickets.Count; i++)
            {
                MovieTicket currentTicket = tickets[i];
                DateTime ticketDateTime = currentTicket.getDate();
                bool isWeekend = ticketDateTime.DayOfWeek == DayOfWeek.Friday || ticketDateTime.DayOfWeek == DayOfWeek.Saturday || ticketDateTime.DayOfWeek == DayOfWeek.Sunday;

                // Is the user a student?
                if (isStudentOrder) // A
                {
                    // Every 2nd ticket is free for students
                    if ((i + 1) % 2 != 0) // B
                    {
                        totalPrice += currentTicket.getPrice();

                        // Apply premium ticket cost for students
                        if (currentTicket.isPremiumTicket()) // C
                        {
                            totalPrice += 2;
                        }
                    }
                }
                else // Non-student order
                {
                    // Weekend pricing
                    if (isWeekend) // D
                    {
                        totalPrice += currentTicket.getPrice();

                        // Apply premium ticket cost for non-students
                        if (currentTicket.isPremiumTicket()) // E
                        {
                            totalPrice += 3;
                        }

                        // Apply group discount for orders with 6 or more tickets
                        if ((i + 1) == tickets.Count && tickets.Count >= 6) // F
                        {
                            totalPrice *= 0.9M;
                        }
                    }
                    else // Weekday pricing
                    {
                        // Every 2nd ticket is free for weekday screenings
                        if ((i + 1) % 2 != 0) // G
                        {
                            totalPrice += currentTicket.getPrice();

                            // Apply premium ticket cost for non-students
                            if (currentTicket.isPremiumTicket()) // H
                            {
                                totalPrice += 3;
                            }
                        }
                    }
                }
            }

            return totalPrice;
        }

        public void export()
        {
            exportStrategy.export(this);
        }
    }
}
