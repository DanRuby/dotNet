using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AnimalSherlterContext:DbContext
    {
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Shelter> Shelter { get; set; }
        public AnimalSherlterContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AnimalSheltersDB;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId)
                    .HasConstraintName("FK_Shelter_Shelter");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
                entity.Property(e => e.ArrivalDate).IsRequired();

                entity.HasOne(e => e.Shelter)
                    .WithMany(e => e.Animals)
                    .HasForeignKey(e => e.ShelterId)
                    .HasConstraintName("FK_Animal_Shelter");
            });
        }
    }
}
