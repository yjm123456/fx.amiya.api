

using Fx.Amiya.BusinessWeChat.Api.Vo.Base;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 订单成交情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ContentPlatFormOrderDealInfoController : ControllerBase
    {


        private IHttpContextAccessor _httpContextAccessor;
        private IContentPlatFormOrderDealInfoService _contentPlatFormOrderDealInfoService;
        public ContentPlatFormOrderDealInfoController(IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取成交情况列表
        /// </summary>
        /// <param name="startDate">登记开始日期</param>
        /// <param name="endDate">登记结束日期</param>
        /// <param name="sendStartDate">派单开始日期</param>
        /// <param name="sendEndDate">派单结束日期</param>
        /// <param name="consultationType">面诊类型（空查询所有）</param>
        /// <param name="isToHospital">是否到院（空查询所有）</param>
        /// <param name="tohospitalStartDate">到院开始时间</param>
        /// <param name="toHospitalEndDate">到院结束时间</param>
        /// <param name="toHospitalType">到院类型（空查询所有）</param>
        /// <param name="isDeal">是否成交（空查询所有）</param>
        /// <param name="dealStartDate">成交开始时间</param>
        /// <param name="dealEndDate">成交结束时间</param>
        /// <param name="lastDealHospitalId">最终成交医院id（空查询所有）</param>
        /// <param name="isAccompanying">是否陪诊（空查询所有）</param>
        /// <param name="isOldCustomer">新老客业绩（空查询所有）</param>
        /// <param name="minAddOrderPrice">最小下单金额（空查询所有）</param>
        /// <param name="maxAddOrderPrice">最大下单金额（空查询所有）</param>
        /// <param name="CheckState">审核状态（空查询所有）</param>
        /// <param name="isReturnBakcPrice">是否回款（空查询所有）</param>
        /// <param name="returnBackPriceStartDate">回款开始时间</param>
        /// <param name="returnBackPriceEndDate">回款结束时间</param>
        /// <param name="customerServiceId">跟进人员（空查询所有，0查医院）</param>
        /// <param name="keyWord">关键字</param>
        /// <param name="createBillCompanyId">开票公司</param>
        /// <param name="isCreateBill">是否开票</param>
        /// <param name="dataFrom">数据获取方：true：财务；false：其他</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("contentPlatFormOrderDealInfo")]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>> GetDealInfoAsync(DateTime? startDate, DateTime? endDate, DateTime? sendStartDate, DateTime? sendEndDate, int? consultationType, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, bool? isToHospital, DateTime? tohospitalStartDate, DateTime? toHospitalEndDate, DateTime? dealStartDate, DateTime? dealEndDate, int? toHospitalType, bool? isDeal, int? lastDealHospitalId, bool? isAccompanying, bool? isOldCustomer, int? CheckState, bool? isReturnBakcPrice, DateTime? returnBackPriceStartDate, DateTime? returnBackPriceEndDate, int? customerServiceId, string keyWord, string createBillCompanyId, bool? isCreateBill, int pageNum, int pageSize, bool? dataFrom)
        {

            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var result = await _contentPlatFormOrderDealInfoService.GetOrderListWithPageAsync(startDate, endDate, sendStartDate, sendEndDate, consultationType, minAddOrderPrice, maxAddOrderPrice, isToHospital, tohospitalStartDate, toHospitalEndDate, dealStartDate, dealEndDate, toHospitalType, isDeal, lastDealHospitalId, isAccompanying, isOldCustomer, CheckState, isReturnBakcPrice, returnBackPriceStartDate, returnBackPriceEndDate, customerServiceId, keyWord, employeeId, createBillCompanyId, isCreateBill, pageNum, pageSize,dataFrom);

            var contentPlatformOrders = from d in result.List
                                        select new ContentPlatFormOrderDealInfoVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            Phone = d.Phone,
                                            EncryptPhone = d.EncryptPhone,
                                            IsDeal = d.IsDeal,
                                            IsOldCustomer = d.IsOldCustomer,
                                            AddOrderPrice = d.AddOrderPrice,
                                            IsAcompanying = d.IsAcompanying,
                                            CommissionRatio = d.CommissionRatio,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalType = d.ToHospitalType,
                                            ToHospitalTypeText = d.ToHospitalTypeText,
                                            ConsultationTypeText = d.ConsultationTypeText,
                                            SendDate = d.SendDate,
                                            TohospitalDate = d.ToHospitalDate,
                                            LastDealHospitalId = d.LastDealHospitalId,
                                            DealPerformanceType = d.DealPerformanceType,
                                            DealPerformanceTypeText = d.DealPerformanceTypeText,
                                            DealHospital = d.LastDealHospital,
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
                                            CheckByEmpName = d.CheckByEmpName,
                                            InformationPrice = d.InformationPrice,
                                            SystemUpdatePrice = d.SystemUpdatePrice,
                                            SettlePrice = d.SettlePrice,
                                            CheckRemark = d.CheckRemark,
                                            IsReturnBackPrice = d.IsReturnBackPrice,
                                            ReturnBackDate = d.ReturnBackDate,
                                            ReturnBackPrice = d.ReturnBackPrice,
                                            CreateBy = d.CreateBy,
                                            CreateByEmpName = d.CreateByEmpName,
                                            BelongLiveAnchor = d.BelongLiveAnchor,
                                            ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                                            IsRepeatProfundityOrder = d.IsRepeatProfundityOrder,
                                            IsCreateBill = d.IsCreateBill,
                                            CreatBillCompany = d.BelongCompany

                                        };
            FxPageInfo<ContentPlatFormOrderDealInfoVo> pageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoVo>();
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }



        /// <summary>
        /// 获取今日到院订单
        /// </summary>
        /// <param name="startDate">登记开始日期</param>
        /// <param name="endDate">登记结束日期</param>
        /// <param name="isDeal">是否成交（空查询所有）</param>
        /// <param name="lastDealHospitalId">最终成交医院id（空查询所有）</param>
        /// <param name="keyWord">关键词（支持模糊查询订单编号，手机号，成交编号）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("todayToHospitalInfo")]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealSimpleInfoVo>>> GetTodayToHospitalInfoAsync(DateTime? startDate, DateTime? endDate,  bool? isDeal, int? lastDealHospitalId,string keyWord, int pageNum, int pageSize)
        {

            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var result = await _contentPlatFormOrderDealInfoService.GetSimpleOrderListWithPageAsync(startDate, endDate, isDeal, lastDealHospitalId, keyWord, employeeId, pageNum, pageSize);

            var contentPlatformOrders = from d in result.List
                                        select new ContentPlatFormOrderDealSimpleInfoVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            IsRepeatProfundityOrder = d.IsRepeatProfundityOrder,
                                            Phone = d.Phone,
                                            IsDeal = d.IsDeal,
                                            DealPrice = d.Price,
                                            IsOldCustomer = d.IsOldCustomer,
                                            ConsultationTypeText =d.ConsultationTypeText,
                                            ToHospitalTypeText = d.ToHospitalTypeText,
                                            TohospitalDate = d.ToHospitalDate,
                                            DealDate = d.DealDate,

                                        };
            FxPageInfo<ContentPlatFormOrderDealSimpleInfoVo> pageInfo = new FxPageInfo<ContentPlatFormOrderDealSimpleInfoVo>();
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<ContentPlatFormOrderDealSimpleInfoVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }

        #region 【枚举下拉框】
        /// <summary>
        /// 获取内容平台成交业绩类型
        /// </summary>
        /// <returns></returns>
        [FxInternalAuthorize]
        [HttpGet("contentPlateFormOrderDealPerformanceType")]
        public ResultData<List<BaseKeyAndValueVo>> GetContentPlateFormOrderDealPerformanceTypeList()
        {
            var orderTypes = from d in _contentPlatFormOrderDealInfoService.GetOrderDealPerformanceTypeList()
                             select new BaseKeyAndValueVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("contentPlateFormOrderDealPerformanceType", orderTypes.ToList());
        }
        #endregion
    }
}
