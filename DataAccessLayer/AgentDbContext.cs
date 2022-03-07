using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class AgentDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("");
        }

        public DbSet<Agent> Agents{ get; set; }
    }
}
