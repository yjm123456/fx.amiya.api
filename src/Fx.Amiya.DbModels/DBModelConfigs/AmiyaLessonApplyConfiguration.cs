using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaLessonApplyConfiguration : IEntityTypeConfiguration<AmiyaLessonApply>
    {
        public void Configure(EntityTypeBuilder<AmiyaLessonApply> builder)
        {
            builder.ToTable("tbl_lesson_apply");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(30)").IsRequired();
            builder.Property(t => t.Position).HasColumnName("position").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.City).HasColumnName("city").HasColumnType("varchar(45)").IsRequired(false);
        }
    }
}
