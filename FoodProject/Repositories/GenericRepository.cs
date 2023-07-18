using FoodProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodProject.Repositories
{
    public class GenericRepository<T> where T: class, new() // T mutlaka bir class olmalı ve new sözcüğünü barındırabilmeli.
    {
        Context context = new Context();

        public List<T> TList()
        {
            return context.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            context.Set<T>().Add(p);
            context.SaveChanges();
        }
        public void TDelete(T p)
        {
            context.Set<T>().Remove(p);
            context.SaveChanges();
        }
        public void TUpdate(T p)
        {
            context.Set<T>().Update(p);
            context.SaveChanges();
        }
        public void TGet(int id)
        {
            context.Set<T>().Find(id);
        }
        public List<T> TList(string p) // İlgili yiyeceğin kategori adını getirebilmek için
        {
            return context.Set<T>().Include(p).ToList();
        }
    }
}
