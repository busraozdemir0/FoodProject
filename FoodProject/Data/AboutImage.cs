using Microsoft.AspNetCore.Http;

namespace FoodProject.Data
{
    public class AboutImage
    {
        public string AboutTitle { get; set; }
        public string AboutText { get; set; }
        public IFormFile AboutImageURL { get; set; }
    }
}
