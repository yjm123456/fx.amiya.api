using Fx.Amiya.Background.Api.Vo.IndicatorOrderData;
using Fx.Amiya.Dto.IndicatorOrderData;
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
    /// 运营指标派单数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class IndicatorOrderDataController : ControllerBase
    {
        private IIndicatorOrderDataService indicatorOrderDataService;

        public IndicatorOrderDataController(IIndicatorOrderDataService indicatorOrderDataService)
        {
            this.indicatorOrderDataService = indicatorOrderDataService;
        }

        /// <summary>
        /// 获取指标派单数据
        /// </summary>
        /// <param name="indicatorId">指标id</param>
        /// <param name="hospitaiId">医院id</param>
        /// <returns></returns>
        [HttpGet("getSendOrderInfo")]
        public async Task<ResultData<IndicatorOrderDataVo>> GetSendOrderInfo(string indicatorId,int hospitaiId){
            var orderData =await indicatorOrderDataService.GetInfoByIndicatorIdAndHospitalId(indicatorId, hospitaiId);
            if (orderData == null) {
                return ResultData<IndicatorOrderDataVo>.Success().AddData("sendOrderData",new IndicatorOrderDataVo());
            } else {
                IndicatorOrderDataVo indicatorOrderDataVo = new IndicatorOrderDataVo();
                indicatorOrderDataVo.HospitalId = orderData.HospitalId;
                indicatorOrderDataVo.IndicatorId = orderData.IndicatorId;
                indicatorOrderDataVo.AllSendorderCount = orderData.AllSendorderCount;
                indicatorOrderDataVo.LocalSendorderCount = orderData.LocalSendorderCount;
                indicatorOrderDataVo.OtherPlaceSendorderCount = orderData.OtherPlaceSendorderCount;
                indicatorOrderDataVo.InvalidSendorderCount = orderData.InvalidSendorderCount;
                indicatorOrderDataVo.EpidemicCount = orderData.EpidemicCount;
                indicatorOrderDataVo.OtherQuestion = orderData.OtherQuestion;
                return ResultData<IndicatorOrderDataVo>.Success().AddData("sendOrderData", indicatorOrderDataVo);
            }
        }
        /// <summary>
        /// 添加修改指标派单数据
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> Add(AddIndicatorOrderDataVo add) {
            AddIndicatorOrderDataDto addDto = new AddIndicatorOrderDataDto();
            addDto.HospitalId = add.HospitalId;
            addDto.IndicatorId = add.IndicatorId;
            addDto.AllSendorderCount = add.AllSendorderCount;
            addDto.LocalSendorderCount = add.LocalSendorderCount;
            addDto.OtherPlaceSendorderCount = add.OtherPlaceSendorderCount;
            addDto.InvalidSendorderCount = add.InvalidSendorderCount;
            addDto.EpidemicCount = add.EpidemicCount;
            addDto.OtherQuestion = add.OtherQuestion;
            await indicatorOrderDataService.AddAsync(addDto);
            return ResultData.Success();
        }
    }
}
