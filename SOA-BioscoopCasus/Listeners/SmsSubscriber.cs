using SOA_BioscoopCasus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.Listeners
{
    public class SmsSubscriber : ISubscriber
    {
        public void Update(string message)
        {
            Console.WriteLine("SMS: " + message);
        }
    }
}
