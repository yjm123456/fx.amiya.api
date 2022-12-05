using Fx.Amiya.Dto.CustomerConsumptionCredentials;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure;
using Fx.Common;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.CheckBaseInfo;

namespace Fx.Amiya.Service
{
    public class CustomerConsumptionCredentialsService : ICustomerConsumptionCredentialsService
    {
        private IDalCustomerConsumptionCredentials dalCustomerConsumptionCredentials;
        public CustomerConsumptionCredentialsService(IDalCustomerConsumptionCredentials dalCustomerConsumptionCredentials)
        {
            this.dalCustomerConsumptionCredentials = dalCustomerConsumptionCredentials;
        }




        public async Task<FxPageInfo<CustomerConsumptionCredentialsDto>> GetListAsync(string keyWord, bool valid, int? checkState, int pageNum, int pageSize)
        {

            var CustomerConsumptionCredentialsBaseInfos = from d in dalCustomerConsumptionCredentials.GetAll()
                                                          where (string.IsNullOrWhiteSpace(keyWord) || d.CustomerName.Contains(keyWord) || d.ToHospitalPhone.Contains(keyWord))
                                                          && (d.Valid == valid)
                                                          && (!checkState.HasValue || d.CheckState == checkState)
                                                          select new CustomerConsumptionCredentialsDto
                                                          {
                                                              Id = d.Id,
                                                              CustomerId=d.CustomerId,
                                                              CustomerName = d.CustomerName,
                                                              ToHospitalPhone = d.ToHospitalPhone,
                                                              LiveAnchorBaseId = d.LiveAnchorBaseId,
                                                              LiveAnchor = d.LiveAnchorBaseInfo.LiveAnchorName,
                                                              ConsumeDate = d.ConsumeDate,
                                                              PayVoucherPicture1 = d.PayVoucherPicture1,
                                                              PayVoucherPicture2 = d.PayVoucherPicture2,
                                                              CheckState = d.CheckState,
                                                              CheckBy = d.CheckBy,
                                                              CheckByEmpname = d.AmiyaEmployee.Name,
                                                              CheckDate = d.CheckDate,
                                                              CreateDate = d.CreateDate,
                                                              UpdateDate = d.UpdateDate,
                                                              DeleteDate = d.DeleteDate,
                                                              Valid = d.Valid,
                                                              CheckRemark=d.CheckRemark,
                                                          };
            FxPageInfo<CustomerConsumptionCredentialsDto> CustomerConsumptionCredentialsBaseInfoPageInfo = new FxPageInfo<CustomerConsumptionCredentialsDto>();
            CustomerConsumptionCredentialsBaseInfoPageInfo.TotalCount = await CustomerConsumptionCredentialsBaseInfos.CountAsync();
            CustomerConsumptionCredentialsBaseInfoPageInfo.List = await CustomerConsumptionCredentialsBaseInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return CustomerConsumptionCredentialsBaseInfoPageInfo;
        }

        public async Task<FxPageInfo<CustomerConsumptionCredentialsDto>> GetByCustomerIdListAsync(string customerId, int pageNum, int pageSize)
        {

            var CustomerConsumptionCredentialsBaseInfos = from d in dalCustomerConsumptionCredentials.GetAll()
                                                          where (d.CustomerId == customerId)
                                                          && (d.Valid == true)
                                                          select new CustomerConsumptionCredentialsDto
                                                          {
                                                              Id = d.Id,
                                                              CustomerId = d.CustomerId,
                                                              CustomerName = d.CustomerName,
                                                              ToHospitalPhone = d.ToHospitalPhone,
                                                              LiveAnchorBaseId = d.LiveAnchorBaseId,
                                                              LiveAnchor = d.LiveAnchorBaseInfo.LiveAnchorName,
                                                              ConsumeDate = d.ConsumeDate,
                                                              PayVoucherPicture1 = d.PayVoucherPicture1,
                                                              PayVoucherPicture2 = d.PayVoucherPicture2,
                                                              CheckState = d.CheckState,
                                                              CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState),
                                                              CheckBy = d.CheckBy,
                                                              CheckByEmpname = d.AmiyaEmployee.Name,
                                                              CheckDate = d.CheckDate,
                                                              CreateDate = d.CreateDate,
                                                              UpdateDate = d.UpdateDate,
                                                              DeleteDate = d.DeleteDate,
                                                              Valid = d.Valid
                                                          };
            FxPageInfo<CustomerConsumptionCredentialsDto> CustomerConsumptionCredentialsBaseInfoPageInfo = new FxPageInfo<CustomerConsumptionCredentialsDto>();
            CustomerConsumptionCredentialsBaseInfoPageInfo.TotalCount = await CustomerConsumptionCredentialsBaseInfos.CountAsync();
            CustomerConsumptionCredentialsBaseInfoPageInfo.List = await CustomerConsumptionCredentialsBaseInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return CustomerConsumptionCredentialsBaseInfoPageInfo;
        }


