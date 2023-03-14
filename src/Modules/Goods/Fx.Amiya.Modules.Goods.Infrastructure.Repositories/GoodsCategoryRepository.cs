
using Fx.Amiya.Modules.Goods.DbModel;
using Fx.Amiya.Modules.Goods.Domin;
using Fx.Amiya.Modules.Goods.Domin.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Infrastructure.Repositories
{
    public class GoodsCategoryRepository : IGoodsCategoryRepository
    {
        private IFreeSql<GoodsFlag> freeSql;
        public GoodsCategoryRepository(IFreeSql<GoodsFlag> freeSql)
        {
            this.freeSql = freeSql;
        }

        public async Task<GoodsCategory> AddAsync(GoodsCategory entity)
        {
            GoodsCategoryDbModel goodsCategoryDbModel = new GoodsCategoryDbModel()
            {
                Name = entity.Name,
                SimpleCode = entity.SimpleCode,
                ShowDirectionType = entity.ShowDirectionType,
                Valid = entity.Valid,
                CreateDate = entity.CreateDate,
                CreateBy = entity.CreateBy,
                Sort = entity.Sort,
                CategoryImg=entity.CategoryImg
            };

            entity.Id = (int)await freeSql.Insert<GoodsCategoryDbModel>().AppendData(goodsCategoryDbModel).ExecuteIdentityAsync();
            return entity;
        }



        public async Task<GoodsCategory> GetByIdAsync(int id)
        {
            var goodsCategory = await freeSql.Select<GoodsCategoryDbModel>().Where(e => e.Id == id).FirstAsync();
            GoodsCategory category = new GoodsCategory()
            {
                Id = goodsCategory.Id,
                Name = goodsCategory.Name,
                SimpleCode = goodsCategory.SimpleCode,
                Valid = goodsCategory.Valid,
                CreateDate = goodsCategory.CreateDate,
                ShowDirectionType = goodsCategory.ShowDirectionType,
                CreateBy = goodsCategory.CreateBy,
                UpdateDate = goodsCategory.UpdateDate,
                UpdateBy = goodsCategory.UpdateBy,
                Sort = goodsCategory.Sort,
                CategoryImg=goodsCategory.CategoryImg
            };
            return category;
        }

        public async Task<GoodsCategory> GetNearGoodsCategory(int Id,int showDirectionType, bool IsUp)
        {
            var goodsCategoryList = await freeSql.Select<GoodsCategoryDbModel>().Where(z=>z.ShowDirectionType==showDirectionType).OrderByDescending(z=>z.Sort).ToListAsync();
            int ExistRow = 0;
            GoodsCategory category = new GoodsCategory();
            foreach (var x in goodsCategoryList)
            {
                if (x.Id == Id)
                {
                    break;
                }
                ExistRow++;
            }
            if (IsUp == true)
            {
                if (ExistRow == 0)
                {
                    var categoryModel = goodsCategoryList.Where(z => z.Id == Id).FirstOrDefault();
                    category.Id = categoryModel.Id;
                    category.Name = categoryModel.Name;
                    category.SimpleCode = categoryModel.SimpleCode;
                    category.Valid = categoryModel.Valid;
                    category.CreateDate = categoryModel.CreateDate;
                    category.ShowDirectionType = categoryModel.ShowDirectionType;
                    category.CreateBy = categoryModel.CreateBy;
                    category.UpdateDate = categoryModel.UpdateDate;
                    category.UpdateBy = categoryModel.UpdateBy;
                    category.CategoryImg = categoryModel.CategoryImg;
                    category.Sort = categoryModel.Sort;
                }
                else{
                    var nearRow = goodsCategoryList[ExistRow - 1];
                    category.Id = nearRow.Id;
                    category.Name = nearRow.Name;
                    category.SimpleCode = nearRow.SimpleCode;
                    category.Valid = nearRow.Valid;
                    category.CreateDate = nearRow.CreateDate;
                    category.ShowDirectionType = nearRow.ShowDirectionType;
                    category.CreateBy = nearRow.CreateBy;
                    category.UpdateDate = nearRow.UpdateDate;
                    category.UpdateBy = nearRow.UpdateBy;
                    category.CategoryImg = nearRow.CategoryImg;
                    category.Sort = nearRow.Sort;
                }
            }
            else {
                if (ExistRow + 1 == goodsCategoryList.Count)
                {
                    var categoryModel = goodsCategoryList.Where(z => z.Id == Id).FirstOrDefault();
                    category.Id = categoryModel.Id;
                    category.Name = categoryModel.Name;
                    category.SimpleCode = categoryModel.SimpleCode;
                    category.Valid = categoryModel.Valid;
                    category.CreateDate = categoryModel.CreateDate;
                    category.ShowDirectionType = categoryModel.ShowDirectionType;
                    category.CreateBy = categoryModel.CreateBy;
                    category.UpdateDate = categoryModel.UpdateDate;
                    category.UpdateBy = categoryModel.UpdateBy;
                    category.CategoryImg = categoryModel.CategoryImg;
                    category.Sort = categoryModel.Sort;
                }
                else{
                    var nearRow = goodsCategoryList[ExistRow + 1];
                    category.Id = nearRow.Id;
                    category.Name = nearRow.Name;
                    category.SimpleCode = nearRow.SimpleCode;
                    category.Valid = nearRow.Valid;
                    category.CreateDate = nearRow.CreateDate;
                    category.ShowDirectionType = nearRow.ShowDirectionType;
                    category.CreateBy = nearRow.CreateBy;
                    category.UpdateDate = nearRow.UpdateDate;
                    category.UpdateBy = nearRow.UpdateBy;
                    category.CategoryImg = nearRow.CategoryImg;
                    category.Sort = nearRow.Sort;
                }
            }
            return category;
        }

        public async Task<int> GetMaxOrMinSortByShowDirectionType(int showDirectionType, bool IsMax)
        {
            if (IsMax == true)
            {
                return await freeSql.Select<GoodsCategoryDbModel>().Where(z => z.ShowDirectionType == showDirectionType).MaxAsync(e => e.Sort);
            }
            else
            {
                return await freeSql.Select<GoodsCategoryDbModel>().Where(z => z.ShowDirectionType == showDirectionType).MinAsync(e => e.Sort);
            }
        }

        public async Task<int> RemoveAsync(GoodsCategory entity)
        {
            return await RemoveAsync(entity.Id);
        }




        public async Task<int> RemoveAsync(int id)
        {
            return await freeSql.Delete<GoodsCategoryDbModel>().Where(e => e.Id == id).ExecuteAffrowsAsync();
        }




        public async Task<int> UpdateAsync(GoodsCategory entity)
        {
            return await freeSql.Update<GoodsCategoryDbModel>()
                 .Set(e => e.Name, entity.Name)
                 .Set(e => e.SimpleCode, entity.SimpleCode)
                 .Set(e => e.ShowDirectionType, entity.ShowDirectionType)
                 .Set(e => e.Valid, entity.Valid)
                 .Set(e => e.UpdateBy, entity.UpdateBy)
                 .Set(e => e.UpdateDate, entity.UpdateDate)
                 .Set(e => e.Sort, entity.Sort)
                 .Set(e=>e.CategoryImg,entity.CategoryImg)
                 .Where(e => e.Id == entity.Id)
                 .ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 根据简码获取分类信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<GoodsCategory> GetGoodsCategoryBySimpleCode(string code)
        {
            var category= freeSql.Select<GoodsCategoryDbModel>().Where(z=>z.SimpleCode==code).First();
            if (category == null)
            {
                throw new Exception("编码错误");
            }
            else {
                GoodsCategory categoryInfo = new GoodsCategory();
                categoryInfo.Id = category.Id;
                categoryInfo.Name = category.Name;
                categoryInfo.SimpleCode = category.SimpleCode;
                categoryInfo.Valid = category.Valid;
                categoryInfo.CreateDate = category.CreateDate;
                categoryInfo.ShowDirectionType = category.ShowDirectionType;
                categoryInfo.CreateBy = category.CreateBy;
                categoryInfo.UpdateDate = category.UpdateDate;
                categoryInfo.UpdateBy = category.UpdateBy;
                categoryInfo.Sort = category.Sort;
                return categoryInfo;
            }

        }
    }
}
