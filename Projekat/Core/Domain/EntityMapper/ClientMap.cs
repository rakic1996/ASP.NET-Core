using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Domain.EntityMapper
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)  
        {  
            builder.ToTable(nameof(Client));
            builder.HasKey(x => x.Id)  
                .HasName("pk_clientid");  
              
            builder.Property(x => x.Id).ValueGeneratedOnAdd()  
                .HasColumnName("id")  
                   .HasColumnType("INT");  
            builder.Property(x => x.Name)  
                .HasColumnName("name")  
                   .HasColumnType("NVARCHAR(100)");  
            builder.Property(x => x.Address)  
              .HasColumnName("adress")  
                 .HasColumnType("NVARCHAR(50)")  
                 .IsRequired();  
            builder.Property(x => x.City)  
              .HasColumnName("city")  
                 .HasColumnType("NVARCHAR(50)")  
                 .IsRequired();  
            builder.Property(x => x.PostalCode)  
              .HasColumnName("postalCode")  
                 .HasColumnType("int")
                 .IsRequired();
            
        }           
    }
}