        /// <summary>
        /// 添加顾客消费凭证
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddCustomerConsumptionCredentialsDto addDto)
        {
            try
            {
                CustomerConsumptionCredentials CustomerConsumptionCredentials = new CustomerConsumptionCredentials();
                CustomerConsumptionCredentials.Id = Guid.NewGuid().ToString();
                CustomerConsumptionCredentials.CustomerId = addDto.CustomerId;
                CustomerConsumptionCredentials.CheckState = 0;
                CustomerConsumptionCredentials.CustomerName = addDto.CustomerName;
                CustomerConsumptionCredentials.ToHospitalPhone = addDto.ToHospitalPhone;
                CustomerConsumptionCredentials.LiveAnchorBaseId = addDto.LiveAnchorBaseId;
                CustomerConsumptionCredentials.ConsumeDate = addDto.ConsumeDate;
                CustomerConsumptionCredentials.PayVoucherPicture1 = addDto.PayVoucherPicture1;
                CustomerConsumptionCredentials.PayVoucherPicture2 = addDto.PayVoucherPicture2;
                CustomerConsumptionCredentials.Valid = true;
                CustomerConsumptionCredentials.CreateDate = DateTime.Now;
                await dalCustomerConsumptionCredentials.AddAsync(CustomerConsumptionCredentials, true);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message.ToString());
            }
        }



        public async Task<CustomerConsumptionCredentialsDto> GetByIdAsync(string id)
        {
            var result = from d in dalCustomerConsumptionCredentials.GetAll().Where(x => x.Valid == true)
                         select d;
            var x = result.FirstOrDefault(e => e.Id == id);
            if (x == null)
            {
                return new CustomerConsumptionCredentialsDto();
            }

            CustomerConsumptionCredentialsDto CustomerConsumptionCredentialsBaseInfoDto = new CustomerConsumptionCredentialsDto();
            CustomerConsumptionCredentialsBaseInfoDto.Id = x.Id;
            CustomerConsumptionCredentialsBaseInfoDto.CustomerId = x.CustomerId;
            CustomerConsumptionCredentialsBaseInfoDto.CustomerName = x.CustomerName;
            CustomerConsumptionCredentialsBaseInfoDto.ToHospitalPhone = x.ToHospitalPhone;
            CustomerConsumptionCredentialsBaseInfoDto.LiveAnchorBaseId = x.LiveAnchorBaseId;
            CustomerConsumptionCredentialsBaseInfoDto.ConsumeDate = x.ConsumeDate;
            CustomerConsumptionCredentialsBaseInfoDto.PayVoucherPicture1 = x.PayVoucherPicture1;
            CustomerConsumptionCredentialsBaseInfoDto.PayVoucherPicture2 = x.PayVoucherPicture2;
            CustomerConsumptionCredentialsBaseInfoDto.Valid = x.Valid;
            return CustomerConsumptionCredentialsBaseInfoDto;
        }


        /// <summary>
        /// 修改顾客消费凭证
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateCustomerConsumptionCredentialsDto updateDto)
        {
            var resultCount = from d in dalCustomerConsumptionCredentials.GetAll().Where(x => x.Valid == true) select d;
            var result = resultCount.FirstOrDefault(e => e.Id == updateDto.Id);
            result.Id = updateDto.Id;
            result.CustomerId = updateDto.CustomerId;
            result.CustomerName = updateDto.CustomerName;
            result.ToHospitalPhone = updateDto.ToHospitalPhone;
            result.LiveAnchorBaseId = updateDto.LiveAnchorBaseId;
            result.ConsumeDate = updateDto.ConsumeDate;
            result.PayVoucherPicture1 = updateDto.PayVoucherPicture1;
            result.PayVoucherPicture2 = updateDto.PayVoucherPicture2;
            result.UpdateDate = DateTime.Now;
            await dalCustomerConsumptionCredentials.UpdateAsync(result, true);
        }

        /// <summary>
        /// 审核顾客消费凭证
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task CheckAsync(CheckInfoDto updateDto)
        {
            var resultCount = from d in dalCustomerConsumptionCredentials.GetAll().Where(x => x.Valid == true) select d;
            var result = resultCount.FirstOrDefault(e => e.Id == updateDto.Id);
            if (result == null)
                throw new Exception("消费凭证编号错误");
            result.Id = updateDto.Id;
            result.CheckBy = updateDto.CheckBy;
            result.CheckState = updateDto.CheckState;
            result.CheckRemark = updateDto.CheckRemark;
            result.CheckDate = DateTime.Now;
            result.UpdateDate = DateTime.Now;
            await dalCustomerConsumptionCredentials.UpdateAsync(result, true);
        }


        /// <summary>
        /// 删除顾客消费凭证
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var result = await dalCustomerConsumptionCredentials.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            result.Valid = false;
            result.DeleteDate = DateTime.Now;
            await dalCustomerConsumptionCredentials.UpdateAsync(result, true);
        }


    }
}
