using Fx.Amiya.Dto.HospitalPosition;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;

namespace Fx.Amiya.Service
{
    public class HospitalPositionInfoService : IHospitalPositionInfoService
    {
        public IDalHospitalPositionInfo dalHospitalPositionInfo;
        public HospitalPositionInfoService(IDalHospitalPositionInfo dalHospitalPositionInfo)
        {
            this.dalHospitalPositionInfo = dalHospitalPositionInfo;
        }



        public async Task<List<HospitalPositionInfoDto>> GetListAsync()
        {
            try
            {
                var position = from d in dalHospitalPositionInfo.GetAll()
                               select new HospitalPositionInfoDto
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   CreateDate = d.CreateDate,
                                   UpdateDate = d.UpdateDate,
                                   UpdateBy = d.UpdateBy,
                                   UpdateName = d.UpdateByAmiyaEmployee.Name
                               };
                return await position.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddAsync(AddHospitalPositionInfoDto addDto)
        {
            try
            {
                HospitalPositionInfo positionInfo = new HospitalPositionInfo();
                positionInfo.Name = addDto.Name;
                positionInfo.CreateDate = DateTime.Now;

                await dalHospitalPositionInfo.AddAsync(positionInfo, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<HospitalPositionInfoDto> GetByIdAsync(int id)
        {
            try
            {
                var position = await dalHospitalPositionInfo.GetAll()
                    .Include(e => e.UpdateByAmiyaEmployee)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (position == null)
                    throw new Exception("职位编号错误");

                HospitalPositionInfoDto positionDto = new HospitalPositionInfoDto();
                positionDto.Id = position.Id;
                positionDto.Name = position.Name;
                positionDto.CreateDate = position.CreateDate;
                positionDto.UpdateBy = position.UpdateBy;
                positionDto.UpdateDate = position.UpdateDate;
                positionDto.UpdateName = position.UpdateByAmiyaEmployee?.Name;

                return positionDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        public async Task UpdateAsync(UpdateHospitalPositionInfoDto updateDto, int employeeId)
        {
            try
            {
                var position = await dalHospitalPositionInfo.GetAll()
                    .SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (position == null)
                    throw new Exception("职位编号错误");

                position.Name = updateDto.Name;
                position.UpdateBy = employeeId;
                position.UpdateDate = DateTime.Now;

                await dalHospitalPositionInfo.UpdateAsync(position, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var position = await dalHospitalPositionInfo.GetAll()
                    .Include(e => e.HospitalEmployeeList)
                   .SingleOrDefaultAsync(e => e.Id == id);

                if (position.HospitalEmployeeList.Count > 0)
                    throw new Exception("有该职位的员工，不能删除");

                await dalHospitalPositionInfo.DeleteAsync(position, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
