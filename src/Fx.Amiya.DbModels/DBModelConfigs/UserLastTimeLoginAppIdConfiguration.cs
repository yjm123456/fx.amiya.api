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
    public class UserLastTimeLoginAppIdConfiguration : IEntityTypeConfiguration<UserLastTimeLoginAppId>
    {
        public void Configure(EntityTypeBuilder<UserLastTimeLoginAppId> builder)
        {
            builder.ToTable("tbl_user_lasttime_loginappid");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.UserId).HasColumnName("user_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.AppId).HasColumnName("app_id").HasColumnType("varchar(50)").IsRequired();
    }
    }
}
