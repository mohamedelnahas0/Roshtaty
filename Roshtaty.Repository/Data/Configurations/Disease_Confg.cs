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
    public class Disease_Confg : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.HasOne(P => P.Category).WithMany().HasForeignKey(P => P.CategoryId);
            builder.Property(P => P.DiseaseName).IsRequired().HasMaxLength(100);

        }
    }
}
