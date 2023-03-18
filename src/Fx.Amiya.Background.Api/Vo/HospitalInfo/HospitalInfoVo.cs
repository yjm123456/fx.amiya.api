using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class HospitalInfoVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleName { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 派单顺序
        /// </summary>
        public int? SendOrder { get; set; }
        /// <summary>
        /// 派单栓徐文本
        /// </summary>
        public string SendOrderText { get; set; }
        /// <summary>
        /// 新诊佣金比例
        /// </summary>
        public decimal? NewCustomerCommissionRatio { get; set; }
        /// <summary>
        /// 复诊佣金比例
        /// </summary>
        public decimal? OldCustomerCommissionRatio { get; set; }
        /// <summary>
        /// 重单规则
        /// </summary>
        public string RepeatOrderRule { get; set; }
        /// <summary>
        /// 年服务费缴纳状态
        /// </summary>
        public int? YearServiceFee { get; set; }
        /// <summary>
        /// 年服务费缴纳状态
        /// </summary>
        public string YearServiceFeeText { get; set; }
        /// <summary>
        /// 保证金缴纳状态
        /// </summary>
        public int? SecurityDeposit { get; set; }
        /// <summary>
        /// 保证金缴纳状态
        /// </summary>
        public string SecurityDepositText { get; set; }
        /// <summary>
        /// 年服务费金额
        /// </summary>
        public decimal YearServiceMoney { get; set; }
        /// <summary>
        /// 保证金金额
        /// </summary>
        public decimal SecurityDepositMoney { get; set; }

        /// <summary>
        /// 图片url
        /// </summary>
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 医院电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        public int? CityId { get; set; }
        public string City { get; set; }
        public DateTime? DueTime { get; set; }
        public string ContractUrl { get; set; }
        /// <summary>
        /// 可用日期
        /// </summary>
        public string HasUsedTime { get; set; }
        /// <summary>
        /// 归属公司
        /// </summary>
        public string BelongCompany { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }


    }
}
