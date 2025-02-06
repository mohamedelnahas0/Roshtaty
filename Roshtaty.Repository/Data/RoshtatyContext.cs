using Microsoft.EntityFrameworkCore;
using Roshtaty.Core.Entites;
using System.Reflection;

namespace Roshtaty.Repository.Data
{
    public class RoshtatyContext :DbContext
    {
        public RoshtatyContext(DbContextOptions<RoshtatyContext> options): base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  Applying_All_Configurations
               base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Main_System> main_Systems { get; set; }
        public DbSet<Category>  categories { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Active_Ingredient> Active_Ingredients { get; set; }
        public DbSet<Trades>  tradeNames { get; set; }
        public DbSet<Prescription>  Prescriptions { get; set; }
    }
}
