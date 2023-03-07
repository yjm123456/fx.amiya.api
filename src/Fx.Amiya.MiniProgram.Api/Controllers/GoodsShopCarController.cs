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
        private IMemberCardHandleService memberCardHandleService;
        public GoodsShopCarController(IGoodsShopCarService goodsShopCarService,
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage, IMemberCardHandleService memberCardHandleService)
        {
            this.goodsShopCarService = goodsShopCarService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
            this.memberCardHandleService = memberCardHandleService;
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

            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
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
                                        InterGrationPrice=d.InterGrationPrice,
                                        ExchangeType = d.ExchangeType,
                                        Num = d.Num,
                                        City=d.City,
                                        CityId=d.CityId,
                                        SelectStandards=d.SelectStandards,
                                        Hospital=d.Hospital,
                                        HospitalId=d.HospitalId,
                                        Status = d.Status,
                                        UpdateDate = d.UpdateDate,
                                        CreateDate = d.CreateDate,
                                        IsMaterial=d.IsMaterial,
                                        HospitalSalePrice=d.HospitalSalePrice,
                                        IsMember=d.GoodsMemberRankPriceList.Find(e=>e.MemberRankId==member.MemberRankId)==null?false:true,
                                        MemberPrice= d.GoodsMemberRankPriceList.Find(e=>e.MemberRankId==member.MemberRankId) ==null?d.Price.Value: d.GoodsMemberRankPriceList.Find(e => e.MemberRankId == member.MemberRankId).Price,
                                        VoucherIdList=d.VoucherIdList                                       
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
                addDto.SelectStandard = addVo.SelectStandard;
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
                updateDto.SelectStandard = updateVo.SelectStandards;
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
        public async Task<ResultData> DeleteGoodsShopCarAsync(DeleteGoodsShopCarVo deleteGoodsShopCarVo)
        {
            try
            {
                await goodsShopCarService.DeleteAsync(deleteGoodsShopCarVo.idList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
