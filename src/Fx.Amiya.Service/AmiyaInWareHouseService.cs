using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Fx.Amiya.Dto.WareHouse.InWareHouse;

namespace Fx.Amiya.Service
{
    public class AmiyaInWareHouseService : IAmiyaInWareHouseService
    {
        private IDalAmiyaInWareHouse dalAmiyaInWareHouseService;
        public AmiyaInWareHouseService(IDalAmiyaInWareHouse dalAmiyaInWareHouseService)
        {
            this.dalAmiyaInWareHouseService = dalAmiyaInWareHouseService;
        }



        public async Task<FxPageInfo<AmiyaInWareHouseDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, string warehouseStorageRacksId, int pageNum, int pageSize)
        {
            try
            {
                var amiyaInWareHouseInfo = from d in dalAmiyaInWareHouseService.GetAll().Include(x => x.WareHouseInfo).ThenInclude(x => x.WareHouseNameManage).ThenInclude(x => x.AmiyaWareHouseStorageRacks)
                                           select d;
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    amiyaInWareHouseInfo = from d in amiyaInWareHouseInfo
                                           where d.CreateDate >= startrq && d.CreateDate < endrq
                                           select d;
                }
                var amiyaInWareHouseService = from d in amiyaInWareHouseInfo
                                              where (keyword == null || d.WareHouseInfo.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.WareHouseInfo.GoodsSourceId == wareHouseInfoId)
                                               && (string.IsNullOrEmpty(warehouseStorageRacksId) || d.WareHouseInfo.StorageRacksId == warehouseStorageRacksId)
                                              select new AmiyaInWareHouseDto
                                              {
                                                  Id = d.Id,
                                                  WareHouseId = d.WareHouseId,
                                                  Unit = d.WareHouseInfo.Unit,
                                                  WareHouseName = d.WareHouseInfo.WareHouseNameManage.Name,
                                                  StorageRacksName = d.WareHouseInfo.WareHouseNameManage.AmiyaWareHouseStorageRacks.Where(x => x.Id == d.WareHouseInfo.StorageRacksId).FirstOrDefault().Name,
                                                  GoodsName = d.WareHouseInfo.GoodsName,
                                                  SinglePrice = d.SinglePrice,
                                                  Num = d.Num,
                                                  AllPrice = d.AllPrice,
                                                  CreateBy = d.CreateBy,
                                                  CreateByEmpName = d.Employee.Name,
                                                  CreateDate = d.CreateDate,
                                                  Remark = d.Remark
                                              };
                FxPageInfo<AmiyaInWareHouseDto> amiyaInWareHouseServicePageInfo = new FxPageInfo<AmiyaInWareHouseDto>();
                amiyaInWareHouseServicePageInfo.TotalCount = await amiyaInWareHouseService.CountAsync();
                amiyaInWareHouseServicePageInfo.List = await amiyaInWareHouseService.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return amiyaInWareHouseServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AmiyaInWareHouseAddDto addDto)
        {
            try
            {
                AmiyaInWarehouse amiyaInWareHouseService = new AmiyaInWarehouse();
                amiyaInWareHouseService.Id = Guid.NewGuid().ToString();
                amiyaInWareHouseService.WareHouseId = addDto.WareHouseId;
                amiyaInWareHouseService.SinglePrice = addDto.SinglePrice;
                amiyaInWareHouseService.Num = addDto.Num;
                amiyaInWareHouseService.AllPrice = addDto.AllPrice;
                amiyaInWareHouseService.CreateBy = addDto.CreateBy;
                amiyaInWareHouseService.CreateDate = DateTime.Now;
                amiyaInWareHouseService.Remark = addDto.Remark;

                await dalAmiyaInWareHouseService.AddAsync(amiyaInWareHouseService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AmiyaInWareHouseDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaInWareHouseService = await dalAmiyaInWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == id);
                if (amiyaInWareHouseService == null)
                {
                    return new AmiyaInWareHouseDto();
                }

                AmiyaInWareHouseDto amiyaInWareHouseServiceDto = new AmiyaInWareHouseDto();
                amiyaInWareHouseServiceDto.Id = amiyaInWareHouseService.Id;
                amiyaInWareHouseServiceDto.SinglePrice = amiyaInWareHouseService.SinglePrice;
                amiyaInWareHouseServiceDto.Num = amiyaInWareHouseService.Num;
                amiyaInWareHouseServiceDto.AllPrice = amiyaInWareHouseService.AllPrice;
                amiyaInWareHouseServiceDto.WareHouseId = amiyaInWareHouseService.WareHouseId;
                amiyaInWareHouseServiceDto.Remark = amiyaInWareHouseService.Remark;
                return amiyaInWareHouseServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(AmiyaInWareHouseUpdateDto updateDto)
        {
            try
            {
                var amiyaInWareHouseService = await dalAmiyaInWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaInWareHouseService == null)
                    throw new Exception("入库编号错误！");
                amiyaInWareHouseService.Id = updateDto.Id;
                amiyaInWareHouseService.SinglePrice = updateDto.SinglePrice;
                amiyaInWareHouseService.Num = updateDto.Num;
                amiyaInWareHouseService.AllPrice = updateDto.AllPrice;
                amiyaInWareHouseService.WareHouseId = updateDto.WareHouseId;
                amiyaInWareHouseService.Remark = updateDto.Remark;
                await dalAmiyaInWareHouseService.UpdateAsync(amiyaInWareHouseService, true);


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
                var amiyaInWareHouseService = await dalAmiyaInWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == id);

                if (amiyaInWareHouseService == null)
                    throw new Exception("入库编号错误");

                await dalAmiyaInWareHouseService.DeleteAsync(amiyaInWareHouseService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<AmiyaInWareHouseDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId,string warehouseStorageRacksId)
        {
            try
            {
                var amiyaInWareHouseInfo = from d in dalAmiyaInWareHouseService.GetAll().Include(x => x.WareHouseInfo).ThenInclude(x => x.WareHouseNameManage).ThenInclude(x => x.AmiyaWareHouseStorageRacks)
                                           select d;
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    amiyaInWareHouseInfo = from d in amiyaInWareHouseInfo
                                           where d.CreateDate >= startrq && d.CreateDate < endrq
                                           select d;
                }
                var amiyaInWareHouseService = from d in amiyaInWareHouseInfo
                                              where (keyword == null || d.WareHouseInfo.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.WareHouseInfo.GoodsSourceId == wareHouseInfoId)
                                               && (string.IsNullOrEmpty(warehouseStorageRacksId) || d.WareHouseInfo.StorageRacksId == warehouseStorageRacksId)
                                              select new AmiyaInWareHouseDto
                                              {
                                                  Id = d.Id,
                                                  WareHouseId = d.WareHouseId,
                                                  Unit = d.WareHouseInfo.Unit,
                                                  WareHouseName = d.WareHouseInfo.WareHouseNameManage.Name,
                                                  GoodsName = d.WareHouseInfo.GoodsName,
                                                  StorageRacksName = d.WareHouseInfo.WareHouseNameManage.AmiyaWareHouseStorageRacks.Where(x => x.Id == d.WareHouseInfo.StorageRacksId).FirstOrDefault().Name,
                                                  SinglePrice = d.SinglePrice,
                                                  Num = d.Num,
                                                  AllPrice = d.AllPrice,
                                                  CreateBy = d.CreateBy,
                                                  CreateByEmpName = d.Employee.Name,
                                                  CreateDate = d.CreateDate,
                                                  Remark = d.Remark
                                              };
                List<AmiyaInWareHouseDto> amiyaInWareHouseServicePageInfo = new List<AmiyaInWareHouseDto>();
                amiyaInWareHouseServicePageInfo = await amiyaInWareHouseService.OrderByDescending(x => x.CreateDate).ToListAsync();
                return amiyaInWareHouseServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
