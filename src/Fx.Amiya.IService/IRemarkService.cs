using Fx.Amiya.Background.Api.Vo.Remark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRemarkService
    {
        /// <summary>
        /// 获取优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<AmiyaRemarkDto> GetAmiyaRemark(string indicatorId);
        /// <summary>
        /// 添加优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddAmiyaRemark(AddAmiyaRemarkDto add);
        /// <summary>
        /// 修改优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateAmiyaRemark(UpdateAmiyaRemarkDto update);



        /// <summary>
        /// 获取机构运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<HospitalOperationRemarkDto> GetHospitalOperationRemark(string indicatorId,int hospitalId);
        /// <summary>
        /// 添加机构运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddHospitalOperationRemark(AddHospitalOperationRemarkDto add);
        /// <summary>
        /// 修改机构运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateHospitalOperationRemark(UpdateHospitalOperationRemarkDto update);



        /// <summary>
        /// 获取机构咨询师运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<HospitalConsultRemarkDto> GetHospitalConsultRemark(string indicatorId, int hospitalId);
        /// <summary>
        /// 添加机构咨询师运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddHospitalConsultRemark(AddHospitalConsultRemarkDto add);
        /// <summary>
        /// 修改机构咨询师运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateHospitalConsultRemark(UpdateHospitalConsultRemarkDto update);



        /// <summary>
        /// 获取机构网咨运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<HospitalOnlineConsultRemarkDto> GetHospitalOnlineConsultRemark(string indicatorId, int hospitalId);
        /// <summary>
        /// 添加机构网咨运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddHospitalOnlineConsultRemark(AddHospitalOnlineConsultRemarkDto add);
        /// <summary>
        /// 修改机构网咨运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateHospitalOnlineConsultRemark(UpdateHospitalOnlineConsultRemarkDto update);




        /// <summary>
        /// 获取机构医生运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<HospitalDoctorRemarkDto> GetHospitalDoctorRemark(string indicatorId, int hospitalId);
        /// <summary>
        /// 添加机构医生运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddHospitalDoctorRemark(AddHospitalDoctorRemarkDto add);
        /// <summary>
        /// 修改机构医生运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateHospitalDoctorRemark(UpdateHospitalDoctorRemarkDto update);




        /// <summary>
        /// 获取机构成交品项运营数据批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<HospitalDealRemarkDto> GetHospitalDealRemark(string indicatorId, int hospitalId);
        /// <summary>
        /// 添加机构成交品项运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddHospitalDealRemark(AddHospitalDealRemarkDto add);
        /// <summary>
        /// 修改机构成交品项运营批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateHospitalDealRemark(UpdateHospitalDealRemarkDto update);

    }
}
