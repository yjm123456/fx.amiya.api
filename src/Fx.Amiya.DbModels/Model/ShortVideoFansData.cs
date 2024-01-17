using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class ShortVideoFansData:BaseDbModel
    {
        public DateTime StatsDate { get; set; }
        public int NewFansCount { get; set; }
        public int TotalFansCount { get; set; }
        public int? BelongLiveAnchorId { get; set; }
    }
}
