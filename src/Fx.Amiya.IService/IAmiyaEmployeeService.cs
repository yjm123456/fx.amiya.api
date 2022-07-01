
using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaEmployeeService
    {

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<AmiyaEmployeeDto> LoginAsync(string userName, string password);


        /// <summary>
        /// 检测密码是否合法（数字+英文不少于8位）
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> CheckPasswordAsync(string password);


        /// <summary>
        /// 添加阿美雅员工
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddAmiyaEmployeeDto addDto);

        /// <summary>
        /// 根据员工编号获取阿美雅员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmiyaEmployeeDto> GetByIdAsync(int id);


        /// <summary>
        /// 取阿美雅员工列表（分页）
        /// </summary>
        /// <param name="keyword">搜索员工名字关键字</param>
        /// <param name="valid">是否有效</param>
        /// <param name="positionId">职位id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AmiyaEmployeeDto>> GetListWithPageAsync(string keyword, bool valid, int positionId, int pageNum, int pageSize);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="employeeId"></param>
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
        /// 修改员工信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateAmiyaEmployeeDto updateDto);


        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task DeleteAsync(int employeeId,int deleteBy);


     
        /// <summary>
        /// 修改用户名密码
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdatePasswordAsync(UpdatePasswordAmiyaDto updateDto,int employeeId);


        /// <summary>
        /// 管理员修改员工密码
        /// </summary>
        /// <returns></returns>
        Task UpdateEmployeePasswordByIdAsync(UpdateEmployeePasswordDto updateDto);



        /// <summary>
        /// 根据员工id集合获取员工基础信息列表
        /// </summary>
        /// <param name="employeeIds">阿美雅员工编号</param>
        /// <returns></returns>
        Task<List<AmiyaEmployeeBaseInfoDto>> GetInfoListIdsAsync(int[] employeeIds);

        /// <summary>
        /// 获取客服列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerServiceEmployeeDto>> GetCustomerSeviceListWithPageAsync(int pageNum, int pageSize);


        /// <summary>
        /// 获取客服姓名列表
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaEmployeeNameDto>> GetCustomerServiceNameListAsync();

        /// <summary>
        /// 获取运营咨询人员姓名列表
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaEmployeeNameDto>> GetOperatingConsultingNameListAsync();

        /// <summary>
        /// 获取面诊员姓名列表
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaEmployeeNameDto>> GetConsultingNameListAsync();

        /// <summary>
        /// 根据职位id获取人员
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<List<AmiyaEmployeeNameDto>> GetemployeeByPositionIdAsync(int positionId);

    }
}
