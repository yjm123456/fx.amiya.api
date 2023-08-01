using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.SupplierCategory.Input;
using Fx.Amiya.Background.Api.Vo.SupplierCategory.Output;
using Fx.Amiya.Dto.SupplierCategory.Input;
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
    /// 供应商品类管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class SupplierCategoryController : ControllerBase
    {
        private ISupplierCategoryService _supplierCategoryService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="supplierCategoryService"></param>
        public SupplierCategoryController(ISupplierCategoryService supplierCategoryService,

            IHttpContextAccessor httpContextAccessor)
        {
            _supplierCategoryService = supplierCategoryService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取供应商品类管理信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<SupplierCategoryVo>>> GetListWithPageAsync([FromQuery] QuerySupplierCategoryVo query)
        {
            try
            {
                QuerySupplierCategoryDto querySupplierCategoryDto = new QuerySupplierCategoryDto();
                querySupplierCategoryDto.PageNum = query.PageNum;
                querySupplierCategoryDto.PageSize = query.PageSize;
                querySupplierCategoryDto.KeyWord = query.KeyWord;
                querySupplierCategoryDto.Valid = query.Valid;
                var q = await _supplierCategoryService.GetListWithPageAsync(querySupplierCategoryDto);

                var supplierCategory = from d in q.List
                                                 select new SupplierCategoryVo
                                                 {
                                                     Id = d.Id,
                                                     CreateDate = d.CreateDate,
                                                     CategoryName = d.CategoryName,
                                                     Valid = d.Valid,
                                                     DeleteDate = d.DeleteDate,
                                                 };

                FxPageInfo<SupplierCategoryVo> supplierCategoryPageInfo = new FxPageInfo<SupplierCategoryVo>();
                supplierCategoryPageInfo.TotalCount = q.TotalCount;
                supplierCategoryPageInfo.List = supplierCategory;

                return ResultData<FxPageInfo<SupplierCategoryVo>>.Success().AddData("supplierCategoryInfo", supplierCategoryPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<SupplierCategoryVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加供应商品类管理信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ResultData> AddAsync(SupplierCategoryAddVo addVo)
        {
            try
            {
                SupplierCategoryAddDto addDto = new SupplierCategoryAddDto();
                addDto.CategoryName = addVo.CategoryName;
                await _supplierCategoryService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据供应商品类管理编号获取供应商品类管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<SupplierCategoryVo>> GetByIdAsync(string id)
        {
            try
            {
                var supplierCategory = await _supplierCategoryService.GetByIdAsync(id);
                SupplierCategoryVo supplierCategoryVo = new SupplierCategoryVo();
                supplierCategoryVo.Id = supplierCategory.Id;
                supplierCategoryVo.CategoryName = supplierCategory.CategoryName;
                supplierCategoryVo.CreateDate = supplierCategory.CreateDate;
                supplierCategoryVo.UpdateDate = supplierCategory.UpdateDate;
                supplierCategoryVo.DeleteDate = supplierCategory.DeleteDate;
                supplierCategoryVo.Valid = supplierCategory.Valid;
                return ResultData<SupplierCategoryVo>.Success().AddData("supplierCategoryInfo", supplierCategoryVo);
            }
            catch (Exception ex)
            {
                return ResultData<SupplierCategoryVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改供应商品类管理信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(SupplierCategoryUpdateVo updateVo)
        {
            try
            {
                SupplierCategoryUpdateDto updateDto = new SupplierCategoryUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.CategoryName = updateVo.CategoryName;
                await _supplierCategoryService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除供应商品类管理信息(软删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _supplierCategoryService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取供应商品类
        /// </summary>
        /// <returns></returns>
        [HttpGet("getSupplierCategoryList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetOperatingConsultingNameListAsync()
        {
            var result = from d in await _supplierCategoryService.GetValidByBrandIdAsync()
                         select new BaseIdAndNameVo
                         {
                             Id = d.Key,
                             Name = d.Value
                         };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("supplierCategoryList", result.ToList());
        }

    }
}
