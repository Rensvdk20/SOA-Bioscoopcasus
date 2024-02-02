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
        private decimal pricePerSeat;
        private Movie movie;

        public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat) {
            this.movie = movie;
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public decimal getPricePerSeat()
        {
            return pricePerSeat;
        }

        public string toString()
        {
            return this.movie.toString();
        }
    }
}
