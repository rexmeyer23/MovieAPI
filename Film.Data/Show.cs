using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Data
{
    public enum ShowMaturityRating
    {
        TV_Y = 1,
        TV_Y7,
        TV_Y7_FV, //Fantasy Violence
        TV_G,
        TV_PG,
        TV_14,
        TV_MA
    }

    public enum ShowGenre
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
    public class Show
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public ShowMaturityRating ShowMaturityRating { get; set; }
        public ShowGenre TypeOfGenre { get; set; }

        public Show(string title, string description, double starRating, ShowMaturityRating showMaturityRating, ShowGenre genreType)
        {
            Title = title;
            Description = description;
            StarRating = starRating;
            ShowMaturityRating = showMaturityRating;
            TypeOfGenre = genreType;
        }
    }
}
