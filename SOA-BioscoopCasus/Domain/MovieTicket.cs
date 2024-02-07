namespace SOA_BioscoopCasus.Domain
{
    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private readonly bool isPremium;
        private readonly MovieScreening _movieScreening;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this._movieScreening = movieScreening;
            this._rowNr = rowNr;
            this._seatNr = seatNr;
            this.isPremium = isPremium;
        }

        public bool isPremiumTicket()
        {
            return isPremium;
        }

        public DateTime getDate()
        {
            return this._movieScreening.getDateAndTime();
        }

        public decimal getPrice()
        {
            return _movieScreening.getPricePerSeat();
        }

        public string toString()
        {
            return this._movieScreening.toString();
        }


    }
}