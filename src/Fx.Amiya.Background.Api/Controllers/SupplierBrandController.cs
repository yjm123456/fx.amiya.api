using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.SupplierBrand.Input;
using Fx.Amiya.Background.Api.Vo.SupplierBrand.OutPut;
using Fx.Amiya.Dto.SupplierBrand.Input;
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
    /// 供应商品牌管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class SupplierBrandController : ControllerBase
    {
        private ISupplierBrandService _supplierBrandService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="supplierBrandService"></param>
        public SupplierBrandController(ISupplierBrandService supplierBrandService,

            IHttpContextAccessor httpContextAccessor)
        {
            _supplierBrandService = supplierBrandService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取供应商品牌管理信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<SupplierBrandVo>>> GetListWithPageAsync([FromQuery] QuerySupplierBrandVo query)
        {
            try
            {
                QuerySupplierBrandDto querySupplierBrandDto = new QuerySupplierBrandDto();
                querySupplierBrandDto.PageNum = query.PageNum;
                querySupplierBrandDto.PageSize = query.PageSize;
                querySupplierBrandDto.KeyWord = query.KeyWord;
                querySupplierBrandDto.Valid = query.Valid;
                var q = await _supplierBrandService.GetListWithPageAsync(querySupplierBrandDto);

                var supplierBrand = from d in q.List
                                                 select new SupplierBrandVo
                                                 {
                                                     Id = d.Id,
                                                     BrandName = d.BrandName,
                                                     CreateDate = d.CreateDate,
                                                     Valid = d.Valid,
                                                     DeleteDate = d.DeleteDate,
                                                 };

                FxPageInfo<SupplierBrandVo> supplierBrandPageInfo = new FxPageInfo<SupplierBrandVo>();
                supplierBrandPageInfo.TotalCount = q.TotalCount;
                supplierBrandPageInfo.List = supplierBrand;

                return ResultData<FxPageInfo<SupplierBrandVo>>.Success().AddData("supplierBrandInfo", supplierBrandPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<SupplierBrandVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加供应商品牌管理信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ResultData> AddAsync(SupplierBrandAddVo addVo)
        {
            try
            {
                SupplierBrandAddDto addDto = new SupplierBrandAddDto();
                addDto.BrandName = addVo.BrandName;
                await _supplierBrandService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据供应商品牌管理编号获取供应商品牌管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<SupplierBrandVo>> GetByIdAsync(string id)
        {
            try
            {
                var supplierBrand = await _supplierBrandService.GetByIdAsync(id);
                SupplierBrandVo supplierBrandVo = new SupplierBrandVo();
                supplierBrandVo.Id = supplierBrand.Id;
                supplierBrandVo.BrandName = supplierBrand.BrandName;
                supplierBrandVo.CreateDate = supplierBrand.CreateDate;
                supplierBrandVo.UpdateDate = supplierBrand.UpdateDate;
                supplierBrandVo.DeleteDate = supplierBrand.DeleteDate;
                supplierBrandVo.Valid = supplierBrand.Valid;
                return ResultData<SupplierBrandVo>.Success().AddData("supplierBrandInfo", supplierBrandVo);
            }
            catch (Exception ex)
            {
                return ResultData<SupplierBrandVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改供应商品牌管理信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(SupplierBrandUpdateVo updateVo)
        {
            try
            {
                SupplierBrandUpdateDto updateDto = new SupplierBrandUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.BrandName = updateVo.BrandName;
                await _supplierBrandService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除供应商品牌管理信息(软删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _supplierBrandService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 根据供应商品牌id获取供应商品类
        /// </summary>
        /// <returns></returns>
        [HttpGet("getSupplierBrandList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetSupplierBrandListAsync()
        {
            var result = from d in await _supplierBrandService.GetSupplierBrandListAsync()
                         select new BaseIdAndNameVo
                         {
                             Id = d.Key,
                             Name = d.Value
                         };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("supplierBrandList", result.ToList());
        }
    }
}
