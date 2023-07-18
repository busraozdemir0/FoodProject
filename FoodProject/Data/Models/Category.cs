using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category Name Not Empty")]
        [StringLength(50,ErrorMessage ="Please only enter 3-50 characters",MinimumLength = 3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; } = true;
        public List<Food> Foods { get; set; } // Bir kategori birden fazla food içinde yer alabilir.
    }
}
