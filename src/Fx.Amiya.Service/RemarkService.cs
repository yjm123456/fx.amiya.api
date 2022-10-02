using Fx.Amiya.Background.Api.Vo.Remark;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
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
        private IIndicatorSendHospitalService indicatorSendHospitalService;
        private IUnitOfWork unitOfWork;
        public RemarkService(IDalRemark dalRemark, IIndicatorSendHospitalService indicatorSendHospitalService, IUnitOfWork unitOfWork)
        {
            this.dalRemark = dalRemark;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
        }

        #region 优秀机构运营健康指标批注
        /// <summary>
        /// 添加优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task AddAmiyaRemark(AddAmiyaRemarkDto addAmiyaRemarkDto)
        {
            var healthIndicatorRemark = dalRemark.GetAll().Where(e => e.IndicatorId == addAmiyaRemarkDto.IndicatorId && e.HospitalId == null).SingleOrDefault();
            if (healthIndicatorRemark == null)
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
            else
            {
                healthIndicatorRemark.AmiyaRemark = addAmiyaRemarkDto.Remark;
                healthIndicatorRemark.UpdateDate = DateTime.Now;
                await dalRemark.UpdateAsync(healthIndicatorRemark, true);
            }
        }
        /// <summary>
        /// 获取优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task<AmiyaRemarkDto> GetAmiyaRemark(string indicatorId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == null).SingleOrDefault();
            if (remark == null) return null;
            return new AmiyaRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                AmiyaRemark = remark.AmiyaRemark
            };

        }
        /// <summary>
        /// 修改优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        /*public async Task UpdateAmiyaRemark(UpdateAmiyaRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.AmiyaRemark = update.Remark;
        }*/

        #endregion

        #region 医院咨询师运营数据批注
        /// <summary>
        /// 添加机构咨询师运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
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
                    HospitalConsultRemark = add.HospitalConsultRemark,
                    AmiyaConsultRemark = add.AmiyaConsultRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                if (JudgeAmiyaRemark(add.AmiyaConsultRemark))
                {
                    await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                }
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalConsultRemark = add.HospitalConsultRemark;
                exsit.AmiyaConsultRemark = add.AmiyaConsultRemark;
                if (JudgeAmiyaRemark(add.AmiyaConsultRemark))
                {
                    await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                }
                await dalRemark.UpdateAsync(exsit, true);
            }
        }
        /// <summary>
        /// 获取机构咨询师运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task<HospitalConsultRemarkDto> GetHospitalConsultRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            if (remark == null) return null;
            return new HospitalConsultRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalConsultRemark = remark.HospitalConsultRemark,
                AmiyaConsultRemark = remark.AmiyaConsultRemark
            };
        }
        /// <summary>
        /// 修改机构咨询师运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        /*public async Task UpdateHospitalConsultRemark(UpdateHospitalConsultRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalConsultRemark = update.HospitalConsultRemark;
            remark.AmiyaConsultRemark = update.AmiyaConsultRemark;
            await dalRemark.UpdateAsync(remark, true);
        }*/

        #endregion

        #region 医院成交品项批注
        /// <summary>
        /// 添加机构成交品项运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task AddHospitalDealRemark(AddHospitalDealRemarkDto add)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
                if (exsit == null)
                {
                    Remark remark = new Remark()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IndicatorId = add.IndicatorId,
                        HospitalId = add.HospitalId,
                        HospitalDealRemark = add.HospitalDealRemark,
                        AmiyaDealRemark = add.AmiyaDealRemark,
                        CreateDate = DateTime.Now,
                        Valid = true
                    };
                    if (JudgeAmiyaRemark(add.AmiyaDealRemark))
                    {
                        await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                    }
                    await dalRemark.AddAsync(remark, true);
                }
                else
                {
                    exsit.HospitalDealRemark = add.HospitalDealRemark;
                    exsit.AmiyaDealRemark = add.AmiyaDealRemark;
                    if (JudgeAmiyaRemark(add.AmiyaDealRemark))
                    {
                        await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                    }
                    await dalRemark.UpdateAsync(exsit, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 获取机构成交品项运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task<HospitalDealRemarkDto> GetHospitalDealRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            if (remark == null) return null;
            return new HospitalDealRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalDealRemark = remark.HospitalDealRemark,
                AmiyaDealRemark = remark.AmiyaDealRemark
            };
        }
        /// <summary>
        /// 修改机构成交品项运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        /*public async Task UpdateHospitalDealRemark(UpdateHospitalDealRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalDoctorRemark = update.HospitalDealRemark;
            remark.AmiyaDealRemark = update.AmiyaDealRemark;
            await dalRemark.UpdateAsync(remark, true);
        }*/
        #endregion

        #region 医院医生运营数据批注
        /// <summary>
        /// 添加机构医生运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task AddHospitalDoctorRemark(AddHospitalDoctorRemarkDto add)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
                if (exsit == null)
                {
                    Remark remark = new Remark()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IndicatorId = add.IndicatorId,
                        HospitalId = add.HospitalId,
                        HospitalDoctorRemark = add.HospitalDoctorRemark,
                        AmiyaDoctorRemark = add.AmiyaDoctorRemark,
                        CreateDate = DateTime.Now,
                        Valid = true
                    };
                    if (JudgeAmiyaRemark(add.AmiyaDoctorRemark))
                    {
                        await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                    }
                    await dalRemark.AddAsync(remark, true);
                }
                else
                {
                    exsit.HospitalDoctorRemark = add.HospitalDoctorRemark;
                    exsit.AmiyaDoctorRemark = add.AmiyaDoctorRemark;
                    if (JudgeAmiyaRemark(add.AmiyaDoctorRemark))
                    {
                        await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                    }
                    await dalRemark.UpdateAsync(exsit, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<HospitalDoctorRemarkDto> GetHospitalDoctorRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            if (remark == null) return null;
            return new HospitalDoctorRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalDoctorRemark = remark.HospitalDoctorRemark,
                AmiyaDoctorRemark = remark.AmiyaDoctorRemark
            };
        }
        /// <summary>
        /// 修改机构医生运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        /*public async Task UpdateHospitalDoctorRemark(UpdateHospitalDoctorRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalDoctorRemark = update.HospitalDoctorRemark;
            remark.AmiyaDoctorRemark = update.AmiyaDoctorRemark;
            await dalRemark.UpdateAsync(remark, true);
        }*/

        #endregion

        #region 医院网咨运营数据批注
        /// <summary>
        /// 添加机构网咨运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task AddHospitalOnlineConsultRemark(AddHospitalOnlineConsultRemarkDto add)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var exsit = dalRemark.GetAll().Where(e => e.HospitalId == add.HospitalId && e.IndicatorId == add.IndicatorId).SingleOrDefault();
                if (exsit == null)
                {
                    Remark remark = new Remark()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IndicatorId = add.IndicatorId,
                        HospitalId = add.HospitalId,
                        HospitalOnlineConsultRemark = add.HospitalOnlineConsultRemark,
                        AmiyaOnlineConsultRemark = add.AmiyaOnlineConsultRemark,
                        CreateDate = DateTime.Now,
                        Valid = true
                    };
                    if (JudgeAmiyaRemark(add.AmiyaOnlineConsultRemark))
                    {
                        await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                    }
                    await dalRemark.AddAsync(remark, true);
                }
                else
                {
                    exsit.HospitalOnlineConsultRemark = add.HospitalOnlineConsultRemark;
                    exsit.AmiyaOnlineConsultRemark = add.AmiyaOnlineConsultRemark;
                    if (JudgeAmiyaRemark(add.AmiyaOnlineConsultRemark))
                    {
                        await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                    }
                    await dalRemark.UpdateAsync(exsit, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 获取机构网咨运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task<HospitalOnlineConsultRemarkDto> GetHospitalOnlineConsultRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            if (remark == null) return null;
            return new HospitalOnlineConsultRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalOnlineConsultRemark = remark.HospitalOnlineConsultRemark,
                AmiyaOnlineConsultRemark = remark.AmiyaOnlineConsultRemark
            };
        }
        /// <summary>
        /// 修改机构网咨运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        /*public async Task UpdateHospitalOnlineConsultRemark(UpdateHospitalOnlineConsultRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalOperationRemark = update.HospitalOnlineConsultRemark;
            remark.AmiyaOperationRemark = update.AmiyaOnlineConsultRemark;
            await dalRemark.UpdateAsync(remark, true);
        }*/

        #endregion

        #region 机构运营数据分析
        /// <summary>
        /// 添加机构运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
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
                    AmiyaOperationRemark = add.AmiyaOperationRemark,
                    CreateDate = DateTime.Now,
                    Valid = true
                };
                if (JudgeAmiyaRemark(add.AmiyaOperationRemark))
                {
                    await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                }
                await dalRemark.AddAsync(remark, true);
            }
            else
            {
                exsit.HospitalOperationRemark = add.HospitalOperationRemark;
                exsit.AmiyaOperationRemark = add.AmiyaOperationRemark;
                if (JudgeAmiyaRemark(add.AmiyaOperationRemark))
                {
                    await indicatorSendHospitalService.UpdateRemarkStatusAsync(add.IndicatorId, add.HospitalId);
                }
                await dalRemark.UpdateAsync(exsit, true);
            }

        }
        /// <summary>
        /// 获取机构运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task<HospitalOperationRemarkDto> GetHospitalOperationRemark(string indicatorId, int hospitalId)
        {
            var remark = dalRemark.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId).SingleOrDefault();
            if (remark == null) return null;
            return new HospitalOperationRemarkDto
            {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId.Value,
                HospitalOperationRemark = remark.HospitalOperationRemark,
                AmiyaOperationRemark = remark.AmiyaOperationRemark
            };
        }
        /// <summary>
        /// 修改机构运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        /*public async Task UpdateHospitalOperationRemark(UpdateHospitalOperationRemarkDto update)
        {
            var remark = dalRemark.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            remark.UpdateDate = DateTime.Now;
            remark.HospitalOperationRemark = update.HospitalOperationRemark;
            remark.AmiyaOperationRemark = update.AmiyaOperationRemark;
            await dalRemark.UpdateAsync(remark, true);
        }*/
        #endregion

        #region 内部公共方法
        //判断啊美雅批注是否为空
        private bool JudgeAmiyaRemark(string remark)
        {
            return !string.IsNullOrEmpty(remark);
        }
        #endregion
    }
}
