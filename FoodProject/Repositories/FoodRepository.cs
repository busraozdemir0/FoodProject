using FoodProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodProject.Repositories
{
    public class FoodRepository
    {
        Context context = new Context();

        public List<Food> FoodList()
        {
            return context.Foods.ToList();
        }
        public void FoodAdd(Food food)
        {
            context.Foods.Add(food);
            context.SaveChanges();
        }
        public void FoodDelete(Food food)
        {
            context.Foods.Remove(food);
            context.SaveChanges();
        }
        public void FoodUpdate(Food food)
        {
            context.Foods.Update(food);
            context.SaveChanges();
        }
        public void GetFood(int id)
        {
            context.Foods.Find(id);
        }
    }
}
