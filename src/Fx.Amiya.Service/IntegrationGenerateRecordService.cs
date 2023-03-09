using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dal;
using Fx.Amiya.Dto.Integration;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class IntegrationGenerateRecordService : IIntegrationGenerateRecordService
    {
        private readonly IDalCustomerInfo dalCustomerInfo;
        private readonly IDalIntegrationGenerateRecord dalIntegrationGenerateRecord;
        private readonly IDalAmiyaEmployee dalAmiyaEmployee;
        private readonly IIntegrationAccount integrationAccountService;
        public IntegrationGenerateRecordService(IDalCustomerInfo dalCustomerInfo, IDalIntegrationGenerateRecord dalIntegrationGenerateRecord, IDalAmiyaEmployee dalAmiyaEmployee, IIntegrationAccount integrationAccountService)
        {
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalIntegrationGenerateRecord = dalIntegrationGenerateRecord;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.integrationAccountService = integrationAccountService;
        }

        public async Task EditIntegrationRecordAsync(EditIntegrationgenerationDto editIntegrationgenerationDto)
        {
            var balance =await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(editIntegrationgenerationDto.CustomerId);
            if (balance < editIntegrationgenerationDto.Quantity) throw new Exception($"该用户积分余额为{balance}积分,修正数量超过余额无法修改！");
            ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto
            {
                Quantity = -Math.Floor(editIntegrationgenerationDto.Quantity),
                Percent = 1,
                AmountOfConsumption = editIntegrationgenerationDto.Quantity,
                Date = DateTime.Now,
                CustomerId = editIntegrationgenerationDto.CustomerId,
                OrderId = null,
                Type = 7,
                HandleBy = editIntegrationgenerationDto.EmployeeId
            };
            await integrationAccountService.AddByConsumptionAsync(consumptionIntegrationDto);
        }

        public async Task<FxPageInfo<IntegrationgenerationRecordDto>> GetAllIntegrationgenerationRecordAsync(string keyword,DateTime? startDate,DateTime? endDate, int pageNum, int pageSize)
        {
            startDate = startDate.HasValue ? startDate.Value.Date : DateTime.Now.Date;
            endDate = endDate.HasValue ? endDate.Value.AddDays(1).Date : DateTime.Now.AddDays(1).Date;
            var record = from d in dalIntegrationGenerateRecord.GetAll()
                         join c in dalCustomerInfo.GetAll()
                         on d.CustomerId equals c.Id
                         where (string.IsNullOrEmpty(keyword)||c.Phone.Contains(keyword)) && (d.Date>=startDate&&d.Date<endDate)
                         orderby d.Date descending
                         select new IntegrationgenerationRecordDto
                         {
                             Id = d.Id,
                             CustomerId = d.CustomerId,
                             Phone = ServiceClass.GetIncompletePhone(c.Phone),
                             CreateDate = d.Date,
                             TypeText = ServiceClass.GetIntegrationTypeText(d.Type),
                             Quantity = d.Quantity,
                             OrderId = d.OrderId,
                             ConsumptionAmount = d.AmountOfConsumption,
                             Percent = d.Percents,
                             StockQuantity = d.StockQuantity,
                             HandleBy = d.HandleBy.ToString()
                         };
            FxPageInfo<IntegrationgenerationRecordDto> fxPageInfo = new FxPageInfo<IntegrationgenerationRecordDto>();
            fxPageInfo.TotalCount = record.Count();
            fxPageInfo.List = record.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            foreach (var item in fxPageInfo.List)
            {
                item.HandleBy = string.IsNullOrEmpty(item.HandleBy) ? "未知" : dalAmiyaEmployee.GetAll().Where(e => e.Id == Convert.ToInt32(item.HandleBy)).FirstOrDefault()?.Name;
                item.AccountBalance =await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(item.CustomerId);
            }
            return fxPageInfo;
        }
    }
}
