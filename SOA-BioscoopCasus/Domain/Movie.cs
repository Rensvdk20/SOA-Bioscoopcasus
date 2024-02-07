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

        //public void addScreening(MovieScreening screening)
        //{
        //    _movieScreenings.Add(screening);
        //}

        //public string getTitle()
        //{
        //    return _title;
        //}

        public string toString()
        {
            return this._title;
        }
    }
}