using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class FormResponse
    {
        //Add all of the columns we need for the form and add validation
        [Key]
        [Required]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "Category selection is invalid")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]

        public int Year { get; set; }

        [Required(ErrorMessage = "Rating selection is invalid")]

        public string Rating { get; set; }

        public bool Edited { get; set; }
        
        public string Lent_To { get; set; }

        public string Notes { get; set; }

    }
}
