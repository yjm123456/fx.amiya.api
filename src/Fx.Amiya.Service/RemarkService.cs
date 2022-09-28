using Fx.Amiya.Background.Api.Vo.Remark;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{

    public class RemarkService : IRemarkService
    {
        private readonly IDalRemark dalRemark;

        public RemarkService(IDalRemark dalRemark)
        {
            this.dalRemark = dalRemark;
        }

        public async Task AddAmiyaRemark(AddAmiyaRemarkDto addAmiyaRemarkDto)
        {
            Remark remark = new Remark()
            {
                Id = Guid.NewGuid().ToString(),
                IndicatorId = addAmiyaRemarkDto.IndicatorId,
                AmiyaRemark = addAmiyaRemarkDto.Remark,
                CreateDate = DateTime.Now,
                Valid = true
            };
            await dalRemark.AddAsync(remark, true);

        }

        public async Task AddHospitalConsultRemark(AddHospitalConsultRemarkDto add)
        {
            var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
            if (exsit == null)
            {
                Remark remark = new Remark()
                {
                    Id = Guid.NewGuid().ToString(),
                    IndicatorId = add.IndicatorId,
                    HospitalId = add.HospitalId,
                    HospitalOperationRemark = add.HospitalConsultRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalConsultRemark = add.HospitalConsultRemark;
                exsit.AmiyaConsultRemark = add.AmiyaConsultRemark;
                await dalRemark.UpdateAsync(exsit, true);
            }
        }

        public async Task AddHospitalDealRemark(AddHospitalDealRemarkDto add)
        {
            var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
            if (exsit == null)
            {
                Remark remark = new Remark()
                {
                    Id = Guid.NewGuid().ToString(),
                    IndicatorId = add.IndicatorId,
                    HospitalId = add.HospitalId,
                    HospitalDealRemark = add.HospitalDealRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalDealRemark = add.HospitalDealRemark;
                exsit.AmiyaDealRemark = add.AmiyaDealRemark;
                await dalRemark.UpdateAsync(exsit, true);
            }
        }

        public async Task AddHospitalDoctorRemark(AddHospitalDoctorRemarkDto add)
        {
            var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
            if (exsit == null)
            {
                Remark remark = new Remark()
                {
                    Id = Guid.NewGuid().ToString(),
                    IndicatorId = add.IndicatorId,
                    HospitalId = add.HospitalId,
                    HospitalDoctorRemark = add.HospitalDoctorRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalConsultRemark = add.HospitalDoctorRemark;
                exsit.AmiyaConsultRemark = add.AmiyaDoctorRemark;
                await dalRemark.UpdateAsync(exsit, true);
            }
        }

        public async Task AddHospitalOnlineConsultRemark(AddHospitalOnlineConsultRemarkDto add)
        {
            var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
            if (exsit == null)
            {
                Remark remark = new Remark()
                {
                    Id = Guid.NewGuid().ToString(),
                    IndicatorId = add.IndicatorId,
                    HospitalId = add.HospitalId,
                    HospitalOperationRemark = add.HospitalOnlineConsultRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalOnlineConsultRemark = add.HospitalOnlineConsultRemark;
                exsit.AmiyaOnlineConsultRemark = add.AmiyaOnlineConsultRemark;
                await dalRemark.UpdateAsync(exsit, true);
            }
        }

        public async Task AddHospitalOperationRemark(AddHospitalOperationRemarkDto add)
        {
            var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
            if (exsit == null)
            {
                Remark remark = new Remark()
                {
                    Id = Guid.NewGuid().ToString(),
                    IndicatorId = add.IndicatorId,
                    HospitalId = add.HospitalId,
                    HospitalOperationRemark = add.HospitalOperationRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalOperationRemark = add.HospitalOperationRemark;
                exsit.AmiyaOperationRemark = add.AmiyaOperationRemark;
                await dalRemark.UpdateAsync(exsit, true);
            }

        }

        public async Task<AmiyaRemarkDto> GetAmiyaRemark(string indicatorId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId&&e.HospitalId==null).SingleOrDefault();
            return new AmiyaRemarkDto { Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                AmiyaRemark = remark.AmiyaRemark };
        }

        public async Task<HospitalConsultRemarkDto> GetHospitalConsultRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            return new HospitalConsultRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalConsultRemark = remark.HospitalConsultRemark,
                AmiyaConsultRemark = remark.AmiyaConsultRemark
            };
        }

        public async Task<HospitalDealRemarkDto> GetHospitalDealRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            return new HospitalDealRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalDealRemark = remark.HospitalDealRemark,
                AmiyaDealRemark = remark.AmiyaDealRemark
            };
        }

        public async Task<HospitalDoctorRemarkDto> GetHospitalDoctorRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            return new HospitalDoctorRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalDoctorRemark = remark.HospitalDoctorRemark,
                AmiyaDoctorRemark = remark.AmiyaDoctorRemark
            };
        }

        public async Task<HospitalOnlineConsultRemarkDto> GetHospitalOnlineConsultRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            return new HospitalOnlineConsultRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalOnlineConsultRemark = remark.HospitalOnlineConsultRemark,
                AmiyaOnlineConsultRemark = remark.AmiyaOnlineConsultRemark
            };
        }

        public async Task<HospitalOperationRemarkDto> GetHospitalOperationRemark(string indicatorId,int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId&&e.HospitalId==hospitalId).SingleOrDefault();
            return new HospitalOperationRemarkDto {
                Id = remark.Id, 
                IndicatorId = remark.IndicatorId, 
                HospitalId=remark.HospitalId.Value,
                HospitalOperationRemark = remark.HospitalOperationRemark,
                AmiyaOperationRemark=remark.AmiyaOperationRemark 
            };
        }

        public async Task UpdateAmiyaRemark(UpdateAmiyaRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.AmiyaRemark = update.Remark;
        }

        public async Task UpdateHospitalConsultRemark(UpdateHospitalConsultRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalConsultRemark = update.HospitalConsultRemark;
            remark.AmiyaConsultRemark = update.AmiyaConsultRemark;
            await dalRemark.UpdateAsync(remark, true);
        }

        public async Task UpdateHospitalDealRemark(UpdateHospitalDealRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalDoctorRemark = update.HospitalDealRemark;
            remark.AmiyaDealRemark = update.AmiyaDealRemark;
            await dalRemark.UpdateAsync(remark, true);
        }

        public async Task UpdateHospitalDoctorRemark(UpdateHospitalDoctorRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalDoctorRemark = update.HospitalDoctorRemark;
            remark.AmiyaDoctorRemark = update.AmiyaDoctorRemark;
            await dalRemark.UpdateAsync(remark, true);
        }

        public async Task UpdateHospitalOnlineConsultRemark(UpdateHospitalOnlineConsultRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalOperationRemark = update.HospitalOnlineConsultRemark;
            remark.AmiyaOperationRemark = update.AmiyaOnlineConsultRemark;
            await dalRemark.UpdateAsync(remark, true);
        }

        public async Task UpdateHospitalOperationRemark(UpdateHospitalOperationRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalOperationRemark = update.HospitalOperationRemark;
            remark.AmiyaOperationRemark=update.AmiyaOperationRemark;
            await  dalRemark.UpdateAsync(remark,true);
        }
    }
}
