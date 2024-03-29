﻿using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Infrastructure;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Dal;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Modules.Goods.DbModel;
using Fx.Amiya.Modules.Goods.Domin;
using Fx.Amiya.Modules.Goods.Domin.IRepository;
using Fx.Amiya.Modules.Goods.Infrastructure.Repositories;
using Fx.Amiya.Service;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.AppService
{
    public class GoodsCategoryAppService : IGoodsCategory
    {
        private IGoodsCategoryRepository _goodsCategoryRepository;
        private IFreeSql<GoodsFlag> freeSql;
        private readonly IDalMiniprogram dalMiniprogram;
        private readonly IMiniprogramService miniprogramService;
        public GoodsCategoryAppService(IGoodsCategoryRepository goodsCategoryRepository,
            IFreeSql<GoodsFlag> freeSql, IMiniprogramService miniprogramService, IDalMiniprogram dalMiniprogram)
        {
            _goodsCategoryRepository = goodsCategoryRepository;
            this.freeSql = freeSql;
            this.miniprogramService = miniprogramService;
            this.dalMiniprogram = dalMiniprogram;
        }
        public async Task AddAsync(GoodsCategoryAddDto goodsCategoryAdd)
        {
            var maxSort = await _goodsCategoryRepository.GetMaxOrMinSortByShowDirectionType(goodsCategoryAdd.ShowDirectionType,true);
            GoodsCategory goodsCategory = new GoodsCategory()
            {
                Name = goodsCategoryAdd.Name,
                SimpleCode = goodsCategoryAdd.SimpleCode,
                ShowDirectionType = goodsCategoryAdd.ShowDirectionType,
                Valid = true,
                CreateBy = goodsCategoryAdd.CreateBy,
                CreateDate = DateTime.Now,
                Sort = maxSort + 1,
                CategoryImg = goodsCategoryAdd.CategoryImg,
                IsHot=goodsCategoryAdd.IsHot,
                AppId=goodsCategoryAdd.AppId,
                IsBrand=goodsCategoryAdd.IsBrand
            };
            await _goodsCategoryRepository.AddAsync(goodsCategory);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _goodsCategoryRepository.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }
        }

        public async Task<GoodsCategoryDto> GetByIdAsync(int id)
        {
            var goodsCategory = await _goodsCategoryRepository.GetByIdAsync(id);
            GoodsCategoryDto category = new GoodsCategoryDto()
            {
                Id = goodsCategory.Id,
                Name = goodsCategory.Name,
                SimpleCode = goodsCategory.SimpleCode,
                Valid = goodsCategory.Valid,
                CreateDate = goodsCategory.CreateDate,
                CreateBy = goodsCategory.CreateBy,
                ShowDirectionType = goodsCategory.ShowDirectionType.Value,
                ShowDirectionTypeName = showDirectionTypeDict[((ShowDirectionType)goodsCategory.ShowDirectionType)],
                UpdateDate = goodsCategory.UpdateDate,
                UpdateBy = goodsCategory.UpdateBy,
                CategoryImg = goodsCategory.CategoryImg,
                IsHot = goodsCategory.IsHot,
                AppId = goodsCategory.AppId,
                MiniprogramName = dalMiniprogram.GetAll().Where(e => e.AppId == goodsCategory.AppId).FirstOrDefault()?.Name ?? "共享分类",
                IsBrand=goodsCategory.IsBrand
            };
            return category;
        }

        public async Task<FxPageInfo<GoodsCategoryDto>> GetListAsync(string keyword, string showDirection)
        {
            var goodsCategorys = freeSql.Select<GoodsCategoryDbModel>()
                .Where(e => string.IsNullOrWhiteSpace(keyword) || e.Name.Contains(keyword) || e.SimpleCode.Contains(keyword))
                .Where(k => k.ShowDirectionType.Value == Convert.ToInt32(showDirection));

            var categorys = from d in await goodsCategorys.ToListAsync()
                            select new GoodsCategoryDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                SimpleCode = d.SimpleCode,
                                Valid = d.Valid,
                                ShowDirectionType = d.ShowDirectionType.Value,
                                ShowDirectionTypeName = showDirectionTypeDict[((ShowDirectionType)d.ShowDirectionType)],
                                CreateDate = d.CreateDate,
                                CreateBy = d.CreateBy,
                                UpdateDate = d.UpdateDate,
                                UpdateBy = d.UpdateBy,
                                Sort = d.Sort,
                                CategoryImg = d.CategoryImg,
                                AppId = d.AppId,
                                IsHot = d.IsHot,
                                MiniprogramName = dalMiniprogram.GetAll().Where(e=>e.AppId== d.AppId).FirstOrDefault()?.Name ?? "共享分类",
                                IsBrand=d.IsBrand
                            };
            FxPageInfo<GoodsCategoryDto> categoryPageInfo = new FxPageInfo<GoodsCategoryDto>();
            categoryPageInfo.TotalCount = (int)await goodsCategorys.CountAsync();
            categoryPageInfo.List = categorys.OrderByDescending(z => z.Sort);
            return categoryPageInfo;
        }



        public async Task<List<GoodsCategoryNameDto>> GetCategoryNameListAsync(bool? valid,string appId=null)
        {
            var goodsCategorys =freeSql.Select<GoodsCategoryDbModel>()
                .Where(e => valid == null || e.Valid == valid)
                .OrderByDescending(z => z.Sort);
            if (!string.IsNullOrEmpty(appId)) {
                var appInfo =await miniprogramService.GetMiniprogramInfoByAppIdAsync(appId);
                if (appInfo.IsMain) {
                    goodsCategorys = goodsCategorys.Where(e => e.AppId == appId || string.IsNullOrEmpty(e.AppId));
                }

                if (!appInfo.IsMain) {
                    goodsCategorys = goodsCategorys.Where(e => e.AppId == appId || string.IsNullOrEmpty(e.AppId) || e.AppId == appInfo.BelongMiniprogramAppId);
                }
            }

            var categorys = from d in goodsCategorys.ToList()
                            select new GoodsCategoryNameDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                ShowDirectionType = d.ShowDirectionType.Value,
                                CategoryImg=d.CategoryImg
                            };
            return categorys.ToList();
        }

        

        public async Task UpdateAsync(GoodsCategoryUpdateDto goodsCategoryUpdate)
        {
            var goodsCategoryInfo = await _goodsCategoryRepository.GetByIdAsync(goodsCategoryUpdate.Id);
            GoodsCategory goodsCategory = new GoodsCategory()
            {
                Id = goodsCategoryUpdate.Id,
                Name = goodsCategoryUpdate.Name,
                SimpleCode = goodsCategoryUpdate.SimpleCode,
                ShowDirectionType = goodsCategoryUpdate.ShowDirectionType.Value,
                ShowDirectionTypeName = showDirectionTypeDict[((ShowDirectionType)goodsCategoryUpdate.ShowDirectionType)],
                Valid = goodsCategoryUpdate.Valid,
                UpdateBy = goodsCategoryUpdate.UpdateBy,
                UpdateDate = DateTime.Now,
                Sort = goodsCategoryInfo.Sort,
                CategoryImg=goodsCategoryUpdate.CategoryImg,
                IsBrand=goodsCategoryUpdate.IsBrand,
                IsHot=goodsCategoryUpdate.IsHot,
                AppId= goodsCategoryUpdate.AppId
            };
            await _goodsCategoryRepository.UpdateAsync(goodsCategory);

        }

        public async Task MoveAsync(GoodsCategoryMoveDto goodsCategoryMove)
        {
            var goodsCategoryInfo = await _goodsCategoryRepository.GetByIdAsync(goodsCategoryMove.Id);
            var changeGoodsCategoryInfo = await _goodsCategoryRepository.GetNearGoodsCategory(goodsCategoryMove.Id,goodsCategoryInfo.ShowDirectionType.Value, goodsCategoryMove.MoveState);
            if (goodsCategoryInfo.Id != changeGoodsCategoryInfo.Id)
            {
                int changeSort = goodsCategoryInfo.Sort;
                //修改参数
                goodsCategoryInfo.UpdateBy = goodsCategoryMove.UpdateBy;
                goodsCategoryInfo.UpdateDate = DateTime.Now;
                goodsCategoryInfo.Sort = changeGoodsCategoryInfo.Sort;
                //待修改参数数据
                changeGoodsCategoryInfo.UpdateBy = goodsCategoryMove.UpdateBy;
                changeGoodsCategoryInfo.UpdateDate = DateTime.Now;
                changeGoodsCategoryInfo.Sort = changeSort;

                List<GoodsCategory> addGoodsCategoryList = new List<GoodsCategory>();
                addGoodsCategoryList.Add(goodsCategoryInfo);
                addGoodsCategoryList.Add(changeGoodsCategoryInfo);
                foreach (var z in addGoodsCategoryList)
                {
                    await _goodsCategoryRepository.UpdateAsync(z);
                }
            }

        }

        public async Task MoveTopOrDownAsync(GoodsCategoryMoveDto goodsCategoryMove)
        {
            var goodsCategoryInfo = await _goodsCategoryRepository.GetByIdAsync(goodsCategoryMove.Id);
            if (goodsCategoryMove.MoveState == true)
            {
                goodsCategoryInfo.Sort = await _goodsCategoryRepository.GetMaxOrMinSortByShowDirectionType(goodsCategoryInfo.ShowDirectionType.Value,true)+1;
            }
            else
            {
                goodsCategoryInfo.Sort = await _goodsCategoryRepository.GetMaxOrMinSortByShowDirectionType(goodsCategoryInfo.ShowDirectionType.Value, false) -1;
            }
            //修改参数
            goodsCategoryInfo.UpdateBy = goodsCategoryMove.UpdateBy;
            goodsCategoryInfo.UpdateDate = DateTime.Now;
            await _goodsCategoryRepository.UpdateAsync(goodsCategoryInfo);

        }

        public List<ShowDirectionTypeDto> GetshowDirectionTypeList()
        {
            var showDirectionTypes = Enum.GetValues(typeof(ShowDirectionType));
            List<ShowDirectionTypeDto> showDirectionTypeList = new List<ShowDirectionTypeDto>();
            foreach (var item in showDirectionTypes)
            {
                ShowDirectionTypeDto exchangeTypeDto = new ShowDirectionTypeDto();
                exchangeTypeDto.ShowDirectionType = Convert.ToByte(item);
                exchangeTypeDto.ShowDirectionTypeText = showDirectionTypeDict[(ShowDirectionType)item];
                showDirectionTypeList.Add(exchangeTypeDto);
            }
            return showDirectionTypeList;
        }

        public Task<GoodsCategoryDto> GetGoodsCategoryByCode(string code)
        {
            var category = _goodsCategoryRepository.GetGoodsCategoryBySimpleCode(code);
            return null;
        }
        /// <summary>
        /// 根据appid获取指定数量的热门分类
        /// </summary>
        /// <param name="valid"></param>
        /// <param name="count"></param>
        /// <param name="isBrand">是否是品牌分类</param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<List<GoodsCategoryNameDto>> GetHotCategoryNameListAsync(bool? valid, int count,bool isBrand,bool isHot, string appId = null)
        {
            var goodsCategorys = freeSql.Select<GoodsCategoryDbModel>()
                .Where(e => valid == null || e.Valid == valid)
                .Where(e=>e.IsHot==isHot)
                .Where(e=>e.IsBrand==isBrand)
                .OrderByDescending(z => z.Sort);
            if (!string.IsNullOrEmpty(appId))
            {
                var appInfo = await miniprogramService.GetMiniprogramInfoByAppIdAsync(appId);
                if (appInfo.IsMain)
                {
                    goodsCategorys = goodsCategorys.Where(e => e.AppId == appId || string.IsNullOrEmpty(e.AppId));
                }

                if (!appInfo.IsMain)
                {
                    goodsCategorys = goodsCategorys.Where(e => e.AppId == appId || string.IsNullOrEmpty(e.AppId) || e.AppId == appInfo.BelongMiniprogramAppId);
                }
            }

            var categorys = from d in goodsCategorys.Skip(0).Take(count).ToList()
                            select new GoodsCategoryNameDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                ShowDirectionType = d.ShowDirectionType.Value,
                                CategoryImg = d.CategoryImg
                            };
            return categorys.ToList();
        }

        Dictionary<ShowDirectionType, string> showDirectionTypeDict = new Dictionary<ShowDirectionType, string>()
        {
            { ShowDirectionType.Store,"商城"},
            { ShowDirectionType.Integral,"积分兑换"},
            { ShowDirectionType.IntegralAndStore,"积分加钱购"}
        };


    }
}
