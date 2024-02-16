using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.Interfaces
{
    public interface IOrder
    {
        void SetState(IOrderState newState);

        void AddSeatReservation(MovieTicket ticket);

        int GetOrderNr();

        List<MovieTicket> GetTickets();

        bool IsStudentOrder();

        decimal CalculatePrice();

        void SubmitOrder();

        void PayOrder();

        void CancelOrder();

        void Export();
    }
}
