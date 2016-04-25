using MySql.Data.Entity;
using Receptbok.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Receptbok.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ReceptbokContext : DbContext
    {
        public ReceptbokContext() : base("ReceptbokContextConnectionString")
        {
            Database.SetInitializer(new ReceptbokInitializer());
        }

        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<FilePath> FilePath { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}