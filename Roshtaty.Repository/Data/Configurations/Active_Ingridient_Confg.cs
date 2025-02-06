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
    public class Active_Ingridient_Confg : IEntityTypeConfiguration<Active_Ingredient>
    {
        public void Configure(EntityTypeBuilder<Active_Ingredient> builder)
        {
            builder.HasOne(P => P.Disease).WithMany().HasForeignKey(P => P.DiseaseId);



            builder.Property(P => P.ActiveIngredientName).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Strength).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(P => P.StrengthUnit).IsRequired();

        }
    }
}
