using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roshtaty.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Repository.Data.Configurations
{
    public class Category_Confg : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(P => P.MainSystem).WithMany().HasForeignKey(P => P.MainSystemId);
            builder.Property(P => P.CategoryName).IsRequired().HasMaxLength(100);
        }
    }
}
