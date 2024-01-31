using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.Domain
{
    public class Order
    {
        private int orderNr;
        private bool isStudentOrder;
        private List<MovieTicket> tickets = new List<MovieTicket>();

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        public int getOrderNr()
        {
            return this.orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            this.tickets.Add(ticket);
        }

        public double calculatePrice()
        {
            double totalPrice = 0;
            bool isWeekend = DateTime.Now.DayOfWeek == DayOfWeek.Friday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;

            for (int i = 0; i < tickets.Count; i++)
            {
                MovieTicket currentTicket = tickets[i];

                // Is the user a student?
                if (isStudentOrder)
                {
                    // Every 2nd ticket is free for students or for weekday screenings
                    if (i % 2 == 0 || !isWeekend)
                    {
                        totalPrice += currentTicket.getPrice();
                    }

                    // Apply premium ticket cost for students
                    if (currentTicket.isPremiumTicket())
                    {
                        totalPrice += 2.0;
                    }
                }
                else // Non-student order
                {
                    // Weekend pricing
                    if (isWeekend)
                    {
                        // Apply group discount for orders with 6 or more tickets
                        if (tickets.Count >= 6)
                        {
                            totalPrice += currentTicket.getPrice() * 0.9;
                        }
                        else
                        {
                            totalPrice += currentTicket.getPrice();
                        }
                    }
                    else // Weekday pricing
                    {
                        // Every 2nd ticket is free for weekday screenings
                        if (i % 2 == 0)
                        {
                            totalPrice += currentTicket.getPrice();
                        }
                    }

                    // Apply premium ticket cost for non-students
                    if (currentTicket.isPremiumTicket())
                    {
                        totalPrice += 3.0;
                    }
                }
            }

            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {
            
        }
    }
}
