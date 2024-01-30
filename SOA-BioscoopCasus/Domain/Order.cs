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
            for (int i = 0; i < tickets.Count; i++)
            {
                // Is the user a student?
                if(isStudentOrder)
                {
                    // Every second ticket is free for students
                    if (i % 2 == 0)
                    {
                        totalPrice += tickets[i].getPrice();
                    }
                } else
                {
                    
                }
            }

            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {
            
        }
    }
}
