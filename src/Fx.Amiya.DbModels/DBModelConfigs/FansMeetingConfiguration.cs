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
    public class FansMeetingConfiguration : IEntityTypeConfiguration<FansMeeting>
    {
        public void Configure(EntityTypeBuilder<FansMeeting> builder)
        {
            builder.ToTable("tbl_fans_meeting");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.StartDate).HasColumnName("start_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.EndDate).HasColumnName("end_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.FansMeetingList).HasForeignKey(t => t.HospitalId);
        }
    }
}
