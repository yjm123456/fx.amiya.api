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
    public class FaceTagWithAestheticsDesignReportConfiguration : IEntityTypeConfiguration<FaceTagWithAestheticsDesignReport>
    {
        public void Configure(EntityTypeBuilder<FaceTagWithAestheticsDesignReport> builder)
        {
            builder.ToTable("tbl_aesthetics_design_report_tags");
            builder.HasKey(e => new { e.ReportId, e.TagId });
            builder.Property(e => e.ReportId).HasColumnName("report_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.TagId).HasColumnName("tag_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.DirectType).HasColumnName("direct_type").HasColumnType("int").IsRequired();
        }
    }
}
