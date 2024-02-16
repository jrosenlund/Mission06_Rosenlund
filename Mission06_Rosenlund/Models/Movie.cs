using System.ComponentModel.DataAnnotations;

namespace Mission06_Rosenlund.Models
{
    public class Movie
    {
        [Key]
        public int Movie_ID { get; set;  }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Category { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public int? Edited { get; set; }
        public string? Lent_To { get; set; }
        [Range(0, 25)]
        public string? Notes { get; set; }

    }
}
