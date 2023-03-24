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
    public class AestheticsDesignConfiguration : IEntityTypeConfiguration<AestheticsDesign>
    {
        public void Configure(EntityTypeBuilder<AestheticsDesign> builder)
        {
            builder.ToTable("tbl_aesthetics_design");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.AestheticsDesignReportId).HasColumnName("aesthetics_design_report_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Design).HasColumnName("design").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.SimpleHospitalName).HasColumnName("simple_hospital_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(e => e.RecommendDoctor).HasColumnName("recommend_doctor").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.FrontPicture).HasColumnName("front_picture").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.SidePicture).HasColumnName("side_picture").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
