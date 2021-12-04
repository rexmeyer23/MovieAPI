using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Data
{
    public enum MovieMaturityRating
    {
        G = 1,
        PG,
        PG_13,
        R,
        NC_17,
        TV_MA,
        NR
    }

    public enum MovieGenre
    {
        TV_Drama,
        Comedy,
        Factual,
        Entertainment,
        Sports,
        MusicTv,
        Children,
        Horror,
        Thriller,
        Romantic_Comedy,
        Drama,
        Action,
        Romance,
        Documentary,
        Fantasy,
        Western,
        Sci_Fi,
        Musical,
        Crime,
        Historical
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public MovieMaturityRating MovieMaturityRating { get; set; }
        public MovieGenre TypeOfGenre { get; set; }

        public Movie(string title, string description, double starRating, MovieMaturityRating movieMaturityRating, MovieGenre genreType)
        {
            Title = title;
            Description = description;
            StarRating = starRating;
            MovieMaturityRating = movieMaturityRating;
            TypeOfGenre = genreType;
        }
    }
}
