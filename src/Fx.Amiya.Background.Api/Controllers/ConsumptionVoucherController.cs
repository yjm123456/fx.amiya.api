using Fx.Amiya.Background.Api.Vo.ConsumptionVoucher;
using Fx.Amiya.IService;
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
    /// 抵用券
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionVoucherController : ControllerBase
    {
        private readonly IConsumptionVoucherService consumptionVoucherService;

        public ConsumptionVoucherController(IConsumptionVoucherService consumptionVoucherService)
        {
            this.consumptionVoucherService = consumptionVoucherService;
        }

        /// <summary>
        /// 获取抵用券名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<ConsumptionVoucherVo>>> GetMemberRankNameListAsync()
        {
            var consumptionVoucherInfos = from d in await consumptionVoucherService.GetConsumptionVoucherkNameListAsync()
                                  select new ConsumptionVoucherVo
                                  {
                                      ConsumptionVoiucherId = d.Id,
                                      ConsumptionVoucherName = d.Name,
                                  };
            return ResultData<List<ConsumptionVoucherVo>>.Success().AddData("consumptionVoucherNames", consumptionVoucherInfos.ToList());
        }
    }
}
