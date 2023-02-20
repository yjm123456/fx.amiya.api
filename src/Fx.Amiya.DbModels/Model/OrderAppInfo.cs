using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class OrderAppInfo
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public byte AppType { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RefreshToken { get; set; }

        public int? BelongLiveAnchor { get; set; }

    }
}
