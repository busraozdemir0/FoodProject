using Microsoft.AspNetCore.Http;

namespace FoodProject.Data
{
    public class FoodImage
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageURL { get; set; }
        public string ImageName { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
    }
}
