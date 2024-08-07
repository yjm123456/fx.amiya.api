using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.LivingTakeGoodsOrder.Input;
using Fx.Amiya.Background.Api.Vo.LivingTakeGoodsOrder.Result;
using Fx.Amiya.Dto.LivingTakeGoodsOrder.Input;
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
    /// 直播中带货订单
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LivingTakeGoodsOrderController : ControllerBase
    {
        private readonly ILivingTakeGoodsOrderService livingTakeGoodsOrderService;

        public LivingTakeGoodsOrderController(ILivingTakeGoodsOrderService livingTakeGoodsOrderService)
        {
            this.livingTakeGoodsOrderService = livingTakeGoodsOrderService;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAsync(AddLivingTakeGoodsOrderVo addVo)
        {
            AddLivingTakeGoodsOrderDto addDto = new AddLivingTakeGoodsOrderDto();
            addDto.Id = addVo.Id;
            addDto.GoodsId = addVo.GoodsId;
            addDto.GoodsName = addVo.GoodsName;
            addDto.OrderStatus = addVo.OrderStatus;
            addDto.LiveanchorName = addVo.LiveanchorName;
            addDto.DealPrice = addVo.DealPrice;
            addDto.GoodsCount = addVo.GoodsCount;
            await livingTakeGoodsOrderService.AddLivingTakeGoodsOrderAsync(addDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<ResultData> UpdateAsync(UpdateLivingTakeGoodsOrderVo updateVo)
        {
            UpdateLivingTakeGoodsOrderDto updateDto = new UpdateLivingTakeGoodsOrderDto();
            updateDto.Id = updateVo.Id;
            updateDto.GoodsId = updateVo.GoodsId;
            updateDto.GoodsName = updateVo.GoodsName;
            updateDto.OrderStatus = updateVo.OrderStatus;
            updateDto.LiveanchorName = updateVo.LiveanchorName;
            updateDto.DealPrice = updateVo.DealPrice;
            updateDto.GoodsCount = updateVo.GoodsCount;
            await livingTakeGoodsOrderService.UpdateAsync(updateDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await livingTakeGoodsOrderService.DeleteAsync(id);
            return ResultData.Success();
        }

        /// <summary>
        /// 列表展示
        /// </summary>
        /// <param name="queryVo"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<LivingTakeGoodsOrderVo>>> GetListByPageAsync([FromQuery] QueryLivingTakeGoodsOrderByPageVo queryVo)
        {
            FxPageInfo<LivingTakeGoodsOrderVo> pageInfo = new FxPageInfo<LivingTakeGoodsOrderVo>();
            QueryLivingTakeGoodsOrderByPageDto queryDto = new QueryLivingTakeGoodsOrderByPageDto();
            queryDto.KeyWord = queryVo.KeyWord;
            queryDto.StartDate = queryVo.StartDate;
            queryDto.EndDate = queryVo.EndDate;
            queryDto.PageNum = queryVo.PageNum;
            queryDto.PageSize = queryVo.PageSize;
            var res = await livingTakeGoodsOrderService.GetListByPageAsync(queryDto);
            pageInfo.TotalCount = res.TotalCount;
            pageInfo.List = res.List.Select(e => new LivingTakeGoodsOrderVo {
                Id=e.Id,
                GoodsId=e.GoodsId,
                GoodsName = e.GoodsName,
                OrderStatus=e.OrderStatus,
                OrderStatusText=e.OrderStatusText,
                LiveanchorName=e.LiveanchorName,
                DealPrice=e.DealPrice,
                GoodsCount=e.GoodsCount,
                CreateDate=e.CreateDate
            }).ToList();
            return ResultData<FxPageInfo<LivingTakeGoodsOrderVo>>.Success().AddData("data",pageInfo);
        }
        /// <summary>
        /// 根据id获取订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId")]
        public async Task<ResultData<LivingTakeGoodsOrderVo>> GetByIdAsync(string id) {
            var res = await livingTakeGoodsOrderService.GetByIdAsync(id);
            LivingTakeGoodsOrderVo order = new LivingTakeGoodsOrderVo();
            order.Id= res.Id;
            order.GoodsId = res.GoodsId;
            order.GoodsName = res.GoodsName;
            order.OrderStatus = res.OrderStatus;
            order.LiveanchorName = res.LiveanchorName;
            order.DealPrice = res.DealPrice;
            order.GoodsCount = res.GoodsCount;
            return ResultData<LivingTakeGoodsOrderVo>.Success().AddData("data", order);
        }
        /// <summary>
        /// 获取订单状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("orderStatusList")]
        public ResultData<List<BaseIdAndNameVo<int>>> GetOrderStatusListAsync()
        {
            var nameList = livingTakeGoodsOrderService.GetOrderStatusList();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("statusList", result);
        }
    }
}
