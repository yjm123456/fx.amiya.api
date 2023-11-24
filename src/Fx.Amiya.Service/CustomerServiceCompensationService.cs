﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CustomerServiceCompensation.Input;
using Fx.Amiya.Dto.CustomerServiceCompensation.Result;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class CustomerServiceCompensationService : ICustomerServiceCompensationService
    {
        private readonly IDalCustomerServiceCompensation dalCustomerServiceCompensation;
        private IRecommandDocumentSettleService recommandDocumentSettleService;
        private readonly IUnitOfWork unitOfWork;
        public CustomerServiceCompensationService(IDalCustomerServiceCompensation dalCustomerServiceCompensation,
            IRecommandDocumentSettleService recommandDocumentSettleService,
            IUnitOfWork unitOfWork)
        {
            this.dalCustomerServiceCompensation = dalCustomerServiceCompensation;
            this.recommandDocumentSettleService = recommandDocumentSettleService;
            this.unitOfWork = unitOfWork;
        }



        /// <summary>
        /// 根据条件获取助理薪资单信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerServiceCompensationDto>> GetListAsync(QueryCustomerServiceCompensationDto query)
        {
            var customerServiceCompensations = from d in dalCustomerServiceCompensation.GetAll().Include(x => x.CreateByEmployee).Include(x => x.BelongEmployee)
                                               where (string.IsNullOrWhiteSpace(query.KeyWord) || d.Name.Contains(query.KeyWord) || d.Remark.Contains(query.KeyWord))
                                               && (!query.BelongEmpId.HasValue || d.BelongEmpId == query.BelongEmpId.Value)
                                               && (!query.Valid.HasValue || d.Valid == query.Valid.Value)
                                               && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                                               && (!query.EndDate.HasValue || d.CreateDate < query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                               select new CustomerServiceCompensationDto
                                               {
                                                   Id = d.Id,
                                                   CreateDate = d.CreateDate,
                                                   CreateBy = d.CreateBy,
                                                   CreateByEmpName = d.CreateByEmployee.Name,
                                                   UpdateDate = d.UpdateDate,
                                                   Valid = d.Valid,
                                                   DeleteDate = d.DeleteDate,
                                                   Name = d.Name,
                                                   BelongEmpId = d.BelongEmpId,
                                                   BelongEmpName = d.BelongEmployee.Name,
                                                   TotalPrice = d.TotalPrice,
                                                   OtherPrice = d.OtherPrice,
                                                   Remark = d.Remark,
                                               };
            FxPageInfo<CustomerServiceCompensationDto> customerServiceCompensationPageInfo = new FxPageInfo<CustomerServiceCompensationDto>();
            customerServiceCompensationPageInfo.TotalCount = await customerServiceCompensations.CountAsync();
            customerServiceCompensationPageInfo.List = await customerServiceCompensations.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return customerServiceCompensationPageInfo;
        }


        /// <summary>
        /// 添加助理薪资单
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddCustomerServiceCompensationDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                CustomerServiceCompensation customerServiceCompensation = new CustomerServiceCompensation();
                customerServiceCompensation.Id = Guid.NewGuid().ToString();
                customerServiceCompensation.CreateDate = DateTime.Now;
                customerServiceCompensation.CreateBy = addDto.CreateBy;
                customerServiceCompensation.Name = addDto.Name;
                customerServiceCompensation.Valid = true;
                customerServiceCompensation.BelongEmpId = addDto.BelongEmpId;
                customerServiceCompensation.TotalPrice = addDto.TotalPrice;
                customerServiceCompensation.OtherPrice = addDto.OtherPrice;
                customerServiceCompensation.Remark = addDto.Remark;
                await dalCustomerServiceCompensation.AddAsync(customerServiceCompensation, true);

                //对账单审核记录加入id
                await recommandDocumentSettleService.AddCustomerServiceCompensationIdAsync(addDto.RecommandDocumentSettleIdList, customerServiceCompensation.Id);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.ToString());
            }
        }



        public async Task<CustomerServiceCompensationDto> GetByIdAsync(string id)
        {
            var result = await dalCustomerServiceCompensation.GetAll().Include(x => x.CreateByEmployee).Include(x => x.BelongEmployee).Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new CustomerServiceCompensationDto();
            }

            CustomerServiceCompensationDto returnResult = new CustomerServiceCompensationDto();

            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.CreateBy = result.CreateBy;
            returnResult.CreateByEmpName = result.CreateByEmployee.Name;
            returnResult.UpdateDate = result.UpdateDate;
            returnResult.Valid = result.Valid;
            returnResult.DeleteDate = result.DeleteDate;
            returnResult.Name = result.Name;
            returnResult.BelongEmpId = result.BelongEmpId;
            returnResult.BelongEmpName = result.BelongEmployee.Name;
            returnResult.TotalPrice = result.TotalPrice;
            returnResult.OtherPrice = result.OtherPrice;
            returnResult.Remark = result.Remark;

            return returnResult;
        }



        /// <summary>
        /// 修改助理薪资单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateCustomerServiceCompensationDto updateDto)
        {
            var result = await dalCustomerServiceCompensation.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到助理薪资单信息");
            result.Name = updateDto.Name;
            result.BelongEmpId = updateDto.BelongEmpId;
            result.TotalPrice = updateDto.TotalPrice;
            result.OtherPrice = updateDto.OtherPrice;
            result.Remark = updateDto.Remark;
            result.UpdateDate = DateTime.Now;
            await dalCustomerServiceCompensation.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废助理薪资单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {

                var result = await dalCustomerServiceCompensation.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到助理薪资单信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalCustomerServiceCompensation.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }

    }
}