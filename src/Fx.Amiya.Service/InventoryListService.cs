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
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.Dto.WareHouse.InventoryList;

namespace Fx.Amiya.Service
{
    public class InventoryListService : IInventoryListService
    {
        private IDalInventoryList dalInventoryListService;
        public InventoryListService(IDalInventoryList dalInventoryListService)
        {
            this.dalInventoryListService = dalInventoryListService;
        }



        public async Task<FxPageInfo<InventoryListDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, int pageNum, int pageSize)
        {
            try
            {
                var inventoryList = from d in dalInventoryListService.GetAll()
                                    select d;
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    inventoryList = from d in inventoryList
                                    where d.CreateDate >= startrq && d.CreateDate < endrq
                                    select d;
                }
                var inventoryListService = from d in inventoryList
                                           where (keyword == null || d.WareHouseInfo.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.WareHouseInfo.GoodsSourceId == wareHouseInfoId)
                                           select new InventoryListDto
                                           {
                                               Id = d.Id,
                                               GoodsName = d.WareHouseInfo.GoodsName,
                                               Unit=d.WareHouseInfo.Unit,
                                               WareHouseName=d.WareHouseInfo.WareHouseNameManage.Name,
                                               InventoryState = d.InventoryState,
                                               InventoryStateText = ServiceClass.GetInventoryStateText(d.InventoryState),
                                               InventoryNum = d.InventoryNum,
                                               InventoryPrice = d.InventoryPrice,
                                               WareHouseId = d.WareHouseId,
                                               BeforeInventorySinglePrice = d.BeforeInventorySinglePrice,
                                               BeforeInventoryNum = d.BeforeInventoryNum,
                                               BeforeInventoryAllPrice = d.BeforeInventoryAllPrice,
                                               AfterInventoryAllPrice = d.AfterInventoryAllPrice,
                                               AfterInventorySinglePrice = d.AfterInventorySinglePrice,
                                               AfterInventoryNum = d.AfterInventoryNum,
                                               CreateBy = d.CreateBy,
                                               CreateByEmpName = d.Employee.Name,
                                               CreateDate = d.CreateDate,
                                               Remark = d.Remark
                                           };
                FxPageInfo<InventoryListDto> inventoryListServicePageInfo = new FxPageInfo<InventoryListDto>();
                inventoryListServicePageInfo.TotalCount = await inventoryListService.CountAsync();
                inventoryListServicePageInfo.List = await inventoryListService.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return inventoryListServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(InventoryListAddDto addDto)
        {
            try
            {
                InventoryList inventoryListService = new InventoryList();
                inventoryListService.Id = Guid.NewGuid().ToString();
                inventoryListService.WareHouseId = addDto.WareHouseId;
                inventoryListService.BeforeInventorySinglePrice = addDto.BeforeInventorySinglePrice;
                inventoryListService.BeforeInventoryNum = addDto.BeforeInventoryNum;
                inventoryListService.BeforeInventoryAllPrice = addDto.BeforeInventoryAllPrice;
                inventoryListService.AfterInventoryAllPrice = addDto.AfterInventoryAllPrice;
                inventoryListService.AfterInventoryNum = addDto.AfterInventoryNum;
                inventoryListService.AfterInventorySinglePrice = addDto.AfterInventorySinglePrice;
                inventoryListService.CreateBy = addDto.CreateBy;
                inventoryListService.CreateDate = DateTime.Now;
                inventoryListService.Remark = addDto.Remark;

                inventoryListService.InventoryNum = inventoryListService.AfterInventoryNum - inventoryListService.BeforeInventoryNum;
                inventoryListService.InventoryPrice = inventoryListService.AfterInventoryAllPrice - inventoryListService.BeforeInventoryAllPrice;
                if (inventoryListService.InventoryNum > 0)
                {
                    inventoryListService.InventoryState = (int)InventoryStatus.Profit;
                }
                if (inventoryListService.InventoryNum == 0)
                {
                    inventoryListService.InventoryState = (int)InventoryStatus.Normal;
                }
                if (inventoryListService.InventoryNum < 0)
                {
                    inventoryListService.InventoryState = (int)InventoryStatus.Loss;
                }
                await dalInventoryListService.AddAsync(inventoryListService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InventoryListDto> GetByIdAsync(string id)
        {
            try
            {
                var inventoryListService = await dalInventoryListService.GetAll().FirstOrDefaultAsync(e => e.Id == id);
                if (inventoryListService == null)
                {
                    return new InventoryListDto();
                }

                InventoryListDto inventoryListServiceDto = new InventoryListDto();
                inventoryListServiceDto.Id = inventoryListService.Id;
                inventoryListServiceDto.BeforeInventoryAllPrice = inventoryListService.BeforeInventoryAllPrice;
                inventoryListServiceDto.BeforeInventorySinglePrice = inventoryListService.BeforeInventorySinglePrice;
                inventoryListServiceDto.BeforeInventoryNum = inventoryListService.BeforeInventoryNum;
                inventoryListServiceDto.AfterInventoryAllPrice = inventoryListService.AfterInventoryAllPrice;
                inventoryListServiceDto.AfterInventorySinglePrice = inventoryListService.AfterInventorySinglePrice;
                inventoryListServiceDto.AfterInventoryNum = inventoryListService.AfterInventoryNum;
                inventoryListServiceDto.CreateBy = inventoryListService.CreateBy;
                inventoryListServiceDto.Remark = inventoryListService.Remark;
                inventoryListServiceDto.CreateDate = inventoryListService.CreateDate;


                return inventoryListServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(InventoryListUpdateDto updateDto)
        {
            try
            {
                var inventoryListService = await dalInventoryListService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (inventoryListService == null)
                    throw new Exception("盘库编号错误！");
                inventoryListService.Id = updateDto.Id;
                inventoryListService.BeforeInventoryAllPrice = updateDto.BeforeInventoryAllPrice;
                inventoryListService.BeforeInventorySinglePrice = updateDto.BeforeInventorySinglePrice;
                inventoryListService.BeforeInventoryNum = updateDto.BeforeInventoryNum;
                inventoryListService.AfterInventoryAllPrice = updateDto.AfterInventoryAllPrice;
                inventoryListService.AfterInventorySinglePrice = updateDto.AfterInventorySinglePrice;
                inventoryListService.AfterInventoryNum = updateDto.AfterInventoryNum;
                inventoryListService.Remark = updateDto.Remark;
                await dalInventoryListService.UpdateAsync(inventoryListService, true);


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
                var inventoryListService = await dalInventoryListService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (inventoryListService == null)
                    throw new Exception("盘库编号错误");

                await dalInventoryListService.DeleteAsync(inventoryListService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<InventoryListDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId)
        {
            try
            {
                var inventoryList = from d in dalInventoryListService.GetAll()
                                    select d;
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    inventoryList = from d in inventoryList
                                    where d.CreateDate >= startrq && d.CreateDate < endrq
                                    select d;
                }
                var inventoryListService = from d in inventoryList
                                           where (keyword == null || d.WareHouseInfo.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.WareHouseInfo.GoodsSourceId == wareHouseInfoId)
                                           select new InventoryListDto
                                           {
                                               Id = d.Id,
                                               GoodsName = d.WareHouseInfo.GoodsName,
                                               Unit = d.WareHouseInfo.Unit,
                                               WareHouseName = d.WareHouseInfo.WareHouseNameManage.Name,
                                               InventoryState = d.InventoryState,
                                               InventoryStateText = ServiceClass.GetInventoryStateText(d.InventoryState),
                                               InventoryNum = d.InventoryNum,
                                               InventoryPrice = d.InventoryPrice,
                                               WareHouseId = d.WareHouseId,
                                               BeforeInventorySinglePrice = d.BeforeInventorySinglePrice,
                                               BeforeInventoryNum = d.BeforeInventoryNum,
                                               BeforeInventoryAllPrice = d.BeforeInventoryAllPrice,
                                               AfterInventoryAllPrice = d.AfterInventoryAllPrice,
                                               AfterInventorySinglePrice = d.AfterInventorySinglePrice,
                                               AfterInventoryNum = d.AfterInventoryNum,
                                               CreateBy = d.CreateBy,
                                               CreateByEmpName = d.Employee.Name,
                                               CreateDate = d.CreateDate,
                                               Remark = d.Remark
                                           };
                List<InventoryListDto> inventoryListServicePageInfo = new List<InventoryListDto>();
                inventoryListServicePageInfo = await inventoryListService.OrderByDescending(x => x.CreateDate).ToListAsync();
                return inventoryListServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
