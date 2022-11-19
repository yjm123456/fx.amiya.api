using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 物流公司板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ExpressManageController : ControllerBase
    {
        private IExpressManageService expressService;
        private IOrderService _orderService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="expressService"></param>
        public ExpressManageController(IExpressManageService expressService, IOrderService orderService)
        {
            this.expressService = expressService;
            _orderService = orderService;
        }


        /// <summary>
        /// 获取物流公司信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ExpressVo>>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await expressService.GetListWithPageAsync(keyword, pageNum, pageSize);

                var express = from d in q.List
                              select new ExpressVo
                              {
                                  Id = d.Id,
                                  ExpressCode = d.ExpressCode,
                                  ExpressName = d.ExpressName,
                                  Valid = d.Valid
                              };

                FxPageInfo<ExpressVo> expressPageInfo = new FxPageInfo<ExpressVo>();
                expressPageInfo.TotalCount = q.TotalCount;
                expressPageInfo.List = express;

                return ResultData<FxPageInfo<ExpressVo>>.Success().AddData("expressInfo", expressPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ExpressVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取物流公司id和名称（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getExpressList")]
        public async Task<ResultData<List<ExpressIdAndNameVo>>> getExpressList()
        {
            try
            {
                var q = await expressService.GetIdAndNames();

                var express = from d in q
                              select new ExpressIdAndNameVo
                              {
                                  Id = d.Id,
                                  ExpressName = d.ExpressName
                              };

                return ResultData<List<ExpressIdAndNameVo>>.Success().AddData("ExpressList", express.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<ExpressIdAndNameVo>>.Fail().AddData("ExpressList", new List<ExpressIdAndNameVo>());
            }
        }


        /// <summary>
        /// 添加物流公司信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddExpressVo addVo)
        {
            try
            {
                AddExpressDto addDto = new AddExpressDto();
                addDto.ExpressCode = addVo.ExpressCode;
                addDto.ExpressName = addVo.ExpressName;
                addDto.Valid = addVo.Valid;

                await expressService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据物流公司编号获取物流公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ExpressVo>> GetByIdAsync(string id)
        {
            try
            {
                var express = await expressService.GetByIdAsync(id);
                ExpressVo expressVo = new ExpressVo();
                expressVo.Id = express.Id;
                expressVo.ExpressCode = express.ExpressCode;
                expressVo.ExpressName = express.ExpressName;
                expressVo.Valid = express.Valid;

                return ResultData<ExpressVo>.Success().AddData("expressInfo", expressVo);
            }
            catch (Exception ex)
            {
                return ResultData<ExpressVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改物流公司信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateExpressVo updateVo)
        {
            try
            {
                UpdateExpressDto updateDto = new UpdateExpressDto();
                updateDto.Id = updateVo.Id;
                updateDto.ExpressName = updateVo.ExpressName;
                updateDto.ExpressCode = updateVo.ExpressCode;
                updateDto.Valid = updateVo.Valid;
                await expressService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除物流公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await expressService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据条件获取快递信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("giftExpressInfo")]
        public async Task<ResultData<KuaiDi100ExpressInfoVo>> GetGiftExpressInfoAsync([FromQuery] GetExpressInfoVo input)
        {
            var orderExpressInfoDto = await _orderService.GetExpressInfo(input.ReceiverPhone, input.CourierNumber, input.ExpressId);
            KuaiDi100ExpressInfoVo orderExpressInfoVo = new KuaiDi100ExpressInfoVo();
            var orderExpressInfoDetails = from d in orderExpressInfoDto.data
                                          select new KuaiDi100ExpressDetailsVo
                                          {
                                              time = d.time,
                                              content = d.context
                                          };
            orderExpressInfoVo.ExpressNo = orderExpressInfoDto.ExpressNo;
            orderExpressInfoVo.ExpressName = orderExpressInfoDto.ExpressName;
            orderExpressInfoVo.state = KuaiDi100Utils.GetExpressState(orderExpressInfoDto.state);
            orderExpressInfoVo.ExpressDetailList = orderExpressInfoDetails.ToList();
            return ResultData<KuaiDi100ExpressInfoVo>.Success().AddData("orderExpressInfoVo", orderExpressInfoVo);
        }
    }
}
