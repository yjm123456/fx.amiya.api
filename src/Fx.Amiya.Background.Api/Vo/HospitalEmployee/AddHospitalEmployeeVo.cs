using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalEmployee
{
    /// <summary>
    /// 添加医院员工模型
    /// </summary>
    public class AddHospitalEmployeeVo
    {
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
        /// 密码
        /// </summary>

        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }


        /// <summary>
        /// 是否允许创建子账户（啊美雅添加员工）
        /// </summary>
        public bool IsCreateSubAccount { get; set; }

        /// <summary>
        /// 医院编号（啊美雅添加员工）
        /// </summary>
        public int? HospitalId { get; set; }

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
