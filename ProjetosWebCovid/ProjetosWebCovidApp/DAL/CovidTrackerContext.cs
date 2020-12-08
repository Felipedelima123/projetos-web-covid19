using ProjetosWebCovidApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetosWebCovidApp.DAL
{
    public class CovidTrackerContext : DbContext
    {
        public CovidTrackerContext() : base("CovidTrackerContext")
        {

        }

        // colocamos todos os modelos aqui
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<InfectedData> InfectedDatas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}