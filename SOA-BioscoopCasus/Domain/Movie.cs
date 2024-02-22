namespace SOA_BioscoopCasus.Domain
{
    public class Movie
    {
        private readonly string _title;
        private readonly List<MovieScreening> _movieScreenings = new List<MovieScreening>();

        public Movie(string title)
        {
            this._title = title;
        }

        public override string ToString()
        {
            return this._title;
        }
    }
}