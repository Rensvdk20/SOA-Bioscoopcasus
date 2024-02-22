using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.Interfaces
{
    public interface ISubscriber
    {
        void Update(string message);
    }
}
