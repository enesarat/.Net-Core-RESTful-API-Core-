using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramwork
{
    public class EfUserRoleRepository : EfGenericRepository<UserRole>, IUserRoleDAL
    {
    }
}
