using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaGoodsDemandConfiguration : IEntityTypeConfiguration<AmiyaGoodsDemand>
    {
        public void Configure(EntityTypeBuilder<AmiyaGoodsDemand> builder)
        {
            builder.ToTable("tbl_amiya_goods_demand");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalDepartmentId).HasColumnName("hospital_department_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.ProjectNname).HasColumnName("project_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.ThumbPictureUrl).HasColumnName("thumb_picturl_url").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
