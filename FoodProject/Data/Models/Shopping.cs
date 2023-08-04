using System;

namespace FoodProject.Data.Models
{
    public class Shopping
    {
        public int ShoppingID { get; set; }
        public int ShoppingQuantity { get; set; } = 1;
        public DateTime ShoppingDate { get; set; } = DateTime.Now.Date;
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
