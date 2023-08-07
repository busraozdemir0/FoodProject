using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public string FoodImage { get; set; }
        public int FoodStock { get; set; }
        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
