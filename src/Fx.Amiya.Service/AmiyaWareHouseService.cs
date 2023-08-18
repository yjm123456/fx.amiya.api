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
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.InWareHouse;

namespace Fx.Amiya.Service
{
    public class AmiyaWareHouseService : IAmiyaWareHouseService
    {
        private IDalAmiyaWareHouse dalAmiyaWareHouseService;
        private IInventoryListService inventoryListService;
        private IUnitOfWork unitOfWork;
        private IAmiyaOutWareHouseService amiyaOutWareHouseService;
        private IAmiyaInWareHouseService amiyaInWareHouseService;

        public AmiyaWareHouseService(IDalAmiyaWareHouse dalAmiyaWareHouseService,
            IInventoryListService inventoryListService,
            IAmiyaInWareHouseService inWareHouseService,
            IAmiyaOutWareHouseService amiyaOutWareHouseService,
            IUnitOfWork unitofWork)
        {
            this.dalAmiyaWareHouseService = dalAmiyaWareHouseService;
            this.inventoryListService = inventoryListService;
            this.amiyaOutWareHouseService = amiyaOutWareHouseService;
            this.amiyaInWareHouseService = inWareHouseService;
            this.unitOfWork = unitofWork;
        }



        public async Task<FxPageInfo<AmiyaWareHouseDto>> GetListWithPageAsync(string keyword, string wareHouseInfoId, string warehouseStorageRacksId, int pageNum, int pageSize)
        {
            try
            {
                var amiyaWareHouseService = from d in dalAmiyaWareHouseService.GetAll().Include(x => x.WareHouseNameManage).ThenInclude(x => x.AmiyaWareHouseStorageRacks)
                                            where (keyword == null || d.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.GoodsSourceId == wareHouseInfoId)
                                               && (string.IsNullOrEmpty(warehouseStorageRacksId) ||d.StorageRacksId == warehouseStorageRacksId)
                                            select new AmiyaWareHouseDto
                                            {
                                                Id = d.Id,
                                                Unit = d.Unit,
                                                GoodsName = d.GoodsName,
                                                GoodsSourceName = d.WareHouseNameManage.Name,
                                                StorageRacks = d.WareHouseNameManage.AmiyaWareHouseStorageRacks.Where(x => x.Id == d.StorageRacksId).FirstOrDefault().Name,
                                                SinglePrice = d.SinglePrice,
                                                Amount = d.Amount,
                                                TotalPrice = d.TotalPrice,
                                            };
                FxPageInfo<AmiyaWareHouseDto> amiyaWareHouseServicePageInfo = new FxPageInfo<AmiyaWareHouseDto>();
                amiyaWareHouseServicePageInfo.TotalCount = await amiyaWareHouseService.CountAsync();
                amiyaWareHouseServicePageInfo.List = await amiyaWareHouseService.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return amiyaWareHouseServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<AmiyaWareHouseDto>> ExportListAsync(string keyword, string wareHouseInfoId, string warehouseStorageRacksId)
        {
            try
            {
                var amiyaWareHouseService = from d in dalAmiyaWareHouseService.GetAll().Include(x=>x.WareHouseNameManage).ThenInclude(x=>x.AmiyaWareHouseStorageRacks)
                                            where (keyword == null || d.GoodsName.Contains(keyword))
                                               && (string.IsNullOrEmpty(wareHouseInfoId) || d.GoodsSourceId == wareHouseInfoId)
                                               && (string.IsNullOrEmpty(warehouseStorageRacksId) || d.StorageRacksId == warehouseStorageRacksId)
                                            select new AmiyaWareHouseDto
                                            {
                                                Id = d.Id,
                                                Unit = d.Unit,
                                                GoodsName = d.GoodsName,
                                                GoodsSourceName = d.WareHouseNameManage.Name,
                                                StorageRacks = d.WareHouseNameManage.AmiyaWareHouseStorageRacks.Where(x => x.Id == d.StorageRacksId).FirstOrDefault().Name,
                                                SinglePrice = d.SinglePrice,
                                                Amount = d.Amount,
                                                TotalPrice = d.TotalPrice,
                                            };
                List<AmiyaWareHouseDto> amiyaWareHouseServicePageInfo = new List<AmiyaWareHouseDto>();
                amiyaWareHouseServicePageInfo = await amiyaWareHouseService.ToListAsync();
                return amiyaWareHouseServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddAsync(AmiyaWareHouseAddDto addDto)
        {
            try
            {
                AmiyaWareHouse amiyaWareHouseService = new AmiyaWareHouse();
                amiyaWareHouseService.Id = Guid.NewGuid().ToString();
                amiyaWareHouseService.Unit = addDto.Unit;
                amiyaWareHouseService.GoodsName = addDto.GoodsName;
                amiyaWareHouseService.GoodsSourceId = addDto.GoodsSourceId;
                amiyaWareHouseService.StorageRacksId = addDto.StorageRacksId;
                amiyaWareHouseService.SinglePrice = addDto.SinglePrice;
                amiyaWareHouseService.Amount = addDto.Amount;
                amiyaWareHouseService.TotalPrice = addDto.TotalPrice;

                await dalAmiyaWareHouseService.AddAsync(amiyaWareHouseService, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<AmiyaWareHouseDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaWareHouseService = await dalAmiyaWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == id);
                if (amiyaWareHouseService == null)
                {
                    return new AmiyaWareHouseDto();
                }

                AmiyaWareHouseDto amiyaWareHouseServiceDto = new AmiyaWareHouseDto();
                amiyaWareHouseServiceDto.Id = amiyaWareHouseService.Id;
                amiyaWareHouseServiceDto.Unit = amiyaWareHouseService.Unit;
                amiyaWareHouseServiceDto.GoodsName = amiyaWareHouseService.GoodsName;
                amiyaWareHouseServiceDto.GoodsSourceId = amiyaWareHouseService.GoodsSourceId;
                amiyaWareHouseServiceDto.SinglePrice = amiyaWareHouseService.SinglePrice;
                amiyaWareHouseServiceDto.StorageRacksId = amiyaWareHouseService.StorageRacksId;
                amiyaWareHouseServiceDto.Amount = amiyaWareHouseService.Amount;
                amiyaWareHouseServiceDto.TotalPrice = amiyaWareHouseService.TotalPrice;


                return amiyaWareHouseServiceDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(AmiyaWareHouseUpdateDto updateDto)
        {
            try
            {
                var amiyaWareHouseService = await dalAmiyaWareHouseService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaWareHouseService == null)
                    throw new Exception("仓库编号错误！");

                amiyaWareHouseService.Unit = updateDto.Unit;
                amiyaWareHouseService.GoodsName = updateDto.GoodsName;
                amiyaWareHouseService.GoodsSourceId = updateDto.GoodsSourceId;
                amiyaWareHouseService.StorageRacksId = updateDto.StorageRacksId;

                await dalAmiyaWareHouseService.UpdateAsync(amiyaWareHouseService, true);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task InventoryWareHouseAsync(AmiyaWareHouseUpdateDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var amiyaWareHouseService = await dalAmiyaWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaWareHouseService == null)
                    throw new Exception("仓库编号错误！");
                InventoryListAddDto inventoryListAddDto = new InventoryListAddDto();
                inventoryListAddDto.WareHouseId = amiyaWareHouseService.Id;
                inventoryListAddDto.BeforeInventorySinglePrice = amiyaWareHouseService.SinglePrice;
                inventoryListAddDto.BeforeInventoryAllPrice = amiyaWareHouseService.TotalPrice;
                inventoryListAddDto.BeforeInventoryNum = amiyaWareHouseService.Amount;
                inventoryListAddDto.AfterInventorySinglePrice = amiyaWareHouseService.SinglePrice;
                inventoryListAddDto.AfterInventorySinglePrice = updateDto.SinglePrice.Value;
                inventoryListAddDto.AfterInventoryNum = updateDto.Amount.Value;
                inventoryListAddDto.AfterInventoryAllPrice = updateDto.TotalPrice.Value;
                inventoryListAddDto.CreateBy = updateDto.CreateBy;
                inventoryListAddDto.Remark = updateDto.Remark;
                await inventoryListService.AddAsync(inventoryListAddDto);

                amiyaWareHouseService.SinglePrice = updateDto.SinglePrice.Value;
                amiyaWareHouseService.Amount = updateDto.Amount.Value;
                amiyaWareHouseService.TotalPrice = updateDto.TotalPrice.Value;

                await dalAmiyaWareHouseService.UpdateAsync(amiyaWareHouseService, true);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task OutWareHouseAsync(AmiyaWareHouseUpdateDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var amiyaWareHouseService = await dalAmiyaWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaWareHouseService == null)
                    throw new Exception("仓库编号错误！");
                if (amiyaWareHouseService.Amount - updateDto.Amount < 0)
                { throw new Exception("出库数量不能大于库存数量，请重新输入！"); }
                AmiyaOutWareHouseAddDto outWarehouseAddDto = new AmiyaOutWareHouseAddDto();
                outWarehouseAddDto.WareHouseId = amiyaWareHouseService.Id;
                outWarehouseAddDto.SinglePrice = amiyaWareHouseService.SinglePrice;
                outWarehouseAddDto.Num = updateDto.Amount.Value;
                outWarehouseAddDto.AllPrice = updateDto.TotalPrice.Value;
                outWarehouseAddDto.CreateBy = updateDto.CreateBy;
                outWarehouseAddDto.EmployeeId = updateDto.EmployeeId;
                outWarehouseAddDto.DepartmentId = updateDto.DepartmentId;
                outWarehouseAddDto.Remark = updateDto.Remark;
                await amiyaOutWareHouseService.AddAsync(outWarehouseAddDto);

                amiyaWareHouseService.Amount -= updateDto.Amount.Value;
                amiyaWareHouseService.TotalPrice -= updateDto.TotalPrice.Value;

                await dalAmiyaWareHouseService.UpdateAsync(amiyaWareHouseService, true);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task InWareHouseAsync(AmiyaWareHouseUpdateDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var amiyaWareHouseService = await dalAmiyaWareHouseService.GetAll().FirstOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaWareHouseService == null)
                    throw new Exception("仓库编号错误！");
                AmiyaInWareHouseAddDto outWarehouseAddDto = new AmiyaInWareHouseAddDto();
                outWarehouseAddDto.WareHouseId = amiyaWareHouseService.Id;
                outWarehouseAddDto.SinglePrice = updateDto.SinglePrice.Value;
                outWarehouseAddDto.Num = updateDto.Amount.Value;
                outWarehouseAddDto.AllPrice = updateDto.TotalPrice.Value;
                outWarehouseAddDto.CreateBy = updateDto.CreateBy;
                outWarehouseAddDto.Remark = updateDto.Remark;
                await amiyaInWareHouseService.AddAsync(outWarehouseAddDto);

                amiyaWareHouseService.Amount += updateDto.Amount.Value;
                amiyaWareHouseService.TotalPrice += updateDto.TotalPrice.Value;
                amiyaWareHouseService.SinglePrice = (amiyaWareHouseService.TotalPrice / amiyaWareHouseService.Amount);
                await dalAmiyaWareHouseService.UpdateAsync(amiyaWareHouseService, true);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task DeleteAsync(string id)
        {
            try
            {
                var amiyaWareHouseService = await dalAmiyaWareHouseService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (amiyaWareHouseService == null)
                    throw new Exception("仓库编号错误");

                await dalAmiyaWareHouseService.DeleteAsync(amiyaWareHouseService, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
