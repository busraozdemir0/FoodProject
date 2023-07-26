using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutText { get; set; }
        public string AboutImageURL { get; set; }
    }
}
