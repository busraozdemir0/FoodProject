using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data
{
    public class AboutImage
    {

        public int AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutText { get; set; }
        public IFormFile AboutImageURL { get; set; }
    }
}
