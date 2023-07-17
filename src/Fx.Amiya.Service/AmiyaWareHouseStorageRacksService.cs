using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Output;
using Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Input;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class AmiyaWareHouseStorageRacksService : IAmiyaWareHouseStorageRacksService
    {
        private IDalAmiyaWareHouseStorageRacks dalAmiyaWareHouseStorageRacksService;

        public AmiyaWareHouseStorageRacksService(IDalAmiyaWareHouseStorageRacks dalAmiyaWareHouseStorageRacksService)
        {
            this.dalAmiyaWareHouseStorageRacksService = dalAmiyaWareHouseStorageRacksService;
        }



        public async Task<FxPageInfo<AmiyaWareHouseStorageRacksDto>> GetListWithPageAsync(QueryAmiyaWareHouseStorageRacksDto query)
        {
            try
            {
                var amiyaWareHouseStorageRacksService = from d in dalAmiyaWareHouseStorageRacksService.GetAll()
                                                        where (query.KeyWord == null || d.Name.Contains(query.KeyWord))
                                                           && (string.IsNullOrEmpty(query.WarehouseId) || d.WareHouseId == query.WarehouseId)
                                                           && (!query.Valid.HasValue || d.Valid == query.Valid)
                                                        select new AmiyaWareHouseStorageRacksDto
                                                        {
                                                            Id = d.Id,
                                                            WareHouseId = d.WareHouseId,
                                                            WareHouseName = d.WareHouseNameManage.Name,
                                                            CreateDate = d.CreateDate,
                                                            CreateBy = d.CreateBy,
                                                            CreateByEmpName=d.AmiyaEmployee.Name,
                                                            Valid = d.Valid,
                                                            DeleteDate = d.DeleteDate,
                                                        };
                FxPageInfo<AmiyaWareHouseStorageRacksDto> amiyaWareHouseStorageRacksServicePageInfo = new FxPageInfo<AmiyaWareHouseStorageRacksDto>();
                amiyaWareHouseStorageRacksServicePageInfo.TotalCount = await amiyaWareHouseStorageRacksService.CountAsync();
                amiyaWareHouseStorageRacksServicePageInfo.List = await amiyaWareHouseStorageRacksService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                return amiyaWareHouseStorageRacksServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AmiyaWareHouseStorageRacksAddDto addDto)
        {
            try
            {
                AmiyaWareHouseStorageRacks amiyaWareHouseStorageRacksService = new AmiyaWareHouseStorageRacks();
                amiyaWareHouseStorageRacksService.Id = Guid.NewGuid().ToString();
                amiyaWareHouseStorageRacksService.Name = addDto.Name;
                amiyaWareHouseStorageRacksService.WareHouseId = addDto.WareHouseId;
                amiyaWareHouseStorageRacksService.CreateBy = addDto.CreateBy;
                amiyaWareHouseStorageRacksService.CreateDate = DateTime.Now;
                amiyaWareHouseStorageRacksService.Valid = true;

                await dalAmiyaWareHouseStorageRacksService.AddAsync(amiyaWareHouseStorageRacksService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AmiyaWareHouseStorageRacksDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaWareHouseStorageRacksService = await dalAmiyaWareHouseStorageRacksService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (amiyaWareHouseStorageRacksService == null)
                {
                    return new AmiyaWareHouseStorageRacksDto();
                }

                AmiyaWareHouseStorageRacksDto amiyaWareHouseStorageRacksServiceDto = new AmiyaWareHouseStorageRacksDto();
                amiyaWareHouseStorageRacksServiceDto.Id = amiyaWareHouseStorageRacksService.Id;
                amiyaWareHouseStorageRacksServiceDto.Name = amiyaWareHouseStorageRacksService.Name;
                amiyaWareHouseStorageRacksServiceDto.WareHouseId = amiyaWareHouseStorageRacksService.WareHouseId;
                amiyaWareHouseStorageRacksServiceDto.CreateBy = amiyaWareHouseStorageRacksService.CreateBy;
                amiyaWareHouseStorageRacksServiceDto.CreateDate = amiyaWareHouseStorageRacksService.CreateDate;
                amiyaWareHouseStorageRacksServiceDto.UpdateDate = amiyaWareHouseStorageRacksService.UpdateDate;
                amiyaWareHouseStorageRacksServiceDto.DeleteDate = amiyaWareHouseStorageRacksService.DeleteDate;
                amiyaWareHouseStorageRacksServiceDto.Valid = amiyaWareHouseStorageRacksService.Valid;
                return amiyaWareHouseStorageRacksServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(AmiyaWareHouseStorageRacksUpdateDto updateDto)
        {
            try
            {
                var amiyaWareHouseStorageRacksService = await dalAmiyaWareHouseStorageRacksService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaWareHouseStorageRacksService == null)
                    throw new Exception("货架编号错误！");

                amiyaWareHouseStorageRacksService.WareHouseId = updateDto.WareHouseId;
                amiyaWareHouseStorageRacksService.Name = updateDto.Name;
                amiyaWareHouseStorageRacksService.UpdateDate = DateTime.Now;

                await dalAmiyaWareHouseStorageRacksService.UpdateAsync(amiyaWareHouseStorageRacksService, true);


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
                var amiyaWareHouseStorageRacksService = await dalAmiyaWareHouseStorageRacksService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (amiyaWareHouseStorageRacksService == null)
                    throw new Exception("货架编号错误");
                amiyaWareHouseStorageRacksService.Valid = false;
                amiyaWareHouseStorageRacksService.DeleteDate = DateTime.Now;

                await dalAmiyaWareHouseStorageRacksService.UpdateAsync(amiyaWareHouseStorageRacksService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 根据仓库id获取货架
        /// </summary>
        /// <returns></returns>

        public async Task<List<BaseKeyValueDto>> GetValidByWareHouseIdAsync(string warehouseId)
        {
            var employee = from d in dalAmiyaWareHouseStorageRacksService.GetAll()
                           where d.Valid
                           && (d.WareHouseId == warehouseId)
                           select new BaseKeyValueDto
                           {
                               Key = d.Id,
                               Value = d.Name,
                           };
            return await employee.ToListAsync();

        }

    }
}
