using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CheckBaseInfo;
using Fx.Amiya.Background.Api.Vo.CustomerConsumptionCredentials;
using Fx.Amiya.Background.Api.Vo.CustomerConsumptionCredentials.Input;
using Fx.Amiya.Dto.CheckBaseInfo;
using Fx.Amiya.Dto.CustomerConsumptionCredentials;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 客户消费凭证板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerConsumptionCredentialsController : ControllerBase
    {
        private ICustomerConsumptionCredentialsService customerConsumptionCredentialsService;
        private IHttpContextAccessor _httpContextAccessor;
        private ICustomerService customerService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerConsumptionCredentialsService"></param>
        public CustomerConsumptionCredentialsController(ICustomerConsumptionCredentialsService customerConsumptionCredentialsService,
            IHttpContextAccessor httpContextAccessor, ICustomerService customerService)
        {
            this.customerConsumptionCredentialsService = customerConsumptionCredentialsService;
            _httpContextAccessor = httpContextAccessor;
            this.customerService = customerService;
        }


        /// <summary>
        /// 获取客户消费凭证信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerConsumptionCredentialsVo>>> GetListWithPageAsync(string keyword, bool valid, int? checkState, int pageNum, int pageSize)
        {
            try
            {
                var q = await customerConsumptionCredentialsService.GetListAsync(keyword, valid, checkState, pageNum, pageSize);

                var customerConsumptionCredentials = from d in q.List
                                                     select new CustomerConsumptionCredentialsVo
                                                     {
                                                         Id = d.Id,
                                                         CustomerId=d.CustomerId,
                                                         CustomerName = d.CustomerName,
                                                         ToHospitalPhone = d.ToHospitalPhone,
                                                         LiveAnchor = d.LiveAnchor,
                                                         ConsumeDate = d.ConsumeDate,
                                                         PayVoucherPicture1 = d.PayVoucherPicture1,
                                                         PayVoucherPicture2 = d.PayVoucherPicture2,
                                                         PayVoucherPicture3 = d.PayVoucherPicture3,
                                                         PayVoucherPicture4 = d.PayVoucherPicture4,
                                                         PayVoucherPicture5 = d.PayVoucherPicture5,
                                                         CheckState = d.CheckState,
                                                         CheckBy = d.CheckBy,
                                                         CheckByEmpname = d.CheckByEmpname,
                                                         CheckDate = d.CheckDate,
                                                         CreateDate = d.CreateDate,
                                                         UpdateDate = d.UpdateDate,
                                                         DeleteDate = d.DeleteDate,
                                                         Valid = d.Valid,
                                                         CheckRemark=d.CheckRemark
                                                     };

                FxPageInfo<CustomerConsumptionCredentialsVo> customerConsumptionCredentialsPageInfo = new FxPageInfo<CustomerConsumptionCredentialsVo>();
                customerConsumptionCredentialsPageInfo.TotalCount = q.TotalCount;
                customerConsumptionCredentialsPageInfo.List = customerConsumptionCredentials;

                return ResultData<FxPageInfo<CustomerConsumptionCredentialsVo>>.Success().AddData("customerConsumptionCredentialsInfo", customerConsumptionCredentialsPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerConsumptionCredentialsVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 审核客户消费凭证信息
        /// </summary>
        /// <param name="checkInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(CheckInfoVo checkInfo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int  employeeId = Convert.ToInt32(employee.Id);
                CheckInfoDto updateDto = new CheckInfoDto();
                updateDto.Id = checkInfo.Id;
                updateDto.CheckState = checkInfo.CheckState;
                updateDto.CheckRemark = checkInfo.CheckRemark;
                updateDto.CheckBy = employeeId;
                await customerConsumptionCredentialsService.CheckAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
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
                var customerInfo =await customerService.GetByPhoneAsync(addVo.BindPhone);
                if (string.IsNullOrEmpty(customerInfo.Phone)) throw new Exception("该手机号未绑定小程序！");
                AddCustomerConsumptionCredentialsDto addDto = new AddCustomerConsumptionCredentialsDto();
                addDto.CustomerId = customerInfo.Id;
                addDto.CustomerName = addVo.CustomerName;
                addDto.ToHospitalPhone = addVo.ToHospitalPhone;
                addDto.ConsumeDate = addVo.ConsumeDate;
                addDto.PayVoucherPicture1 = addVo.PayVoucherPicture1;
                addDto.PayVoucherPicture2 = addVo.PayVoucherPicture2;
                addDto.PayVoucherPicture3 = addVo.PayVoucherPicture3;
                addDto.PayVoucherPicture4 = addVo.PayVoucherPicture4;
                addDto.PayVoucherPicture5 = addVo.PayVoucherPicture5;
                addDto.AssistantId = addVo.AssistantId;
                addDto.BaseLiveAnchorId = addVo.BaseLiveAnchorId;
                await customerConsumptionCredentialsService.AddAsync(addDto);
                return ResultData<int>.Success();
            }
            catch (Exception ex)
            {
                return ResultData<int>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改绑定助理
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updateAssistant")]
        public async Task<ResultData> UpdateAssistantAsync(UpdateCustomerConsumptionCredentialVo updateVo) {
            await customerConsumptionCredentialsService.UpdateAssistantAsync(updateVo.Id,updateVo.AssistantId);
            return ResultData.Success();
        }


    }
}
