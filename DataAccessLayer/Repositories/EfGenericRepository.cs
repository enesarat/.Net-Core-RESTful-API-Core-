using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class EfGenericRepository<T> : IGenericEntityDAL<T> where T : class, IEntity, new()
    {
        public void DeleteItem(int id)
        {
            using(AgentDbContext dbContext = new AgentDbContext())
            {
                var deleteItem = GetItemById(id);
                dbContext.Set<T>().Remove(deleteItem);
                dbContext.SaveChanges();
            }
        }

        public List<T> GetAllItems()
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                var itemList = dbContext.Set<T>().ToList();
                return itemList;
            }
        }

        public T GetItemById(int id)
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                var item = dbContext.Set<T>().Find(id);
                return item;
            }
        }

        public T InsertItem(T item)
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                dbContext.Set<T>().Add(item);
                dbContext.SaveChanges();
                return item;
            }
        }

        public T UpdateItem(T item)
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                dbContext.Set<T>().Update(item);
                dbContext.SaveChanges();
                return item;
            }
        }
    }
}
