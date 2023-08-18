using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.GiftCategory;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GiftCategoryService : IGiftCategoryService
    {
        private readonly IDalGiftCategory dalGiftCategory;

        public GiftCategoryService(IDalGiftCategory dalGiftCategory)
        {
            this.dalGiftCategory = dalGiftCategory;
        }

        public async Task AddAsync(AddGiftCategoryDto add)
        {
            GiftCategory giftCategory = new GiftCategory();
            giftCategory.Id = Guid.NewGuid().ToString().Replace("-", "");
            giftCategory.Name = add.Name;
            giftCategory.SimpleCode = add.SimpleCode;
            giftCategory.CreateDate = DateTime.Now;
            giftCategory.Valid = true;
            giftCategory.CreateBy = add.CreateBy;
            await dalGiftCategory.AddAsync(giftCategory, true);
        }

        public async Task DeleteAsync(string id)
        {
            var category = dalGiftCategory.GetAll().Where(e => e.Id == id).SingleOrDefault();
            await dalGiftCategory.DeleteAsync(category, true);
        }

        public async Task<GiftCategoryInfoDto> GetByIdAsync(string id)
        {
            var category = await dalGiftCategory.GetAll().Where(e => e.Id == id).SingleOrDefaultAsync();
            GiftCategoryInfoDto giftCategoryInfoDto = new GiftCategoryInfoDto();
            giftCategoryInfoDto.Id = category.Id;
            giftCategoryInfoDto.Name = category.Name;
            giftCategoryInfoDto.SimpleCode = category.SimpleCode;
            giftCategoryInfoDto.Valid = category.Valid;
            return giftCategoryInfoDto;

        }
        /// <summary>
        /// 获取礼品分类名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseIdAndNameDto>> GetCategoryNameList()
        {
            var categoryList = dalGiftCategory.GetAll().Where(e=>e.Valid==true).Select(e => new BaseIdAndNameDto { Id = e.Id, Name = e.Name }).ToList();
            return categoryList;
        }

        public async Task<FxPageInfo<GiftCategoryInfoDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            FxPageInfo<GiftCategoryInfoDto> fxPageInfo = new FxPageInfo<GiftCategoryInfoDto>();
            var category = dalGiftCategory.GetAll().Where(e=>e.Valid==true).Select(e => new GiftCategoryInfoDto
            {
                Id = e.Id,
                Name = e.Name,
                SimpleCode = e.SimpleCode,
                CreateDate = e.CreateDate,
                UpdateDate = e.UpdateDate,
                CreateBy = e.CreateBy,
                UpdateBy = e.UpdateBy,
                Valid = e.Valid
            });
            fxPageInfo.TotalCount = category.Count();
            fxPageInfo.List = category.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }

        public async Task UpdateAsync(UpdateGiftCategoryDto update)
        {
            var category = await dalGiftCategory.GetAll().Where(e => e.Id == update.Id).SingleOrDefaultAsync();
            category.Name = update.Name;
            category.SimpleCode = update.SimpleCode;
            category.UpdateBy = update.UpdateBy;
            category.UpdateDate = DateTime.Now;
            category.Valid = update.Valid;
            await dalGiftCategory.UpdateAsync(category, true);
        }
    }
}
