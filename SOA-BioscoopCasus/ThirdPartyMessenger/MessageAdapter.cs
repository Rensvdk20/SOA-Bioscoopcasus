using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.ThirdPartyMessenger
{
    public class MessageAdapter
    {
        private MessengerProvider _messengerProvider;
        public MessageAdapter()
        {
            _messengerProvider = new MessengerProvider();
        }

        public void Send(string message)
        {
            _messengerProvider.SendMessage(message);
        }
    }
}
