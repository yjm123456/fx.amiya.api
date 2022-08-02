using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 成交情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ContentPlatFormOrderDealInfoController : ControllerBase
    {
        private IContentPlatFormOrderDealInfoService _contentPlatFormOrderDealInfoService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contentPlatFormOrderDealInfoService"></param>
        public ContentPlatFormOrderDealInfoController(IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 获取成交情况列表
        /// </summary>
        /// <param name="startDate">登记开始日期</param>
        /// <param name="endDate">登记结束日期</param>
        /// <param name="sendStartDate">派单开始日期</param>
        /// <param name="sendEndDate">派单结束日期</param>
        /// <param name="consultationType">面诊状态（空查询所有）</param>
        /// <param name="isToHospital">是否到院（空查询所有）</param>
        /// <param name="tohospitalStartDate">到院开始时间</param>
        /// <param name="toHospitalEndDate">到院结束时间</param>
        /// <param name="toHospitalType">到院类型（空查询所有）</param>
        /// <param name="isDeal">是否成交（空查询所有）</param>
        /// <param name="lastDealHospitalId">最终成交医院id（空查询所有）</param>
        /// <param name="isAccompanying">是否陪诊（空查询所有）</param>
        /// <param name="isOldCustomer">新老客业绩（空查询所有）</param>
        /// <param name="CheckState">审核状态（空查询所有）</param>
        /// <param name="isReturnBakcPrice">是否回款（空查询所有）</param>
        /// <param name="returnBackPriceStartDate">回款开始时间</param>
        /// <param name="returnBackPriceEndDate">回款结束时间</param>
        /// <param name="customerServiceId">跟进人员（空查询所有，0查医院）</param>
        /// <param name="keyWord">关键字</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("contentPlatFormOrderDealInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>> GetDealInfo(DateTime? startDate, DateTime? endDate, DateTime? sendStartDate, DateTime? sendEndDate,int? consultationType, bool? isToHospital, DateTime? tohospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool? isDeal, int? lastDealHospitalId, bool? isAccompanying, bool? isOldCustomer, int? CheckState, bool? isReturnBakcPrice, DateTime? returnBackPriceStartDate, DateTime? returnBackPriceEndDate, int? customerServiceId, string keyWord, int pageNum, int pageSize)
        {

            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var result = await _contentPlatFormOrderDealInfoService.GetOrderListWithPageAsync(startDate, endDate, sendStartDate, sendEndDate, consultationType, isToHospital, tohospitalStartDate, toHospitalEndDate, toHospitalType, isDeal, lastDealHospitalId, isAccompanying, isOldCustomer, CheckState, isReturnBakcPrice, returnBackPriceStartDate, returnBackPriceEndDate, customerServiceId, keyWord, employeeId, pageNum, pageSize);

            var contentPlatformOrders = from d in result.List
                                        select new ContentPlatFormOrderDealInfoVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            Phone=d.Phone,
                                            IsDeal = d.IsDeal,
                                            IsOldCustomer = d.IsOldCustomer,
                                            IsAcompanying = d.IsAcompanying,
                                            CommissionRatio = d.CommissionRatio,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalType = d.ToHospitalType,
                                            ToHospitalTypeText =d.ToHospitalTypeText,
                                            ConsultationTypeText=d.ConsultationTypeText,
                                            SendDate = d.SendDate,
                                            TohospitalDate = d.ToHospitalDate,
                                            LastDealHospitalId = d.LastDealHospitalId,
                                            DealHospital=d.LastDealHospital,
                                            DealPicture = d.DealPicture,
                                            Remark = d.Remark,
                                            Price = d.Price,
                                            DealDate = d.DealDate,
                                            OtherOrderId = d.OtherAppOrderId,
                                            CheckState = d.CheckState,
                                            CheckStateText = d.CheckStateText,
                                            CheckPrice = d.CheckPrice,
                                            CheckDate = d.CheckDate,
                                            CheckBy = d.CheckBy,
                                            CheckByEmpName=d.CheckByEmpName,
                                            SettlePrice = d.SettlePrice,
                                            CheckRemark = d.CheckRemark,
                                            IsReturnBackPrice = d.IsReturnBackPrice,
                                            ReturnBackDate = d.ReturnBackDate,
                                            ReturnBackPrice = d.ReturnBackPrice,
                                            CreateBy = d.CreateBy,
                                            CreateByEmpName=d.CreateByEmpName,
                                        };
            FxPageInfo<ContentPlatFormOrderDealInfoVo> pageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoVo>();
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }

        /// <summary>
        /// 根据成交情况编号获取成交情况信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<ContentPlatFormOrderDealInfoVo>> GetByIdAsync(string id)
        {
            try
            {
                var contentPlatFormOrderDealInfo = await _contentPlatFormOrderDealInfoService.GetByIdAsync(id);
                ContentPlatFormOrderDealInfoVo contentPlatFormOrderDealInfoVo = new ContentPlatFormOrderDealInfoVo();
                contentPlatFormOrderDealInfoVo.Id = contentPlatFormOrderDealInfo.Id;
                contentPlatFormOrderDealInfoVo.ContentPlatFormOrderId = contentPlatFormOrderDealInfo.ContentPlatFormOrderId;
                contentPlatFormOrderDealInfoVo.CreateDate = contentPlatFormOrderDealInfo.CreateDate;
                contentPlatFormOrderDealInfoVo.IsOldCustomer = contentPlatFormOrderDealInfo.IsOldCustomer;
                contentPlatFormOrderDealInfoVo.IsAcompanying = contentPlatFormOrderDealInfo.IsAcompanying;
                contentPlatFormOrderDealInfoVo.CommissionRatio = contentPlatFormOrderDealInfo.CommissionRatio;
                contentPlatFormOrderDealInfoVo.IsToHospital = contentPlatFormOrderDealInfo.IsToHospital;
                contentPlatFormOrderDealInfoVo.ToHospitalType = contentPlatFormOrderDealInfo.ToHospitalType;
                contentPlatFormOrderDealInfoVo.TohospitalDate = contentPlatFormOrderDealInfo.ToHospitalDate;
                contentPlatFormOrderDealInfoVo.IsDeal = contentPlatFormOrderDealInfo.IsDeal;
                contentPlatFormOrderDealInfoVo.LastDealHospitalId = contentPlatFormOrderDealInfo.LastDealHospitalId;
                contentPlatFormOrderDealInfoVo.DealPicture = contentPlatFormOrderDealInfo.DealPicture;
                contentPlatFormOrderDealInfoVo.Remark = contentPlatFormOrderDealInfo.Remark;
                contentPlatFormOrderDealInfoVo.Price = contentPlatFormOrderDealInfo.Price;
                contentPlatFormOrderDealInfoVo.DealDate = contentPlatFormOrderDealInfo.DealDate;
                contentPlatFormOrderDealInfoVo.OtherOrderId = contentPlatFormOrderDealInfo.OtherAppOrderId;
                contentPlatFormOrderDealInfoVo.InvitationDocuments = contentPlatFormOrderDealInfo.InvitationDocuments;
                return ResultData<ContentPlatFormOrderDealInfoVo>.Success().AddData("contentPlatFormOrderDealInfoInfo", contentPlatFormOrderDealInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<ContentPlatFormOrderDealInfoVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改成交情况信息(暂停使用)
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(UpdateContentPlatFormOrderDealInfoVo updateVo)
        {
            try
            {
                UpdateContentPlatFormOrderDealInfoDto updateDto = new UpdateContentPlatFormOrderDealInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.ContentPlatFormOrderId = updateVo.ContentPlatFormOrderId;
                updateDto.IsToHospital = updateVo.IsToHospital;
                updateDto.ToHospitalDate = updateVo.TohospitalDate;
                updateDto.IsDeal = updateVo.IsDeal;
                updateDto.LastDealHospitalId = updateVo.LastDealHospitalId;
                updateDto.DealPicture = updateVo.DealPicture;
                updateDto.ToHospitalType = updateVo.ToHospitalType;
                updateDto.Remark = updateVo.Remark;
                updateDto.Price = updateVo.Price;
                updateDto.DealDate = updateVo.DealDate;
                updateDto.OtherAppOrderId = updateVo.OtherAppOrderId;
                await _contentPlatFormOrderDealInfoService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}
