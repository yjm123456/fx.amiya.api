using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.GIftCategory;
using Fx.Amiya.Dto.GiftCategory;
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
    /// 礼品分类
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class GiftCategoryController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IGiftCategoryService giftCategoryService;
        public GiftCategoryController(IHttpContextAccessor httpContextAccessor, IGiftCategoryService giftCategoryService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.giftCategoryService = giftCategoryService;
        }

        /// <summary>
        /// 添加礼品分类
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddGiftCategoryVo add) {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddGiftCategoryDto addGift = new AddGiftCategoryDto();
            addGift.Name = add.Name;
            addGift.SimpleCode = add.SimpleCode;
            addGift.CreateBy = employeeId;
            await giftCategoryService.AddAsync(addGift);
            return ResultData.Success();
        }
        /// <summary>
        /// 分页获取分类
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<GiftCategoryInfoVo>>> GetListWithPageAsync(int pageNum,int pageSize) {
            FxPageInfo<GiftCategoryInfoVo> fxPageInfo = new FxPageInfo<GiftCategoryInfoVo>();
            var categoryList =await giftCategoryService.GetListWithPageAsync(pageNum, pageSize);
            fxPageInfo.TotalCount = categoryList.TotalCount;
            fxPageInfo.List = categoryList.List.Select(e => new GiftCategoryInfoVo {
                Id=e.Id,
                Name=e.Name,
                SimpleCode=e.SimpleCode,
                CreateBy=e.CreateBy,
                UpdateBy=e.UpdateBy,
                UpdateDate=e.UpdateDate,
                CreateDate=e.CreateDate,
                Valid=e.Valid
            }).ToList();
            return ResultData<FxPageInfo<GiftCategoryInfoVo>>.Success().AddData("categoryList", fxPageInfo);
        }
        /// <summary>
        /// 修改分类信息
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateGiftCategoryVo update) {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            UpdateGiftCategoryDto updateGiftCategoryDto = new UpdateGiftCategoryDto();
            updateGiftCategoryDto.Id = update.Id;
            updateGiftCategoryDto.Name = update.Name;
            updateGiftCategoryDto.SimpleCode = update.SimpleCode;
            updateGiftCategoryDto.UpdateBy = employeeId;
            updateGiftCategoryDto.Valid = update.Valid;
            await giftCategoryService.UpdateAsync(updateGiftCategoryDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据id获取类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ResultData<SimpleGiftCategoryInfoVo>> GetById(string id) {
            var category =await giftCategoryService.GetByIdAsync(id);
            SimpleGiftCategoryInfoVo infoVo = new SimpleGiftCategoryInfoVo();
            infoVo.Id = category.Id;
            infoVo.Name = category.Name;
            infoVo.SimpleCode = category.SimpleCode;
            infoVo.Valid = category.Valid;
            return ResultData<SimpleGiftCategoryInfoVo>.Success().AddData("info", infoVo);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id) {
            await giftCategoryService.DeleteAsync(id);
            return ResultData.Success();
        }
        /// <summary>
        /// 获取礼品分类名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetCategoryNameList() {
            var list= await giftCategoryService.GetCategoryNameList();
            var nameList= list.Select(e => new BaseIdAndNameVo
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("nameList", nameList);
        }
        
    }
}
