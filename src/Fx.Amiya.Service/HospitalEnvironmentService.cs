using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalEnvironment;
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
    public class HospitalEnvironmentService : IHospitalEnvironmentService
    {
        private IDalHospitalEnvironment _dalHospitalEnvironment;

        public HospitalEnvironmentService(IDalHospitalEnvironment dalHospitalEnvironment)
        {
            _dalHospitalEnvironment = dalHospitalEnvironment;
        }

        public async Task<FxPageInfo<HospitalEnvironmentDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var hospitalEnvironment = from d in _dalHospitalEnvironment.GetAll()
                             where keyword == null || d.Name.Contains(keyword) 
                             select new HospitalEnvironmentDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };

                FxPageInfo<HospitalEnvironmentDto> expressPageInfo = new FxPageInfo<HospitalEnvironmentDto>();
                expressPageInfo.TotalCount = await hospitalEnvironment.CountAsync();
                expressPageInfo.List = await hospitalEnvironment.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return expressPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(HospitalEnvironmentAddDto addDto)
        {
            try
            {
                HospitalEnvironment hospitalEnvironment = new HospitalEnvironment();
                hospitalEnvironment.Id = Guid.NewGuid().ToString();
                hospitalEnvironment.Name = addDto.Name;
                hospitalEnvironment.Valid = true;

                await _dalHospitalEnvironment.AddAsync(hospitalEnvironment, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<HospitalEnvironmentIdAndNameDto>> GetIdAndNames()
        {
            try
            {
                var hospitalEnvironment = from d in _dalHospitalEnvironment.GetAll()
                              where d.Valid==true
                              select new HospitalEnvironmentIdAndNameDto
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };
                return hospitalEnvironment.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<HospitalEnvironmentDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalEnvironment = await _dalHospitalEnvironment.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (hospitalEnvironment == null)
                {
                    return new HospitalEnvironmentDto() {
                        Id = "",
                        Name = "",
                        Valid=false
                    };
                }

                HospitalEnvironmentDto expressDto = new HospitalEnvironmentDto();
                expressDto.Id = hospitalEnvironment.Id;
                expressDto.Name = hospitalEnvironment.Name;
                expressDto.Valid = hospitalEnvironment.Valid;

                return expressDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(HospitalEnvironmentUpdateDto updateDto)
        {
            try
            {
                var hospitalEnvironment = await _dalHospitalEnvironment.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalEnvironment == null)
                    throw new Exception("医院环境编号错误！");

                hospitalEnvironment.Name = updateDto.Name;
                hospitalEnvironment.Valid = updateDto.Valid;

                await _dalHospitalEnvironment.UpdateAsync(hospitalEnvironment, true);
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
                var hospitalEnvironment = await _dalHospitalEnvironment.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalEnvironment == null)
                    throw new Exception("医院环境编号错误");

                await _dalHospitalEnvironment.DeleteAsync(hospitalEnvironment, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
