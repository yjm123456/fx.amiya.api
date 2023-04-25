using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    /// <summary>
    /// 机构排名数据
    /// </summary>
    public class HospitalRankDto
    {
        public List<RankDataDto> RankList { get; set; }
        public RankDataDto MyRank { get; set; }

    }
}
