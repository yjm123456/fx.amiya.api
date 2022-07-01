using Fx.Amiya.Dto.AmiyaPositionInfo;
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
  public  class AmiyaPositionInfoService: IAmiyaPositionInfoService
    {
        private IDalAmiyaPositionInfo dalAmiyaPositionInfo;
        private IDalAmiyaPositionPermission _dalAmiyaPositionPermission;

        public AmiyaPositionInfoService(IDalAmiyaPositionInfo dalAmiyaPositionInfo,IDalAmiyaPositionPermission dalAmiyaPositionPermission)
        {
            this.dalAmiyaPositionInfo = dalAmiyaPositionInfo;
            _dalAmiyaPositionPermission = dalAmiyaPositionPermission;
        }


        public async Task<List<AmiyaPositionInfoDto>> GetListAsync()
        {
            try 
            {
                var position = from d in dalAmiyaPositionInfo.GetAll()
                               select new AmiyaPositionInfoDto
                               {
                                   Id=d.Id,
                                   Name=d.Name,
                                   CreateDate=d.CreateDate,
                                   UpdateDate=d.UpdateDate,
                                   UpdateBy=d.UpdateBy,
                                   UpdateName=d.UpdateByAmiyaEmployee.Name,
                                   IsDirector=d.IsDirector,
                                   DepartmentId=d.DepartmentId,
                                   DepartmentName=d.AmiyaDepartment.Name
                               };
                return await position.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddAmiyaPositionInfoDto addDto)
        {
            try
            {
                AmiyaPositionInfo positionInfo = new AmiyaPositionInfo();
                positionInfo.Name = addDto.Name;
                positionInfo.CreateDate = DateTime.Now;
                positionInfo.DepartmentId = addDto.DepartmentId;
                positionInfo.IsDirector = addDto.IsDirector;
               await dalAmiyaPositionInfo.AddAsync(positionInfo,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<AmiyaPositionInfoDto> GetByIdAsync(int id)
        {
            try
            {
                var position = await dalAmiyaPositionInfo.GetAll()
                    .Include(e=>e.UpdateByAmiyaEmployee)
                    .Include(e=>e.AmiyaDepartment)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (position == null)
                    throw new Exception("职位编号错误");

                AmiyaPositionInfoDto positionDto = new AmiyaPositionInfoDto();
                positionDto.Id = position.Id;
                positionDto.Name = position.Name;
                positionDto.CreateDate = position.CreateDate;
                positionDto.UpdateBy = position.UpdateBy;
                positionDto.UpdateDate = position.UpdateDate;
                positionDto.UpdateName = position.UpdateByAmiyaEmployee?.Name;
                positionDto.IsDirector = position.IsDirector;
                positionDto.DepartmentId = position.DepartmentId;
                positionDto.DepartmentName = position.AmiyaDepartment.Name;
                return positionDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<AmiyaPositionInfoDto>> GetByDepartmentIdAsync(int departmentId)
        {
            try
            {
                var position = await dalAmiyaPositionInfo.GetAll()
                    .Include(e => e.UpdateByAmiyaEmployee)
                    .Include(e => e.AmiyaDepartment)
                    .Where(e => e.DepartmentId == departmentId).ToListAsync();

                if (position == null)
                    throw new Exception("职位编号错误");

                List<AmiyaPositionInfoDto> amiyaPositionInfoDtos = new List<AmiyaPositionInfoDto>();
                foreach(var x in position)
                {
                    AmiyaPositionInfoDto positionDto = new AmiyaPositionInfoDto();
                    positionDto.Id = x.Id;
                    positionDto.Name = x.Name;
                    positionDto.CreateDate = x.CreateDate;
                    positionDto.UpdateBy = x.UpdateBy;
                    positionDto.UpdateDate = x.UpdateDate;
                    positionDto.UpdateName = x.UpdateByAmiyaEmployee?.Name;
                    positionDto.IsDirector = x.IsDirector;
                    positionDto.DepartmentId = x.DepartmentId;
                    positionDto.DepartmentName = x.AmiyaDepartment.Name;
                    amiyaPositionInfoDtos.Add(positionDto);
                }
                return amiyaPositionInfoDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateAmiyaPositionInfoDto updateDto,int employeeId)
        {
            try
            {
                var position = await dalAmiyaPositionInfo.GetAll()
                    .SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (position == null)
                    throw new Exception("职位编号错误");

                position.Name = updateDto.Name;
                position.UpdateBy = employeeId;
                position.UpdateDate = DateTime.Now;
                position.DepartmentId = updateDto.DepartmentId;
                position.IsDirector = updateDto.IsDirector;
                await dalAmiyaPositionInfo.UpdateAsync(position,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var position = await dalAmiyaPositionInfo.GetAll()
                    .Include(e=>e.AmiyaEmployeeList)
                   .SingleOrDefaultAsync(e => e.Id == id);

                if (position.AmiyaEmployeeList.Count > 0)
                    throw new Exception("有该职位的员工，不能删除");

                var permission = await _dalAmiyaPositionPermission.GetAll()
                  .SingleOrDefaultAsync(e => e.AmiyaPositionId == id);

                if (permission!=null)
                    throw new Exception("请先清除该职位的权限后再进行删除！");

                await dalAmiyaPositionInfo.DeleteAsync(position,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
    }
}
