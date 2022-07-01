using Fx.Amiya.Dto.AmiyaDepartment;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class AmiyaDepartmentService : IAmiyaDepartmentService 
    {
        private IDalAmiyaDepartment dalAmiyaDepartment;
        public AmiyaDepartmentService(IDalAmiyaDepartment dalAmiyaDepartment)
        {
            this.dalAmiyaDepartment = dalAmiyaDepartment;
        }

        public async Task<FxPageInfo<AmiyaDepartmentDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var department = from d in dalAmiyaDepartment.GetAll()
                             select new AmiyaDepartmentDto
                             { 
                                Id=d.Id,
                                Name=d.Name,
                                Valid=d.Valid
                             };
            FxPageInfo<AmiyaDepartmentDto> departmentPageInfo = new FxPageInfo<AmiyaDepartmentDto>();
            departmentPageInfo.TotalCount = await department.CountAsync();
            departmentPageInfo.List = await department.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return departmentPageInfo;
        }



        public async Task<List<AmiyaDepartmentDto>> GetNameListAsync()
        {
            var department = from d in dalAmiyaDepartment.GetAll()
                             where d.Valid==true
                             select new AmiyaDepartmentDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };
            return await department.ToListAsync();
        }


        /// <summary>
        /// 获取有效的需求部门列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaDepartmentDto>> GetNameListOfRequirementAsync()
        {
            var department = from d in dalAmiyaDepartment.GetAll()
                             where d.Valid == true
                             &&d.IsProcessingRequirementDepartment
                             select new AmiyaDepartmentDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };
            return await department.ToListAsync();
        }


        public async Task AddAsync(AddAmiyaDepartmentDto addDto)
        {
            var departmentCount = await dalAmiyaDepartment.GetAll().CountAsync(e => e.Name == addDto.Name && e.Valid == true);
            if (departmentCount > 0)
                throw new Exception("已有该部门，请重新输入");

            AmiyaDepartment amiyaDepartment = new AmiyaDepartment();
            amiyaDepartment.Name = addDto.Name;
            amiyaDepartment.Valid = true;
            await dalAmiyaDepartment.AddAsync(amiyaDepartment,true);
        }




        public async Task<AmiyaDepartmentDto> GetByIdAsync(int id)
        {
            var department = await dalAmiyaDepartment.GetAll().SingleOrDefaultAsync(e=>e.Id==id);
            if (department == null)
                throw new Exception("部门编号错误");

            AmiyaDepartmentDto amiyaDepartmentDto = new AmiyaDepartmentDto();
            amiyaDepartmentDto.Id = department.Id;
            amiyaDepartmentDto.Name = department.Name;
            amiyaDepartmentDto.Valid = department.Valid;
            return amiyaDepartmentDto;
        }



        public async Task UpdateAsync(UpdateAmiyaDepartmentDto updateDto)
        {
            var department = await dalAmiyaDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (department == null)
                throw new Exception("部门编号错误");

            var departmentCount = await dalAmiyaDepartment.GetAll().CountAsync(e => e.Name == updateDto.Name&&e.Id!= updateDto.Id && e.Valid == true);
            if (departmentCount > 0)
                throw new Exception("已有该部门，请重新输入");

            department.Name = updateDto.Name;
            department.Valid = updateDto.Valid;
            await dalAmiyaDepartment.UpdateAsync(department,true);
        }



        public async Task DeleteAsync(int id)
        {
            try
            {
                var department = await dalAmiyaDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (department == null)
                    throw new Exception("部门编号错误");

                await dalAmiyaDepartment.DeleteAsync(department, true);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }

        }
    }
}
