using Microsoft.EntityFrameworkCore;
using PersonDirectoryApi.Models;

namespace PersonDirectoryApi.Persistence
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonToPerson>().HasKey(ptp =>
                new{ ptp.SourcePersonId, ptp.RelatedPersonId });

            modelBuilder.Entity<Person>().HasMany(p => p.PhoneNumbers).WithOne(ph => ph.Person).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>().HasMany(p => p.ConnectedPersons).WithOne(s => s.SourcePerson).HasForeignKey( a => a.SourcePersonId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonToPerson>().HasOne(p => p.RelatedPerson).WithMany(s => s.ConnectionOfPersons).HasForeignKey(a => a.RelatedPersonId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
