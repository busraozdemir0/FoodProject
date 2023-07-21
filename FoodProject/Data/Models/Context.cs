using Microsoft.EntityFrameworkCore;

namespace FoodProject.Data.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-8T3IOH2; database=DbCoreFood; integrated security=true;");
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
