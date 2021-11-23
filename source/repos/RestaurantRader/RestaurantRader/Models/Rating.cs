using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRader.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        //Navigation Property
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0, 10)]
        public double FoodScore { get; set; }

        [Required, Range(0, 10)]
        public double CleanlinessScore { get; set; }

        [Required, Range(0, 10)]
        public double EnvironmentScore { get; set; }

        public double AverageRating
        {
            get
            {
                var TotalScore = FoodScore + EnvironmentScore + CleanlinessScore;
                return TotalScore / 3;
            }
        }
    }
}