using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.OrderCheckPicture;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class OrderCheckPictureService : IOrderCheckPictureService
    {
        private IDalOrderCheckPicture dalOrderCheckPicture;
        public IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;

        public OrderCheckPictureService(IDalOrderCheckPicture dalOrderCheckPicture, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService)
        {
            this.dalOrderCheckPicture = dalOrderCheckPicture;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
        }



        public async Task<FxPageInfo<OrderCheckPictureDto>> GetListWithPageAsync(string orderId, int OrderFrom, int pageNum, int pageSize)
        {
            try
            {
                List<string> OrderIds = new List<string>();
                if(OrderFrom==2)
                {
                    var orderDealInfo = await contentPlatFormOrderDealInfoService.GetByOrderIdAsync(orderId);
                    foreach(var x in orderDealInfo)
                    {
                        OrderIds.Add(x.Id);
                    }
                }
                else
                {
                    OrderIds.Add(orderId);
                }
                var orderCheckPicture = from d in dalOrderCheckPicture.GetAll()
                                        where (OrderIds.Count == 0 || OrderIds.Contains(d.OrderId))
                                        &&(OrderFrom == 0 || d.OrderFrom==OrderFrom)
                                        select new OrderCheckPictureDto
                                        {
                                            Id = d.Id,
                                            OrderFrom = d.OrderFrom,
                                            OrderId = d.OrderId,
                                            PictureUrl = d.PictureUrl,
                                        };

                FxPageInfo<OrderCheckPictureDto> orderCheckPicturePageInfo = new FxPageInfo<OrderCheckPictureDto>();
                orderCheckPicturePageInfo.TotalCount = await orderCheckPicture.CountAsync();
                orderCheckPicturePageInfo.List = await orderCheckPicture.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return orderCheckPicturePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<OrderCheckPictureDto>> GetListAsync(string orderId)
        {
            try
            {
                var orderCheckPicture = from d in dalOrderCheckPicture.GetAll()
                                        where orderId == null || d.OrderId.Contains(orderId)
                                        select new OrderCheckPictureDto
                                        {
                                            Id = d.Id,
                                            OrderFrom = d.OrderFrom,
                                            OrderId = d.OrderId,
                                            PictureUrl = d.PictureUrl,
                                        };

                List<OrderCheckPictureDto> orderCheckPicturePageInfo = new List<OrderCheckPictureDto>();
                orderCheckPicturePageInfo = await orderCheckPicture.ToListAsync();

                return orderCheckPicturePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(AddOrderCheckPictureDto addDto)
        {
            try
            {
                OrderCheckPicture orderCheckPicture = new OrderCheckPicture();
                orderCheckPicture.Id = Guid.NewGuid().ToString();
                orderCheckPicture.OrderFrom = addDto.OrderFrom;
                orderCheckPicture.OrderId = addDto.OrderId;
                orderCheckPicture.PictureUrl = addDto.PictureUrl;

                await dalOrderCheckPicture.AddAsync(orderCheckPicture, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<OrderCheckPictureDto> GetByIdAsync(string id)
        {
            try
            {
                var orderCheckPicture = await dalOrderCheckPicture.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (orderCheckPicture == null)
                {
                    return new OrderCheckPictureDto()
                    {
                        Id = "",
                        OrderId = "",
                        PictureUrl = "",
                        OrderFrom = 0
                    };
                }

                OrderCheckPictureDto orderCheckPictureDto = new OrderCheckPictureDto();
                orderCheckPictureDto.Id = orderCheckPicture.Id;
                orderCheckPictureDto.OrderFrom = orderCheckPicture.OrderFrom;
                orderCheckPictureDto.OrderId = orderCheckPicture.OrderId;
                orderCheckPictureDto.PictureUrl = orderCheckPicture.PictureUrl;

                return orderCheckPictureDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var orderCheckPicture = await dalOrderCheckPicture.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (orderCheckPicture == null)
                    throw new Exception("客户图片编号错误");

                await dalOrderCheckPicture.DeleteAsync(orderCheckPicture, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task DeleteByOrderIdAsync(string orderId)
        {
            try
            {
                var orderCheckPicture = await dalOrderCheckPicture.GetAll().Where(e => e.OrderId == orderId).ToListAsync();

                if (orderCheckPicture != null)
                {
                    foreach (var x in orderCheckPicture)
                    {
                        await dalOrderCheckPicture.DeleteAsync(x, true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
