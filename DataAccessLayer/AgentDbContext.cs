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
            optionsBuilder.UseSqlServer("Server=EARAT-E14; Database=AgentDb; Trusted_Connection=True;");
        }

        public DbSet<Agent> Agents{ get; set; }
    }
}
