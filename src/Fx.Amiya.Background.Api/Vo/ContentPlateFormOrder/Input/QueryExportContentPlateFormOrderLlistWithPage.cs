using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.Input
{
    public class QueryExportContentPlateFormOrderLlistWithPage:BaseQueryVo
    {
       
        /// <summary>
        /// 预约医院
        /// </summary>
        public int? AppointmentHospital { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public int? BelongEmpId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int? LiveAnchorId { get; set; }
        /// <summary>
        /// 面诊员
        /// </summary>
        public int? ConsultationEmpId { get; set; }
        /// <summary>
        /// 医院部门
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int OrderSource { get; set; }
        /// <summary>
        /// 内容平台
        /// </summary>
        public string ContentPlateFormId { get; set; }
        /// <summary>
        /// 基础主播id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
    }
}
