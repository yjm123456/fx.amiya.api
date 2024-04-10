using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.EmployeePerformanceTarget.Input;
using Fx.Amiya.Dto.EmployeePerformanceTarget.Result;
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
    public class EmployeePerformanceTargetService : IEmployeePerformanceTargetService
    {
        private readonly IDalEmployeePerformanceTarget dalEmployeePerformanceTarget;
        public EmployeePerformanceTargetService(IDalEmployeePerformanceTarget dalEmployeePerformanceTarget)
        {
            this.dalEmployeePerformanceTarget = dalEmployeePerformanceTarget;
        }



        /// <summary>
        /// 根据条件获取助理业绩目标信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<EmployeePerformanceTargetDto>> GetListAsync(QueryEmployeePerformanceTargetDto query)
        {
            var cmployeePerformanceTargets = from d in dalEmployeePerformanceTarget.GetAll().Include(x => x.AmiyaEmployee)
                                               where (!query.EmployeeId.HasValue || d.EmployeeId == query.EmployeeId.Value)
                                               && ( d.Valid == true)
                                               && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                                               && (!query.EndDate.HasValue || d.CreateDate < query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                               select new EmployeePerformanceTargetDto
                                               {
                                                   Id = d.Id,
                                                   CreateDate = d.CreateDate,
                                                   EmployeeId = d.EmployeeId,
                                                   EmployeeName = d.AmiyaEmployee.Name,
                                                   UpdateDate = d.UpdateDate,
                                                   Valid = d.Valid,
                                                   DeleteDate = d.DeleteDate,
                                                   BelongMonth = d.BelongMonth,
                                                   BelongYear = d.BelongYear,
                                                   ConsulationCardTarget = d.ConsulationCardTarget,
                                                   AddWechatTarget = d.AddWechatTarget,
                                                   SendOrderTarget = d.SendOrderTarget,
                                                   VisitTarget = d.VisitTarget,
                                                   NewCustomerDealTarget = d.NewCustomerDealTarget,
                                                   OldCustomerDealTarget = d.OldCustomerDealTarget,
                                                   NewCustomerPerformanceTarget = d.NewCustomerPerformanceTarget,
                                                   OldCustomerPerformanceTarget = d.OldCustomerPerformanceTarget,
                                                   PerformanceTarget = d.PerformanceTarget,
                                               };
            FxPageInfo<EmployeePerformanceTargetDto> cmployeePerformanceTargetPageInfo = new FxPageInfo<EmployeePerformanceTargetDto>();
            cmployeePerformanceTargetPageInfo.TotalCount = await cmployeePerformanceTargets.CountAsync();
            cmployeePerformanceTargetPageInfo.List = await cmployeePerformanceTargets.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return cmployeePerformanceTargetPageInfo;
        }


        /// <summary>
        /// 添加助理业绩目标
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddEmployeePerformanceTargetDto addDto)
        {
            try
            {
                EmployeePerformanceTarget cmployeePerformanceTarget = new EmployeePerformanceTarget();
                cmployeePerformanceTarget.Id = Guid.NewGuid().ToString();
                cmployeePerformanceTarget.CreateDate = DateTime.Now;
                cmployeePerformanceTarget.EmployeeId = addDto.EmployeeId;
                cmployeePerformanceTarget.Valid = true;
                cmployeePerformanceTarget.BelongYear = addDto.BelongYear;
                cmployeePerformanceTarget.BelongMonth = addDto.BelongMonth;
                cmployeePerformanceTarget.ConsulationCardTarget = addDto.ConsulationCardTarget;
                cmployeePerformanceTarget.AddWechatTarget = addDto.AddWechatTarget;
                cmployeePerformanceTarget.SendOrderTarget = addDto.SendOrderTarget;
                cmployeePerformanceTarget.VisitTarget = addDto.VisitTarget;
                cmployeePerformanceTarget.NewCustomerDealTarget = addDto.NewCustomerDealTarget;
                cmployeePerformanceTarget.OldCustomerDealTarget = addDto.OldCustomerDealTarget;
                cmployeePerformanceTarget.NewCustomerPerformanceTarget = addDto.NewCustomerPerformanceTarget;
                cmployeePerformanceTarget.OldCustomerPerformanceTarget = addDto.OldCustomerPerformanceTarget;
                cmployeePerformanceTarget.PerformanceTarget = addDto.PerformanceTarget;
                await dalEmployeePerformanceTarget.AddAsync(cmployeePerformanceTarget, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



        public async Task<EmployeePerformanceTargetDto> GetByIdAsync(string id)
        {
            var result = await dalEmployeePerformanceTarget.GetAll().Include(x => x.AmiyaEmployee).Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new EmployeePerformanceTargetDto();
            }

            EmployeePerformanceTargetDto returnResult = new EmployeePerformanceTargetDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.EmployeeId = result.EmployeeId;
            returnResult.EmployeeName = result.AmiyaEmployee.Name;
            returnResult.Valid = result.Valid;
            returnResult.BelongYear = result.BelongYear;
            returnResult.BelongMonth = result.BelongMonth;
            returnResult.ConsulationCardTarget = result.ConsulationCardTarget;
            returnResult.AddWechatTarget = result.AddWechatTarget;
            returnResult.SendOrderTarget = result.SendOrderTarget;
            returnResult.VisitTarget = result.VisitTarget;
            returnResult.NewCustomerDealTarget = result.NewCustomerDealTarget;
            returnResult.OldCustomerDealTarget = result.OldCustomerDealTarget;
            returnResult.NewCustomerPerformanceTarget = result.NewCustomerPerformanceTarget;
            returnResult.OldCustomerPerformanceTarget = result.OldCustomerPerformanceTarget;
            returnResult.PerformanceTarget = result.PerformanceTarget;

            return returnResult;
        }



        /// <summary>
        /// 修改助理业绩目标
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateEmployeePerformanceTargetDto updateDto)
        {
            var result = await dalEmployeePerformanceTarget.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到助理业绩目标信息");

            result.EmployeeId = updateDto.EmployeeId;
            result.BelongYear = updateDto.BelongYear;
            result.BelongMonth = updateDto.BelongMonth;
            result.ConsulationCardTarget = updateDto.ConsulationCardTarget;
            result.AddWechatTarget = updateDto.AddWechatTarget;
            result.SendOrderTarget = updateDto.SendOrderTarget;
            result.VisitTarget = updateDto.VisitTarget;
            result.NewCustomerDealTarget = updateDto.NewCustomerDealTarget;
            result.OldCustomerDealTarget = updateDto.OldCustomerDealTarget;
            result.NewCustomerPerformanceTarget = updateDto.NewCustomerPerformanceTarget;
            result.OldCustomerPerformanceTarget = updateDto.OldCustomerPerformanceTarget;
            result.PerformanceTarget = updateDto.PerformanceTarget;
            result.UpdateDate = DateTime.Now;
            await dalEmployeePerformanceTarget.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废助理业绩目标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalEmployeePerformanceTarget.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到助理业绩目标信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalEmployeePerformanceTarget.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }

    }
}
