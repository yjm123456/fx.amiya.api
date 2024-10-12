using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Amiya.Dto.EmployeePerformanceLadder.Input;
using Fx.Amiya.Dto.EmployeePerformanceLadder.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class EmployeePerformanceLadderService : IEmployeePerformanceLadderService
    {
        private readonly IDalEmployeePerformanceLadder dalEmployeePerformanceLadder;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        public EmployeePerformanceLadderService(IDalEmployeePerformanceLadder dalEmployeePerformanceLadder, IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.dalEmployeePerformanceLadder = dalEmployeePerformanceLadder;
            this.amiyaEmployeeService = amiyaEmployeeService;
        }



        /// <summary>
        /// 根据条件获取助理业绩提点阶梯信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<EmployeePerformanceLadderDto>> GetListAsync(QueryEmployeePerformanceLadderDto query)
        {
            AmiyaEmployeeDto employeeInfo = new AmiyaEmployeeDto();
            var employeePerformanceLadders = from d in dalEmployeePerformanceLadder.GetAll()
                                                where (string.IsNullOrEmpty(query.KeyWord) || d.Remark.Contains(query.KeyWord))
                                                && (d.Valid == query.Valid)
                                                select new EmployeePerformanceLadderDto
                                                {
                                                    Id = d.Id,
                                                    CreateDate = d.CreateDate,
                                                    UpdateDate = d.UpdateDate,
                                                    Valid = d.Valid,
                                                    DeleteDate = d.DeleteDate,
                                                    CustomerServiceId = d.CustomerServiceId,
                                                    IsPersonalConfig = d.IsPersonalConfig,
                                                    PerformanceLowerLimit = d.PerformanceLowerLimit,
                                                    PerformanceUpperLimit = d.PerformanceUpperLimit,
                                                    BasePerformance = d.BasePerformance,
                                                    Year = d.Year,
                                                    Month = d.Month,
                                                    Point = d.Point,
                                                    Remark = d.Remark,
                                                };
            FxPageInfo<EmployeePerformanceLadderDto> employeePerformanceLadderPageInfo = new FxPageInfo<EmployeePerformanceLadderDto>();
            employeePerformanceLadderPageInfo.TotalCount = await employeePerformanceLadders.CountAsync();
            employeePerformanceLadderPageInfo.List = await employeePerformanceLadders.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return employeePerformanceLadderPageInfo;
        }


        /// <summary>
        /// 添加助理业绩提点阶梯
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddEmployeePerformanceLadderDto addDto)
        {
            try
            {
                EmployeePerformanceLadder employeePerformanceLadder = new EmployeePerformanceLadder();
                employeePerformanceLadder.Id = Guid.NewGuid().ToString();
                employeePerformanceLadder.CreateDate = DateTime.Now;
                employeePerformanceLadder.Valid = true;
                employeePerformanceLadder.CustomerServiceId = addDto.CustomerServiceId;
                employeePerformanceLadder.IsPersonalConfig = addDto.IsPersonalConfig;
                employeePerformanceLadder.PerformanceLowerLimit = addDto.PerformanceLowerLimit;
                employeePerformanceLadder.PerformanceUpperLimit = addDto.PerformanceUpperLimit;
                employeePerformanceLadder.BasePerformance = addDto.BasePerformance;
                employeePerformanceLadder.Year = addDto.Year;
                employeePerformanceLadder.Month = addDto.Month;
                employeePerformanceLadder.Remark = addDto.Remark;
                employeePerformanceLadder.Point = addDto.Point;
                await dalEmployeePerformanceLadder.AddAsync(employeePerformanceLadder, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



        public async Task<EmployeePerformanceLadderDto> GetByIdAsync(string id)
        {
            var result = await dalEmployeePerformanceLadder.GetAll().Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new EmployeePerformanceLadderDto();
            }

            EmployeePerformanceLadderDto returnResult = new EmployeePerformanceLadderDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.CustomerServiceId = result.CustomerServiceId;
            returnResult.IsPersonalConfig = result.IsPersonalConfig;
            returnResult.PerformanceLowerLimit = result.PerformanceLowerLimit;
            returnResult.PerformanceUpperLimit = result.PerformanceUpperLimit;
            returnResult.BasePerformance = result.BasePerformance;
            returnResult.Year = result.Year;
            returnResult.Month = result.Month;
            returnResult.Remark = result.Remark;
            returnResult.Point = result.Point;
            return returnResult;
        }

        /// <summary>
        /// 修改助理业绩提点阶梯
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateEmployeePerformanceLadderDto updateDto)
        {
            var result = await dalEmployeePerformanceLadder.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到助理业绩提点阶梯信息");

            result.CustomerServiceId = updateDto.CustomerServiceId;
            result.IsPersonalConfig = updateDto.IsPersonalConfig;
            result.PerformanceLowerLimit = updateDto.PerformanceLowerLimit;
            result.PerformanceUpperLimit = updateDto.PerformanceUpperLimit;
            result.BasePerformance = updateDto.BasePerformance;
            result.Year = updateDto.Year;
            result.Month = updateDto.Month;
            result.Remark = updateDto.Remark;
            result.Point = updateDto.Point;
            result.UpdateDate = DateTime.Now;
            await dalEmployeePerformanceLadder.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废助理业绩提点阶梯
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalEmployeePerformanceLadder.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到助理业绩提点阶梯信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalEmployeePerformanceLadder.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }


        /// <summary>
        /// 获取有效的助理业绩提点阶梯信息（下拉框使用）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetValidListAsync()
        {
            var employeePerformanceLadders = from d in dalEmployeePerformanceLadder.GetAll()
                                                where (d.Valid == true)
                                                select new BaseKeyValueDto
                                                {
                                                    Key = d.Id,
                                                    Value = d.Remark
                                                };
            List<BaseKeyValueDto> employeePerformanceLadderPageInfo = new List<BaseKeyValueDto>();
            employeePerformanceLadderPageInfo = await employeePerformanceLadders.ToListAsync();
            return employeePerformanceLadderPageInfo;
        }
    }
}
