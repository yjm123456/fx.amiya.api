using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.CustomerHospitalDealDetails.Input;
using Fx.Amiya.Dto.CustomerHospitalDealDetails.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class CustomerHospitalDealDetailsService : ICustomerHospitalDealDetailsService
    {
        private readonly IDalCustomerHospitalDealDetails dalCustomerHospitalDealDetails;

        public CustomerHospitalDealDetailsService(IDalCustomerHospitalDealDetails dalCustomerHospitalDealDetails)
        {
            this.dalCustomerHospitalDealDetails = dalCustomerHospitalDealDetails;
        }


        public async Task<FxPageInfo<CustomerHospitalDealDetailsDto>> GetListWithPageAsync(QueryCustomerHospitalDealDetailsPageListDto query)
        {
            try
            {
                var customerHospitalDealDetailsService = from d in dalCustomerHospitalDealDetails.GetAll()
                                                         where (query.KeyWord == null || d.ItemStandard.Contains(query.KeyWord) || d.ItemName.Contains(query.KeyWord) )
                                                         && (string.IsNullOrEmpty(query.CustomerHospitalDealId) || d.CustomerHospitalDealId == query.CustomerHospitalDealId)
                                                         && (!query.EndDate.HasValue || d.CreateDate <= query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                                         select new CustomerHospitalDealDetailsDto
                                                         {
                                                             Id = d.Id,
                                                             CustomerHospitalDealId = d.CustomerHospitalDealId,
                                                             ItemName = d.ItemName,
                                                             ItemStandard = d.ItemStandard,
                                                             Quantity = d.Quantity,
                                                             CashAmount = d.CashAmount,
                                                             CreateDate = d.CreateDate,
                                                         };
                FxPageInfo<CustomerHospitalDealDetailsDto> customerHospitalDealDetailsServicePageDetails = new FxPageInfo<CustomerHospitalDealDetailsDto>();
                customerHospitalDealDetailsServicePageDetails.TotalCount = await customerHospitalDealDetailsService.CountAsync();
                customerHospitalDealDetailsServicePageDetails.List = new List<CustomerHospitalDealDetailsDto>();
                if (customerHospitalDealDetailsServicePageDetails.TotalCount > 0)
                {
                    customerHospitalDealDetailsServicePageDetails.List = await customerHospitalDealDetailsService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                }
                return customerHospitalDealDetailsServicePageDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(AddCustomerHospitalDealDetailsDto addDto)
        {
            try
            {
                CustomerHospitalDealDetails customerHospitalDealDetails = new CustomerHospitalDealDetails();
                customerHospitalDealDetails.Id = Guid.NewGuid().ToString();
                customerHospitalDealDetails.CustomerHospitalDealId = addDto.CustomerHospitalDealId;
                customerHospitalDealDetails.ItemName = addDto.ItemName;
                customerHospitalDealDetails.ItemStandard = addDto.ItemStandard;
                customerHospitalDealDetails.Quantity = addDto.Quantity;
                customerHospitalDealDetails.CashAmount = addDto.CashAmount;
                customerHospitalDealDetails.CreateDate = DateTime.Now;
                await dalCustomerHospitalDealDetails.AddAsync(customerHospitalDealDetails, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            var result = await dalCustomerHospitalDealDetails.GetAll().Where(e => e.Id == id).FirstOrDefaultAsync();
            await dalCustomerHospitalDealDetails.DeleteAsync(result, true);
        }

    }
}
