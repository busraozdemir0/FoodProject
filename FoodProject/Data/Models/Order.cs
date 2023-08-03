
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public int OrderQuantity { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderDate  { get; set; }
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
