using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_MBrown.Models
{
    public class Movie
    {
        // Primary Key
        [Key]
        public int MovieId { get; set; }

        //Foreign key setup for category, not required
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set;}

        //title, required with error message
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        //Year, required with error message
        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2100, ErrorMessage = "Enter a valid year")]
        public int Year { get; set; }

        //Director, not required
        public string? Director { get; set; }

        //Rating, not required
        public string? Rating { get; set; }

        //Edited, required with error message
        [Required(ErrorMessage = "Edited is required")]
        public bool Edited { get; set; }  // Optional

        //LentTo, not required
        public string? LentTo { get; set; }  // Optional
        
        //CopiedToPlex, required with error message
        [Required(ErrorMessage = "CopiedToPlex is required")]
        public bool CopiedToPlex { get; set; }  // Optional
        
        //Notes, not required, with error message and string length max
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }  // Optional, limited to 25 chars
        
    }
}
