using Microsoft.EntityFrameworkCore;

namespace CovidData.Model
{
    public class CovidDbContext : DbContext
    {
        public CovidDbContext(DbContextOptions<CovidDbContext> options) : base(options)
        {
            // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
            //this.Database.EnsureCreated();
            //this.Database.Migrate();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=CovidDB.db");

        public DbSet<CaseDaily> CasesDaily { get; set; }
        public DbSet<CaseTotal> CasesTotal { get; set; }
    }
}
