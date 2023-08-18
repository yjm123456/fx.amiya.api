using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AmiyaLessonApply;
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
    public class AmiyaLessonApplyService : IAmiyaLessonApplyService
    {
        private IDalAmiyaLessonApply dalAmiyaLessonApply;

        public AmiyaLessonApplyService(IDalAmiyaLessonApply dalAmiyaLessonApply)
        {
            this.dalAmiyaLessonApply = dalAmiyaLessonApply;
        }



        public async Task<FxPageInfo<AmiyaLessonApplyDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var amiyaLessonApply = from d in dalAmiyaLessonApply.GetAll()
                             where keyword == null || d.Name.Contains(keyword) || d.Phone.Contains(keyword)
                             select new AmiyaLessonApplyDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Phone = d.Phone,
                                 Position = d.Position,
                                 City = d.City
                             };

                FxPageInfo<AmiyaLessonApplyDto> amiyaLessonApplyPageInfo = new FxPageInfo<AmiyaLessonApplyDto>();
                amiyaLessonApplyPageInfo.TotalCount = await amiyaLessonApply.CountAsync();
                amiyaLessonApplyPageInfo.List = await amiyaLessonApply.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return amiyaLessonApplyPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(AddAmiyaLessonApplyDto addDto)
        {
            try
            {
                AmiyaLessonApply amiyaLessonApply = new AmiyaLessonApply();
                amiyaLessonApply.Id = Guid.NewGuid().ToString();
                amiyaLessonApply.Name = addDto.Name;
                amiyaLessonApply.Phone = addDto.Phone;
                amiyaLessonApply.Position = addDto. Position;
                amiyaLessonApply.City = addDto. City;

                await dalAmiyaLessonApply.AddAsync(amiyaLessonApply, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<AmiyaLessonApplyDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaLessonApply = await dalAmiyaLessonApply.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (amiyaLessonApply == null)
                {
                    return new AmiyaLessonApplyDto() {
                        Id = "",
                        Name = "",
                        Phone = "",
                        Position = "",
                        City=""
                    };
                }

                AmiyaLessonApplyDto amiyaLessonApplyDto = new AmiyaLessonApplyDto();
                amiyaLessonApplyDto.Id = amiyaLessonApply.Id;
                amiyaLessonApplyDto.Name = amiyaLessonApply.Name;
                amiyaLessonApplyDto.Phone = amiyaLessonApply.Phone;
                amiyaLessonApplyDto.Position = amiyaLessonApply.Position;
                amiyaLessonApplyDto.City = amiyaLessonApply.City;
                return amiyaLessonApplyDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateAmiyaLessonApplyDto updateDto)
        {
            try
            {
                var amiyaLessonApply = await dalAmiyaLessonApply.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaLessonApply == null)
                    throw new Exception("报名信息编号错误！");
                amiyaLessonApply.Name = updateDto.Name;
                amiyaLessonApply.Phone = updateDto.Phone;
                amiyaLessonApply.Position = updateDto.Position;
                amiyaLessonApply.City = updateDto.City;

                await dalAmiyaLessonApply.UpdateAsync(amiyaLessonApply, true);
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
                var amiyaLessonApply = await dalAmiyaLessonApply.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (amiyaLessonApply == null)
                    throw new Exception("报名信息编号错误");

                await dalAmiyaLessonApply.DeleteAsync(amiyaLessonApply, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
