using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Input
{
    /// <summary>
    /// 朗姿改单接口
    /// </summary>
    public class UpdateOrderStatusVo:UpdateOrderStatusBaseVo
    {

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }
    public class UpdateOrderStatusBaseVo
    {

        /// <summary>
        /// 机构编码
        /// </summary>
        public string JGBM { get; set; }

        /// <summary>
        /// 派单编号
        /// </summary>
        public string PDBH { get; set; }

        /// <summary>
        /// 是否接单
        /// </summary>
        public bool SFJD { get; set; }

        /// <summary>
        /// 是否重单
        /// </summary>
        public bool SFCD { get; set; }

        /// <summary>
        /// 重单截图
        /// </summary>
        public string RepeateOrderPicture { get; set; }

        /// <summary>
        /// 机构网咨id
        /// </summary>
        public string JGWZID { get; set; }
        /// <summary>
        /// 机构网咨姓名
        /// </summary>
        public string JGWZNM { get; set; }

        /// <summary>
        /// 接单日期
        /// </summary>
        public DateTime JDRQ { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string YL1 { get; set; }

        /// <summary>
        /// 预留字段2
        /// </summary>
        public string YL2 { get; set; }
    }
}
