using System.ComponentModel.DataAnnotations;

namespace Mission6_MBrown.Models;

public class Category
{
    //primary key Category ID, connects to movies table
    [Key] 
    public int CategoryId { get; set; }
    
    //Category name (required for each entry in the categories table
    [Required]
    public string CategoryName { get; set; }
}