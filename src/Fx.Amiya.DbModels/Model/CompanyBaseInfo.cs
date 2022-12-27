using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class CompanyBaseInfo:BaseDbModel
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 公司注册时间
        /// </summary>
        public DateTime? RegisterDate { get; set; }
        /// <summary>
        /// 公司注册地址
        /// </summary>
        public string RegisterAddress { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// 公司法人
        /// </summary>
        public string Corporation { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string BusinessScope { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string ContactEmail { get; set; }
    }
}
