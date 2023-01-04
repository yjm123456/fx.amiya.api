using Fx.Amiya.Background.Api.Vo.Address;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
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
    /// 收货地址
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AddressController : ControllerBase
    {
        private IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        /// <summary>
        /// 获取收货地址列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<AddressVo>>> GetListByCustomerIdAsync(string customerId)
        {
            try
            {
                var address = from d in await addressService.GetListByCustomerIdAsync(customerId)
                              select new AddressVo
                              {
                                  Id = d.Id,
                                  Address = d.Province + d.City + d.District + d.Other,
                                  ReceiveName=d.Contact,
                                  ReceivePhone=d.Phone
                              };
                return ResultData<List<AddressVo>>.Success().AddData("addressList", address.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AddressVo>>.Fail(ex.Message);
            }
        }

    }
}
