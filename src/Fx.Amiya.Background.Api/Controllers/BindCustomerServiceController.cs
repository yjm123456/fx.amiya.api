using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.BindCustomerService;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class BindCustomerServiceController : ControllerBase
    {
        private IBindCustomerServiceService bindCustomerServiceService;
        private IOrderService _orderService;
        private IContentPlateFormOrderService _contentPlatFormOrderService;
        private IHttpContextAccessor httpContextAccessor;
        public BindCustomerServiceController(IBindCustomerServiceService bindCustomerServiceService,
            IOrderService orderService,
            IContentPlateFormOrderService contentPlatFormOrderService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.bindCustomerServiceService = bindCustomerServiceService;
            this.httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
            _contentPlatFormOrderService = contentPlatFormOrderService;
        }

        /// <summary>
        /// 根据手机号筛选合适的客户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]

        public async Task<List<string>> GetPhone(string phone)
        {
            var result = await bindCustomerServiceService.GetEmployeePhoneByPhone(phone);
            return result;
        }


        /// <summary>
        ///绑定客服
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddBindCustomerServiceVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddBindCustomerServiceDto addDto = new AddBindCustomerServiceDto();
            addDto.CustomerServiceId = addVo.CustomerServiceId;
            List<string> orderIds = new List<string>();
            foreach (var item in addVo.OrderIdList)
            {
                orderIds.Add(item);
            }
            UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
            updateOrderBelongEmpIdDto.OrderId = orderIds;
            updateOrderBelongEmpIdDto.BelongEmpId = addVo.CustomerServiceId;
            await _orderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
            addDto.OrderIdList = orderIds;
            await bindCustomerServiceService.AddAsync(addDto, employeeId);
            return ResultData.Success();
        }


        /// <summary>
        /// 下单平台修改绑定客服
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("OrderListBindCustomerService")]
        public async Task<ResultData> OrderListBindCustomerUpdateAsync(UpdateBindCustomerServiceVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            UpdateBindCustomerServiceDto updateDto = new UpdateBindCustomerServiceDto();
            updateDto.CustomerServiceId = updateVo.CustomerServiceId;
            updateDto.EncryptPhoneList = updateVo.EncryptPhoneList;
            await bindCustomerServiceService.UpdateAsync(updateDto, employeeId);

            foreach (var x in updateVo.EncryptPhoneList)
            {
                //(todo;)
                var orderList = await _orderService.GetListByEncryptPhoneAsync(x, 1, 9999);
                var orderIdList = orderList.List.Select(x => x.Id).ToList();
                UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                updateOrderBelongEmpIdDto.OrderId = orderIdList;
                updateOrderBelongEmpIdDto.BelongEmpId = updateVo.CustomerServiceId;
                await _orderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
            }
            return ResultData.Success();
        }
        /// <summary>
        /// 内容平台修改绑定客服
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("ContentPlatFormOrderListBindCustomerService")]
        public async Task<ResultData> ContentPlatFormOrderListBindCustomerUpdateAsync(UpdateBindCustomerServiceVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            UpdateBindCustomerServiceDto updateDto = new UpdateBindCustomerServiceDto();
            updateDto.CustomerServiceId = updateVo.CustomerServiceId;
            updateDto.EncryptPhoneList = updateVo.EncryptPhoneList;
            await bindCustomerServiceService.UpdateAsync(updateDto, employeeId);

            foreach (var x in updateVo.EncryptPhoneList)
            {
                //(todo;)
                var orderList = await _contentPlatFormOrderService.GetListByEncryptPhoneAsync(x, 1, 9999);
                var orderIdList = orderList.List.Select(x => x.Id).ToList();
                UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                updateOrderBelongEmpIdDto.OrderId = orderIdList;
                updateOrderBelongEmpIdDto.BelongEmpId = updateVo.CustomerServiceId;
                await _contentPlatFormOrderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
            }
            return ResultData.Success();
        }


    }
}