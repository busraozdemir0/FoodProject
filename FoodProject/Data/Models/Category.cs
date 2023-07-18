using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category Name Not Empty")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Food> Foods { get; set; } // Bir kategori birden fazla food içinde yer alabilir.
    }
}
