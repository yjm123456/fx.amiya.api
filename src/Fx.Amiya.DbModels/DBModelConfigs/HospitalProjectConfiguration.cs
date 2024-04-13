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
    public class HospitalProjectConfiguration : IEntityTypeConfiguration<HospitalProject>
    {
        public void Configure(EntityTypeBuilder<HospitalProject> builder)
        {
            builder.ToTable("tbl_hospital_project");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e=>e.Name).HasColumnName("name").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.ProjectUrl).HasColumnName("project_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);


            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalProjectList).HasForeignKey(t => t.HospitalId);

        }
    }
}
