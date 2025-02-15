using System.ComponentModel.DataAnnotations;

namespace Mission6_MBrown.Models
{
    public class NewMovie
    {
        // Primary Key
        [Key]
        public int MovieID { get; set; }

        //category
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } 

        //title
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        //Year
        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2100, ErrorMessage = "Enter a valid year")]
        public int Year { get; set; }

        //Director
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        //Rating
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        //Edited
        public bool? Edited { get; set; }  // Optional

        //LentTo
        public string? LentTo { get; set; }  // Optional

        //Notes
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }  // Optional, limited to 25 chars
    }
}