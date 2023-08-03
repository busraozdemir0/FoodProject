namespace FoodProject.Data.Models
{
    public class Shopping
    {
        public int ShoppingID { get; set; }
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
