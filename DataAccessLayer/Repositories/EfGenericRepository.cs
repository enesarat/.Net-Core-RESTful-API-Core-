using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EfGenericRepository<T> : IGenericEntityDAL<T> where T : class, IEntity, new()
    {
        public async Task DeleteItem(int id)
        {
            using(AgentDbContext dbContext = new AgentDbContext())
            {
                var deleteItem = await GetItemById(id);
                dbContext.Set<T>().Remove(deleteItem);
                await dbContext .SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllItems()
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                var itemList = await dbContext.Set<T>().ToListAsync();
                return itemList;
            }
        }

        public async Task<T> GetItemById(int id)
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                var item = await dbContext.Set<T>().FindAsync(id);
                return item;
            }
        }

        public async Task<T> InsertItem(T item)
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                await dbContext.Set<T>().AddAsync(item);
                await dbContext.SaveChangesAsync();
                return item;
            }
        }

        public async Task<T> UpdateItem(T item)
        {
            using (AgentDbContext dbContext = new AgentDbContext())
            {
                dbContext.Set<T>().Update(item);
                await dbContext .SaveChangesAsync();
                return item;
            }
        }
    }
}
