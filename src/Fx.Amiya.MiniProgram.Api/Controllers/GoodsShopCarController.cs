using Fx.Amiya.Dto.GoodsShopCar;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.GoodsShopCar;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class GoodsShopCarController : ControllerBase
    {
        private IGoodsShopCarService goodsShopCarService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        public GoodsShopCarController(IGoodsShopCarService goodsShopCarService,
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage)
        {
            this.goodsShopCarService = goodsShopCarService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }

        /// <summary>
        /// 获取客户的购物车列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("goodsShopCarList")]
        public async Task<ResultData<FxPageInfo<GoodsShopCarVo>>> GetGoodsShopCarInfoListAsync(string keyword, int pageNum, int pageSize)
        {
            var token = _tokenReader.GetToken();
            var sesssionInfo = _sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;

            var q = await goodsShopCarService.GetListWithPageAsync(keyword, customerId, pageNum, pageSize);
            var goodsShopCarInfos = from d in q.List
                                    select new GoodsShopCarVo
                                    {
                                        Id = d.Id,
                                        CustomerId = d.CustomerId,
                                        GoodsId = d.GoodsId,
                                        GoodsName = d.GoodsName,
                                        GoodsPictureUrl=d.GoodsPictureUrl,
                                        Unit = d.Unit,
                                        Price = d.Price,
                                        InterGrationAccount = d.InterGrationAccount,
                                        ExchangeType = d.ExchangeType,
                                        Num = d.Num,
                                        City=d.City,
                                        CityId=d.CityId,
                                        Hospital=d.Hospital,
                                        HospitalId=d.HospitalId,
                                        Status = d.Status,
                                        UpdateDate = d.UpdateDate,
                                        CreateDate = d.CreateDate,
                                    };
            FxPageInfo<GoodsShopCarVo> goodsShopCarPageInfo = new FxPageInfo<GoodsShopCarVo>();
            goodsShopCarPageInfo.TotalCount = q.TotalCount;
            goodsShopCarPageInfo.List = goodsShopCarInfos;
            return ResultData<FxPageInfo<GoodsShopCarVo>>.Success().AddData("goodsShopCarInfos", goodsShopCarPageInfo);
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddGoodsShopCarVo addVo)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;

                AddGoodsShopCarDto addDto = new AddGoodsShopCarDto();
                addDto.CustomerId = customerId;
                addDto.GoodsId = addVo.GoodsId;
                addDto.Num = addVo.Num;
                addDto.CityId = addVo.CityId;
                addDto.HospitalId = addVo.HospitalId;

                await goodsShopCarService.AddAsync(addDto);
                return ResultData.Success();

            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改购物车
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateGoodsShopCarVo updateVo)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                UpdateGoodsShopCarDto updateDto = new UpdateGoodsShopCarDto();
                updateDto.Id = updateVo.Id;
                updateDto.CustomerId = customerId;
                updateDto.GoodsId = updateVo.GoodsId;
                updateDto.Num = updateVo.Num;
                updateDto.CityId = updateVo.CityId;
                updateDto.HospitalId = updateVo.HospitalId;

                await goodsShopCarService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 批量删除用户购物车
        /// </summary>
        /// <param name="idList">购物车id</param>
        /// <returns></returns>
        [HttpPut("deleteGoodsShopCar")]
        public async Task<ResultData> DeleteGoodsShopCarAsync(List<string>idList)
        {
            try
            {
                await goodsShopCarService.DeleteAsync(idList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
