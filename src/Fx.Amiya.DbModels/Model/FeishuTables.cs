using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class FeishuTables:BaseDbModel
    {
        public string AppToken { get; set; }
        public string TableId { get; set; }
        public string BelongAppId { get; set; }
        public int TableType { get; set; }
        public int LiveAnchorId { get; set; }
    }
}
