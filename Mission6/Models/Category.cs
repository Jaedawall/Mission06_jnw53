using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    //Create the category table
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
