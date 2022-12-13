using Fx.Amiya.Background.Api.Vo.OrderRemark;
using Fx.Amiya.Dto.OrderRemark;
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
    /// 订单备注数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OrderRemarkController : ControllerBase
    {
        private IOrderRemarkService _orderRemarkService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orderRemarkService"></param>
        public OrderRemarkController(IOrderRemarkService orderRemarkService,
            IHttpContextAccessor httpContextAccessor)
        {
            _orderRemarkService = orderRemarkService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 根据订单号获取订单备注（分页）
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getByOrderListWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<OrderRemarkVo>>> GetListWithPageAsync(string orderId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _orderRemarkService.GetListWithPageAsync(orderId, pageNum, pageSize);

                var orderRemark = from d in q.List
                              select new OrderRemarkVo
                              {
                                  Id = d.Id,
                                  BelongAuthorize = d.BelongAuthorize,
                                  OrderId = d.OrderId,
                                  Remark=d.Remark,
                                  CreateBy = d.CreateBy,
                                  CreateDate = d.CreateDate,
                                  UpdateDate = d.UpdateDate,
                                  Valid = d.Valid,
                                  DeleteDate = d.DeleteDate,
                                  Avatar=d.Avatar,
                                  EmployeeName=d.EmployeeName,
                              };

                FxPageInfo<OrderRemarkVo> orderRemarkPage = new FxPageInfo<OrderRemarkVo>();
                orderRemarkPage.TotalCount = q.TotalCount;
                orderRemarkPage.List = orderRemark;

                return ResultData<FxPageInfo<OrderRemarkVo>>.Success().AddData("orderRemark", orderRemarkPage);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<OrderRemarkVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 管理端添加订单备注信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("internalAdd")]
        [FxInternalAuthorize]
        public async Task<ResultData> InternamAddAsync(AddOrderRemarkVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddOrderRemarkDto addDto = new AddOrderRemarkDto();
                addDto.OrderId = addVo.OrderId; 
                addDto.Remark = addVo.Remark;
                addDto.CreateBy = employeeId;
                addDto.BelongAuthorize = (int)AuthorizeStatusEnum.InternalAuthorize;
                await _orderRemarkService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 机构端添加订单备注信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("tenantAdd")]
        [FxTenantAuthorize]
        public async Task<ResultData> TenantAddAsync(AddOrderRemarkVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int hospitalId =Convert.ToInt32(employee.Id);
                AddOrderRemarkDto addDto = new AddOrderRemarkDto();
                addDto.OrderId = addVo.OrderId;
                addDto.Remark = addVo.Remark;
                addDto.CreateBy = hospitalId;
                addDto.BelongAuthorize =(int) AuthorizeStatusEnum.TenantAuhtorize;
                await _orderRemarkService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        ///// <summary>
        ///// 根据医院环境编号获取医院环境信息
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("byId/{id}")]
        //[FxInternalAuthorize]
        //public async Task<ResultData<OrderRemarkVo>> GetByIdAsync(string id)
        //{
        //    try
        //    {
        //        var hospitalEnvironment = await _hospitalEnvironmentService.GetByIdAsync(id);
        //        OrderRemarkVo hospitalEnvironmentVo = new OrderRemarkVo();
        //        hospitalEnvironmentVo.Id = hospitalEnvironment.Id;
        //        hospitalEnvironmentVo.Name = hospitalEnvironment.Name;
        //        hospitalEnvironmentVo.Valid = hospitalEnvironment.Valid;

        //        return ResultData<OrderRemarkVo>.Success().AddData("hospitalEnvironmentInfo", hospitalEnvironmentVo);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultData<OrderRemarkVo>.Fail(ex.Message);
        //    }
        //}


        ///// <summary>
        ///// 修改医院环境信息
        ///// </summary>
        ///// <param name="updateVo"></param>
        ///// <returns></returns>
        //[HttpPut]
        //[FxInternalAuthorize]
        //public async Task<ResultData> UpdateAsync(OrderRemarkUpdateVo updateVo)
        //{
        //    try
        //    {
        //        OrderRemarkUpdateDto updateDto = new OrderRemarkUpdateDto();
        //        updateDto.Id = updateVo.Id;
        //        updateDto.Name = updateVo.Name;
        //        updateDto.Valid = updateVo.Valid;
        //        await _hospitalEnvironmentService.UpdateAsync(updateDto);
        //        return ResultData.Success();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultData.Fail(ex.Message);
        //    }
        //}


        ///// <summary>
        ///// 删除医院环境信息
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //[FxInternalAuthorize]
        //public async Task<ResultData> DeleteAsync(string id)
        //{
        //    try
        //    {
        //        await _hospitalEnvironmentService.DeleteAsync(id);
        //        return ResultData.Success();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

    }
}
