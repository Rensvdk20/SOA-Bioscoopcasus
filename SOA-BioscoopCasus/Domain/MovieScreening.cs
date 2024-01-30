using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_BioscoopCasus.Domain
{
    public class MovieScreening
    {
        private DateTime dateAndTime;
        private double pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat) {
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double getPricePerSeat()
        {
            return pricePerSeat;
        }

        public string toString()
        {
            return "";
        }
    }
}
