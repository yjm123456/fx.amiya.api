using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData
{
    public class AddHospitalNetWorkConsulationOperationDataVo
    {
        /// <summary>
        /// 指标id
        /// </summary>
        [Description("指标编号")]
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        [Description("医院编号")]
        public int HospitalId { get; set; }

        /// <summary>
        /// 咨询师名字
        /// </summary>
        [Description("咨询师名字")]
        public string ConsulationName { get; set; }

        /// <summary>
        /// 派单数
        /// </summary>
        [Description("派单数")]
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 新客上门数
        /// </summary>
        [Description("新客上门数")]
        public int NewCustomerVisitNum { get; set; }

        /// <summary>
        /// 新客上门率
        /// </summary>
        [Description("新客上门率")]
        public decimal NewCustomerVisitRate { get; set; }
    }
}
