namespace SOA_BioscoopCasus.Domain
{
    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private readonly bool _isPremium;
        private readonly MovieScreening _movieScreening;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this._movieScreening = movieScreening;
            this._rowNr = rowNr;
            this._seatNr = seatNr;
            this._isPremium = isPremium;
        }

        public bool isPremiumTicket()
        {
            return _isPremium;
        }

        public bool IsWeekend()
        {
            DateTime orderTicketDateTime = GetDate();
            return orderTicketDateTime.DayOfWeek == DayOfWeek.Friday || orderTicketDateTime.DayOfWeek == DayOfWeek.Saturday || orderTicketDateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public DateTime GetDate()
        {
            return this._movieScreening.GetDateAndTime();
        }

        public decimal GetPrice()
        {
            return _movieScreening.GetPricePerSeat();
        }

        public string toString()
        {
            return this._movieScreening.ToString();
        }


    }
}