using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Liberate.Models.Mapping;

namespace Liberate.Models
{
    public partial class LiberateContext : DbContext
    {
        static LiberateContext()
        {
           Database.SetInitializer<LiberateContext>(null);
        }

        public LiberateContext()
            : base("Name=LiberateContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieMap());
        }
    }
}
