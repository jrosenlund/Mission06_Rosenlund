using System.ComponentModel.DataAnnotations;

namespace Mission06_Rosenlund.Models
{
    public class Movie
    {
        [Key] // Make movie ID primary key
        public int Movie_ID { get; set;  }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Category { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        // "Edited" set as string b/c bool was giving me errors, but still only outputs 'true' and 'false'
        public string? Edited { get; set; }
        public string? Lent_To { get; set; }
        [Range(0, 25)] // Limit notes field
        public string? Notes { get; set; }

    }
}
