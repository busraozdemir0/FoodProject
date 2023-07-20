using FoodProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public T TGet(int id)
        {
            return context.Set<T>().Find(id);
        }
        public List<T> TList(string p) // İlgili yiyeceğin kategori adını getirebilmek için
        {
            return context.Set<T>().Include(p).ToList();
        }
        public List<T> List(Expression<Func<T,bool>> filter) // istediğimiz herhangi sütuna göre listeleme işlemi 
        {
            return context.Set<T>().Where(filter).ToList();
        }
    }
}
