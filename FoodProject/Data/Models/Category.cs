using System.Collections.Generic;

namespace FoodProject.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Food> Foods { get; set; } // Bir kategori birden fazla food içinde yer alabilir.
    }
}
