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
using Fx.Amiya.Dto.WareHouse.OutWareHouse;

namespace Fx.Amiya.Service
{
    public class AmiyaOutWareHouseService : IAmiyaOutWareHouseService
    {
        private IDalAmiyaOutWareHouse dalAmiyaOutWareHouseService;
        public AmiyaOutWareHouseService(IDalAmiyaOutWareHouse dalAmiyaOutWareHouseService)
        {
            this.dalAmiyaOutWareHouseService = dalAmiyaOutWareHouseService;
        }



        public async Task<FxPageInfo<AmiyaOutWareHouseDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, string warehouseStorageRacksId, int pageNum, int pageSize)
        {
            try
            {
                var amiyaOutWareHouseInfo = from d in dalAmiyaOutWareHouseService.GetAll().Include(x => x.WareHouseInfo).ThenInclude(x => x.WareHouseNameManage).ThenInclude(x => x.AmiyaWareHouseStorageRacks)
                                            select d;
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    amiyaOutWareHouseInfo = from d in amiyaOutWareHouseInfo
                                            where d.CreateDate >= startrq && d.CreateDate < endrq
                                            select d;
                }
                var amiyaOutWareHouseService = from d in amiyaOutWareHouseInfo
                                               where (keyword == null || d.WareHouseInfo.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.WareHouseInfo.GoodsSourceId == wareHouseInfoId)
                                               && (string.IsNullOrEmpty(warehouseStorageRacksId) || d.WareHouseInfo.StorageRacksId == warehouseStorageRacksId)
                                               select new AmiyaOutWareHouseDto
                                               {
                                                   Id = d.Id,
                                                   WareHouseId = d.WareHouseId,
                                                   Unit=d.WareHouseInfo.Unit,
                                                   WareHouseName = d.WareHouseInfo.WareHouseNameManage.Name,
                                                   GoodsName = d.WareHouseInfo.GoodsName,
                                                   StorageRacksName = d.WareHouseInfo.WareHouseNameManage.AmiyaWareHouseStorageRacks.Where(x => x.Id == d.WareHouseInfo.StorageRacksId).FirstOrDefault().Name,
                                                   SinglePrice = d.SinglePrice,
                                                   Num = d.Num,
                                                   UseEmployee=d.UseEmployee.Name,
                                                   Department=d.Department.Name,
                                                   AllPrice = d.AllPrice,
                                                   CreateBy = d.CreateBy,
                                                   CreateByEmpName = d.Employee.Name,
                                                   CreateDate = d.CreateDate,
                                                   Remark = d.Remark
                                               };
                FxPageInfo<AmiyaOutWareHouseDto> amiyaOutWareHouseServicePageInfo = new FxPageInfo<AmiyaOutWareHouseDto>();
                amiyaOutWareHouseServicePageInfo.TotalCount = await amiyaOutWareHouseService.CountAsync();
                amiyaOutWareHouseServicePageInfo.List = await amiyaOutWareHouseService.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return amiyaOutWareHouseServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AmiyaOutWareHouseAddDto addDto)
        {
            try
            {
                AmiyaOutWarehouse amiyaOutWareHouseService = new AmiyaOutWarehouse();
                amiyaOutWareHouseService.Id = Guid.NewGuid().ToString();
                amiyaOutWareHouseService.WareHouseId = addDto.WareHouseId;
                amiyaOutWareHouseService.SinglePrice = addDto.SinglePrice;
                amiyaOutWareHouseService.Num = addDto.Num;
                amiyaOutWareHouseService.DepartmentId = addDto.DepartmentId;
                amiyaOutWareHouseService.EmployeeId = addDto.EmployeeId;
                amiyaOutWareHouseService.AllPrice = addDto.AllPrice;
                amiyaOutWareHouseService.CreateBy = addDto.CreateBy;
                amiyaOutWareHouseService.CreateDate = DateTime.Now;
                amiyaOutWareHouseService.Remark = addDto.Remark;

                await dalAmiyaOutWareHouseService.AddAsync(amiyaOutWareHouseService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AmiyaOutWareHouseDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaOutWareHouseService = await dalAmiyaOutWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == id);
                if (amiyaOutWareHouseService == null)
                {
                    return new AmiyaOutWareHouseDto();
                }

                AmiyaOutWareHouseDto amiyaOutWareHouseServiceDto = new AmiyaOutWareHouseDto();
                amiyaOutWareHouseServiceDto.Id = amiyaOutWareHouseService.Id;
                amiyaOutWareHouseServiceDto.SinglePrice = amiyaOutWareHouseService.SinglePrice;
                amiyaOutWareHouseServiceDto.Num = amiyaOutWareHouseService.Num;
                amiyaOutWareHouseServiceDto.AllPrice = amiyaOutWareHouseService.AllPrice;
                amiyaOutWareHouseServiceDto.WareHouseId = amiyaOutWareHouseService.WareHouseId;
                amiyaOutWareHouseServiceDto.Remark = amiyaOutWareHouseService.Remark;
                return amiyaOutWareHouseServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(AmiyaOutWareHouseUpdateDto updateDto)
        {
            try
            {
                var amiyaOutWareHouseService = await dalAmiyaOutWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaOutWareHouseService == null)
                    throw new Exception("出库编号错误！");
                amiyaOutWareHouseService.Id = updateDto.Id;
                amiyaOutWareHouseService.SinglePrice = updateDto.SinglePrice;
                amiyaOutWareHouseService.Num = updateDto.Num;
                amiyaOutWareHouseService.AllPrice = updateDto.AllPrice;
                amiyaOutWareHouseService.WareHouseId = updateDto.WareHouseId;
                amiyaOutWareHouseService.Remark = updateDto.Remark;
                await dalAmiyaOutWareHouseService.UpdateAsync(amiyaOutWareHouseService, true);


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
                var amiyaOutWareHouseService = await dalAmiyaOutWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == id);

                if (amiyaOutWareHouseService == null)
                    throw new Exception("出库编号错误");

                await dalAmiyaOutWareHouseService.DeleteAsync(amiyaOutWareHouseService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<AmiyaOutWareHouseDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId,string warehouseStorageRacksId)
        {
            try
            {
                var amiyaOutWareHouseInfo = from d in dalAmiyaOutWareHouseService.GetAll().Include(x => x.WareHouseInfo).ThenInclude(x => x.WareHouseNameManage).ThenInclude(x => x.AmiyaWareHouseStorageRacks)
                                            select d;
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    amiyaOutWareHouseInfo = from d in amiyaOutWareHouseInfo
                                            where d.CreateDate >= startrq && d.CreateDate < endrq
                                            select d;
                }
                var amiyaOutWareHouseService = from d in amiyaOutWareHouseInfo
                                               where (keyword == null || d.WareHouseInfo.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.WareHouseInfo.GoodsSourceId == wareHouseInfoId)
                                               && (string.IsNullOrEmpty(warehouseStorageRacksId) || d.WareHouseInfo.StorageRacksId == warehouseStorageRacksId)
                                               select new AmiyaOutWareHouseDto
                                               {
                                                   Id = d.Id,
                                                   WareHouseId = d.WareHouseId,
                                                   Unit = d.WareHouseInfo.Unit,
                                                   WareHouseName =d.WareHouseInfo.WareHouseNameManage.Name,
                                                   GoodsName = d.WareHouseInfo.GoodsName,
                                                   SinglePrice = d.SinglePrice,
                                                   Num = d.Num,
                                                   AllPrice = d.AllPrice,
                                                   StorageRacksName = d.WareHouseInfo.WareHouseNameManage.AmiyaWareHouseStorageRacks.Where(x => x.Id == d.WareHouseInfo.StorageRacksId).FirstOrDefault().Name,
                                                   CreateBy = d.CreateBy,
                                                   CreateByEmpName = d.Employee.Name,
                                                   CreateDate = d.CreateDate,
                                                   Remark = d.Remark,
                                                   Department=d.Department.Name,
                                                   UseEmployee=d.UseEmployee.Name
                                               };
                List<AmiyaOutWareHouseDto> amiyaOutWareHouseServicePageInfo = new List<AmiyaOutWareHouseDto>();
                amiyaOutWareHouseServicePageInfo = await amiyaOutWareHouseService.OrderByDescending(x => x.CreateDate).ToListAsync();
                return amiyaOutWareHouseServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
