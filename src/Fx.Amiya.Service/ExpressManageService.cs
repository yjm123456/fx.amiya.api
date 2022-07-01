using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ExpressManage;
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
    public class ExpressManageService: IExpressManageService
    {
        private IDalExpressManage dalExpressManage;

        public ExpressManageService(IDalExpressManage dalExpress)
        {
            this.dalExpressManage = dalExpress;
        }



        public async Task<FxPageInfo<ExpressDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var express = from d in dalExpressManage.GetAll()
                             where keyword == null || d.ExpressName.Contains(keyword) || d.ExpressCode.Contains(keyword)
                             select new ExpressDto
                             {
                                 Id = d.Id,
                                 ExpressName = d.ExpressName,
                                 ExpressCode = d.ExpressCode,
                                 Valid = d.Valid
                             };

                FxPageInfo<ExpressDto> expressPageInfo = new FxPageInfo<ExpressDto>();
                expressPageInfo.TotalCount = await express.CountAsync();
                expressPageInfo.List = await express.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return expressPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddExpressDto addDto)
        {
            try
            {
                AmiyaExpress express = new AmiyaExpress();
                express.Id = Guid.NewGuid().ToString();
                express.ExpressName = addDto.ExpressName;
                express.ExpressCode = addDto.ExpressCode;
                express.Valid = true;

                await dalExpressManage.AddAsync(express, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ExpressKeyAndValueDto>> GetIdAndNames()
        {
            try
            {
                var express = from d in dalExpressManage.GetAll()
                              where d.Valid==true
                              select new ExpressKeyAndValueDto
                              {
                                  Id = d.Id,
                                  ExpressName = d.ExpressName
                              };
                return express.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ExpressDto> GetByIdAsync(string id)
        {
            try
            {
                var express = await dalExpressManage.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (express == null)
                {
                    return new ExpressDto() {
                        Id = "",
                        ExpressName = "",
                        ExpressCode = "",
                        Valid=false
                    };
                }

                ExpressDto expressDto = new ExpressDto();
                expressDto.Id = express.Id;
                expressDto.ExpressName = express.ExpressName;
                expressDto.ExpressCode = express.ExpressCode;
                expressDto.Valid = express.Valid;

                return expressDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateExpressDto updateDto)
        {
            try
            {
                var express = await dalExpressManage.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (express == null)
                    throw new Exception("物流公司编号错误！");

                express.ExpressName = updateDto.ExpressName;
                express.ExpressCode = updateDto.ExpressCode;
                express.Valid = updateDto.Valid;

                await dalExpressManage.UpdateAsync(express, true);
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
                var express = await dalExpressManage.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (express == null)
                    throw new Exception("物流公司编号错误");

                await dalExpressManage.DeleteAsync(express, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
