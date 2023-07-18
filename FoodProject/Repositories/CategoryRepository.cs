using FoodProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodProject.Repositories
{
    public class CategoryRepository
    {
        Context context = new Context();

        public List<Category> CategoryList()
        {
            return context.Categories.ToList();
        }
        public void CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
        public void CategoryDelete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
        public void CategoryUpdate(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }
        public void GetCategory(int id)
        {
            context.Categories.Find(id);
        }
    }
}
