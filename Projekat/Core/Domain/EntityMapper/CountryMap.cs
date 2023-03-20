using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Domain.EntityMapper
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)  
        {  
            builder.ToTable(nameof(Country));
            builder.HasKey(x => x.Id)  
                .HasName("pk_countryid");  
            builder.Property(x => x.Name)  
                .HasColumnName("name")  
                   .HasColumnType("NVARCHAR(100)");

        }            
    }
}