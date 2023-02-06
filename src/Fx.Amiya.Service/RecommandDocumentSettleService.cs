
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

        public async Task<List<RecommandDocumentSettleDto>> GetAllAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword)
        {
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
                  IsOldCustomer = e.IsOldCustomer,
                  IsOldCustomerText = e.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                  OrderPrice = e.OrderPrice,
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

            return await record.ToListAsync();
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
                recommandDocumentSettleDto.OrderPrice = z.OrderPrice;
                recommandDocumentSettleDto.IsOldCustomer = z.IsOldCustomer;
                recommandDocumentSettleDto.IsOldCustomerText = z.IsOldCustomer == true ? "老客业绩" : "新客业绩";
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
            recommandDocumentSettle.OrderPrice = addRecommandDocumentSettleDto.OrderPrice;
            recommandDocumentSettle.IsOldCustomer = addRecommandDocumentSettleDto.IsOldCustomer;
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
