using FoodProject.Data.Models;

namespace FoodProject.Data
{
    public class ShoppingViewModel
    {
        public int FoodID { get; set; }      
        public int AppUserID { get; set; }
        public double FoodPrice { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }


    }
}
