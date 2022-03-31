using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramwork
{
    public class EfUserRepository : EfGenericRepository<User>, IUserDAL
    {
        public List<User> GetListWithRoles()
        {
            using (var c = new AgentDbContext())
            {
                var UserListWithRole = c.Users.Include(x => x.UserRole).ToList();
                return UserListWithRole;
            }

        }
    }
}
