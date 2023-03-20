using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Core.Domain.Entities;
using Projekat.Core.Domain.Enums;

namespace Projekat.Core.Domain.EntityMapper
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));
            builder.HasKey(x => x.Id)
                .HasName("pk_employeeid");

            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("id")
                   .HasColumnType("INT");
            builder.Property(x => x.Name)
                .HasColumnName("name")
                   .HasColumnType("NVARCHAR(100)");
            builder.Property(x => x.Username)
              .HasColumnName("username")
                 .HasColumnType("NVARCHAR(50)")
                 .IsRequired();
            builder.Property(x => x.HoursPerWeek)
              .HasColumnName("hours_per_week")
                 .HasColumnType("double");
            builder.Property(x => x.Email)
              .HasColumnName("email")
                 .HasColumnType("NVARCHAR(50)")
                 .IsRequired();
            builder.Property(x => x.Role)
              .HasConversion(
                v => v.ToString(),
                v => (Role)Enum.Parse(typeof(Role), v)
            );
            builder.Property(x => x.Status)
              .HasConversion(
                v => v.ToString(),
                v => (Status)Enum.Parse(typeof(Status), v)
            );
        }
    }
}