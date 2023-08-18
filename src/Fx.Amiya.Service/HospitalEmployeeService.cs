using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalEmployee;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Fx.Common;

namespace Fx.Amiya.Service
{
   public class HospitalEmployeeService: IHospitalEmployeeService
    {
        private IDalHospitalEmployee dalHospitalEmployee;
        public HospitalEmployeeService(IDalHospitalEmployee dalHospitalEmployee)
        {
            this.dalHospitalEmployee = dalHospitalEmployee;
        }


        public async Task AddAsync(AddHospitalEmployeeDto addDto,string employeeType)
        {
            try
            {
                var count = await dalHospitalEmployee.GetAll().CountAsync(e => e.UserName == addDto.UserName);
                if (count > 0)
                    throw new Exception("用户名已被占用，请重新输入");

                HospitalEmployee employee = new HospitalEmployee();

                employee.Name = addDto.Name;
                employee.UserName = addDto.UserName;
                employee.Password = addDto.Password;
                employee.HospitalId = addDto.HospitalId;
                employee.HospitalPositionId = addDto.HospitalPositionId;
                employee.IsCustomerService = addDto.IsCustomerService;
                employee.Valid = true;
                if (employeeType == "amiyaEmployee")
                    employee.IsCreateSubAccount = addDto.IsCreateSubAccount;

                if (employeeType == "hospitalEmployee")
                    employee.IsCreateSubAccount = false;

                await dalHospitalEmployee.AddAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<HospitalEmployeeDto> GetByIdAsync(int id)
        {
            try
            {
                var employee = await dalHospitalEmployee.GetAll()
                    .Include(e=>e.HospitalInfo)
                    .Include(e=>e.HospitalPositionInfo)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                    throw new Exception("员工编号错误");

                HospitalEmployeeDto employeeDto = new HospitalEmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Avatar = employee.Avatar,
                    UserName = employee.UserName,
                    Password = employee.Password,
                    HospitalId = employee.HospitalId,
                    HospitalName = employee.HospitalInfo.Name,
                    Valid = employee.Valid,
                    IsCreateSubAccount = employee.IsCreateSubAccount,
                    HospitalPositionId = employee.HospitalPositionId,
                    HospitalPositionName = employee.HospitalPositionInfo.Name,
                    IsCustomerService = employee.IsCustomerService
                };

                return employeeDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }




        public async Task<FxPageInfo<HospitalEmployeeDto>> GetListWithPageAsync(int? hospitalId,string keyword, int pageNum, int pageSize,bool? valid)
        {
            try
            {
                if (pageSize > 100)
                    throw new Exception("每次查询不能超过100条");

                var employees = from d in dalHospitalEmployee.GetAll()
                                where d.HospitalInfo.Valid
                                &&(hospitalId==null||d.HospitalId==hospitalId)
                                && (keyword == null || d.Name.Contains(keyword)||d.UserName.Contains(keyword))
                                &&(valid==null||d.Valid==valid)
                                select new HospitalEmployeeDto
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    UserName = d.UserName,
                                    Password = d.Password,
                                    Valid = d.Valid,
                                    HospitalId=d.HospitalId,
                                    HospitalName=d.HospitalInfo.Name,
                                    IsCreateSubAccount=d.IsCreateSubAccount,
                                    HospitalPositionId=d.HospitalPositionId,
                                    HospitalPositionName=d.HospitalPositionInfo.Name,
                                    IsCustomerService=d.IsCustomerService,
                                };
                FxPageInfo<HospitalEmployeeDto> employeePageInfo = new FxPageInfo<HospitalEmployeeDto>();
                employeePageInfo.TotalCount = await employees.CountAsync();
                employeePageInfo.List = await employees.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return employeePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }





        public async Task ResetPasswordAsync(int employeeId, string password)
        {
            try
            {
                var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                    throw new Exception("员工编号错误");

                employee.Password = password;
                await dalHospitalEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAccountValidAsync(int employeeId, bool valid)
        {
            try
            {
                var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                    throw new Exception("员工编号错误");

                employee.Valid = valid;
                await dalHospitalEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }




        public async Task UpdateAsync(UpdateHospitalEmployeeDto updateDto,string employeeType)
        {
            try
            {
                var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (employee == null)
                    throw new Exception("员工编号错误");

                var count = await dalHospitalEmployee.GetAll().CountAsync(e => e.UserName == updateDto.UserName && e.Id != updateDto.Id);
                if (count > 0)
                    throw new Exception("用户名已被占用，请重新输入");

                employee.Name = updateDto.Name;
                employee.UserName = updateDto.UserName;
                employee.Valid = updateDto.Valid;
                employee.HospitalPositionId = updateDto.HospitalPositionId;
                employee.IsCustomerService = updateDto.IsCustomerService;
                if (employeeType == "amiyaEmployee")
                {
                    employee.HospitalId = updateDto.HospitalId;
                    employee.IsCreateSubAccount = updateDto.IsCreateSubAccount;
                }

               
                await dalHospitalEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }




        public async Task<HospitalEmployeeDto> LoginAsync(string userName, string password)
        {
            try
            {
                var employee = await dalHospitalEmployee.GetAll()
                    .Include(e=>e.HospitalInfo)
                    .Include(e=>e.HospitalPositionInfo)
                    .SingleOrDefaultAsync(e => e.UserName == userName);

                if (employee == null)
                    throw new Exception("用户名不存在");

                if (employee.Valid == false)
                    throw new Exception("账户已失效");

                if (employee.Password != password)
                    throw new Exception("密码错误");

                HospitalEmployeeDto employeeDto = new HospitalEmployeeDto();
                employeeDto.Id = employee.Id;
                employeeDto.Name = employee.Name;
                employeeDto.UserName = employee.UserName;
                employeeDto.Password = employee.Password;
                employeeDto.Valid = employee.Valid;
                employeeDto.HospitalId = employee.HospitalId;
                employeeDto.HospitalName = employee.HospitalInfo.Name;
                employeeDto.HospitalPositionId = employee.HospitalPositionId;
                employeeDto.HospitalPositionName = employee.HospitalPositionInfo.Name;
                employeeDto.IsCustomerService = employee.IsCustomerService;
                employeeDto.Avatar = employee.Avatar;
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdatePasswordAsync(UpdatePasswordHospitalDto updateDto, int employeeId)
        {
            try
            {
                var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);


                if (updateDto.OldPassword != employee.Password)
                    throw new Exception("原始密码错误，请重新输入！");

                employee.Password = updateDto.NewPassword;
                await dalHospitalEmployee.UpdateAsync(employee, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }




        /// <summary>
        /// 修改医院员工密码
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateEmployeePasswordByIdAsync(UpdateEmployeePasswordDto updateDto)
        {
            var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (employee == null)
                throw new Exception("医院员工编号错误");
            employee.Password = updateDto.Password;
            await dalHospitalEmployee.UpdateAsync(employee,true);
        }




        public async Task DeleteAsync(int id)
        {
            try
            {
                var hospitalEmployee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (hospitalEmployee == null)
                    throw new Exception("医院员工编号错误");

                await dalHospitalEmployee.DeleteAsync(hospitalEmployee,true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 根据员工id集合获取医院员工基础信息列表
        /// </summary>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        public async Task<List<HospitalEmployeeBaseInfoDto>> GetBaseInfoListAsync(int[] employeeIds)
        {
            try
            {
                List<HospitalEmployeeBaseInfoDto>hospitalEmployeeList = new List<HospitalEmployeeBaseInfoDto>();
                foreach (var item in employeeIds)
                {
                    var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == item);
                    if (employee != null)
                    {
                        HospitalEmployeeBaseInfoDto hospitalEmployee = new HospitalEmployeeBaseInfoDto();
                        hospitalEmployee.Id = employee.Id;
                        hospitalEmployee.Name = employee.Name;
                        hospitalEmployeeList.Add(hospitalEmployee);
                    }
                }
                return hospitalEmployeeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 修改医院账号头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAvatarAsync(int id,string url)
        {
            var account =await dalHospitalEmployee.GetAll().Where(e => e.Id == id).SingleOrDefaultAsync();
            if (account == null) throw new Exception("用户编号错误");
            account.Avatar = url;
            await dalHospitalEmployee.UpdateAsync(account,true);
        }
    }
}
