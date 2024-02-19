using SOA_BioscoopCasus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.Interfaces
{
    public interface IOrderState
    {
        void AddSeatReservation(MovieTicket ticket);

        void SubmitOrder();

        void PayOrder();

        void CancelOrder();
    }
}
