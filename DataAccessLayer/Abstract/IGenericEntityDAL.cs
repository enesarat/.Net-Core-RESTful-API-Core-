using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IGenericEntityDAL<T> where T:class,IEntity,new() 
    {
        List<T> GetAllItems();
        //List<T> GetItemsByFilter(Expression<Func<T, bool>> filter);
        T GetItemById(int id);
        T InsertItem(T item);
        T UpdateItem(T item);
        void DeleteItem(int id);
    }
}
