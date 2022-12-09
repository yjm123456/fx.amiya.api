using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("tbl_doctor");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.PicUrl).HasColumnName("pic_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.ProjectPicture).HasColumnName("project_picture").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.DepartmentId).HasColumnName("department_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Position).HasColumnName("position").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.ObtainEmploymentYear).HasColumnName("obtain_employment_year").HasColumnType("int").IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(800)").IsRequired(false);
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsMain).HasColumnName("is_main").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsLeaveOffice).HasColumnName("is_leave_office").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.DocterList).HasForeignKey(t=>t.HospitalId);
        }
    }
}
