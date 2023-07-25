using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.SupplierBrand.Input;
using Fx.Amiya.Dto.SupplierBrand.Output;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class SupplierBrandService : ISupplierBrandService
    {
        private IDalSupplierBrand dalSupplierBrandService;

        public SupplierBrandService(IDalSupplierBrand dalSupplierBrandService)
        {
            this.dalSupplierBrandService = dalSupplierBrandService;
        }



        public async Task<FxPageInfo<SupplierBrandDto>> GetListWithPageAsync(QuerySupplierBrandDto query)
        {
            try
            {
                var supplierBrandService = from d in dalSupplierBrandService.GetAll()
                                           where (query.KeyWord == null || d.BrandName.Contains(query.KeyWord))
                                              && (!query.Valid.HasValue || d.Valid == query.Valid)
                                           select new SupplierBrandDto
                                           {
                                               Id = d.Id,
                                               CreateDate = d.CreateDate,
                                               BrandName = d.BrandName,
                                               Valid = d.Valid,
                                               DeleteDate = d.DeleteDate,
                                           };
                FxPageInfo<SupplierBrandDto> supplierBrandServicePageInfo = new FxPageInfo<SupplierBrandDto>();
                supplierBrandServicePageInfo.TotalCount = await supplierBrandService.CountAsync();
                supplierBrandServicePageInfo.List = await supplierBrandService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                return supplierBrandServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(SupplierBrandAddDto addDto)
        {
            try
            {
                SupplierBrand supplierBrandService = new SupplierBrand();
                supplierBrandService.Id = Guid.NewGuid().ToString();
                supplierBrandService.BrandName = addDto.BrandName;
                supplierBrandService.CreateDate = DateTime.Now;
                supplierBrandService.Valid = true;

                await dalSupplierBrandService.AddAsync(supplierBrandService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SupplierBrandDto> GetByIdAsync(string id)
        {
            try
            {
                var supplierBrandService = await dalSupplierBrandService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (supplierBrandService == null)
                {
                    return new SupplierBrandDto();
                }

                SupplierBrandDto supplierBrandServiceDto = new SupplierBrandDto();
                supplierBrandServiceDto.Id = supplierBrandService.Id;
                supplierBrandServiceDto.BrandName = supplierBrandService.BrandName;
                supplierBrandServiceDto.CreateDate = supplierBrandService.CreateDate;
                supplierBrandServiceDto.UpdateDate = supplierBrandService.UpdateDate;
                supplierBrandServiceDto.DeleteDate = supplierBrandService.DeleteDate;
                supplierBrandServiceDto.Valid = supplierBrandService.Valid;
                return supplierBrandServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(SupplierBrandUpdateDto updateDto)
        {
            try
            {
                var supplierBrandService = await dalSupplierBrandService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (supplierBrandService == null)
                    throw new Exception("品牌编号错误！");

                supplierBrandService.BrandName = updateDto.BrandName;
                supplierBrandService.UpdateDate = DateTime.Now;

                await dalSupplierBrandService.UpdateAsync(supplierBrandService, true);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task DeleteAsync(string id)
        {
            try
            {
                var supplierBrandService = await dalSupplierBrandService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (supplierBrandService == null)
                    throw new Exception("品牌编号错误");
                supplierBrandService.Valid = false;
                supplierBrandService.DeleteDate = DateTime.Now;

                await dalSupplierBrandService.UpdateAsync(supplierBrandService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取所有有效品牌
        /// </summary>
        /// <returns></returns>

        public async Task<List<BaseKeyValueDto>> GetSupplierBrandListAsync()
        {
            var employee = from d in dalSupplierBrandService.GetAll()
                           where d.Valid
                           select new BaseKeyValueDto
                           {
                               Key = d.Id,
                               Value = d.BrandName,
                           };
            return await employee.ToListAsync();

        }

    }
}
