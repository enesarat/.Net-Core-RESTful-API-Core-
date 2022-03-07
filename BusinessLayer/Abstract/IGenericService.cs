using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class, new()
    {
        List<T> GetAllElement();
        //List<T> GetItemsByFilter(Expression<Func<T, bool>> filter);
        T GetElementById(int id);
        T InsertElement(T item);
        T UpdateElement(T item);
        void DeleteElement(int id);
    }
}
