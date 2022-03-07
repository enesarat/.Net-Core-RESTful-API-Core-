using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramwork
{
    public class EfAgentRepository:EfGenericRepository<Agent>, IAgentDAL
    {
    }
}
