using SOA_BioscoopCasus.Interfaces;

namespace SOA_BioscoopCasus.Observer
{
    public class Observable
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber)
        {
            this._subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
        }

        public void NotifySubscribers(string message)
        {
            foreach (var subscriber in this._subscribers)
            {
                subscriber.Update(message);
            }
        }
    }
}
