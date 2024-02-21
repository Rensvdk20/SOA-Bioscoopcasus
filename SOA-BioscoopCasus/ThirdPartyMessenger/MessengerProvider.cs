using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.ThirdPartyMessenger
{
    public class MessengerProvider
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
