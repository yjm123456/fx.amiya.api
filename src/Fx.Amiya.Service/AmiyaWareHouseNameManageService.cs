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
using Fx.Amiya.Dto.WareHouse.WareHouseNameManage;

namespace Fx.Amiya.Service
{
    public class AmiyaWareHouseNameManageService : IAmiyaWareHouseNameManageService
    {
        private IDalAmiyaWareHouseNameManage dalAmiyaWareHouseNameManageService;
        public AmiyaWareHouseNameManageService(IDalAmiyaWareHouseNameManage dalAmiyaWareHouseNameManageService)
        {
            this.dalAmiyaWareHouseNameManageService = dalAmiyaWareHouseNameManageService;
        }



        public async Task<FxPageInfo<AmiyaWareHouseNameManageDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var amiyaWareHouseNameManageService = from d in dalAmiyaWareHouseNameManageService.GetAll()
                                                      where (keyword == null || d.Name.Contains(keyword))
                                                      select new AmiyaWareHouseNameManageDto
                                                      {
                                                          Id = d.Id,
                                                          Name = d.Name,
                                                          Valid = d.Valid
                                                      };
                FxPageInfo<AmiyaWareHouseNameManageDto> amiyaWareHouseNameManageServicePageInfo = new FxPageInfo<AmiyaWareHouseNameManageDto>();
                amiyaWareHouseNameManageServicePageInfo.TotalCount = await amiyaWareHouseNameManageService.CountAsync();
                amiyaWareHouseNameManageServicePageInfo.List = await amiyaWareHouseNameManageService.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return amiyaWareHouseNameManageServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<List<AmiyaWareHouseNameBaseInfoDto>> GetIdAndNameAsync()
        {
            try
            {
                var amiyaWareHouseNameManageService = from d in dalAmiyaWareHouseNameManageService.GetAll()
                                                      where d.Valid == true
                                                      select new AmiyaWareHouseNameBaseInfoDto
                                                      {
                                                          Id = d.Id,
                                                          Name = d.Name
                                                      };
                var result = await amiyaWareHouseNameManageService.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddAsync(AmiyaWareHouseNameManageAddDto addDto)
        {
            try
            {
                AmiyaWareHouseNameManage amiyaWareHouseNameManageService = new AmiyaWareHouseNameManage();
                amiyaWareHouseNameManageService.Id = Guid.NewGuid().ToString();
                amiyaWareHouseNameManageService.Name = addDto.Name;
                amiyaWareHouseNameManageService.Valid = true;

                await dalAmiyaWareHouseNameManageService.AddAsync(amiyaWareHouseNameManageService, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<AmiyaWareHouseNameManageDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaWareHouseNameManageService = await dalAmiyaWareHouseNameManageService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (amiyaWareHouseNameManageService == null)
                {
                    return new AmiyaWareHouseNameManageDto();
                }

                AmiyaWareHouseNameManageDto amiyaWareHouseNameManageServiceDto = new AmiyaWareHouseNameManageDto();
                amiyaWareHouseNameManageServiceDto.Id = amiyaWareHouseNameManageService.Id;
                amiyaWareHouseNameManageServiceDto.Name = amiyaWareHouseNameManageService.Name;
                amiyaWareHouseNameManageServiceDto.Valid = amiyaWareHouseNameManageService.Valid;

                return amiyaWareHouseNameManageServiceDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(AmiyaWareHouseNameManageUpdateDto updateDto)
        {
            try
            {
                var amiyaWareHouseNameManageService = await dalAmiyaWareHouseNameManageService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaWareHouseNameManageService == null)
                    throw new Exception("仓库名称编号错误！");

                amiyaWareHouseNameManageService.Name = updateDto.Name;
                amiyaWareHouseNameManageService.Valid = updateDto.Valid;

                await dalAmiyaWareHouseNameManageService.UpdateAsync(amiyaWareHouseNameManageService, true);
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
                var amiyaWareHouseNameManageService = await dalAmiyaWareHouseNameManageService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (amiyaWareHouseNameManageService == null)
                    throw new Exception("仓库名称编号错误");

                await dalAmiyaWareHouseNameManageService.DeleteAsync(amiyaWareHouseNameManageService, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
