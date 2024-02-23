using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Rosenlund.Models
{
    public class Movie
    {
        [Key] // Make movie ID primary key
        public int MovieId { get; set;  }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "You must enter a title.")] // Title required
        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter a year.")]
        [Range(1888, 10000, ErrorMessage = "You must enter a year after 1888.")] // Only later than 1888
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set; }
        [MaxLength(25,ErrorMessage = "Please keep notes less than 25 characters.")] // Limit notes field
        public string? Notes { get; set; }

    }
}
