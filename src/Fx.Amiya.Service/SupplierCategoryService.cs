using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.SupplierCategory.Input;
using Fx.Amiya.Dto.SupplierCategory.OutPut;

namespace Fx.Amiya.Service
{
    public class SupplierCategoryService : ISupplierCategoryService
    {
        private IDalSupplierCategory dalSupplierCategoryService;

        public SupplierCategoryService(IDalSupplierCategory dalSupplierCategoryService)
        {
            this.dalSupplierCategoryService = dalSupplierCategoryService;
        }



        public async Task<FxPageInfo<SupplierCategoryDto>> GetListWithPageAsync(QuerySupplierCategoryDto query)
        {
            try
            {
                var supplierCategoryService = from d in dalSupplierCategoryService.GetAll()
                                                        where (query.KeyWord == null || d.CategoryName.Contains(query.KeyWord))
                                                           && (!query.Valid.HasValue || d.Valid == query.Valid)
                                                        select new SupplierCategoryDto
                                                        {
                                                            Id = d.Id,
                                                            CreateDate = d.CreateDate,
                                                            CategoryName=d.CategoryName,
                                                            Valid = d.Valid,
                                                            DeleteDate = d.DeleteDate,
                                                        };
                FxPageInfo<SupplierCategoryDto> supplierCategoryServicePageInfo = new FxPageInfo<SupplierCategoryDto>();
                supplierCategoryServicePageInfo.TotalCount = await supplierCategoryService.CountAsync();
                supplierCategoryServicePageInfo.List = await supplierCategoryService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                return supplierCategoryServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(SupplierCategoryAddDto addDto)
        {
            try
            {
                SupplierCategory supplierCategoryService = new SupplierCategory();
                supplierCategoryService.Id = Guid.NewGuid().ToString();
                supplierCategoryService.CategoryName = addDto.CategoryName;
                supplierCategoryService.CreateDate = DateTime.Now;
                supplierCategoryService.Valid = true;

                await dalSupplierCategoryService.AddAsync(supplierCategoryService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SupplierCategoryDto> GetByIdAsync(string id)
        {
            try
            {
                var supplierCategoryService = await dalSupplierCategoryService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (supplierCategoryService == null)
                {
                    return new SupplierCategoryDto();
                }

                SupplierCategoryDto supplierCategoryServiceDto = new SupplierCategoryDto();
                supplierCategoryServiceDto.Id = supplierCategoryService.Id;
                supplierCategoryServiceDto.CategoryName = supplierCategoryService.CategoryName;
                supplierCategoryServiceDto.CreateDate = supplierCategoryService.CreateDate;
                supplierCategoryServiceDto.UpdateDate = supplierCategoryService.UpdateDate;
                supplierCategoryServiceDto.DeleteDate = supplierCategoryService.DeleteDate;
                supplierCategoryServiceDto.Valid = supplierCategoryService.Valid;
                return supplierCategoryServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(SupplierCategoryUpdateDto updateDto)
        {
            try
            {
                var supplierCategoryService = await dalSupplierCategoryService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (supplierCategoryService == null)
                    throw new Exception("品类编号错误！");

                supplierCategoryService.CategoryName = updateDto.CategoryName;
                supplierCategoryService.UpdateDate = DateTime.Now;

                await dalSupplierCategoryService.UpdateAsync(supplierCategoryService, true);


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
                var supplierCategoryService = await dalSupplierCategoryService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (supplierCategoryService == null)
                    throw new Exception("品类编号错误");
                supplierCategoryService.Valid = false;
                supplierCategoryService.DeleteDate = DateTime.Now;

                await dalSupplierCategoryService.UpdateAsync(supplierCategoryService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 获取品类
        /// </summary>
        /// <returns></returns>

        public async Task<List<BaseKeyValueDto>> GetValidByBrandIdAsync()
        {
            var employee = from d in dalSupplierCategoryService.GetAll()
                           where d.Valid
                           select new BaseKeyValueDto
                           {
                               Key = d.Id,
                               Value = d.CategoryName,
                           };
            return await employee.ToListAsync();

        }

    }
}
