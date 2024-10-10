using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.Input
{
    public class BatchEditSendInfoVo
    {
       
        /// <summary>
        /// 派单医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 派单id集合
        /// </summary>
        public List<int> SendInfoIdList { get; set; }
        /// <summary>
        /// 是否指定医院账户
        /// </summary>
        public bool IsSpecifyHospitalEmployee { get; set; }

        /// <summary>
        /// 医院账户id
        /// </summary>
        public int HospitalEmployeeId { get; set; }
    }
}
