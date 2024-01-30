namespace SOA_BioscoopCasus.Domain
{
    public class Movie
    {
        private string title;
        private List<MovieScreening> movieScreenings = new List<MovieScreening>();

        public Movie(string title)
        {
            this.title = title;
        }

        public void addScreening(MovieScreening screening)
        {
            movieScreenings.Add(screening);
        }

        public string toString()
        {
            return this.title;
        }
    }
}