using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalEnvironmentPicture;
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
    public class HospitalEnvironmentPictureService : IHospitalEnvironmentPictureService
    {
        private IDalHospitalEnvironmentPicture _dalHospitalEnvironmentPicture;

        public HospitalEnvironmentPictureService(IDalHospitalEnvironmentPicture dalHospitalEnvironmentPicture)
        {
            _dalHospitalEnvironmentPicture = dalHospitalEnvironmentPicture;
        }

        public async Task<FxPageInfo<HospitalEnvironmentPictureDto>> GetListWithPageAsync(string environmentId, int hospitalId, int pageNum, int pageSize)
        {
            try
            {
                var hospitalEnvironmentPicture = from d in _dalHospitalEnvironmentPicture.GetAll()
                                                 where (hospitalId == 0 || d.HospitalId == hospitalId)
                                                 && (string.IsNullOrEmpty(environmentId) || d.HospitalEnvironmentId == environmentId)
                                                 select new HospitalEnvironmentPictureDto
                                                 {
                                                     HospitalId = d.HospitalId,
                                                     HospitalEnvironmentId = d.HospitalEnvironmentId,
                                                     PictureUrl = d.PictureUrl
                                                 };

                FxPageInfo<HospitalEnvironmentPictureDto> expressPageInfo = new FxPageInfo<HospitalEnvironmentPictureDto>();
                expressPageInfo.TotalCount = await hospitalEnvironmentPicture.CountAsync();
                expressPageInfo.List = await hospitalEnvironmentPicture.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return expressPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(hospitalEnvironmentPictureAddDto addDto)
        {
            try
            {
                HospitalEnvironmentPicture hospitalEnvironmentPicture = new HospitalEnvironmentPicture();
                hospitalEnvironmentPicture.Id = Guid.NewGuid().ToString();
                hospitalEnvironmentPicture.HospitalId = addDto.HospitalId;
                hospitalEnvironmentPicture.HospitalEnvironmentId = addDto.HospitalEnvironmentId;
                hospitalEnvironmentPicture.PictureUrl = addDto.PictureUrl;

                await _dalHospitalEnvironmentPicture.AddAsync(hospitalEnvironmentPicture, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task DeleteByHospitalIdAndEnvironmentIdAsync(int hospitalId, string environmentId)
        {
            try
            {
                var hospitalEnvironmentPicture = await _dalHospitalEnvironmentPicture.GetAll().Where(e => e.HospitalId == hospitalId && e.HospitalEnvironmentId == environmentId).ToListAsync();

                if (hospitalEnvironmentPicture.Count != 0)
                    foreach (var x in hospitalEnvironmentPicture)
                    {
                        await _dalHospitalEnvironmentPicture.DeleteAsync(x, true);
                    }
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
                var hospitalEnvironmentPicture = await _dalHospitalEnvironmentPicture.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalEnvironmentPicture == null)
                    throw new Exception("医院环境编号错误");

                await _dalHospitalEnvironmentPicture.DeleteAsync(hospitalEnvironmentPicture, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
