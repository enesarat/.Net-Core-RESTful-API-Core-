using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericEntityDAL<T> where T:class,IEntity,new() 
    {
        Task<List<T>> GetAllItems();
        //List<T> GetItemsByFilter(Expression<Func<T, bool>> filter);
        Task<T> GetItemById(int id);
        Task<T> InsertItem(T item);
        Task<T> UpdateItem(T item);
        Task DeleteItem(int id);
    }
}
