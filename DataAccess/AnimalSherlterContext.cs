using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AnimalSherlterContext:DbContext
    {
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Shelter> Shelter { get; set; }
        public AnimalSherlterContext() => Database.EnsureCreated();

        public AnimalSherlterContext(DbContextOptions<AnimalSherlterContext> options)
            : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AnimalSheltersDB;Trusted_Connection=True;");*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Shelter>(entity =>
            {

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Address).IsRequired();
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.MoneyNeededPerMonth).IsRequired();
                entity.Property(e => e.ArrivalDate).IsRequired();
            });

            

        }
    }
}
