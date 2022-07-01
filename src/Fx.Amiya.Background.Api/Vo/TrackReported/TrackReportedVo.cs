using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TrackReported
{
    public class TrackReportedVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 提报状态
        /// </summary>
        public int SendStatus { get; set; }
        /// <summary>
        /// 提报状态文本
        /// </summary>
        public string SendStatusText { get; set; }

        /// <summary>
        /// 提报内容
        /// </summary>
        public string SendContent { get; set; }

        /// <summary>
        /// 提报医院id
        /// </summary>
        public int SendHospitalId { get; set; }

        /// <summary>
        /// 提报医院
        /// </summary>
        public string SendHospital { get; set; }

        /// <summary>
        /// 医院回访内容
        /// </summary>
        public string HospitalContent { get; set; }

        /// <summary>
        /// 提报日期
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 提报人
        /// </summary>
        public int SendBy { get; set; }

        /// <summary>
        /// 填报人
        /// </summary>
        public string SendByName { get; set; }

        /// <summary>
        /// 追踪回访id
        /// </summary>
        public int? TrackRecordId { get; set; }
    }
}
