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
    public class TradeName_Confg : IEntityTypeConfiguration<Trades>
    {
        public void Configure(EntityTypeBuilder<Trades> builder)
        {
            builder.HasOne(P => P.Active_Ingredient).WithMany().HasForeignKey(P => P.Active_IngredientId);



            builder.Property(P => P.TradeName).IsRequired().HasMaxLength(100);
            builder.Property(P => P.PublicPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(P => P.ShelfLife).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(P => P.StorageConditions).IsRequired();
            builder.Property(P => P.ManufactureCountry).IsRequired();
            builder.Property(P => P.Dose).IsRequired();
            builder.Property(P => P.PharmaceuticalForm).IsRequired();
            builder.Property(P => P.AdministrationRoute).IsRequired();
            builder.Property(P => P.PackageSize).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(P => P.PackageTypes).IsRequired();
            builder.Property(P => P.LegalStatus).IsRequired();
            builder.Property(P => P.DistributeArea).IsRequired();
            builder.Property(P => P.Indication).IsRequired();
            builder.Property(P => P.ProductControl).IsRequired(); 
            builder.Property(P => P.SideEffects).IsRequired();

        }
    }
}
