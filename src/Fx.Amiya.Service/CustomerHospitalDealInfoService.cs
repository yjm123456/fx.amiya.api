using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CustomerHospitalDealDetails.Input;
using Fx.Amiya.Dto.CustomerHospitalDealInfo.Input;
using Fx.Amiya.Dto.CustomerHospitalDealInfo.Result;
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
    public class CustomerHospitalDealInfoService : ICustomerHospitalDealInfoService
    {
        private readonly IDalCustomerHospitalDealInfo dalCustomerHospitalDealInfo;
        private ICustomerHospitalDealDetailsService customerHospitalDealDetailsService;
        private ICustomerBaseInfoService customerBaseInfoService;
        private readonly IUnitOfWork unitOfWork;

        public CustomerHospitalDealInfoService(IDalCustomerHospitalDealInfo dalCustomerHospitalDealInfo,
           ICustomerBaseInfoService customerBaseInfoService,
            ICustomerHospitalDealDetailsService customerHospitalDealDetailsService, IUnitOfWork unitOfWork)
        {
            this.dalCustomerHospitalDealInfo = dalCustomerHospitalDealInfo;
            this.customerHospitalDealDetailsService = customerHospitalDealDetailsService;
            this.customerBaseInfoService = customerBaseInfoService;
            this.unitOfWork = unitOfWork;
        }


        public async Task<FxPageInfo<CustomerHospitalDealInfoDto>> GetListWithPageAsync(QueryCustomerHospitalDealInfoPageListDto query)
        {
            try
            {
                var customerHospitalDealInfoService = from d in dalCustomerHospitalDealInfo.GetAll().Include(x => x.HospitalInfoData).Include(x => x.CustomerHospitalDealDetailsList)
                                                      where (query.KeyWord == null || d.CustomerPhone.Contains(query.KeyWord) || d.CustomerName.Contains(query.KeyWord) || d.MsgId.Contains(query.KeyWord))
                                                      && (!query.Type.HasValue || d.Type == query.Type.Value)
                                                      && (!query.ConsumptionType.HasValue || d.ConsumptionType == query.ConsumptionType.Value)
                                                      && (!query.HospitalId.HasValue || d.HospitalId == query.HospitalId.Value)
                                                      && (!query.RefundType.HasValue || d.RefundType == query.RefundType.Value)
                                                      && (!query.StartDate.HasValue || d.Date >= query.StartDate.Value)
                                                      && (!query.EndDate.HasValue || d.Date <= query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                                      select new CustomerHospitalDealInfoDto
                                                      {
                                                          Id = d.Id,
                                                          HospitalId = d.HospitalId,
                                                          HospitalName = d.HospitalInfoData.Name,
                                                          Type = d.Type,
                                                          TypeText = ServiceClass.GetHospitalDealTypeText(d.Type),
                                                          CustomerName = d.CustomerName,
                                                          CustomerPhone = d.CustomerPhone,
                                                          Date = d.Date,
                                                          TotalCashAmount = d.TotalCashAmount,
                                                          ConsumptionType = d.ConsumptionType,
                                                          ConsumptionTypeText = d.Type == 0 ? d.ConsumptionType.HasValue ? ServiceClass.GetHospitalConsumptionTypeText(d.ConsumptionType.Value) : "" : "",
                                                          RefundType = d.RefundType,
                                                          RefundTypeText = d.Type == 1 ? d.RefundType.HasValue ? ServiceClass.GetHospitalRefundTypeText(d.RefundType.Value) : "" : "",
                                                          MsgId = d.MsgId,
                                                          CreateDate = d.CreateDate,
                                                      };
                FxPageInfo<CustomerHospitalDealInfoDto> customerHospitalDealInfoServicePageInfo = new FxPageInfo<CustomerHospitalDealInfoDto>();
                customerHospitalDealInfoServicePageInfo.TotalCount = await customerHospitalDealInfoService.CountAsync();
                customerHospitalDealInfoServicePageInfo.List = new List<CustomerHospitalDealInfoDto>();
                if (customerHospitalDealInfoServicePageInfo.TotalCount > 0)
                {
                    customerHospitalDealInfoServicePageInfo.List = await customerHospitalDealInfoService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                }
                return customerHospitalDealInfoServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(AddCustomerHospitalDealInfoDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                CustomerHospitalDealInfo customerHospitalDealInfo = new CustomerHospitalDealInfo();
                customerHospitalDealInfo.Id = Guid.NewGuid().ToString();
                customerHospitalDealInfo.HospitalId = addDto.HospitalId;
                customerHospitalDealInfo.Type = addDto.Type;
                customerHospitalDealInfo.CustomerName = addDto.CustomerName;
                customerHospitalDealInfo.CustomerPhone = addDto.CustomerPhone;
                customerHospitalDealInfo.Date = addDto.Date;
                customerHospitalDealInfo.CreateDate = DateTime.Now;
                customerHospitalDealInfo.TotalCashAmount = addDto.TotalCashAmount;
                customerHospitalDealInfo.ConsumptionType = addDto.ConsumptionType;
                customerHospitalDealInfo.RefundType = addDto.RefundType;
                customerHospitalDealInfo.MsgId = addDto.MsgId;
                await dalCustomerHospitalDealInfo.AddAsync(customerHospitalDealInfo, true);
                foreach (var x in addDto.addCustomerHospitalDealDetailsDtos)
                {
                    AddCustomerHospitalDealDetailsDto addCustomerHospitalDealDetailsDto = new AddCustomerHospitalDealDetailsDto();
                    addCustomerHospitalDealDetailsDto.CustomerHospitalDealId = customerHospitalDealInfo.Id;
                    addCustomerHospitalDealDetailsDto.ItemName = x.ItemName;
                    addCustomerHospitalDealDetailsDto.ItemStandard = x.ItemStandard;
                    addCustomerHospitalDealDetailsDto.Quantity = x.Quantity;
                    addCustomerHospitalDealDetailsDto.CashAmount = x.CashAmount;
                    await customerHospitalDealDetailsService.AddAsync(addCustomerHospitalDealDetailsDto);
                }
                await customerBaseInfoService.UpdateState(1, addDto.CustomerName, addDto.CustomerPhone);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            var result = await dalCustomerHospitalDealInfo.GetAll().Where(e => e.Id == id).FirstOrDefaultAsync();
            await dalCustomerHospitalDealInfo.DeleteAsync(result, true);
        }


        /// <summary>
        /// 获取医院成交类型
        /// </summary>
        /// <returns></returns>
        public List<BaseIdAndNameDto> GetHospitalDealTypeList()
        {
            var appointmentTypes = Enum.GetValues(typeof(HospitalDealType));
            List<BaseIdAndNameDto> appointmentTypeList = new List<BaseIdAndNameDto>();
            foreach (var item in appointmentTypes)
            {
                BaseIdAndNameDto appointmentType = new BaseIdAndNameDto();
                appointmentType.Id = Convert.ToInt32(item).ToString();
                appointmentType.Name = ServiceClass.GetHospitalDealTypeText(Convert.ToByte(item));
                appointmentTypeList.Add(appointmentType);
            }
            return appointmentTypeList;
        }

        /// <summary>
        /// 获取医院消费类型
        /// </summary>
        /// <returns></returns>
        public List<BaseIdAndNameDto> GetHospitalConsumptionTypeList()
        {
            var appointmentTypes = Enum.GetValues(typeof(HospitalConsumptionType));
            List<BaseIdAndNameDto> appointmentTypeList = new List<BaseIdAndNameDto>();
            foreach (var item in appointmentTypes)
            {
                BaseIdAndNameDto appointmentType = new BaseIdAndNameDto();
                appointmentType.Id = Convert.ToInt32(item).ToString();
                appointmentType.Name = ServiceClass.GetHospitalConsumptionTypeText(Convert.ToByte(item));
                appointmentTypeList.Add(appointmentType);
            }
            return appointmentTypeList;
        }


        /// <summary>
        /// 获取医院退款类型
        /// </summary>
        /// <returns></returns>
        public List<BaseIdAndNameDto> GetHospitalRefundTypeList()
        {
            var appointmentTypes = Enum.GetValues(typeof(HospitalRefundType));
            List<BaseIdAndNameDto> appointmentTypeList = new List<BaseIdAndNameDto>();
            foreach (var item in appointmentTypes)
            {
                BaseIdAndNameDto appointmentType = new BaseIdAndNameDto();
                appointmentType.Id = Convert.ToInt32(item).ToString();
                appointmentType.Name = ServiceClass.GetHospitalRefundTypeText(Convert.ToByte(item));
                appointmentTypeList.Add(appointmentType);
            }
            return appointmentTypeList;
        }
    }
}
