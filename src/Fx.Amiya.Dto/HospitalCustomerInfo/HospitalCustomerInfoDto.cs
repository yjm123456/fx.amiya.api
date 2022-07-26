using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalCustomerInfo
{
    public class HospitalCustomerInfoDto
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string MemberCardNum { get; set; }

        /// <summary>
        /// 医院客户编号
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属现场
        /// </summary>
        public string SceneEmployeeName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? RegisterDate { get; set; }

        /// <summary>
        /// 所属地区
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 渠道类别
        /// </summary>
        public string ChannelCategory { get; set; }

        /// <summary>
        /// 渠道
        /// </summary>
        public string Channel { get; set; }
    }
}
