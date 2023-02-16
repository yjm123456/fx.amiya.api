using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    class ControlPageShowConfiguration : IEntityTypeConfiguration<ControlPageShow>
    {
        public void Configure(EntityTypeBuilder<ControlPageShow> builder)
        {
            builder.ToTable("tbl_control_page_show");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Show).HasColumnName("show").HasColumnType("bit").IsRequired();
        }
    }
}
