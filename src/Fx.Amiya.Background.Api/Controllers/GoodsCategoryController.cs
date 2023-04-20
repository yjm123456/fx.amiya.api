
using Fx.Amiya.Background.Api.Vo.GoodsCategory;
using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Infrastructure;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class GoodsCategoryController : ControllerBase
    {
        private IGoodsCategory goodsCategoryService;
        private IAmiyaEmployeeService amiyaEmployeeService;
        private IHttpContextAccessor httpContextAccessor;
        public GoodsCategoryController(IGoodsCategory goodsCategoryService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.goodsCategoryService = goodsCategoryService;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 根据展示方向获取商品分类列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="showDirection">展示方向(0：积分兑换，1：商城) </param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<GoodsCategoryVo>>> GetListAsync(string keyword,[Required]string showDirection)
        {
            var q = await goodsCategoryService.GetListAsync(keyword,showDirection);

            List<int> createIds = new List<int>();
            List<int> updateIds = new List<int>();

            foreach (var item in q.List)
            {
                if (!createIds.Exists(e => e == item.CreateBy))
                    createIds.Add(item.CreateBy);

                if (item.UpdateBy != null&& !updateIds.Exists(e=>e==item.UpdateBy))
                    updateIds.Add((int)item.UpdateBy);
            }
            var goodsCategorys = from d in q.List
                                 join ce in await amiyaEmployeeService.GetInfoListIdsAsync(createIds.ToArray()) on d.CreateBy equals ce.Id
                                 join ue in await amiyaEmployeeService.GetInfoListIdsAsync(updateIds.ToArray()) on d.UpdateBy equals ue.Id into ued
                                 from ue in ued.DefaultIfEmpty()
                                 select new GoodsCategoryVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     SimpleCode = d.SimpleCode,
                                     Valid = d.Valid,
                                     CreateDate = d.CreateDate,
                                     CreateBy = d.CreateBy,
                                     ShowDirectionType = d.ShowDirectionType.Value,
                                     ShowDirectionTypeName = d.ShowDirectionTypeName,
                                     CreateName = ce.Name,
                                     UpdateDate = d.UpdateDate,
                                     UpdateBy = d.UpdateBy,
                                     UpdateName = ue?.Name,
                                     Sort=d.Sort,
                                     IsHot=d.IsHot,
                                     MiniprogramName=d.MiniprogramName,
                                     AppId=d.AppId,
                                     CategoryImg=d.CategoryImg,
                                     IsBrand=d.IsBrand
                                 };
            FxPageInfo<GoodsCategoryVo> categoryPageInfo = new FxPageInfo<GoodsCategoryVo>();
            categoryPageInfo.TotalCount = q.TotalCount;
            categoryPageInfo.List = goodsCategorys;

            return ResultData<FxPageInfo<GoodsCategoryVo>>.Success().AddData("goodsCategorys", categoryPageInfo);
        }



        /// <summary>
        /// 根据编号获取商品分类信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResultData<GoodsCategoryVo>> GetByIdAsync(int id)
        {

            var goodsCategory = await goodsCategoryService.GetByIdAsync(id);
            GoodsCategoryVo category = new GoodsCategoryVo();
            category.Id = goodsCategory.Id;
            category.Name = goodsCategory.Name;
            category.SimpleCode = goodsCategory.SimpleCode;
            category.Valid = goodsCategory.Valid;
            category.CreateBy = goodsCategory.CreateBy;
            category.ShowDirectionType = goodsCategory.ShowDirectionType.Value;
            category.ShowDirectionTypeName = goodsCategory.ShowDirectionTypeName;
            category.CreateName = "";
            category.CreateDate = goodsCategory.CreateDate;
            category.UpdateBy = goodsCategory.UpdateBy;
            category.UpdateDate = goodsCategory.UpdateDate;
            category.UpdateName = "";
            category.CategoryImg = goodsCategory.CategoryImg;
            category.AppId = goodsCategory.AppId;
            category.IsHot = goodsCategory.IsHot;
            category.MiniprogramName = goodsCategory.MiniprogramName;
            category.IsBrand = goodsCategory.IsBrand;
            return ResultData<GoodsCategoryVo>.Success().AddData("goodsCategory", category);
        }



        /// <summary>
        /// 获取所有的分类名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("allNameList")]
        public async Task<ResultData<List<GoodsCategoryNameVo>>> GetAllCategoryNameListAsync()
        {
            var goodsCategorys = from d in await goodsCategoryService.GetCategoryNameListAsync(null)
                                 select new GoodsCategoryNameVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                 };


            return ResultData<List<GoodsCategoryNameVo>>.Success().AddData("goodsCategorys", goodsCategorys.ToList());
        }


        /// <summary>
        /// 获取有效的分类名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("validNameList")]
        public async Task<ResultData<List<GoodsCategoryNameVo>>> GetValidCategoryNameListAsync()
        {
            var goodsCategorys = from d in await goodsCategoryService.GetCategoryNameListAsync(true)
                                 select new GoodsCategoryNameVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                 };


            return ResultData<List<GoodsCategoryNameVo>>.Success().AddData("goodsCategorys", goodsCategorys.ToList());
        }


        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(GoodsCategoryAddVo goodsCategoryAdd)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            GoodsCategoryAddDto category = new GoodsCategoryAddDto()
            {
                Name = goodsCategoryAdd.Name,
                SimpleCode = goodsCategoryAdd.SimpleCode,
                ShowDirectionType=goodsCategoryAdd.ShowDirectionType,
                CreateBy = employeeId,
                CategoryImg=goodsCategoryAdd.CategoryImg,
                IsHot=goodsCategoryAdd.IsHot,
                AppId=goodsCategoryAdd.AppId,
                IsBrand=goodsCategoryAdd.IsBrand
            };

            await goodsCategoryService.AddAsync(category);
            return ResultData.Success();
        }



        /// <summary>
        /// 修改商品分类
        /// </summary>
        /// <param name="goodsCategoryUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(GoodsCategoryUpdateVo goodsCategoryUpdate)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            GoodsCategoryUpdateDto goodsCategoryUpdateDto = new GoodsCategoryUpdateDto()
            {
                Id = goodsCategoryUpdate.Id,
                Name = goodsCategoryUpdate.Name,
                ShowDirectionType = goodsCategoryUpdate.ShowDirectionType,
                SimpleCode = goodsCategoryUpdate.SimpleCode,
                Valid = goodsCategoryUpdate.Valid,
                UpdateBy = employeeId,
                CategoryImg=goodsCategoryUpdate.CategoryImg,
                IsHot=goodsCategoryUpdate.IsHot,
                AppId=goodsCategoryUpdate.AppId,
                IsBrand=goodsCategoryUpdate.IsBrand
            };
            await goodsCategoryService.UpdateAsync(goodsCategoryUpdateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 移动商品分类
        /// </summary>
        /// <param name="goodsCategoryMove">商品分类移动基础类</param>
        /// <returns></returns>
        [HttpPut("move")]
        public async Task<ResultData> UpdateSortAsync(GoodsCategoryMoveVo goodsCategoryMove)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            GoodsCategoryMoveDto goodsCategoryMoveDto = new GoodsCategoryMoveDto()
            {
                Id = goodsCategoryMove.Id,
                MoveState = goodsCategoryMove.MoveState,
                UpdateBy = employeeId,
            };
            await goodsCategoryService.MoveAsync(goodsCategoryMoveDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 置顶/底商品分类
        /// </summary>
        /// <param name="goodsCategoryMove">商品分类移动基础类</param>
        /// <returns></returns>
        [HttpPut("movetopordown")]
        public async Task<ResultData> UpdateTopOrDownAsync(GoodsCategoryMoveVo goodsCategoryMove)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            GoodsCategoryMoveDto goodsCategoryMoveDto = new GoodsCategoryMoveDto()
            {
                Id = goodsCategoryMove.Id,
                MoveState = goodsCategoryMove.MoveState,
                UpdateBy = employeeId,
            };
            await goodsCategoryService.MoveTopOrDownAsync(goodsCategoryMoveDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            await goodsCategoryService.DeleteAsync(id);
            return ResultData.Success();
        }



        /// <summary>
        /// 获取展示方向
        /// </summary>
        /// <returns></returns>
        [HttpGet("exchangeTypeList")]
        public ResultData<List<ShowDirectionTypeVo>> GetExchangeTypeList()
        {
            var showDirectionTypes = from d in goodsCategoryService.GetshowDirectionTypeList()
                                select new ShowDirectionTypeVo
                                {
                                    ShowDirectionType = d.ShowDirectionType,
                                    ShowDirectionTypeText = d.ShowDirectionTypeText
                                };
            return ResultData<List<ShowDirectionTypeVo>>.Success().AddData("exchangeTypes", showDirectionTypes.ToList());
        }

    }
}
