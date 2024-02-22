using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.ThirdPartyMessenger;

namespace SOA_BioscoopCasus.Listeners
{
    public class SmsSubscriber : ISubscriber
    {
        private MessageAdapter _messageAdapter = new MessageAdapter();

        public void Update(string message)
        {
            _messageAdapter.Send("SMS: " + message);
        }
    }
}
