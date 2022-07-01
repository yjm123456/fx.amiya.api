using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class AmiyaEmployeeVo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 职位编号
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }
     
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// 是否是客服
        /// </summary>
        public bool IsCustomerService { get; set; }
        /// <summary>
        /// 绑定主播信息
        /// </summary>
        public List<int> LiveAnchorIds { get; set; }
    }
}
