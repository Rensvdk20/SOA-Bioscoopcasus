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

        public DateTime getDateAndTime()
        {
            return dateAndTime;
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
