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
using Fx.Amiya.Dto.SupplierItemDetails.Input;
using Fx.Amiya.Dto.SupplierItemDetails.OutPut;

namespace Fx.Amiya.Service
{
    public class SupplierItemDetailsService : ISupplierItemDetailsService
    {
        private IDalSupplierItemDetails dalSupplierItemDetailsService;

        public SupplierItemDetailsService(IDalSupplierItemDetails dalSupplierItemDetailsService)
        {
            this.dalSupplierItemDetailsService = dalSupplierItemDetailsService;
        }



        public async Task<FxPageInfo<SupplierItemDetailsDto>> GetListWithPageAsync(QuerySupplierItemDetailsDto query)
        {
            try
            {
                var supplierItemDetailsService = from d in dalSupplierItemDetailsService.GetAll()
                                                        where (query.KeyWord == null || d.ItemDetailsName.Contains(query.KeyWord))
                                                           && (string.IsNullOrEmpty(query.BrandId) || d.BrandId == query.BrandId)
                                                           && (!query.Valid.HasValue || d.Valid == query.Valid)
                                                        select new SupplierItemDetailsDto
                                                        {
                                                            Id = d.Id,
                                                            BrandId = d.BrandId,
                                                            BrandName = d.SupplierBrand.BrandName,
                                                            CreateDate = d.CreateDate,
                                                            ItemDetailsName=d.ItemDetailsName,
                                                            Valid = d.Valid,
                                                            DeleteDate = d.DeleteDate,
                                                        };
                FxPageInfo<SupplierItemDetailsDto> supplierItemDetailsServicePageInfo = new FxPageInfo<SupplierItemDetailsDto>();
                supplierItemDetailsServicePageInfo.TotalCount = await supplierItemDetailsService.CountAsync();
                supplierItemDetailsServicePageInfo.List = await supplierItemDetailsService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                return supplierItemDetailsServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(SupplierItemDetailsAddDto addDto)
        {
            try
            {
                SupplierItemDetails supplierItemDetailsService = new SupplierItemDetails();
                supplierItemDetailsService.Id = Guid.NewGuid().ToString();
                supplierItemDetailsService.ItemDetailsName = addDto.ItemDetailsName;
                supplierItemDetailsService.BrandId = addDto.BrandId;
                supplierItemDetailsService.CreateDate = DateTime.Now;
                supplierItemDetailsService.Valid = true;

                await dalSupplierItemDetailsService.AddAsync(supplierItemDetailsService, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<SupplierItemDetailsDto> GetByIdAsync(string id)
        {
            try
            {
                var supplierItemDetailsService = await dalSupplierItemDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (supplierItemDetailsService == null)
                {
                    return new SupplierItemDetailsDto();
                }

                SupplierItemDetailsDto supplierItemDetailsServiceDto = new SupplierItemDetailsDto();
                supplierItemDetailsServiceDto.Id = supplierItemDetailsService.Id;
                supplierItemDetailsServiceDto.ItemDetailsName = supplierItemDetailsService.ItemDetailsName;
                supplierItemDetailsServiceDto.BrandId = supplierItemDetailsService.BrandId;
                supplierItemDetailsServiceDto.CreateDate = supplierItemDetailsService.CreateDate;
                supplierItemDetailsServiceDto.UpdateDate = supplierItemDetailsService.UpdateDate;
                supplierItemDetailsServiceDto.DeleteDate = supplierItemDetailsService.DeleteDate;
                supplierItemDetailsServiceDto.Valid = supplierItemDetailsService.Valid;
                return supplierItemDetailsServiceDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(SupplierItemDetailsUpdateDto updateDto)
        {
            try
            {
                var supplierItemDetailsService = await dalSupplierItemDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (supplierItemDetailsService == null)
                    throw new Exception("品项编号错误！");

                supplierItemDetailsService.BrandId = updateDto.BrandId;
                supplierItemDetailsService.ItemDetailsName = updateDto.ItemDetailsName;
                supplierItemDetailsService.UpdateDate = DateTime.Now;

                await dalSupplierItemDetailsService.UpdateAsync(supplierItemDetailsService, true);


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
                var supplierItemDetailsService = await dalSupplierItemDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (supplierItemDetailsService == null)
                    throw new Exception("品项编号错误");
                supplierItemDetailsService.Valid = false;
                supplierItemDetailsService.DeleteDate = DateTime.Now;

                await dalSupplierItemDetailsService.UpdateAsync(supplierItemDetailsService, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 根据品牌id获取品项
        /// </summary>
        /// <returns></returns>

        public async Task<List<BaseKeyValueDto>> GetValidByBrandIdAsync(string brandId)
        {
            var employee = from d in dalSupplierItemDetailsService.GetAll()
                           where d.Valid
                           && (d.BrandId == brandId)
                           select new BaseKeyValueDto
                           {
                               Key = d.Id,
                               Value = d.ItemDetailsName,
                           };
            return await employee.ToListAsync();

        }

    }
}
