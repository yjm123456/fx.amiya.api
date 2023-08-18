using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OrderRemark;
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
    public class OrderRemarkService : IOrderRemarkService
    {
        private IDalOrderRemark dalOrderRemark;
        private IAmiyaEmployeeService amiyaEmployeeService;
        private IHospitalEmployeeService hospitalEmployeeService;


        public OrderRemarkService(IDalOrderRemark dalOrderRemark,
            IAmiyaEmployeeService amiyaEmployeeService,
            IHospitalEmployeeService hospitalEmployeeService)
        {
            this.dalOrderRemark = dalOrderRemark;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.hospitalEmployeeService = hospitalEmployeeService;
        }


        /// <summary>
        /// 根据订单号获取订单备注
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="orderId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderRemarkDto>> GetListWithPageAsync(string orderId, int pageNum, int pageSize)
        {
            try
            {
                var orderRemark = from d in dalOrderRemark.GetAll()
                                           where  (d.OrderId == orderId)
                                           && d.Valid
                                           select new OrderRemarkDto
                                           {
                                               Id = d.Id,
                                               BelongAuthorize=d.BelongAuthorize,
                                               OrderId=d.OrderId,
                                               CreateBy=d.CreateBy,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               Valid = d.Valid,
                                               Remark=d.Remark,
                                               DeleteDate = d.DeleteDate
                                           };

                FxPageInfo<OrderRemarkDto> orderRemarkPageInfo = new FxPageInfo<OrderRemarkDto>();
                orderRemarkPageInfo.TotalCount = await orderRemark.CountAsync();
                orderRemarkPageInfo.List = await orderRemark.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                foreach (var x in orderRemarkPageInfo.List)
                {
                    if (x.BelongAuthorize ==(int) AuthorizeStatusEnum.InternalAuthorize)
                    {
                        var amiyaEmployeeInfo = await amiyaEmployeeService.GetByIdAsync(x.CreateBy);
                        x.Avatar = amiyaEmployeeInfo.Avatar;
                        x.EmployeeName = amiyaEmployeeInfo.Name;
                    }
                    else
                    {
                        var hospitalEmployeeInfo = await hospitalEmployeeService.GetByIdAsync(x.CreateBy);
                        x.Avatar = hospitalEmployeeInfo.Avatar;
                        x.EmployeeName = hospitalEmployeeInfo.Name;
                    }
                }
                return orderRemarkPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }





        public async Task AddAsync(AddOrderRemarkDto addDto)
        {
            try
            {
                OrderRemark orderRemark = new OrderRemark();
                orderRemark.Id = Guid.NewGuid().ToString();
                orderRemark.BelongAuthorize = addDto.BelongAuthorize;
                orderRemark.OrderId = addDto.OrderId;
                orderRemark.CreateBy = addDto.CreateBy;
                orderRemark.Remark = addDto.Remark;
                orderRemark.CreateDate = DateTime.Now;
                orderRemark.Valid = true;

                await dalOrderRemark.AddAsync(orderRemark, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<OrderRemarkDto> GetByIdAsync(string id)
        {
            try
            {
                var orderRemark = await dalOrderRemark.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (orderRemark == null)
                {
                    return new OrderRemarkDto();
                }

                OrderRemarkDto orderRemarkDto = new OrderRemarkDto();
                orderRemarkDto.Id = orderRemark.Id;
                orderRemarkDto.BelongAuthorize = orderRemark.BelongAuthorize;
                orderRemarkDto.OrderId = orderRemark.OrderId;
                orderRemarkDto.CreateBy = orderRemark.CreateBy;
                orderRemarkDto.Remark = orderRemark.Remark;
                orderRemarkDto.CreateDate = orderRemark.CreateDate;
                orderRemarkDto.UpdateDate = orderRemark.UpdateDate;
                orderRemarkDto.Valid = orderRemark.Valid;
                orderRemarkDto.DeleteDate = orderRemark.DeleteDate;
                return orderRemarkDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateOrderRemarkDto updateDto)
        {
            try
            {
                var orderRemark = await dalOrderRemark.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (orderRemark == null)
                {
                  throw new Exception("备注编号错误！");
                }

                OrderRemarkDto orderRemarkDto = new OrderRemarkDto();
                orderRemarkDto.BelongAuthorize = orderRemark.BelongAuthorize;
                orderRemarkDto.OrderId = orderRemark.OrderId;
                orderRemarkDto.CreateBy = orderRemark.CreateBy;
                orderRemarkDto.Remark = orderRemark.Remark;
                orderRemarkDto.UpdateDate = DateTime.Now;
                await dalOrderRemark.UpdateAsync(orderRemark, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var orderRemark = await dalOrderRemark.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (orderRemark == null)
                    throw new Exception("备注编号错误！");
                orderRemark.Valid = false;
                orderRemark.DeleteDate = DateTime.Now;
                await dalOrderRemark.UpdateAsync(orderRemark, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
