using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.Dto.AmiyaEmployee;
using System.Text.RegularExpressions;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class AmiyaEmployeeService : IAmiyaEmployeeService
    {
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalBindCustomerService dalBindCustomerService;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;
        public AmiyaEmployeeService(IDalAmiyaEmployee dalAmiyaEmployee,
            IDalBindCustomerService dalBindCustomerService,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService)
        {
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalBindCustomerService = dalBindCustomerService;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
        }


        public async Task<AmiyaEmployeeDto> LoginAsync(string userName, string password)
        {
            try
            {
                var employee = await dalAmiyaEmployee.GetAll()
                    .Include(e => e.AmiyaPositionInfo).ThenInclude(e => e.AmiyaDepartment)
                    .SingleOrDefaultAsync(e => e.UserName == userName);

                if (employee == null)
                    throw new Exception("用户名不存在");

                if (employee.Valid == false)
                    throw new Exception("账户已失效");

                if (employee.Password != password)
                    throw new Exception("密码错误");

                AmiyaEmployeeDto employeeDto = new AmiyaEmployeeDto();
                employeeDto.Id = employee.Id;
                employeeDto.Name = employee.Name;
                employeeDto.UserName = employee.UserName;
                employeeDto.Password = employee.Password;
                employeeDto.Valid = employee.Valid;
                employeeDto.PositionId = employee.AmiyaPositionId;
                employeeDto.PositionName = employee.AmiyaPositionInfo.Name;
                employeeDto.IsCustomerService = employee.IsCustomerService;
                employeeDto.DepartmentId = employee.AmiyaPositionInfo.DepartmentId;
                employeeDto.DepartmentName = employee.AmiyaPositionInfo.AmiyaDepartment.Name;


                return employeeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<bool> CheckPasswordAsync(string password)
        {
            string tr = "(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{8,}";
            Regex regex = new Regex(tr);
            if (!regex.IsMatch(password))
                return false;
            return true;

        }

        public async Task AddAsync(AddAmiyaEmployeeDto addDto)
        {
            try
            {
                var count = await dalAmiyaEmployee.GetAll().CountAsync(e => e.UserName == addDto.UserName);
                if (count > 0)
                    throw new Exception("用户名已被占用，请重新输入");

                AmiyaEmployee employee = new AmiyaEmployee()
                {
                    Name = addDto.Name,
                    UserName = addDto.UserName,
                    Password = addDto.Password,
                    AmiyaPositionId = addDto.PositionId,
                    Valid = true,
                    Email = addDto.Email,
                    IsCustomerService = addDto.IsCustomerService
                };
                await dalAmiyaEmployee.AddAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<AmiyaEmployeeDto> GetByIdAsync(int id)
        {
            try
            {
                var employee = await dalAmiyaEmployee.GetAll()
                    .Include(e => e.AmiyaPositionInfo).ThenInclude(e => e.AmiyaDepartment)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                    return new AmiyaEmployeeDto();

                AmiyaEmployeeDto employeeDto = new AmiyaEmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    UserName = employee.UserName,
                    Password = employee.Password,
                    Valid = employee.Valid,
                    Email = (employee.Email == "0") ? "" : employee.Email,
                    PositionId = employee.AmiyaPositionId,
                    PositionName = employee.AmiyaPositionInfo.Name,
                    IsCustomerService = employee.IsCustomerService,
                    DepartmentId = employee.AmiyaPositionInfo.DepartmentId,
                    DepartmentName = employee.AmiyaPositionInfo.AmiyaDepartment.Name,
                };
                if (employeeDto.IsCustomerService == true || employeeDto.PositionId == 19)
                {
                    employeeDto.LiveAnchorIds = new List<int>();
                    var liveAnchorIdsResult = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeDto.Id);
                    if (liveAnchorIdsResult.Count > 0)
                    {
                        foreach (var x in liveAnchorIdsResult)
                        {
                            employeeDto.LiveAnchorIds.Add(x.LiveAnchorId);
                        }
                    }
                }
                return employeeDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<FxPageInfo<AmiyaEmployeeDto>> GetListWithPageAsync(string keyword, bool valid, int positionId, int pageNum, int pageSize)
        {
            try
            {
                var employees = from d in dalAmiyaEmployee.GetAll()
                                where (keyword == null || d.Name.Contains(keyword))
                                && (d.Valid == valid)
                                && (positionId == 0 || d.AmiyaPositionId == positionId)
                                select new AmiyaEmployeeDto
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    UserName = d.UserName,
                                    Password = d.Password,
                                    Email = (d.Email == "0") ? "" : d.Email,
                                    Valid = d.Valid,
                                    PositionId = d.AmiyaPositionId,
                                    PositionName = d.AmiyaPositionInfo.Name,
                                    IsCustomerService = d.IsCustomerService
                                };
                FxPageInfo<AmiyaEmployeeDto> employeePageInfo = new FxPageInfo<AmiyaEmployeeDto>();
                employeePageInfo.TotalCount = await employees.CountAsync();
                employeePageInfo.List = await employees.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return employeePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task ResetPasswordAsync(int employeeId, string password)
        {
            try
            {
                var employee = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                    throw new Exception("员工编号错误");

                employee.Password = password;
                await dalAmiyaEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task UpdateAccountValidAsync(int employeeId, bool valid)
        {
            try
            {
                var employee = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                    throw new Exception("员工编号错误");

                employee.Valid = valid;
                await dalAmiyaEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task UpdateAsync(UpdateAmiyaEmployeeDto updateDto)
        {
            try
            {

                var employee = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (employee == null)
                    throw new Exception("员工编号错误");

                var count = await dalAmiyaEmployee.GetAll().CountAsync(e => e.UserName == updateDto.UserName && e.Id != updateDto.Id);
                if (count > 0)
                    throw new Exception("用户名已被占用，请重新输入");

                employee.Name = updateDto.Name;
                employee.UserName = updateDto.UserName;
                employee.Valid = updateDto.Valid;
                employee.Email = updateDto.Email;
                employee.AmiyaPositionId = updateDto.PositionId;
                employee.IsCustomerService = updateDto.IsCustomerService;
                await dalAmiyaEmployee.UpdateAsync(employee, true);


                if (updateDto.IsCustomerService == true || updateDto.PositionId == 19)
                {
                    if (updateDto.LiveAnchorIds.Count > 0)
                    {
                        //当为客服状态需要添加归属主播
                        UpdateEmployeeBindLiveAnchorDto dto = new UpdateEmployeeBindLiveAnchorDto();
                        dto.EmployeeId = updateDto.Id;
                        dto.LiveAnchorId = updateDto.LiveAnchorIds;
                        await employeeBindLiveAnchorService.UpdateAsync(dto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task DeleteAsync(int employeeId, int deleteBy)
        {
            try
            {
                if (employeeId == deleteBy)
                    throw new Exception("删除失败");

                var employee = await dalAmiyaEmployee.GetAll()
                   .SingleOrDefaultAsync(e => e.Id == employeeId);

                if (employee == null)
                    throw new Exception("阿美雅员工编号错误");

                await dalAmiyaEmployee.DeleteAsync(employee, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        public async Task UpdatePasswordAsync(UpdatePasswordAmiyaDto updateDto, int employeeId)
        {
            try
            {
                var employee = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);

                if (updateDto.OldPassword != employee.Password)
                    throw new Exception("原始密码错误");

                employee.Password = updateDto.NewPassword;
                await dalAmiyaEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 管理员修改员工密码
        /// </summary>
        /// <returns></returns>
        public async Task UpdateEmployeePasswordByIdAsync(UpdateEmployeePasswordDto updateDto)
        {
            var employee = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (employee == null)
                throw new Exception("员工编号错误");
            employee.Password = updateDto.Password;
            await dalAmiyaEmployee.UpdateAsync(employee, true);
        }





        /// <summary>
        /// 根据员工id集合获取员工姓名列表
        /// </summary>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        public async Task<List<AmiyaEmployeeBaseInfoDto>> GetInfoListIdsAsync(int[] employeeIds)
        {
            try
            {
                List<AmiyaEmployeeBaseInfoDto> amiyaEmployeeList = new List<AmiyaEmployeeBaseInfoDto>();
                foreach (var item in employeeIds)
                {
                    var employee = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == item);
                    if (employee != null)
                    {
                        AmiyaEmployeeBaseInfoDto amiyaEmployee = new AmiyaEmployeeBaseInfoDto();
                        amiyaEmployee.Id = employee.Id;
                        amiyaEmployee.Name = employee.Name;
                        amiyaEmployeeList.Add(amiyaEmployee);
                    }
                }
                return amiyaEmployeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FxPageInfo<CustomerServiceEmployeeDto>> GetCustomerSeviceListWithPageAsync(int pageNum, int pageSize)
        {
            var employee = from d in dalAmiyaEmployee.GetAll()
                           where d.IsCustomerService && d.Valid
                           select new CustomerServiceEmployeeDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                               UserName = d.UserName,
                           };

            var customerServiceEmployeeList = await employee.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            foreach (var item in customerServiceEmployeeList)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == item.Id).ToListAsync();
                item.BindCustomerQuantity = bindCustomerService.Count();

            }


            FxPageInfo<CustomerServiceEmployeeDto> customerServicePageInfo = new FxPageInfo<CustomerServiceEmployeeDto>();
            customerServicePageInfo.TotalCount = await employee.CountAsync();
            customerServicePageInfo.List = customerServiceEmployeeList;

            return customerServicePageInfo;
        }




        /// <summary>
        /// 获取客服姓名列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaEmployeeNameDto>> GetCustomerServiceNameListAsync()
        {
            var employee = from d in dalAmiyaEmployee.GetAll()
                           where d.IsCustomerService==true
                           && d.Valid==true
                           && (d.AmiyaPositionInfo.Name.Contains("客服")
                           || d.AmiyaPositionInfo.Name.Contains("客服管理员"))
                           select new AmiyaEmployeeNameDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                           };
            return await employee.ToListAsync();

        }
        /// <summary>
        /// 获取运营咨询人员姓名列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaEmployeeNameDto>> GetOperatingConsultingNameListAsync()
        {
            var employee = from d in dalAmiyaEmployee.GetAll()
                           where d.Valid
                           && d.AmiyaPositionInfo.Id == 19
                           select new AmiyaEmployeeNameDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                           };
            return await employee.ToListAsync();

        }

        /// <summary>
        /// 获取财务人员姓名列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaEmployeeNameDto>> GetFinancialNameListAsync()
        {
            var employee = from d in dalAmiyaEmployee.GetAll()
                           where d.Valid
                           && d.AmiyaPositionInfo.Id == 13
                           select new AmiyaEmployeeNameDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                           };
            return await employee.ToListAsync();

        }
        /// <summary>
        /// 获取面诊员姓名列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaEmployeeNameDto>> GetConsultingNameListAsync()
        {
            var employee = from d in dalAmiyaEmployee.GetAll()
                           where d.IsCustomerService && d.Valid
                           && d.AmiyaPositionInfo.Name.Contains("面诊员")
                           select new AmiyaEmployeeNameDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                           };
            return await employee.ToListAsync();

        }

        /// <summary>
        /// 根据职位id获取人员
        /// </summary>
        /// <returns></returns>

        public async Task<List<AmiyaEmployeeNameDto>> GetemployeeByPositionIdAsync(int positionId)
        {
            var employee = from d in dalAmiyaEmployee.GetAll()
                           where d.Valid
                           && d.AmiyaPositionInfo.Id == positionId
                           select new AmiyaEmployeeNameDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                           };
            return await employee.ToListAsync();

        }
    }
}
