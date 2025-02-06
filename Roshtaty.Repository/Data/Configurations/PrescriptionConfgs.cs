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
    public class PrescriptionConfgs : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasOne(P => P.Active_Ingredient).WithMany().HasForeignKey(P => P.Active_IngredientId)
                       .OnDelete(DeleteBehavior.Restrict);
            

            builder.Property(P => P.Form).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Dose).IsRequired();
            builder.Property(P => P.PrescriptionDate).IsRequired();

       

        }

    }
}
