using Fx.Amiya.Dto.RequirementType;
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
   public class RequirementTypeService: IRequirementTypeService
    {
        private IDalRequirementType dalRequirementType;
        public RequirementTypeService(IDalRequirementType dalRequirementType)
        {
            this.dalRequirementType = dalRequirementType;
        }

        public async Task<FxPageInfo<RequirementTypeDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var requirementType = from d in dalRequirementType.GetAll()
                             select new RequirementTypeDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };
            FxPageInfo<RequirementTypeDto> requirementTypePageInfo = new FxPageInfo<RequirementTypeDto>();
            requirementTypePageInfo.TotalCount = await requirementType.CountAsync();
            requirementTypePageInfo.List = await requirementType.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return requirementTypePageInfo;
        }


        public async Task<List<RequirementTypeDto>> GetNameListAsync()
        {
            var requirementType = from d in dalRequirementType.GetAll()
                                  where d.Valid==true
                                  select new RequirementTypeDto
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      Valid = d.Valid
                                  };
            return await requirementType.ToListAsync();
        }


        public async Task AddAsync(AddRequirementTypeDto addDto)
        {
            var requirementTypeCount = await dalRequirementType.GetAll().CountAsync(e => e.Name == addDto.Name && e.Valid == true);
            if (requirementTypeCount > 0)
                throw new Exception("已有该需求类型，请重新输入");

            RequirementType requirementType = new RequirementType();
            requirementType.Name = addDto.Name;
            requirementType.Valid = true;
            await dalRequirementType.AddAsync(requirementType,true);
        }


        public async Task<RequirementTypeDto> GetByIdAsync(int id)
        {
            var requirementType = await dalRequirementType.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (requirementType == null)
                throw new Exception("需求类型编号错误");

            RequirementTypeDto requirementTypeDto = new RequirementTypeDto();
            requirementTypeDto.Id = requirementType.Id;
            requirementTypeDto.Name = requirementType.Name;
            requirementTypeDto.Valid = requirementType.Valid;
            return requirementTypeDto;
        }


        public async Task UpdateAsync(UpdateRequirementTypeDto updateDto)
        {
            var requirementType = await dalRequirementType.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (requirementType == null)
                throw new Exception("需求类型编号错误");

            var requirementTypeCount = await dalRequirementType.GetAll().CountAsync(e => e.Name == updateDto.Name&&e.Id!=updateDto.Id && e.Valid == true);
            if (requirementTypeCount > 0)
                throw new Exception("已有该需求类型，请重新输入");

            requirementType.Name = updateDto.Name;
            requirementType.Valid = updateDto.Valid;
            await dalRequirementType.UpdateAsync(requirementType,true);
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var requirementType = await dalRequirementType.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (requirementType == null)
                    throw new Exception("需求类型编号错误");
                await dalRequirementType.DeleteAsync(requirementType, true);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }
        }
    }
}
