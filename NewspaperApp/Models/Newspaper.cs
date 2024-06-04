using NewspaperApp15003.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewspaperApp15003.Models
{
    public class Newspaper
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title of the Newspaper is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price of the neswpaper is required!")]
        [Range(0.1, Double.MaxValue, ErrorMessage ="Min price value is 0.1!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Category of the newspaper is required!")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }

}