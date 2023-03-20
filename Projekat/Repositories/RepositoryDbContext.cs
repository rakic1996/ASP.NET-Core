using Microsoft.EntityFrameworkCore;
using Projekat.Core.Domain.Entities;

namespace Projekat.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)   
        {

        }

        public DbSet<Employee> Employees { get; set; }     
        public DbSet<Client> Clients { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder) // unique employee name
        {
        modelBuilder.Entity<Employee>()
        .HasIndex(e => e.Name)
        .IsUnique();
        // modelBuilder.Entity<Client>()
        //         .HasOne(e => e.Country)
        //         .WithMany(c => c.Clients);
        // modelBuilder.Entity<Country>()  // ne znam jel treba
        //     .HasMany(c => c.Clients)
        //     .WithOne(e => e.Country);
    }
}
}