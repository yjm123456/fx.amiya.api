using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsDemand;
using Fx.Amiya.Dto.HospitalInfo;
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
    public class TmallGoodsSkuService : ITmallGoodsSkuService
    {
        private IDalTmallGoodsSku dalTmallGoodsSku;

        public TmallGoodsSkuService(IDalTmallGoodsSku dalTmallGoodsSku)
        {
            this.dalTmallGoodsSku = dalTmallGoodsSku;
        }



        public async Task<FxPageInfo<TmallGoodsSkuDto>> GetListWithPageAsync(string keyword,string hospitalName, int pageNum, int pageSize)
        {
            try
            {
                var tmallGoodsSku = from d in dalTmallGoodsSku.GetAll()
                                    where d.CreateHospital==hospitalName
                                    && (keyword == null || d.SkuName.Contains(keyword) || d.GoodsId.Contains(keyword))
                                    select new TmallGoodsSkuDto
                                    {
                                        Id = d.Id,
                                        SkuName = d.SkuName,
                                        GoodsId = d.GoodsId,
                                        Price = d.Price,
                                        AllCount = d.AllCount,
                                    };

                FxPageInfo<TmallGoodsSkuDto> tmallGoodsSkuPageInfo = new FxPageInfo<TmallGoodsSkuDto>();
                tmallGoodsSkuPageInfo.TotalCount = await tmallGoodsSku.CountAsync();
                tmallGoodsSkuPageInfo.List = await tmallGoodsSku.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return tmallGoodsSkuPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<TmallGoodsSkuDto>> GetAllAsync()
        {
            try
            {
                var tmallGoodsSku = from d in dalTmallGoodsSku.GetAll()
                                    select new TmallGoodsSkuDto
                                    {
                                        Id = d.Id,
                                        SkuName = d.SkuName,
                                        GoodsId = d.GoodsId,
                                        Price = d.Price,
                                        AllCount = d.AllCount,
                                        CreateHospital = d.CreateHospital
                                    };

                return await tmallGoodsSku.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task AddAsync(AddTmallGoodsSkuDto addDto)
        {
            try
            {
                TmallGoodsSku tmallGoodsSku = new TmallGoodsSku();
                tmallGoodsSku.Id = Guid.NewGuid().ToString();
                tmallGoodsSku.SkuName = addDto.SkuName;
                tmallGoodsSku.GoodsId = addDto.GoodsId;
                tmallGoodsSku.Price = addDto.Price;
                tmallGoodsSku.AllCount = addDto.AllCount;
                tmallGoodsSku.CreateHospital = addDto.CreateHospital;
                await dalTmallGoodsSku.AddAsync(tmallGoodsSku, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<TmallGoodsSkuDto> GetByIdAsync(string id)
        {
            try
            {
                var tmallGoodsSku = await dalTmallGoodsSku.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (tmallGoodsSku == null)
                {
                    return new TmallGoodsSkuDto()
                    {
                        Id = "",
                        SkuName = "",
                        GoodsId = "",
                        Price = 0.00M,
                        AllCount=0
                    };
                }

                TmallGoodsSkuDto tmallGoodsSkuDto = new TmallGoodsSkuDto();
                tmallGoodsSkuDto.Id = tmallGoodsSku.Id;
                tmallGoodsSkuDto.SkuName = tmallGoodsSku.SkuName;
                tmallGoodsSkuDto.GoodsId = tmallGoodsSku.GoodsId;
                tmallGoodsSkuDto.Price = tmallGoodsSku.Price;
                tmallGoodsSkuDto.AllCount = tmallGoodsSku.AllCount;

                return tmallGoodsSkuDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateTmallGoodsSkuDto updateDto)
        {
            try
            {
                var tmallGoodsSku = await dalTmallGoodsSku.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (tmallGoodsSku == null)
                    throw new Exception("天猫商品编号错误！");

                tmallGoodsSku.SkuName = updateDto.SkuName;
                tmallGoodsSku.GoodsId = updateDto.GoodsId;
                tmallGoodsSku.Price = updateDto.Price;
                tmallGoodsSku.AllCount = updateDto.AllCount;

                await dalTmallGoodsSku.UpdateAsync(tmallGoodsSku, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var tmallGoodsSku = await dalTmallGoodsSku.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (tmallGoodsSku == null)
                    throw new Exception("天猫商品编号错误");

                await dalTmallGoodsSku.DeleteAsync(tmallGoodsSku, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteBySkuIdAndHospitalNameAsync(string SKUId,string hospitalName)
        {
            try
            {
                var tmallGoodsSku = await dalTmallGoodsSku.GetAll().Where(e => e.GoodsId == SKUId&&e.CreateHospital==hospitalName).ToListAsync();

                foreach (var z in tmallGoodsSku)
                {
                    await dalTmallGoodsSku.DeleteAsync(z, true);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
