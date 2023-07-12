using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class BindCustomerInfoVo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 首次项目需求
        /// </summary>
        public string FirstProjectDemand { get; set; }
        /// <summary>
        /// 最新消费渠道
        /// </summary>
        public string NewContentPlatForm { get; set; }
        /// <summary>
        /// 最新消费时间
        /// </summary>

        public DateTime? NewConsumptionDate { get; set; }

        /// <summary>
        /// 加密电话
        /// </summary>
        public string EncryptPhone{get;set;}

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 绑定客服编号
        /// </summary>
        public int? CustomerServiceId { get; set; }

        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }

        public string Name { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }

        /// <summary>
        /// 累计消费
        /// </summary>
        public decimal? AllPrice { get; set; }

        /// <summary>
        /// 总单数
        /// </summary>
        public int? AllOrderCount { get; set; }

        /// <summary>
        /// 距今消费间隔天数
        /// </summary>
        public int ConsumptionDate { get; set; }

        /// <summary>
        /// RFM类型
        /// </summary>
        public int RfmType { get; set; }

        /// <summary>
        /// RFM类型文本
        /// </summary>
        public string RfmTypeText { get; set; }
    }
}
