using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalEmployee
{
    public class UpdateHospitalEmployeeVo
    {
        /// <summary>
        ///员工编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>

        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }


        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }


        /// <summary>
        /// 医院编号（阿美雅修改才需该字段）
        /// </summary>
        public int? HospitalId { get; set; }

        /// <summary>
        /// 是否允许创建子账户（阿美雅修改才需该字段）
        /// </summary>
        public bool IsCreateSubAccount { get; set; }

        /// <summary>
        /// 医院职位编号
        /// </summary>
        public int HospitalPositionId { get; set; }

        /// <summary>
        /// 是否是客服
        /// </summary>
        public bool IsCustomerService { get; set; }
    }
}
