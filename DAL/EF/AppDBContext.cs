using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class AppDBContext : DbContext
    {
        public DbSet<Keepers> Keepers { get; set; }
        public DbSet<Details> Details { get; set; }
        public static void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
        }
        static AppDBContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public AppDBContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDBContext>
    {
        protected override void Seed(AppDBContext db)
        {
            db.Keepers.Add(new Keepers { Name = "Keeper 1" });
            db.SaveChanges();
        }
    }
}
