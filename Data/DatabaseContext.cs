namespace Enozom_task.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<CountryHoliday> CHolidays { get; set; }
    }
}
