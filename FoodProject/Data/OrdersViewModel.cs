using FoodProject.Data.Models;

namespace FoodProject.Data
{
    public class OrdersViewModel
    {
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public string FoodImage { get; set; }
        public int FoodStock { get; set; }
        public double ShoppingTotal { get; set; }


    }
}
