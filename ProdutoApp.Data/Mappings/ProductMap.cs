using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdutoApp.Data.Entities;

namespace ProdutoApp.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
            .HasColumnName("ID");

            builder.Property(p => p.Name)
            .HasColumnName("NAME") 
            .HasMaxLength(150) 
            .IsRequired(); 
              
         


            builder.Property(p => p.UnitaryPrice)
            .HasColumnName("UNITARYPRICE")
             .HasColumnType("int")
              .IsRequired();

            builder.Property(t => t.Type)
               .HasColumnName("TYPE") 
               .IsRequired(); 


           
        }
    }
}
    

