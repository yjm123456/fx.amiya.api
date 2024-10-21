﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Amiya.Dto.CustomerServiceCheckPerformance.Input;
using Fx.Amiya.Dto.CustomerServiceCheckPerformance.Result;
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
    public class CustomerServiceCheckPerformanceService : ICustomerServiceCheckPerformanceService
    {
        private readonly IDalCustomerServiceCheckPerformance dalCustomerServiceCheckPerformance;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        public CustomerServiceCheckPerformanceService(IDalCustomerServiceCheckPerformance dalCustomerServiceCheckPerformance, IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.dalCustomerServiceCheckPerformance = dalCustomerServiceCheckPerformance;
            this.amiyaEmployeeService = amiyaEmployeeService;
        }



        /// <summary>
        /// 根据条件获取助理提取业绩信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerServiceCheckPerformanceDto>> GetListAsync(QueryCustomerServiceCheckPerformanceDto query)
        {
            AmiyaEmployeeDto employeeInfo = new AmiyaEmployeeDto();
            var customerServiceCheckPerformances = from d in dalCustomerServiceCheckPerformance.GetAll().Include(x => x.AmiyaEmployee)
                                                   where (string.IsNullOrEmpty(query.KeyWord) || d.Remark.Contains(query.KeyWord) || d.DealInfoId.Contains(query.KeyWord) || d.OrderId.Contains(query.KeyWord))
                                                   && (!query.Valid.HasValue || d.Valid == query.Valid.Value)
                                                   && (!query.BelongEmpId.HasValue || d.BelongEmpId == query.BelongEmpId.Value)
                                                   && (query.IsCheckPerformance==false || d.PerformanceType ==(int)PerformanceType.Check)
                                                   && (!query.CheckEmpId.HasValue || d.CheckEmpId == query.CheckEmpId.Value)
                                                   && (query.PerformanceTypeList.Count()==0 || query.PerformanceTypeList.Contains(d.PerformanceType))
                                                   select new CustomerServiceCheckPerformanceDto
                                                   {
                                                       Id = d.Id,
                                                       CreateDate = d.CreateDate,
                                                       UpdateDate = d.UpdateDate,
                                                       Valid = d.Valid,
                                                       DeleteDate = d.DeleteDate,
                                                       DealInfoId = d.DealInfoId,
                                                       OrderId = d.OrderId,
                                                       OrderFrom = d.OrderFrom,
                                                       OrderFromText = ServiceClass.GetOrderFromText(d.OrderFrom),
                                                       DealPrice = d.DealPrice,
                                                       DealCreateDate = d.DealCreateDate,
                                                       PerformanceType = d.PerformanceType,
                                                       PerformanceTypeText = ServiceClass.GetPerformanceTypeText(d.PerformanceType),
                                                       BelongEmpId = d.BelongEmpId,
                                                       BelongEmpName = d.AmiyaEmployee.Name,
                                                       CheckEmpId = d.CheckEmpId,
                                                       Remark = d.Remark,
                                                       Point = d.Point,
                                                       PerformanceCommision = d.PerformanceCommision,
                                                       PerformanceCommisionCheck = d.PerformanceCommisionCheck,
                                                       BillId = d.BillId,
                                                       CheckBillId = d.CheckBillId,
                                                   };
            FxPageInfo<CustomerServiceCheckPerformanceDto> customerServiceCheckPerformancePageInfo = new FxPageInfo<CustomerServiceCheckPerformanceDto>();
            customerServiceCheckPerformancePageInfo.TotalCount = await customerServiceCheckPerformances.CountAsync();
            customerServiceCheckPerformancePageInfo.List = await customerServiceCheckPerformances.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            foreach (var x in customerServiceCheckPerformancePageInfo.List)
            {
                if (x.CheckEmpId.HasValue)
                {
                    var empInfo = await amiyaEmployeeService.GetByIdAsync(x.CheckEmpId.Value);
                    x.CheckEmpName = empInfo.Name;
                }
            }
            return customerServiceCheckPerformancePageInfo;
        }


        /// <summary>
        /// 添加助理提取业绩
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddCustomerServiceCheckPerformanceDto addDto)
        {
            try
            {
                CustomerServiceCheckPerformance customerServiceCheckPerformance = new CustomerServiceCheckPerformance();
                customerServiceCheckPerformance.Id = Guid.NewGuid().ToString();
                customerServiceCheckPerformance.CreateDate = DateTime.Now;
                customerServiceCheckPerformance.Valid = true;
                customerServiceCheckPerformance.DealInfoId = addDto.DealInfoId;
                customerServiceCheckPerformance.OrderId = addDto.OrderId;
                customerServiceCheckPerformance.OrderFrom = addDto.OrderFrom;
                customerServiceCheckPerformance.DealPrice = addDto.DealPrice;
                customerServiceCheckPerformance.DealCreateDate = addDto.DealCreateDate;
                customerServiceCheckPerformance.PerformanceType = addDto.PerformanceType;
                customerServiceCheckPerformance.BelongEmpId = addDto.BelongEmpId;
                customerServiceCheckPerformance.Remark = addDto.Remark;
                customerServiceCheckPerformance.Point = addDto.Point;
                customerServiceCheckPerformance.CheckEmpId = addDto.CheckEmpId;
                customerServiceCheckPerformance.BillId = addDto.BillId;
                customerServiceCheckPerformance.CheckBillId = addDto.CheckBillId;
                customerServiceCheckPerformance.PerformanceCommisionCheck = addDto.PerformanceCommisionCheck;
                customerServiceCheckPerformance.PerformanceCommision = addDto.PerformanceCommision;
                await dalCustomerServiceCheckPerformance.AddAsync(customerServiceCheckPerformance, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



        public async Task<CustomerServiceCheckPerformanceDto> GetByIdAsync(string id)
        {
            var result = await dalCustomerServiceCheckPerformance.GetAll().Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new CustomerServiceCheckPerformanceDto();
            }

            CustomerServiceCheckPerformanceDto returnResult = new CustomerServiceCheckPerformanceDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.DealInfoId = result.DealInfoId;
            returnResult.OrderId = result.OrderId;
            returnResult.OrderFrom = result.OrderFrom;
            returnResult.DealPrice = result.DealPrice;
            returnResult.DealCreateDate = result.DealCreateDate;
            returnResult.PerformanceType = result.PerformanceType;
            returnResult.BelongEmpId = result.BelongEmpId;
            returnResult.Remark = result.Remark;
            returnResult.Point = result.Point;
            returnResult.PerformanceCommision = result.PerformanceCommision;
            returnResult.PerformanceCommisionCheck = result.PerformanceCommisionCheck;
            returnResult.CheckEmpId = result.CheckEmpId;
            returnResult.BillId = result.BillId;
            returnResult.CheckBillId = result.CheckBillId;
            return returnResult;
        }

        /// <summary>
        /// 修改助理提取业绩
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateCustomerServiceCheckPerformanceDto updateDto)
        {
            var result = await dalCustomerServiceCheckPerformance.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到助理提取业绩信息");

            result.DealInfoId = updateDto.DealInfoId;
            result.OrderId = updateDto.OrderId;
            result.OrderFrom = updateDto.OrderFrom;
            result.DealPrice = updateDto.DealPrice;
            result.DealCreateDate = updateDto.DealCreateDate;
            result.PerformanceType = updateDto.PerformanceType;
            result.BelongEmpId = updateDto.BelongEmpId;
            result.Remark = updateDto.Remark;
            result.Point = updateDto.Point;
            result.PerformanceCommision = updateDto.PerformanceCommision;
            result.PerformanceCommisionCheck = updateDto.PerformanceCommisionCheck;
            result.CheckEmpId = updateDto.CheckEmpId;
            result.BillId = updateDto.BillId;
            result.CheckBillId = updateDto.CheckBillId;
            result.UpdateDate = DateTime.Now;
            await dalCustomerServiceCheckPerformance.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废助理提取业绩
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalCustomerServiceCheckPerformance.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到助理提取业绩信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalCustomerServiceCheckPerformance.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }

    }
}
