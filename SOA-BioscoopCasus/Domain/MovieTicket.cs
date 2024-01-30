﻿namespace SOA_BioscoopCasus.Domain
{
    public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private bool isPremium;
        private MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this.movieScreening = movieScreening;
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }

        public bool isPremiumTicket()
        {
            return isPremium;
        }

        public double getPrice()
        {
            return movieScreening.getPricePerSeat();
        }

        public string toString()
        {
            return "";
        }


    }
}