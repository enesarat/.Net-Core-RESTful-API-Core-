using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class, new()
    {
        Task<List<T>> GetAllElement();
        //List<T> GetItemsByFilter(Expression<Func<T, bool>> filter);
        Task<T> GetElementById(int id);
        Task<T> InsertElement(T item);
        Task<T> UpdateElement(T item);
        Task DeleteElement(int id);
    }
}
