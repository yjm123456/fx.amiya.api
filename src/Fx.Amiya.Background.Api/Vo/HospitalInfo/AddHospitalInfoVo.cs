using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class AddHospitalInfoVo
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        [Required(ErrorMessage ="医院名称不能为空")]
        [StringLength(100,ErrorMessage ="医院名称最多{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 医院简称
        /// </summary>
        public string SimpleName { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Required(ErrorMessage ="图片不能为空")]
        [StringLength(500, ErrorMessage = "医院名称最多{1}个字符")]
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength(200, ErrorMessage = "地址最多{1}个字符")]
        public string Address { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Range(0,180.0,ErrorMessage ="请输入正确的经度")]
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [Range(0, 90.0, ErrorMessage = "请输入正确的纬度")]
        public decimal Latitude { get; set; }

        /// <summary>
        /// 医院电话
        /// </summary>
        [StringLength(20, ErrorMessage = "电话最多{1}个字符")]
        public string Phone { get; set; }
        /// <summary>
        /// 所属城市
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }

        /// <summary>
        /// 标签编号数组
        /// </summary>
        public int[] TagIds { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? DueTime { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
        public string ContractUrl { get; set; }
        /// <summary>
        /// 归属公司
        /// </summary>
        public string BelongCompany { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }
        /// <summary>
        /// 派单顺序
        /// </summary>
        public int? SendOrder { get; set; }
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
        /// 保证金缴纳状态
        /// </summary>
        public int? SecurityDeposit { get; set; }
        /// <summary>
        /// 年服务费金额
        /// </summary>
        public decimal YearServiceMoney { get; set; }
        /// <summary>
        /// 保证金金额
        /// </summary>
        public decimal SecurityDepositMoney { get; set; }
    }
}
