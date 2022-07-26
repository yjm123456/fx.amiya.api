using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.HospitalCustomerInfo;
using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.OutWareHouse;
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
    /// 医院客户数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class HospitalCustomerInfoController : ControllerBase
    {
        private IDockingHospitalCustomerInfoService _hospitalCustomerInfoService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalCustomerInfoService"></param>
        public HospitalCustomerInfoController(IDockingHospitalCustomerInfoService hospitalCustomerInfoService,

            IHttpContextAccessor httpContextAccessor)
        {
            _hospitalCustomerInfoService = hospitalCustomerInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 获取医院客户信息列表（分页）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<HospitalCustomerInfoVo>>> GetListWithPageAsync(DateTime startDate, DateTime endDate, string customerName, string customerPhone, int hospitalId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _hospitalCustomerInfoService.GetListAsync(startDate, endDate, customerName, customerPhone, hospitalId, pageNum, pageSize);

                var hospitalCustomerInfo = from d in q.List
                                           select new HospitalCustomerInfoVo
                                           {
                                               MemberCardNum = d.MemberCardNum,
                                               CustomerId = d.CustomerId,
                                               CustomerName = d.Name,
                                               SceneEmployeeName = d.SceneEmployeeName,
                                               Sex = d.Sex,
                                               Age = d.Age,
                                               RegisterDate = d.RegisterDate,
                                               Region = d.Region,
                                               ChannelCategory = d.ChannelCategory,
                                               Channel = d.Channel,
                                           };

                FxPageInfo<HospitalCustomerInfoVo> hospitalCustomerInfoPageOutfo = new FxPageInfo<HospitalCustomerInfoVo>();
                hospitalCustomerInfoPageOutfo.TotalCount = q.TotalCount;
                hospitalCustomerInfoPageOutfo.List = hospitalCustomerInfo;

                return ResultData<FxPageInfo<HospitalCustomerInfoVo>>.Success().AddData("hospitalCustomerInfoOutfo", hospitalCustomerInfoPageOutfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalCustomerInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据客户编号获取消费记录（分页）
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getOrderByCustomerIdlistWithPage")]

        public async Task<ResultData<FxPageInfo<HospitalCustomerOrderInfoVo>>> GetOrderByCustomerIdWithPageAsync(string customerId, int hospitalId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _hospitalCustomerInfoService.GetCustomerOrderListAsync(customerId, hospitalId, pageNum, pageSize);

                var hospitalCustomerInfo = from d in q.List
                                           select new HospitalCustomerOrderInfoVo
                                           {
                                               customerID = d.customerID,
                                               date = d.date,
                                               memberCardNum = d.memberCardNum,
                                               customerName = d.customerName,
                                               sceneName = d.sceneName,
                                               channelCategory = d.channelCategory,
                                               channelName = d.channelName,
                                               docType = d.docType,
                                               itemName = d.itemName,
                                               itemStandard = d.itemStandard,
                                               quantity = d.quantity,
                                               amount = d.amount,
                                               cashAmount = d.cashAmount,
                                               prepaymentAmount = d.prepaymentAmount,
                                               cashOfMoneyCardAmount = d.cashOfMoneyCardAmount,
                                               yearCardAmount = d.yearCardAmount,
                                               handselOfMoneyCardAmount = d.handselOfMoneyCardAmount,
                                               integrationAmount = d.integrationAmount,
                                               insteadMoneyAmount = d.insteadMoneyAmount,
                                               arrearsAmount = d.arrearsAmount,
                                           };

                FxPageInfo<HospitalCustomerOrderInfoVo> hospitalCustomerInfoPageOutfo = new FxPageInfo<HospitalCustomerOrderInfoVo>();
                hospitalCustomerInfoPageOutfo.TotalCount = q.TotalCount;
                hospitalCustomerInfoPageOutfo.List = hospitalCustomerInfo;

                return ResultData<FxPageInfo<HospitalCustomerOrderInfoVo>>.Success().AddData("hospitalCustomerInfoOutfo", hospitalCustomerInfoPageOutfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalCustomerOrderInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取医院客户信息列表（分页）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetOrderlistWithPage")]

        public async Task<ResultData<FxPageInfo<HospitalCustomerOrderInfoVo>>> GetHospitalOrderWithPageAsync(DateTime startDate, DateTime endDate, string customerName, string customerPhone, int hospitalId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _hospitalCustomerInfoService.GetOrderListAsync(startDate, endDate, customerName, customerPhone, hospitalId, pageNum, pageSize);

                var hospitalCustomerInfo = from d in q.List
                                           select new HospitalCustomerOrderInfoVo
                                           {
                                               customerID = d.customerID,
                                               date = d.date,
                                               memberCardNum = d.memberCardNum,
                                               customerName = d.customerName,
                                               sceneName = d.sceneName,
                                               channelCategory = d.channelCategory,
                                               channelName = d.channelName,
                                               docType = d.docType,
                                               itemName = d.itemName,
                                               itemStandard = d.itemStandard,
                                               quantity = d.quantity,
                                               amount = d.amount,
                                               cashAmount = d.cashAmount,
                                               prepaymentAmount = d.prepaymentAmount,
                                               cashOfMoneyCardAmount = d.cashOfMoneyCardAmount,
                                               yearCardAmount = d.yearCardAmount,
                                               handselOfMoneyCardAmount = d.handselOfMoneyCardAmount,
                                               integrationAmount = d.integrationAmount,
                                               insteadMoneyAmount = d.insteadMoneyAmount,
                                               arrearsAmount = d.arrearsAmount,
                                           };

                FxPageInfo<HospitalCustomerOrderInfoVo> hospitalCustomerInfoPageOutfo = new FxPageInfo<HospitalCustomerOrderInfoVo>();
                hospitalCustomerInfoPageOutfo.TotalCount = q.TotalCount;
                hospitalCustomerInfoPageOutfo.List = hospitalCustomerInfo;

                return ResultData<FxPageInfo<HospitalCustomerOrderInfoVo>>.Success().AddData("hospitalCustomerInfoOutfo", hospitalCustomerInfoPageOutfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalCustomerOrderInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取已配置对接订单客户的医院信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDockingHospitalInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetDockingHospitalInfo()
        {
            try
            {
                var hospital = from d in await _hospitalCustomerInfoService.GetDockingHospitalIdAndName()
                               select new BaseIdAndNameVo
                               {
                                   Id = d.Id,
                                   Name = d.Name
                               };

                return ResultData<List<BaseIdAndNameVo>>.Success().AddData("hospitalInfo", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseIdAndNameVo>>.Fail(ex.Message);
            }
        }
    }
}
