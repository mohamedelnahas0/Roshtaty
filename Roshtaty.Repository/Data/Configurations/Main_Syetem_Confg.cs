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
    public class Main_Syetem_Confg : IEntityTypeConfiguration<Main_System>
    {
        public void Configure(EntityTypeBuilder<Main_System> builder)
        {
            builder.Property(P => P.MainSystemName).IsRequired().HasMaxLength(100);

        }
    }
}
