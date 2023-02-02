
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ReconciliationDocuments;
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
    public class RecommandDocumentSettleService : IRecommandDocumentSettleService
    {
        private IDalRecommandDocumentSettle _dalRecommandDocumentSettle;
        private IAmiyaEmployeeService amiyaEmployeeService;
        private ILiveAnchorService liveAnchorService;
        public RecommandDocumentSettleService(IDalRecommandDocumentSettle dalRecommandDocumentSettle,
            ILiveAnchorService liveAnchorService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            _dalRecommandDocumentSettle = dalRecommandDocumentSettle;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.liveAnchorService = liveAnchorService;
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="isSettle"></param>
        /// <param name="accountType"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<RecommandDocumentSettleDto>> GetListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword, int pageNum, int pageSize)
        {
            if (endDate.HasValue)
            {
                endDate = endDate.Value.Date.AddDays(1);
            }
            var record = _dalRecommandDocumentSettle.GetAll().Include(x => x.AmiyaEmployee)
                .Where(e => (string.IsNullOrEmpty(keyword) || e.RecommandDocumentId.Contains(keyword) || e.OrderId.Contains(keyword) || e.DealInfoId.Contains(keyword)))
                .Where(e => !isSettle.HasValue || e.IsSettle == isSettle.Value)
                .Where(e => !startDate.HasValue || e.CreateDate >= startDate)
                .Where(e => !endDate.HasValue || e.CreateDate <= endDate)
                .Where(e => !accountType.HasValue || e.AccountType == accountType).OrderByDescending(x => x.CreateDate)
                .Select(e => new RecommandDocumentSettleDto
                {
                    Id = e.Id,
                    RecommandDocumentId = e.RecommandDocumentId,
                    OrderId = e.OrderId,
                    DealInfoId = e.DealInfoId,
                    OrderFrom = e.OrderFrom,
                    OrderFromText = ServiceClass.GetOrderFromText(e.OrderFrom),
                    ReturnBackPrice = e.ReturnBackPrice,
                    CreateDate = e.CreateDate,
                    IsSettle = e.IsSettle,
                    SettleDate = e.SettleDate,
                    BelongLiveAnchorAccount = e.BelongLiveAnchorAccount,
                    BelongEmpId = e.BelongEmpId,
                    CreateByEmpName = e.AmiyaEmployee.Name,
                    AccountTypeText = e.AccountType == true ? "出账" : "入账",
                    AccountPrice = e.AccountPrice
                });
            FxPageInfo<RecommandDocumentSettleDto> fxPageInfo = new FxPageInfo<RecommandDocumentSettleDto>();
            fxPageInfo.TotalCount =await record.CountAsync();
            fxPageInfo.List =await record.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in fxPageInfo.List)
            {
                if (x.BelongEmpId.HasValue)
                {
                    var empInfo = await amiyaEmployeeService.GetByIdAsync(x.BelongEmpId.Value);
                    x.BelongEmpName = empInfo.Name;
                }
                if (x.BelongLiveAnchorAccount.HasValue)
                {
                    var liveAnchor = await liveAnchorService.GetByIdAsync(x.BelongLiveAnchorAccount.Value);
                    x.BelongLiveAnchor = liveAnchor.Name;
                }
            }
            return fxPageInfo;
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="isSettle"></param>
        /// <param name="accountType"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<RecommandDocumentSettleDto>> ExportListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword)
        {
            if (endDate.HasValue)
            {
                endDate = endDate.Value.Date.AddDays(1);
            }
            var record = _dalRecommandDocumentSettle.GetAll().Include(x => x.AmiyaEmployee)
                .Where(e => (string.IsNullOrEmpty(keyword) || e.RecommandDocumentId.Contains(keyword) || e.OrderId.Contains(keyword) || e.DealInfoId.Contains(keyword)))
                .Where(e => !isSettle.HasValue || e.IsSettle == isSettle.Value)
                .Where(e => !startDate.HasValue || e.CreateDate >= startDate)
                .Where(e => !endDate.HasValue || e.CreateDate <= endDate)
                .Where(e => !accountType.HasValue || e.AccountType == accountType).OrderByDescending(x => x.CreateDate)
                .Select(e => new RecommandDocumentSettleDto
                {
                    Id = e.Id,
                    RecommandDocumentId = e.RecommandDocumentId,
                    OrderId = e.OrderId,
                    DealInfoId = e.DealInfoId,
                    OrderFrom = e.OrderFrom,
                    OrderFromText = ServiceClass.GetOrderFromText(e.OrderFrom),
                    ReturnBackPrice = e.ReturnBackPrice,
                    CreateDate = e.CreateDate,
                    IsSettle = e.IsSettle,
                    SettleDate = e.SettleDate,
                    BelongLiveAnchorAccount = e.BelongLiveAnchorAccount,
                    BelongEmpId = e.BelongEmpId,
                    CreateByEmpName = e.AmiyaEmployee.Name,
                    AccountTypeText = e.AccountType == true ? "出账" : "入账",
                    AccountPrice = e.AccountPrice
                });
            List<RecommandDocumentSettleDto> resultInfo = new List<RecommandDocumentSettleDto>();
            resultInfo = await record.ToListAsync();
            foreach (var x in resultInfo)
            {
                if (x.BelongEmpId.HasValue)
                {
                    var empInfo = await amiyaEmployeeService.GetByIdAsync(x.BelongEmpId.Value);
                    x.BelongEmpName = empInfo.Name;
                }
                if (x.BelongLiveAnchorAccount.HasValue)
                {
                    var liveAnchor = await liveAnchorService.GetByIdAsync(x.BelongLiveAnchorAccount.Value);
                    x.BelongLiveAnchor = liveAnchor.Name;
                }
            }
            return resultInfo;
        }
        public async Task<List<RecommandDocumentSettleDto>> GetRecommandDocumentSettleAsync(List<string> recommandDocumentIds, bool? isSettle)
        {
            var recommandDocumentSettle = await _dalRecommandDocumentSettle.GetAll().Where(z => !isSettle.HasValue || z.IsSettle == isSettle).Where(z => recommandDocumentIds.Contains(z.RecommandDocumentId)).ToListAsync();
            List<RecommandDocumentSettleDto> RecommandDocumentSettleDtoList = new List<RecommandDocumentSettleDto>();
            foreach (var z in recommandDocumentSettle)
            {

                RecommandDocumentSettleDto recommandDocumentSettleDto = new RecommandDocumentSettleDto();
                recommandDocumentSettleDto.RecommandDocumentId = z.RecommandDocumentId;
                recommandDocumentSettleDto.Id = z.Id;
                recommandDocumentSettleDto.OrderId = z.OrderId;
                recommandDocumentSettleDto.DealInfoId = z.DealInfoId;
                recommandDocumentSettleDto.OrderFrom = z.OrderFrom;
                recommandDocumentSettleDto.ReturnBackPrice = z.ReturnBackPrice;
                recommandDocumentSettleDto.CreateDate = z.CreateDate;
                recommandDocumentSettleDto.IsSettle = z.IsSettle;
                RecommandDocumentSettleDtoList.Add(recommandDocumentSettleDto);
            };
            return RecommandDocumentSettleDtoList;

        }

        public async Task AddAsync(AddRecommandDocumentSettleDto addRecommandDocumentSettleDto)
        {
            RecommandDocumentSettle recommandDocumentSettle = new RecommandDocumentSettle();
            recommandDocumentSettle.Id = Guid.NewGuid().ToString();
            recommandDocumentSettle.RecommandDocumentId = addRecommandDocumentSettleDto.RecommandDocumentId;
            recommandDocumentSettle.OrderId = addRecommandDocumentSettleDto.OrderId;
            recommandDocumentSettle.OrderFrom = addRecommandDocumentSettleDto.OrderFrom;
            recommandDocumentSettle.DealInfoId = addRecommandDocumentSettleDto.DealInfoId;
            recommandDocumentSettle.ReturnBackPrice = addRecommandDocumentSettleDto.ReturnBackPrice;
            recommandDocumentSettle.CreateDate = DateTime.Now;
            recommandDocumentSettle.IsSettle = false;
            recommandDocumentSettle.BelongEmpId = addRecommandDocumentSettleDto.BelongEmpId;
            recommandDocumentSettle.BelongLiveAnchorAccount = addRecommandDocumentSettleDto.BelongLiveAnchorAccount;
            recommandDocumentSettle.CreateBy = addRecommandDocumentSettleDto.CreateBy;
            recommandDocumentSettle.AccountType = addRecommandDocumentSettleDto.AccountType;
            recommandDocumentSettle.AccountPrice = addRecommandDocumentSettleDto.AccountPrice;
            await _dalRecommandDocumentSettle.AddAsync(recommandDocumentSettle, true);
        }


        public async Task UpdateIsRerturnBackAsync(string Id)
        {
            var result = await _dalRecommandDocumentSettle.GetAll().Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsSettle = true;
                result.SettleDate = DateTime.Now;
                await _dalRecommandDocumentSettle.UpdateAsync(result, true);
            }
        }


    }
}
