using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.SupplierItemDetails.Input;
using Fx.Amiya.Background.Api.Vo.SupplierItemDetails.Output;
using Fx.Amiya.Dto.SupplierItemDetails.Input;
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
    /// 供应商品项管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class SupplierItemDetailsController : ControllerBase
    {
        private ISupplierItemDetailsService _supplierItemDetailsService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="supplierItemDetailsService"></param>
        public SupplierItemDetailsController(ISupplierItemDetailsService supplierItemDetailsService,

            IHttpContextAccessor httpContextAccessor)
        {
            _supplierItemDetailsService = supplierItemDetailsService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取供应商品项管理信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<SupplierItemDetailsVo>>> GetListWithPageAsync([FromQuery] QuerySupplierItemDetailsVo query)
        {
            try
            {
                QuerySupplierItemDetailsDto querySupplierItemDetailsDto = new QuerySupplierItemDetailsDto();
                querySupplierItemDetailsDto.PageNum = query.PageNum;
                querySupplierItemDetailsDto.PageSize = query.PageSize;
                querySupplierItemDetailsDto.KeyWord = query.KeyWord;
                querySupplierItemDetailsDto.BrandId = query.BrandId;
                querySupplierItemDetailsDto.Valid = query.Valid;
                var q = await _supplierItemDetailsService.GetListWithPageAsync(querySupplierItemDetailsDto);

                var supplierItemDetails = from d in q.List
                                                 select new SupplierItemDetailsVo
                                                 {
                                                     Id = d.Id,
                                                     BrandId = d.BrandId,
                                                     BrandName = d.BrandName,
                                                     CreateDate = d.CreateDate,
                                                     ItemDetailsName = d.ItemDetailsName,
                                                     Valid = d.Valid,
                                                     DeleteDate = d.DeleteDate,
                                                 };

                FxPageInfo<SupplierItemDetailsVo> supplierItemDetailsPageInfo = new FxPageInfo<SupplierItemDetailsVo>();
                supplierItemDetailsPageInfo.TotalCount = q.TotalCount;
                supplierItemDetailsPageInfo.List = supplierItemDetails;

                return ResultData<FxPageInfo<SupplierItemDetailsVo>>.Success().AddData("supplierItemDetailsInfo", supplierItemDetailsPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<SupplierItemDetailsVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加供应商品项管理信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ResultData> AddAsync(SupplierItemDetailsAddVo addVo)
        {
            try
            {
                SupplierItemDetailsAddDto addDto = new SupplierItemDetailsAddDto();
                addDto.BrandId = addVo.BrandId;
                addDto.ItemDetailsName = addVo.ItemDetailsName;
                await _supplierItemDetailsService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据供应商品项管理编号获取供应商品项管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<SupplierItemDetailsVo>> GetByIdAsync(string id)
        {
            try
            {
                var supplierItemDetails = await _supplierItemDetailsService.GetByIdAsync(id);
                SupplierItemDetailsVo supplierItemDetailsVo = new SupplierItemDetailsVo();
                supplierItemDetailsVo.Id = supplierItemDetails.Id;
                supplierItemDetailsVo.ItemDetailsName = supplierItemDetails.ItemDetailsName;
                supplierItemDetailsVo.BrandId = supplierItemDetails.BrandId;
                supplierItemDetailsVo.CreateDate = supplierItemDetails.CreateDate;
                supplierItemDetailsVo.UpdateDate = supplierItemDetails.UpdateDate;
                supplierItemDetailsVo.DeleteDate = supplierItemDetails.DeleteDate;
                supplierItemDetailsVo.Valid = supplierItemDetails.Valid;
                return ResultData<SupplierItemDetailsVo>.Success().AddData("supplierItemDetailsInfo", supplierItemDetailsVo);
            }
            catch (Exception ex)
            {
                return ResultData<SupplierItemDetailsVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改供应商品项管理信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(SupplierItemDetailsUpdateVo updateVo)
        {
            try
            {
                SupplierItemDetailsUpdateDto updateDto = new SupplierItemDetailsUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.BrandId = updateVo.BrandId;
                updateDto.ItemDetailsName = updateVo.ItemDetailsName;
                await _supplierItemDetailsService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除供应商品项管理信息(软删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _supplierItemDetailsService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 根据供应商品牌id获取供应商品项
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <returns></returns>
        [HttpGet("getSupplierItemDetailsListByBrandId")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetOperatingConsultingNameListAsync(string brandId)
        {
            var result = from d in await _supplierItemDetailsService.GetValidByBrandIdAsync(brandId)
                         select new BaseIdAndNameVo
                         {
                             Id = d.Key,
                             Name = d.Value
                         };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("supplierItemDetailsList", result.ToList());
        }

    }
}
