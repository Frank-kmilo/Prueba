using Microsoft.EntityFrameworkCore;
using Prueba.API.Data.Entities;
using System.Data.Common;

namespace Prueba.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<TaskManagement> TaskManagements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskManagement>().HasIndex(x=> x.Id).IsUnique();
        }
    }
}
