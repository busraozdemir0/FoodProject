using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodProject.Data.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public string FoodImage { get; set; }
        public int FoodQuantity { get; set; }
        public DateTime FoodOrderDate { get; set; }
        public int FoodStock { get; set; }
        public int AppUserID { get; set; }
        // public virtual AppUser AppUser { get; set; }
        [NotMapped]
        public List<AppUser> AppUsers { get; set; }

    }
}
