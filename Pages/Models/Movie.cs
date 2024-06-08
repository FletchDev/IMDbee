using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IMDbee.Pages.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is required")]
        [StringLength(100, ErrorMessage = "Director can't be longer than 100 characters")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1888 and 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
        public float Rating { get; set; }
    }
}
