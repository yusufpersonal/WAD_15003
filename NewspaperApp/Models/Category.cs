using System.ComponentModel.DataAnnotations;

namespace NewspaperApp15003.Models
{
    public class Category
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "Title of the category required!")]
        public string Title { get; set; }


    }
}
