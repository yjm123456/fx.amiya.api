using Fx.Amiya.Dto.CustomerConsumptionCredentials;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.CustomerConsumptionCredentialsService;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class CustomerConsumptionCredentialsController : ControllerBase
    {
        private readonly ICustomerConsumptionCredentialsService customerConsumptionCredentialsService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;

        public CustomerConsumptionCredentialsController(ICustomerConsumptionCredentialsService customerConsumptionCredentialsService, TokenReader tokenReader, IMiniSessionStorage sessionStorage)
        {
            this.customerConsumptionCredentialsService = customerConsumptionCredentialsService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }

        /// <summary>
        /// 获取消费凭证列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<CustomerConsumptionCredentialsVo>>> GetGoodsInfoListAsync( int pageNum, int pageSize)
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var q = await customerConsumptionCredentialsService.GetByCustomerIdListAsync(customerId, pageNum, pageSize);

            var customerConsumptionCredentials = from d in q.List
                                                 select new CustomerConsumptionCredentialsVo
                                                 {
                                                     Id = d.Id,
                                                     CustomerId = d.CustomerId,
                                                     CustomerName = d.CustomerName,
                                                     ToHospitalPhone = d.ToHospitalPhone,
                                                     ConsumeDate = d.ConsumeDate,
                                                     PayVoucherPicture1 = d.PayVoucherPicture1,
                                                     PayVoucherPicture2 = d.PayVoucherPicture2,
                                                     CheckState = d.CheckState,
                                                     CheckStateText=d.CheckStateText,
                                                     CheckBy = d.CheckBy,
                                                     CheckByEmpname = d.CheckByEmpname,
                                                     CheckDate = d.CheckDate,
                                                     CreateDate = d.CreateDate,
                                                     UpdateDate = d.UpdateDate,
                                                     DeleteDate = d.DeleteDate,
                                                     Valid = d.Valid,
                                                     CheckRemark = d.CheckRemark
                                                 };

            FxPageInfo<CustomerConsumptionCredentialsVo> goodsPageInfo = new FxPageInfo<CustomerConsumptionCredentialsVo>();
            goodsPageInfo.TotalCount = q.TotalCount;
            goodsPageInfo.List = customerConsumptionCredentials;
            return ResultData<FxPageInfo<CustomerConsumptionCredentialsVo>>.Success().AddData("customerConsumptionCredentials", goodsPageInfo);
        }


        /// <summary>
        /// 根据消费凭证编号获取消费凭证信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<CustomerConsumptionCredentialsVo>> GetByIdAsync(string id)
        {
            try
            {
                var cCustomerConsumptionCredentials = await customerConsumptionCredentialsService.GetByIdAsync(id);
                CustomerConsumptionCredentialsVo cCustomerConsumptionCredentialsVo = new CustomerConsumptionCredentialsVo();

                cCustomerConsumptionCredentialsVo.Id = cCustomerConsumptionCredentials.Id;
                cCustomerConsumptionCredentialsVo.CustomerId = cCustomerConsumptionCredentials.CustomerId;
                cCustomerConsumptionCredentialsVo.CustomerName = cCustomerConsumptionCredentials.CustomerName;
                cCustomerConsumptionCredentialsVo.ToHospitalPhone = cCustomerConsumptionCredentials.ToHospitalPhone;
                cCustomerConsumptionCredentialsVo.ConsumeDate = cCustomerConsumptionCredentials.ConsumeDate;
                cCustomerConsumptionCredentialsVo.PayVoucherPicture1 = cCustomerConsumptionCredentials.PayVoucherPicture1;
                cCustomerConsumptionCredentialsVo.PayVoucherPicture2 = cCustomerConsumptionCredentials.PayVoucherPicture2;
                cCustomerConsumptionCredentialsVo.PayVoucherPicture3 = cCustomerConsumptionCredentials.PayVoucherPicture3;
                cCustomerConsumptionCredentialsVo.PayVoucherPicture4 = cCustomerConsumptionCredentials.PayVoucherPicture4;
                cCustomerConsumptionCredentialsVo.PayVoucherPicture5 = cCustomerConsumptionCredentials.PayVoucherPicture5;
                cCustomerConsumptionCredentialsVo.Valid = cCustomerConsumptionCredentials.Valid;
                return ResultData<CustomerConsumptionCredentialsVo>.Success().AddData("cCustomerConsumptionCredentialsInfo", cCustomerConsumptionCredentialsVo);
            }
            catch (Exception ex)
            {
                return ResultData<CustomerConsumptionCredentialsVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加消费凭证
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData<int>> AddAsync(AddCustomerConsumptionCredentialsVo addVo)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;

                AddCustomerConsumptionCredentialsDto addDto = new AddCustomerConsumptionCredentialsDto();
                addDto.CustomerId = customerId;
                addDto.CustomerName = addVo.CustomerName;
                addDto.ToHospitalPhone = addVo.ToHospitalPhone;
                addDto.ConsumeDate = addVo.ConsumeDate;
                addDto.BaseLiveAnchorId = addVo.BaseLiveAnchorId;
                addDto.PayVoucherPicture1 = addVo.PayVoucherPicture1;
                addDto.PayVoucherPicture2 = addVo.PayVoucherPicture2;
                addDto.PayVoucherPicture3 = addVo.PayVoucherPicture3;
                addDto.PayVoucherPicture4 = addVo.PayVoucherPicture4;
                addDto.PayVoucherPicture5 = addVo.PayVoucherPicture5;
                await customerConsumptionCredentialsService.AddAsync(addDto);
                return ResultData<int>.Success();
            }
            catch (Exception ex)
            {
                return ResultData<int>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改消费凭证
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateCustomerConsumptionCredentialsVo updateVo)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                UpdateCustomerConsumptionCredentialsDto updateDto = new UpdateCustomerConsumptionCredentialsDto();
                updateDto.Id = updateVo.Id;
                updateDto.CustomerId = customerId;
                updateDto.CustomerName = updateVo.CustomerName;
                updateDto.ToHospitalPhone = updateVo.ToHospitalPhone;
                updateDto.ConsumeDate = updateVo.ConsumeDate;
                updateDto.PayVoucherPicture1 = updateVo.PayVoucherPicture1;
                updateDto.PayVoucherPicture2 = updateVo.PayVoucherPicture2;
                updateDto.PayVoucherPicture3 = updateVo.PayVoucherPicture3;
                updateDto.PayVoucherPicture4 = updateVo.PayVoucherPicture4;
                updateDto.PayVoucherPicture5 = updateVo.PayVoucherPicture5;
                await customerConsumptionCredentialsService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除消费凭证
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await customerConsumptionCredentialsService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}
