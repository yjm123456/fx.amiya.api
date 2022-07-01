using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class UserInfoUpdateRecordConfiguration : IEntityTypeConfiguration<UserInfoUpdateRecord>
    {
        public void Configure(EntityTypeBuilder<UserInfoUpdateRecord> builder)
        {
            builder.ToTable("tbl_user_info_update_record");
            builder.HasKey(e => e.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("user_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LatestUpdateDate).HasColumnName("latest_updatet_date").HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.UserInfo).WithMany(t => t.UserInfoUpdateRecordList).HasForeignKey(t => t.UserId);
        }
    }
}
