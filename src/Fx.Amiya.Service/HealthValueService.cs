using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.HealthValue;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HealthValueService : IHealthValueService
    {
        private readonly IDalHealthValue dalHealthValue;

        public HealthValueService(IDalHealthValue dalHealthValue)
        {
            this.dalHealthValue = dalHealthValue;
        }

        public async Task AddAsync(AddHealthValueDto addHealthValueDto)
        {
            var result = dalHealthValue.GetAll().Where(e => e.Code == addHealthValueDto.Code).SingleOrDefault();
            if (result != null)
            {
                throw new Exception("编码重复！");
            }
            HealthValue healthValue = new HealthValue();
            healthValue.Id = Guid.NewGuid().ToString().Replace("-", "");
            healthValue.Name = addHealthValueDto.Name;
            healthValue.Code = addHealthValueDto.Code;
            healthValue.Value = addHealthValueDto.Value;
            healthValue.CreateDate = DateTime.Now;
            healthValue.Valid = true;
            await dalHealthValue.AddAsync(healthValue, true);
        }

        public async Task DeleteAsync(string id)
        {
            var healthValue = dalHealthValue.GetAll().Where(e => e.Id == id).SingleOrDefault();
            if (healthValue == null) throw new Exception("健康值编号错误！");
            healthValue.Valid = false;
            await dalHealthValue.UpdateAsync(healthValue, true);
        }
        /// <summary>
        /// 根据编码获取健康值
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<decimal> GetValueByCode(string code)
        {
            var healthValue = dalHealthValue.GetAll().Where(e => e.Code == code).SingleOrDefault();
            if (healthValue == null)
            {
                return 0m;
            }
            else
            {
                return healthValue.Value;
            }
        }

        public async Task<HealthValueDto> GetByIdAsync(string id)
        {
            var healthValue = dalHealthValue.GetAll().Where(e => e.Id == id).SingleOrDefault();
            if (healthValue == null) throw new Exception("健康值编号错误！");
            HealthValueDto healthValueDto = new HealthValueDto();
            healthValueDto.Id = healthValue.Id;
            healthValueDto.Name = healthValue.Name;
            healthValueDto.Code = healthValue.Code;
            healthValueDto.Value = healthValue.Value;
            healthValueDto.Valid = healthValue.Valid;
            return healthValueDto;
        }

        public async Task<FxPageInfo<HealthValueDto>> GetListWithPageAsync(bool? valid, string keyWord, int pageSize, int pageNum)
        {
            var list = dalHealthValue.GetAll()
                .Where(e => string.IsNullOrEmpty(keyWord) || e.Name.Contains(keyWord) || e.Code.Contains(keyWord))
                .Where(e => !valid.HasValue || e.Valid == valid)
                .Select(e => new HealthValueDto
                {
                    Name = e.Name,
                    Code = e.Code,
                    Value = e.Value,
                    Valid = e.Valid,
                    Id = e.Id
                });
            FxPageInfo<HealthValueDto> fxPageInfo = new FxPageInfo<HealthValueDto>();
            fxPageInfo.TotalCount = list.Count();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;

        }

        public async Task UpdateAsync(UpdateHealthValueDto updateHealthValueDto)
        {
            var result = dalHealthValue.GetAll().Where(e => e.Id != updateHealthValueDto.Id && e.Code == updateHealthValueDto.Code).FirstOrDefault();
            if (result != null) throw new Exception("编码重复！");
            var healthValue = dalHealthValue.GetAll().Where(e => e.Id == updateHealthValueDto.Id).SingleOrDefault();
            if (healthValue == null) throw new Exception("编号错误！");
            healthValue.Name = updateHealthValueDto.Name;
            healthValue.Code = updateHealthValueDto.Code;
            healthValue.Value = updateHealthValueDto.Value;
            healthValue.Valid = updateHealthValueDto.Valid;
            healthValue.UpdateDate = DateTime.Now;
            await dalHealthValue.UpdateAsync(healthValue, true);
        }

        public async Task<List<BaseKeyValueAndPercentDto>> GetValidListAsync()
        {
            var list = dalHealthValue.GetAll()
                .Where(e => e.Valid == true)
                .Select(e => new BaseKeyValueAndPercentDto
                {
                    Key = e.Code,
                    Value = e.Name,
                    Rate = e.Value,
                });
            return list.ToList();

        }
    }
}
