using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.LivingTakeGoodsOrder;
using Fx.Amiya.Dto.LivingTakeGoodsOrder.Input;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LivingTakeGoodsOrderService : ILivingTakeGoodsOrderService
    {
        private readonly IDalLivingTakeGoodsOrder dalLivingTakeGoodsOrder;
        private readonly IDalItemInfo dalItemInfo;
        public LivingTakeGoodsOrderService(IDalLivingTakeGoodsOrder dalLivingTakeGoodsOrder, IDalItemInfo dalItemInfo)
        {
            this.dalLivingTakeGoodsOrder = dalLivingTakeGoodsOrder;
            this.dalItemInfo = dalItemInfo;
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddLivingTakeGoodsOrderAsync(AddLivingTakeGoodsOrderDto addDto)
        {
            var existFlag = dalLivingTakeGoodsOrder.GetAll().Where(e => e.Id == addDto.Id).Any();
            if (existFlag)
                throw new Exception("该订单号已存在");
            var goodsExistFlag = dalItemInfo.GetAll().Where(e => e.OtherAppItemId.Contains(addDto.GoodsId)).Any();
            if (!goodsExistFlag)
                throw new Exception($"带货商品列表中不包含编号为:{addDto.GoodsId}的商品,请先完善带货商品列表再添加");
            LivingTakeGoodsOrder order = new LivingTakeGoodsOrder();
            order.Id = addDto.Id;
            order.GoodsId = addDto.GoodsId;
            order.GoodsName = addDto.GoodsName;
            order.OrderStatus = addDto.OrderStatus;
            order.LiveanchorName = addDto.LiveanchorName;
            order.DealPrice = addDto.DealPrice;
            order.GoodsCount = addDto.GoodsCount;
            order.CreateDate = DateTime.Now;
            order.Valid = true;
            await dalLivingTakeGoodsOrder.AddAsync(order, true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var order = dalLivingTakeGoodsOrder.GetAll().Where(e => e.Id == id).FirstOrDefault();
            if (order == null)
                throw new Exception("订单号错误");
            await dalLivingTakeGoodsOrder.DeleteAsync(order, true);
        }
        /// <summary>
        /// 根据编号获取订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LivingTakeGoodsOrderDto> GetByIdAsync(string id)
        {
            var order = await dalLivingTakeGoodsOrder.GetAll().Where(e => e.Id == id).FirstOrDefaultAsync();
            if (order == null)
                throw new Exception("订单号错误");
            LivingTakeGoodsOrderDto orderDto = new LivingTakeGoodsOrderDto();
            orderDto.Id = order.Id;
            orderDto.GoodsId = order.GoodsId;
            orderDto.GoodsName = order.GoodsName;
            orderDto.OrderStatus = order.OrderStatus;
            orderDto.OrderStatusText = ServiceClass.LivingTakeGoodsOrderStatusText(order.OrderStatus);
            orderDto.LiveanchorName = order.LiveanchorName;
            orderDto.DealPrice = order.DealPrice;
            orderDto.GoodsCount = order.GoodsCount;
            return orderDto;
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<LivingTakeGoodsOrderDto>> GetListByPageAsync(QueryLivingTakeGoodsOrderByPageDto query)
        {
            var orders = dalLivingTakeGoodsOrder.GetAll()
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.Id.Contains(query.KeyWord) || e.GoodsId.Contains(query.KeyWord) || e.GoodsName.Contains(query.KeyWord) || e.LiveanchorName.Contains(query.KeyWord))
                .Where(e => !query.StartDate.HasValue || e.CreateDate >= query.StartDate.Value)
                .Where(e => !query.EndDate.HasValue || e.CreateDate < query.EndDate.Value.AddDays(1))
                .Select(e => new LivingTakeGoodsOrderDto
                {
                    Id = e.Id,
                    GoodsId = e.GoodsId,
                    GoodsName = e.GoodsName,
                    OrderStatus = e.OrderStatus,
                    OrderStatusText = ServiceClass.LivingTakeGoodsOrderStatusText(e.OrderStatus),
                    LiveanchorName = e.LiveanchorName,
                    DealPrice = e.DealPrice,
                    GoodsCount = e.GoodsCount,
                    CreateDate=e.CreateDate
                });
            FxPageInfo<LivingTakeGoodsOrderDto> pageInfo = new FxPageInfo<LivingTakeGoodsOrderDto>();
            pageInfo.TotalCount = orders.Count();
            pageInfo.List = await orders.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return pageInfo;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateLivingTakeGoodsOrderDto updateDto)
        {
            var order = await dalLivingTakeGoodsOrder.GetAll().Where(e => e.Id == updateDto.Id).FirstOrDefaultAsync();
            if (order == null)
                throw new Exception("订单编号错误");
            var goodsExistFlag = dalItemInfo.GetAll().Where(e => e.OtherAppItemId.Contains(updateDto.GoodsId)).Any();
            if (goodsExistFlag)
                throw new Exception($"带货商品列表中不包含编号为:{updateDto.GoodsId}的商品,请先完善带货商品列表再添加");
            order.GoodsId = updateDto.GoodsId;
            order.GoodsName = updateDto.GoodsName;
            order.OrderStatus = updateDto.OrderStatus;
            order.LiveanchorName = updateDto.LiveanchorName;
            order.DealPrice = updateDto.DealPrice;
            order.GoodsCount = updateDto.GoodsCount;
            order.UpdateDate = DateTime.Now;
            await dalLivingTakeGoodsOrder.UpdateAsync(order, true);
        }
        /// <summary>
        /// 获取订单状态列表
        /// </summary>
        /// <returns></returns>
        public List<BaseIdAndNameDto<int>> GetOrderStatusList()
        {
            var status = Enum.GetValues(typeof(LivingTakeGoodsOrderStatus));
            List<BaseIdAndNameDto<int>> emergencyLevelList = new List<BaseIdAndNameDto<int>>();
            foreach (var statu in status)
            {
                BaseIdAndNameDto<int> item = new BaseIdAndNameDto<int>();
                item.Id = Convert.ToInt32(statu);
                item.Name = ServiceClass.LivingTakeGoodsOrderStatusText(item.Id);
                emergencyLevelList.Add(item);
            }
            return emergencyLevelList;
        }
    }
}
