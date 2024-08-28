using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    public class GetCooperationLiveAnchorSendAndVisitNumVo
    {
        /// <summary>
        /// 新客派单人数
        /// </summary>
        public int SendOrderNum { get; set; }
        public int VisitNum { get; set; }
        /// <summary>
        /// 老带新成交人数
        /// </summary>
        public int OldTakeNewDealNum { get; set; }
    }
}
