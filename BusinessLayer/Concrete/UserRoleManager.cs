using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDAL userRoleAccess;
        public UserRoleManager(IUserRoleDAL userRoleAccess)
        {
            this.userRoleAccess = userRoleAccess;
        }
        public async Task DeleteElement(int id)
        {
            await userRoleAccess.DeleteItem(id);
        }

        public async Task<List<UserRole>> GetAllElement()
        {
            var userRoleList = await userRoleAccess.GetAllItems();
            return userRoleList;
        }

        public async Task<UserRole> GetElementById(int id)
        {
            var userRole = await userRoleAccess.GetItemById(id);
            return userRole;
        }

        public async Task<UserRole> InsertElement(UserRole item)
        {
            await userRoleAccess.InsertItem(item);
            return item;
        }

        public async Task<UserRole> UpdateElement(UserRole item)
        {
            await userRoleAccess.UpdateItem(item);
            return item;
        }
    }
}
