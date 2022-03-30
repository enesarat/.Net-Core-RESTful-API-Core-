using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManger : IUserService
    {
        IUserDAL userAccess;

        public UserManger(IUserDAL userAccess)
        {
            this.userAccess = userAccess;
        }

        public async Task DeleteElement(int id)
        {
            await userAccess.DeleteItem(id);
        }

        public async Task<List<User>> GetAllElement()
        {
            var userList = await userAccess.GetAllItems();
            return userList;
        }

        public async Task<User> GetElementById(int id)
        {
            var user = await userAccess.GetItemById(id);
            return user;
        }

        public async Task<User> InsertElement(User item)
        {
            await userAccess.InsertItem(item);
            return item;
        }

        public async Task<User> UpdateElement(User item)
        {
            await userAccess.UpdateItem(item);
            return item;
        }
    }
}
