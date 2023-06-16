using Fx.Amiya.Dto.HospitalEmployee;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface IHospitalEmployeeService
    {

        /// <summary>
        /// 添加医院员工
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalEmployeeDto addDto,string employeeType);
       


        /// <summary>
        /// 根据员工编号获取医院员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalEmployeeDto> GetByIdAsync(int id);


        /// <summary>
        /// 取医院员工列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalEmployeeDto>> GetListWithPageAsync(int? hospitalId,string keyword, int pageNum, int pageSize,bool? valid);


        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task ResetPasswordAsync(int employeeId, string password);


        /// <summary>
        /// 更新帐户是否有效
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        Task UpdateAccountValidAsync(int employeeId, bool valid);



        /// <summary>
        /// 修改医院员工信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateHospitalEmployeeDto updateDto, string employeeType);

        /// <summary>
        /// 修改医院账号头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateAvatarAsync(int id,string url);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<HospitalEmployeeDto> LoginAsync(string userName, string password);



        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdatePasswordAsync(UpdatePasswordHospitalDto updateDto, int employeeId);



        /// <summary>
        /// 修改医院员工密码
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateEmployeePasswordByIdAsync(UpdateEmployeePasswordDto updateDto);

        /// <summary>
        /// 删除医院员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);



        /// <summary>
        /// 根据员工id集合获取医院员工基础信息列表
        /// </summary>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
       Task<List<HospitalEmployeeBaseInfoDto>> GetBaseInfoListAsync(int[] employeeIds);
    }
}
