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
        private readonly IDalCustomerHospitalDealInfo dalCustomerHospitalDealInfo;

        public CustomerHospitalDealDetailsService(IDalCustomerHospitalDealDetails dalCustomerHospitalDealDetails, IDalCustomerHospitalDealInfo dalCustomerHospitalDealInfo)
        {
            this.dalCustomerHospitalDealDetails = dalCustomerHospitalDealDetails;
            this.dalCustomerHospitalDealInfo = dalCustomerHospitalDealInfo;
        }


        public async Task<FxPageInfo<CustomerHospitalDealDetailsDto>> GetListWithPageAsync(QueryCustomerHospitalDealDetailsPageListDto query)
        {
            try
            {
                var customerHospitalDealDetailsService = from d in dalCustomerHospitalDealDetails.GetAll()
                                                         where (query.KeyWord == null || d.ItemStandard.Contains(query.KeyWord) || d.ItemName.Contains(query.KeyWord))
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
        /// <summary>
        /// 根据id集合获取成交明细
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerHospitalDealDetailsDto>> GetListByIdsWithPageAsync(QueryCustomerHospitalDealDetailsByIdsPageListDto query)
        {
            try
            {
                if (query.CustomerHospitalDealIds.Count() <= 0) throw new Exception("编号集合不能为空！");
                var customerHospitalDealInfo = dalCustomerHospitalDealInfo.GetAll().Where(e => query.CustomerHospitalDealIds.Contains(e.Id)).Select(e => new
                {
                    Id = e.Id,
                    Type = e.Type,
                    TotalCashAmount = e.TotalCashAmount,
                    ConsumptionType = e.ConsumptionType,
                    RefundType = e.RefundType,
                    CreateDate = e.CreateDate
                }).ToList();
                var customerHospitalDealDetailsService = from d in dalCustomerHospitalDealDetails.GetAll()
                                                         where (query.KeyWord == null || d.ItemStandard.Contains(query.KeyWord) || d.ItemName.Contains(query.KeyWord))
                                                         && (query.CustomerHospitalDealIds.Contains(d.CustomerHospitalDealId))
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
                customerHospitalDealDetailsServicePageDetails.List = new List<CustomerHospitalDealDetailsDto>();
                customerHospitalDealDetailsServicePageDetails.TotalCount = customerHospitalDealDetailsService.Count();
                if (customerHospitalDealDetailsServicePageDetails.TotalCount > 0)
                {
                    customerHospitalDealDetailsServicePageDetails.List = await customerHospitalDealDetailsService.ToListAsync();
                    var existDetailIds = customerHospitalDealDetailsServicePageDetails.List.Select(e => e.CustomerHospitalDealId).Distinct();
                    var unExistDetailIds = query.CustomerHospitalDealIds.Except(existDetailIds);
                    if (unExistDetailIds.Count() > 0)
                    {
                        foreach (var item in unExistDetailIds)
                        {
                            var data = customerHospitalDealInfo.Where(e => e.Id == item).FirstOrDefault();
                            if (data == null) throw new Exception("编号错误！");
                            CustomerHospitalDealDetailsDto customerHospitalDealDetail = new CustomerHospitalDealDetailsDto();
                            customerHospitalDealDetail.Id = item;
                            customerHospitalDealDetail.CustomerHospitalDealId = item;
                            customerHospitalDealDetail.ItemName = data.Type == (int)HospitalDealType.Charge ? ServiceClass.GetHospitalConsumptionTypeText(data.ConsumptionType.Value) : ServiceClass.GetHospitalRefundTypeText(data.ConsumptionType.Value);
                            customerHospitalDealDetail.ItemStandard = "";
                            customerHospitalDealDetail.Quantity = 1;
                            customerHospitalDealDetail.CashAmount = data.Type == (int)HospitalDealType.Charge ? data.TotalCashAmount : -data.TotalCashAmount; ;
                            customerHospitalDealDetail.CreateDate = data.CreateDate;
                            customerHospitalDealDetailsServicePageDetails.List.Append(customerHospitalDealDetail);
                        }
                        customerHospitalDealDetailsServicePageDetails.TotalCount = customerHospitalDealDetailsServicePageDetails.List.Count();
                    }
                    
                    customerHospitalDealDetailsServicePageDetails.List = customerHospitalDealDetailsServicePageDetails.List.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToList();
                }
                else
                {
                    List<CustomerHospitalDealDetailsDto> generateList = new List<CustomerHospitalDealDetailsDto>();
                    foreach (var item in query.CustomerHospitalDealIds)
                    {
                        var data = customerHospitalDealInfo.Where(e => e.Id == item).FirstOrDefault();
                        if (data == null) throw new Exception("编号错误！");
                        CustomerHospitalDealDetailsDto customerHospitalDealDetail = new CustomerHospitalDealDetailsDto();
                        customerHospitalDealDetail.Id = item;
                        customerHospitalDealDetail.CustomerHospitalDealId = item;
                        customerHospitalDealDetail.ItemName = data.Type == (int)HospitalDealType.Charge ? ServiceClass.GetHospitalConsumptionTypeText(data.ConsumptionType.Value) : ServiceClass.GetHospitalRefundTypeText(data.ConsumptionType.Value);
                        customerHospitalDealDetail.ItemStandard = "";
                        customerHospitalDealDetail.Quantity = 1;
                        customerHospitalDealDetail.CashAmount = data.Type == (int)HospitalDealType.Charge ? data.TotalCashAmount : -data.TotalCashAmount;
                        customerHospitalDealDetail.CreateDate = data.CreateDate;
                        generateList.Add(customerHospitalDealDetail);
                    }
                    customerHospitalDealDetailsServicePageDetails.TotalCount = generateList.Count();
                    customerHospitalDealDetailsServicePageDetails.List = generateList.OrderByDescending(e => e.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToList();
                }
                return customerHospitalDealDetailsServicePageDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
