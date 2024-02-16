using SOA_BioscoopCasus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.States
{
    public interface IOrderState
    {
        void AddSeatReservation(MovieTicket ticket);

        void SubmitOrder();

        void PayOrder();

        void CancelOrder();
    }
}
