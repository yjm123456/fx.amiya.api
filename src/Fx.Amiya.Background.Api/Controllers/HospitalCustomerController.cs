using Fx.Amiya.Background.Api.Vo.HospitalCustomer;
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

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院顾客数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxTenantAuthorize]
    public class HospitalCustomerController : ControllerBase
    {
        private IHospitalCustomerInfoService _hospitalCustomerService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalCustomerService"></param>
        public HospitalCustomerController(IHospitalCustomerInfoService hospitalCustomerService,
            IHttpContextAccessor httpContextAccessor)
        {
            _hospitalCustomerService = hospitalCustomerService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取医院顾客（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("allCustomerListWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalCustomerVo>>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int hospitalId = employee.HospitalId;
                var q = await _hospitalCustomerService.GetListWithPageAsync(keyword, hospitalId,pageNum, pageSize);

                var hospitalCustomer = from d in q.List
                              select new HospitalCustomerVo
                              {
                                  CustomerName=d.CustomerName,
                                  CustomerPhone=d.CustomerPhone,
                                  IsMyFollow=d.IsMyFollow,
                                  City=d.City,
                                  GoodsDemand=d.NewGoodsDemand,
                                  FirstSendDate=d.CreateDate,
                                  ConfirmOrderDate=d.ConfirmOrderDate,
                                  NewSendDate=d.UpdateDate,
                                  SendOrderNum=d.SendAmount,
                                  DealNum=d.DealAmount
                              };

                FxPageInfo<HospitalCustomerVo> hospitalCustomerPageInfo = new FxPageInfo<HospitalCustomerVo>();
                hospitalCustomerPageInfo.TotalCount = q.TotalCount;
                hospitalCustomerPageInfo.List = hospitalCustomer;

                return ResultData<FxPageInfo<HospitalCustomerVo>>.Success().AddData("hospitalCustomerInfo", hospitalCustomerPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalCustomerVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取“我来跟进”的顾客（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("myFollowListWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalCustomerVo>>> GetByHospitalEmployeeIdListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int hospitalEmployeeId = Convert.ToInt32(employee.Id);
                var q = await _hospitalCustomerService.GetByHospitalEmployeeIdListWithPageAsync(keyword, hospitalEmployeeId, pageNum, pageSize);

                var hospitalCustomer = from d in q.List
                                       select new HospitalCustomerVo
                                       {
                                           CustomerName = d.CustomerName,
                                           CustomerPhone = d.CustomerPhone,
                                           IsMyFollow = d.IsMyFollow,
                                           City = d.City,
                                           GoodsDemand = d.NewGoodsDemand,
                                           FirstSendDate = d.CreateDate,
                                           ConfirmOrderDate = d.ConfirmOrderDate,
                                           NewSendDate = d.UpdateDate,
                                           SendOrderNum = d.SendAmount,
                                           DealNum = d.DealAmount
                                       };

                FxPageInfo<HospitalCustomerVo> hospitalCustomerPageInfo = new FxPageInfo<HospitalCustomerVo>();
                hospitalCustomerPageInfo.TotalCount = q.TotalCount;
                hospitalCustomerPageInfo.List = hospitalCustomer;

                return ResultData<FxPageInfo<HospitalCustomerVo>>.Success().AddData("hospitalCustomerInfo", hospitalCustomerPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalCustomerVo>>.Fail(ex.Message);
            }
        }


    }
}
