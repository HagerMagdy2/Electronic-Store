using ElectronicStore.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Data.Config
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Id).IsRequired();
            builder.HasData( new Category {  Id=1, Name="Test", Description= "Test"});
        }
    }
}
