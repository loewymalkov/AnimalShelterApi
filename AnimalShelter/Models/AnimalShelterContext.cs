using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
          .HasData(
              new Animal {AnimalId = 1, Type = "dog", Name = "Rose", Age = 9},
              new Animal {AnimalId = 2, Type = "dog", Name = "Cannoli", Age = 1},
              new Animal {AnimalId = 3, Type = "dog", Name = "Blue", Age = 8},
              new Animal {AnimalId = 4, Type = "cat", Name = "Finley", Age = 7},
              new Animal {AnimalId = 5, Type = "cat", Name = "Ludovica", Age = 8}
          );
    }
  
  }
}