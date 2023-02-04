using Fx.Amiya.Background.Api.Vo.UnCheckOrder;
using Fx.Amiya.Background.Api.Vo.ImproveAndRemark;
using Fx.Amiya.Background.Api.Vo.Remark;
using Fx.Amiya.Dto.UnCheckOrder;
using Fx.Amiya.Dto.ImprovePlanAndRemark;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Common;
using Fx.Amiya.Service;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 未对账订单列表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UnCheckOrderController : ControllerBase
    {
        private readonly IUnCheckOrderService unCheckOrderService;
        private IWxAppConfigService configService;
        private IHttpContextAccessor httpContextAccessor;

        public UnCheckOrderController(IUnCheckOrderService UnCheckOrderService,
            IWxAppConfigService wxAppConfigService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.unCheckOrderService = UnCheckOrderService;
            this.configService = wxAppConfigService;
            this.httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startDate">创建开始时间</param>
        /// <param name="endDate">创建结束时间</param>
        /// <param name="isSubmitReconciliationDocuments">是否上传对账单（默认查询未上传）</param>
        /// <param name="orderFrom">订单来源</param>
        /// <param name="hospitalId">指派医院</param>
        /// <param name="keyword">关键字（订单号，手机号）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]

        public async Task<ResultData<FxPageInfo<UnCheckOrderVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, bool? isSubmitReconciliationDocuments, int? orderFrom, int? hospitalId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await unCheckOrderService.GetListByPageAsync(startDate, endDate, isSubmitReconciliationDocuments, orderFrom, hospitalId, keyword, pageNum, pageSize);

                var express = from e in q.List
                              select new UnCheckOrderVo
                              {
                                  Id = e.Id,
                                  OrderId = e.OrderId,
                                  OrderFrom = e.OrderFrom,
                                  OrderFromText = e.OrderFromText,
                                  Phone = e.Phone,
                                  DealDate = e.DealDate,
                                  DealPrice = e.DealPrice,
                                  InformationPricePercent = e.InformationPricePercent,
                                  SystemUpdatePercent = e.SystemUpdatePercent,
                                  InformationPrice = e.InformationPrice,
                                  SystemUpdatePrice = e.SystemUpdatePrice,
                                  ReturnBackPrice = e.ReturnBackPrice,
                                  IsSubmitReconciliationDocuments = e.IsSubmitReconciliationDocuments,
                                  IsSubmitReconciliationDocumentsText = e.IsSubmitReconciliationDocumentsText,
                                  SendHospital = e.SendHospital,
                                  CreateBy = e.CreateBy,
                                  CreateDate = e.CreateDate,
                                  CreateByName = e.CreateByName,
                                  SendHospitalName = e.SendHospitalName
                              };

                FxPageInfo<UnCheckOrderVo> unCheckOrderPageInfo = new FxPageInfo<UnCheckOrderVo>();
                unCheckOrderPageInfo.TotalCount = q.TotalCount;
                unCheckOrderPageInfo.List = express;

                return ResultData<FxPageInfo<UnCheckOrderVo>>.Success().AddData("unCheckOrder", unCheckOrderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<UnCheckOrderVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加未对账订单列表
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxInternalAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddUnCheckOrderVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            try
            {
                List<AddUnCheckOrderDto> AddUnCheckOrderDtoList = new List<AddUnCheckOrderDto>();
                foreach (var x in addVo.AddBaseOrderInfoVoList)
                {
                    var config = await configService.GetCallCenterConfig();
                    string decryptPhone = ServiceClass.Decrypto(x.Phone, config.PhoneEncryptKey);
                    AddUnCheckOrderDto addUnCheckOrderDto = new AddUnCheckOrderDto();
                    addUnCheckOrderDto.OrderId = x.OrderId;
                    addUnCheckOrderDto.OrderFrom = addVo.OrderFrom;
                    addUnCheckOrderDto.Phone = decryptPhone;
                    addUnCheckOrderDto.DealDate = x.DealDate;
                    addUnCheckOrderDto.DealPrice = x.DealPrice;
                    addUnCheckOrderDto.InformationPricePercent = addVo.InformationPricePercent;
                    addUnCheckOrderDto.InformationPrice = x.DealPrice * addVo.InformationPricePercent / 100;
                    addUnCheckOrderDto.SystemUpdatePercent = addVo.SystemUpdatePercent;
                    addUnCheckOrderDto.SystemUpdatePrice = x.DealPrice * addVo.SystemUpdatePercent / 100;
                    addUnCheckOrderDto.ReturnBackPrice = addUnCheckOrderDto.InformationPrice + addUnCheckOrderDto.SystemUpdatePrice;
                    addUnCheckOrderDto.CreateBy = employeeId;
                    AddUnCheckOrderDtoList.Add(addUnCheckOrderDto);
                }
                await unCheckOrderService.AddListAsync(AddUnCheckOrderDtoList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取未对账订单列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [FxInternalAuthorize]
        public async Task<ResultData<UnCheckOrderVo>> GetByIdAsync(string id)
        {
            var selectResult = await unCheckOrderService.GetByIdAsync(id);
            UnCheckOrderVo result = new UnCheckOrderVo();
            result.Id = selectResult.Id;
            result.OrderId = selectResult.OrderId;
            result.OrderFrom = selectResult.OrderFrom;
            result.Phone = selectResult.Phone;
            result.DealDate = selectResult.DealDate;
            result.DealPrice = selectResult.DealPrice;
            result.InformationPricePercent = selectResult.InformationPricePercent;
            result.SystemUpdatePercent = selectResult.SystemUpdatePercent;
            result.InformationPrice = selectResult.InformationPrice;
            result.SystemUpdatePrice = selectResult.SystemUpdatePrice;
            result.ReturnBackPrice = selectResult.ReturnBackPrice;
            result.IsSubmitReconciliationDocuments = selectResult.IsSubmitReconciliationDocuments;
            return ResultData<UnCheckOrderVo>.Success().AddData("unCheckOrderVo", result);

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateUnCheckOrderVo updateVo)
        {
            try
            {
                UpdateUnCheckOrderDto updateUnCheckOrderDto = new UpdateUnCheckOrderDto();
                updateUnCheckOrderDto.Id = updateVo.Id;
                updateUnCheckOrderDto.InformationPricePercent = updateVo.InformationPricePercent;
                updateUnCheckOrderDto.SystemUpdatePercent = updateVo.SystemUpdatePercent;
                updateUnCheckOrderDto.InformationPrice = updateVo.InformationPrice;
                updateUnCheckOrderDto.SystemUpdatePrice = updateVo.SystemUpdatePrice;
                updateUnCheckOrderDto.ReturnBackPrice = updateVo.ReturnBackPrice;
                updateUnCheckOrderDto.IsSubmitReconciliationDocuments = updateVo.IsSubmitReconciliationDocuments;
                await unCheckOrderService.UpdateAsync(updateUnCheckOrderDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 指派医院
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("sendToHospital")]
        [FxInternalAuthorize]
        public async Task<ResultData> SendToHospitalAsync(UnCheckOrderSendToHospitalVo updateVo)
        {
            try
            {
                UnCheckOrderSendToHospitalDto unCheckOrderSendToHospitalDto = new UnCheckOrderSendToHospitalDto();
                unCheckOrderSendToHospitalDto.idList = updateVo.idList;
                unCheckOrderSendToHospitalDto.HospitalId = updateVo.HospitalId;
                await unCheckOrderService.SendToHospitalByIdListAsync(unCheckOrderSendToHospitalDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpDelete]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(List<string> idList)
        {
            try
            {
                await unCheckOrderService.DeleteAsync(idList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
