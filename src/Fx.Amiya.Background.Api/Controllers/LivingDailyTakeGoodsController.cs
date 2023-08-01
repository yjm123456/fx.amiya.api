using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Input;
using Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Output;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
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
    /// 直播间带货数据数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LivingDailyTakeGoodsController : ControllerBase
    {
        private ILivingDailyTakeGoodsService _LivingDailyTakeGoodsService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="LivingDailyTakeGoodsService"></param>
        public LivingDailyTakeGoodsController(ILivingDailyTakeGoodsService LivingDailyTakeGoodsService,

            IHttpContextAccessor httpContextAccessor)
        {
            _LivingDailyTakeGoodsService = LivingDailyTakeGoodsService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取直播间带货数据信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<LivingDailyTakeGoodsVo>>> GetListWithPageAsync([FromQuery] QueryLivingDailyTakeGoodsVo query)
        {
            try
            {
                QueryLivingDailyTakeGoodsDto queryLivingDailyTakeGoodsDto = new QueryLivingDailyTakeGoodsDto();
                queryLivingDailyTakeGoodsDto.PageNum = query.PageNum;
                queryLivingDailyTakeGoodsDto.PageSize = query.PageSize;
                queryLivingDailyTakeGoodsDto.StartDate = query.StartDate;
                queryLivingDailyTakeGoodsDto.EndDate = query.EndDate;
                queryLivingDailyTakeGoodsDto.KeyWord = query.KeyWord;
                queryLivingDailyTakeGoodsDto.BrandId = query.BrandId;
                queryLivingDailyTakeGoodsDto.CategoryId = query.CategoryId;
                queryLivingDailyTakeGoodsDto.ItemDetailsId = query.ItemDetailsId;
                queryLivingDailyTakeGoodsDto.CreateBy = query.CreateBy;
                queryLivingDailyTakeGoodsDto.Valid = query.Valid;
                var q = await _LivingDailyTakeGoodsService.GetListWithPageAsync(queryLivingDailyTakeGoodsDto);

                var LivingDailyTakeGoods = from d in q.List
                                           select new LivingDailyTakeGoodsVo
                                           {
                                               Id = d.Id,
                                               CreateDate = d.CreateDate,
                                               CreatBy = d.CreatBy,
                                               CreateByEmpName = d.CreateByEmpName,
                                               UpdateDate = d.UpdateDate,
                                               Valid = d.Valid,
                                               DeleteDate = d.DeleteDate,
                                               TakeGoodsDate = d.TakeGoodsDate,
                                               BrandName = d.BrandName,
                                               CategoryName = d.CategoryName,
                                               ItemDetailsName = d.ItemDetailsName,
                                               ContentPlatFormName = d.ContentPlatFormName,
                                               LiveAnchorName = d.LiveAnchorName,
                                               ItemName = d.ItemName,
                                               SinglePrice = d.SinglePrice,
                                               TakeGoodsQuantity = d.TakeGoodsQuantity,
                                               TotalPrice = d.TotalPrice,
                                               TakeGoodsTypeText = d.TakeGoodsTypeText,
                                               Remark = d.Remark,
                                           };

                FxPageInfo<LivingDailyTakeGoodsVo> LivingDailyTakeGoodsPageInfo = new FxPageInfo<LivingDailyTakeGoodsVo>();
                LivingDailyTakeGoodsPageInfo.TotalCount = q.TotalCount;
                LivingDailyTakeGoodsPageInfo.List = LivingDailyTakeGoods;

                return ResultData<FxPageInfo<LivingDailyTakeGoodsVo>>.Success().AddData("LivingDailyTakeGoodsInfo", LivingDailyTakeGoodsPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LivingDailyTakeGoodsVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加直播间带货数据信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ResultData> AddAsync(LivingDailyTakeGoodsAddVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                LivingDailyTakeGoodsAddDto addDto = new LivingDailyTakeGoodsAddDto();

                addDto.CreatBy = employeeId;
                addDto.BrandId = addVo.BrandId;
                addDto.CategoryId = addVo.CategoryId;
                addDto.ItemDetailsId = addVo.ItemDetailsId;
                addDto.TakeGoodsDate = addVo.TakeGoodsDate;
                addDto.ContentPlatFormId = addVo.ContentPlatFormId;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.ItemId = addVo.ItemId;
                addDto.SinglePrice = addVo.SinglePrice;
                addDto.TakeGoodsQuantity = addVo.TakeGoodsQuantity;
                addDto.TotalPrice = addVo.TotalPrice;
                addDto.TakeGoodsType = addVo.TakeGoodsType;
                addDto.Remark = addVo.Remark;
                await _LivingDailyTakeGoodsService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据直播间带货数据编号获取直播间带货数据信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<LivingDailyTakeGoodsVo>> GetByIdAsync(string id)
        {
            try
            {
                var LivingDailyTakeGoods = await _LivingDailyTakeGoodsService.GetByIdAsync(id);
                LivingDailyTakeGoodsVo LivingDailyTakeGoodsVo = new LivingDailyTakeGoodsVo();
                LivingDailyTakeGoodsVo.Id = LivingDailyTakeGoods.Id;
                LivingDailyTakeGoodsVo.CreatBy = LivingDailyTakeGoods.CreatBy;
                LivingDailyTakeGoodsVo.TakeGoodsDate = LivingDailyTakeGoods.TakeGoodsDate;
                LivingDailyTakeGoodsVo.BrandId = LivingDailyTakeGoods.BrandId;
                LivingDailyTakeGoodsVo.CategoryId = LivingDailyTakeGoods.CategoryId;
                LivingDailyTakeGoodsVo.ItemDetailsId = LivingDailyTakeGoods.ItemDetailsId;
                LivingDailyTakeGoodsVo.ContentPlatFormId = LivingDailyTakeGoods.ContentPlatFormId;
                LivingDailyTakeGoodsVo.LiveAnchorId = LivingDailyTakeGoods.LiveAnchorId;
                LivingDailyTakeGoodsVo.ItemId = LivingDailyTakeGoods.ItemId;
                LivingDailyTakeGoodsVo.SinglePrice = LivingDailyTakeGoods.SinglePrice;
                LivingDailyTakeGoodsVo.TakeGoodsQuantity = LivingDailyTakeGoods.TakeGoodsQuantity;
                LivingDailyTakeGoodsVo.TotalPrice = LivingDailyTakeGoods.TotalPrice;
                LivingDailyTakeGoodsVo.TakeGoodsType = LivingDailyTakeGoods.TakeGoodsType;
                LivingDailyTakeGoodsVo.Remark = LivingDailyTakeGoods.Remark;

                LivingDailyTakeGoodsVo.CreateDate = LivingDailyTakeGoods.CreateDate;
                LivingDailyTakeGoodsVo.Valid = LivingDailyTakeGoods.Valid;
                return ResultData<LivingDailyTakeGoodsVo>.Success().AddData("LivingDailyTakeGoodsInfo", LivingDailyTakeGoodsVo);
            }
            catch (Exception ex)
            {
                return ResultData<LivingDailyTakeGoodsVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改直播间带货数据信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(LivingDailyTakeGoodsUpdateVo updateVo)
        {
            try
            {
                LivingDailyTakeGoodsUpdateDto updateDto = new LivingDailyTakeGoodsUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.BrandId = updateVo.BrandId;
                updateDto.TakeGoodsDate = updateVo.TakeGoodsDate;
                updateDto.CategoryId = updateVo.CategoryId;
                updateDto.ItemDetailsId = updateVo.ItemDetailsId;
                updateDto.ContentPlatFormId = updateVo.ContentPlatFormId;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.ItemId = updateVo.ItemId;
                updateDto.SinglePrice = updateVo.SinglePrice;
                updateDto.TakeGoodsQuantity = updateVo.TakeGoodsQuantity;
                updateDto.TotalPrice = updateVo.TotalPrice;
                updateDto.TakeGoodsType = updateVo.TakeGoodsType;
                updateDto.Remark = updateVo.Remark;
                await _LivingDailyTakeGoodsService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除直播间带货数据信息(软删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _LivingDailyTakeGoodsService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取带货商品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTakeGoodsTypeText")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetTakeGoodsTypeTextAsync()
        {
            var result = from d in await _LivingDailyTakeGoodsService.GetTakeGoodsTypeAsync()
                         select new BaseIdAndNameVo
                         {
                             Id = d.Key,
                             Name = d.Value
                         };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("takeGoodsTypeText", result.ToList());
        }

    }
}
