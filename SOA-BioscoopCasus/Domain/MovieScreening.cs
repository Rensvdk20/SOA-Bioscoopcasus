namespace SOA_BioscoopCasus.Domain
{
    public class MovieScreening
    {
        private readonly DateTime _dateAndTime;
        private readonly decimal _pricePerSeat;
        private readonly Movie _movie;

        public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat) {
            this._movie = movie;
            this._dateAndTime = dateAndTime;
            this._pricePerSeat = pricePerSeat;
        }

        public DateTime GetDateAndTime()
        {
            return _dateAndTime;
        }

        public decimal GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public override string ToString()
        {
            return _movie.ToString();
        }
    }
}
