using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalFeedBack;
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

namespace Fx.Amiya.Service
{
    public class HospitalFeedBackServiceService : IHospitalFeedBackService
    {
        private IDalHospitalFeedBack dalHospitalFeedBackService;
        private IHospitalInfoService _hospitalInfoService;
        public HospitalFeedBackServiceService(IDalHospitalFeedBack dalHospitalFeedBackService,
            IHospitalInfoService  hospitalInfoService)
        {
            this.dalHospitalFeedBackService = dalHospitalFeedBackService;
            _hospitalInfoService = hospitalInfoService;
        }



        public async Task<FxPageInfo<HospitalFeedBackDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var hospitalFeedBackService = from d in dalHospitalFeedBackService.GetAll()
                                               where (keyword == null || d.Title.Contains(keyword) )
                                               && ((!startDate.HasValue && !endDate.HasValue) || d.CreateDate >= startDate.Value.Date && d.CreateDate < endDate.Value.AddDays(1).Date)
                                               && (!hospitalId.HasValue || d.CreateHospital == hospitalId)
                                               select new HospitalFeedBackDto
                                               {
                                                   Id = d.Id,
                                                   Title = d.Title,
                                                   Content = d.Content,
                                                   Level = d.Level,
                                                   CreateHospital = d.CreateHospital,
                                                   CreateDate = d.CreateDate,
                                               };
                FxPageInfo<HospitalFeedBackDto> hospitalFeedBackServicePageInfo = new FxPageInfo<HospitalFeedBackDto>();
                hospitalFeedBackServicePageInfo.TotalCount = await hospitalFeedBackService.CountAsync();
                hospitalFeedBackServicePageInfo.List = await hospitalFeedBackService.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in hospitalFeedBackServicePageInfo.List)
                {
                    var hospitalInfo = await _hospitalInfoService.GetByIdAsync(x.CreateHospital);
                    x.Hospital = hospitalInfo.Name;
                }
                return hospitalFeedBackServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddHospitalFeedBackDto addDto)
        {
            try
            {
                HospitalFeedBack hospitalFeedBackService = new HospitalFeedBack();
                hospitalFeedBackService.Id = CreateOrderIdHelper.GetNextNumber();
                hospitalFeedBackService.Title = addDto.Title;
                hospitalFeedBackService.Content = addDto.Content;
                hospitalFeedBackService.Level = 0;
                hospitalFeedBackService.CreateHospital = addDto.CreateHospital;
                hospitalFeedBackService.CreateDate = DateTime.Now;

                await dalHospitalFeedBackService.AddAsync(hospitalFeedBackService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HospitalFeedBackDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalFeedBackService = await dalHospitalFeedBackService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (hospitalFeedBackService == null)
                {
                    return new HospitalFeedBackDto();
                }

                HospitalFeedBackDto hospitalFeedBackServiceDto = new HospitalFeedBackDto();
                hospitalFeedBackServiceDto.Id = hospitalFeedBackService.Id;
                hospitalFeedBackServiceDto.Title = hospitalFeedBackService.Title;
                hospitalFeedBackServiceDto.Content = hospitalFeedBackService.Content;
                hospitalFeedBackServiceDto.Level = hospitalFeedBackService.Level;
                hospitalFeedBackServiceDto.CreateHospital = hospitalFeedBackService.CreateHospital;
                hospitalFeedBackServiceDto.CreateDate = hospitalFeedBackService.CreateDate;

                return hospitalFeedBackServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateHospitalFeedBackDto updateDto)
        {
            try
            {
                var hospitalFeedBackService = await dalHospitalFeedBackService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalFeedBackService == null)
                    throw new Exception("医院投诉与反馈编号错误！");

                hospitalFeedBackService.Title = updateDto.Title;
                hospitalFeedBackService.Content = updateDto.Content;
                hospitalFeedBackService.Level = updateDto.Level;

                await dalHospitalFeedBackService.UpdateAsync(hospitalFeedBackService, true);
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
                var hospitalFeedBackService = await dalHospitalFeedBackService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalFeedBackService == null)
                    throw new Exception("医院投诉与反馈编号错误");

                await dalHospitalFeedBackService.DeleteAsync(hospitalFeedBackService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
