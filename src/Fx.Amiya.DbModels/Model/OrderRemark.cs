using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class OrderRemark : BaseDbModel
    {
        public int BelongAuthorize { get; set; }
        public string OrderId { get; set; }
        public int CreateBy { get; set; }
        public string Remark { get; set; }

    }
}
