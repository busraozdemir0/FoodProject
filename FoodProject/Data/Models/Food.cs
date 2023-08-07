using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodProject.Data.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage = "Food Name Not Empty")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public List<Shopping> Shoppings { get; set; }
        [NotMapped]
        public List<Payment> Payments { get; set; }
    }
}
