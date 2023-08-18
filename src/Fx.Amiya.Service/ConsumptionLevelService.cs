using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ConsumptionLevel;
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
    public class ConsumptionLevelService : IConsumptionLevelService
    {
        private IDalConsumptionLevel _dalConsumptionLevel;

        public ConsumptionLevelService(IDalConsumptionLevel dalConsumptionLevel)
        {
            _dalConsumptionLevel = dalConsumptionLevel;
        }

        public async Task<FxPageInfo<ConsumptionLevelDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var consumptionLevel = from d in _dalConsumptionLevel.GetAll()
                             where keyword == null || d.Name.Contains(keyword) 
                             select new ConsumptionLevelDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 MinPrice = d.MinPrice,
                                 MaxPrice = d.MaxPrice,
                                 Valid = d.Valid
                             };

                FxPageInfo<ConsumptionLevelDto> expressPageInfo = new FxPageInfo<ConsumptionLevelDto>();
                expressPageInfo.TotalCount = await consumptionLevel.CountAsync();
                expressPageInfo.List = await consumptionLevel.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return expressPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(ConsumptionLevelAddDto addDto)
        {
            try
            {
                ConsumptionLevel consumptionLevel = new ConsumptionLevel();
                consumptionLevel.Id = Guid.NewGuid().ToString();
                consumptionLevel.Name = addDto.Name;
                consumptionLevel.MinPrice = addDto.MinPrice;
                consumptionLevel.MaxPrice = addDto.MaxPrice;
                consumptionLevel.Valid = true;

                await _dalConsumptionLevel.AddAsync(consumptionLevel, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<ConsumptionLevelIdAndNameDto>> GetIdAndNames()
        {
            try
            {
                var consumptionLevel = from d in _dalConsumptionLevel.GetAll()
                              where d.Valid==true
                              select new ConsumptionLevelIdAndNameDto
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };
                return consumptionLevel.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<ConsumptionLevelDto> GetByIdAsync(string id)
        {
            try
            {
                var consumptionLevel = await _dalConsumptionLevel.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (consumptionLevel == null)
                {
                    return new ConsumptionLevelDto() {
                        Id = "",
                        Name = "",
                        Valid=false
                    };
                }

                ConsumptionLevelDto expressDto = new ConsumptionLevelDto();
                expressDto.Id = consumptionLevel.Id;
                expressDto.Name = consumptionLevel.Name;
                expressDto.MinPrice = consumptionLevel.MinPrice;
                expressDto.MaxPrice = consumptionLevel.MaxPrice;
                expressDto.Valid = consumptionLevel.Valid;

                return expressDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(ConsumptionLevelUpdateDto updateDto)
        {
            try
            {
                var consumptionLevel = await _dalConsumptionLevel.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (consumptionLevel == null)
                    throw new Exception("消费等级编号错误！");

                consumptionLevel.Name = updateDto.Name;
                consumptionLevel.MinPrice = updateDto.MinPrice;
                consumptionLevel.MaxPrice = updateDto.MaxPrice;
                consumptionLevel.Valid = updateDto.Valid;

                await _dalConsumptionLevel.UpdateAsync(consumptionLevel, true);
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
                var consumptionLevel = await _dalConsumptionLevel.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (consumptionLevel == null)
                    throw new Exception("消费等级编号错误");

                await _dalConsumptionLevel.DeleteAsync(consumptionLevel, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
