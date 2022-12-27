using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Doctor;
using Fx.Amiya.Background.Api.Vo.HospitalInfo;
using Fx.Amiya.Dto.HospitalEnvironmentPicture;
using Fx.Amiya.Dto.HospitalInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HospitalInfoController : ControllerBase
    {
        private IHospitalInfoService hospitalInfoService;
        private IHttpContextAccessor httpContextAccessor;
        private IHospitalEnvironmentService _hospitalEnvironmentService;
        private IHospitalEnvironmentPictureService _hospitalEnvironmentPictureService;
        private IAmiyaHospitalDepartmentService _amiyaHospitalDepartmentService;
        private IDoctorService _doctorService;
        public HospitalInfoController(IHospitalInfoService hospitalInfoService,
            IHttpContextAccessor httpContextAccessor,
            IHospitalEnvironmentService hospitalEnvironmentService,
            IHospitalEnvironmentPictureService hospitalEnvironmentPictureService,
            IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService,
            IDoctorService doctorService)
        {
            this.hospitalInfoService = hospitalInfoService;
            this.httpContextAccessor = httpContextAccessor;
            _hospitalEnvironmentService = hospitalEnvironmentService;
            _hospitalEnvironmentPictureService = hospitalEnvironmentPictureService;
            _amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
            _doctorService = doctorService;
        }



        /// <summary>
        /// 获取医院列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="cityId">城市id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalInfoVo>>> GetListWithAsync(string keyword, int? cityId, int pageNum, int pageSize, bool? valid)
        {
            try
            {
                var q = await hospitalInfoService.GetListWithPageAsync(keyword, cityId, pageNum, pageSize, valid);
                var hospital = from d in q.List
                               select new HospitalInfoVo
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   Address = d.Address,
                                   Longitude = d.Longitude,
                                   Latitude = d.Latitude,
                                   Phone = d.Phone,
                                   Valid = d.Valid,
                                   ThumbPicUrl = d.ThumbPicUrl,
                                   CityId = d.CityId,
                                   City = d.City,
                                   DueTime = d.DueTime,
                                   ContractUrl = d.ContractUrl,
                                   HasUsedTime = d.HasUsedTime
                               };


                FxPageInfo<HospitalInfoVo> hospitalPageInfo = new FxPageInfo<HospitalInfoVo>();
                hospitalPageInfo.TotalCount = q.TotalCount;
                hospitalPageInfo.List = hospital;

                return ResultData<FxPageInfo<HospitalInfoVo>>.Success().AddData("hospitalInfo", hospitalPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取医院资料审核情况列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="submitState">资料提交状态（默认展示已提交的）</param>
        /// <param name="CheckState">审核状态（-1查询全部）</param>
        /// <returns></returns>
        [HttpGet("hospitalCheckWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalCheckInfoVo>>> GetListWithAsync(string keyword, int pageNum, int pageSize, int CheckState ,int submitState)
        {
            try
            {
                var q = await hospitalInfoService.GetCheckListWithPageAsync(keyword,  pageNum, pageSize,  CheckState,  submitState);
                var hospital = from d in q.List
                               select new HospitalCheckInfoVo
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   ThumbPicUrl = d.ThumbPicUrl,
                                   CheckState = d.CheckState,
                                   CheckStateText = d.CheckStateText,
                                   CheckBy = d.CheckBy,
                                   CheckDate = d.CheckDate,
                                   CheckRemark = d.CheckRemark,
                                   SubmitStateText =d.SubmitStateText,
                                   SubmitState = d.SubmitState,
                               };


                FxPageInfo<HospitalCheckInfoVo> hospitalPageInfo = new FxPageInfo<HospitalCheckInfoVo>();
                hospitalPageInfo.TotalCount = q.TotalCount;
                hospitalPageInfo.List = hospital;

                return ResultData<FxPageInfo<HospitalCheckInfoVo>>.Success().AddData("hospitalInfo", hospitalPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalCheckInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 审核医院资料
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("hospitalInfoCheck")]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerManageCheckAsync(HospitalInfoCheckInfoVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int empId = Convert.ToInt32(employee.Id);
            HospitalInfoCheckInfoDto checkDto = new HospitalInfoCheckInfoDto();
            checkDto.Id = updateVo.Id;
            checkDto.CheckState = updateVo.CheckState;
            checkDto.Remark = updateVo.Remark;
            checkDto.CheckBy = empId;
            await hospitalInfoService.HospitalInfoCheckAsync(checkDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 获取资料审核通过医院名称列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("checkPassedNameList")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalNameVo>>> GetCheckPassedNameListAsync(string name)
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetCheckPassedHospitalNameListAsync(null, name)
                               select new HospitalNameVo
                               {
                                   Id = d.Id,
                                   Name = d.Name
                               };

                return ResultData<List<HospitalNameVo>>.Success().AddData("hospitalInfo", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalNameVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据编号获取医院资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detailsById/{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<SingleHospitalInfoVo>> GetHospitalInfoByIdAsync(int id)
        {
            try
            {
                var hospital = await hospitalInfoService.GetByIdAsync(id);
                SingleHospitalInfoVo hospitalInfoVo = new SingleHospitalInfoVo();
                hospitalInfoVo.Id = hospital.Id;
                hospitalInfoVo.Name = hospital.Name;
                hospitalInfoVo.ThumbPicUrl = hospital.ThumbPicUrl;
                hospitalInfoVo.Address = hospital.Address;
                hospitalInfoVo.DescriptionPicture = hospital.DescriptionPicture;
                hospitalInfoVo.Phone = hospital.Phone;
                hospitalInfoVo.Area = hospital.Area;
                hospitalInfoVo.HospitalCreateDate = hospital.HospitalCreateDate;
                hospitalInfoVo.IndustryHonors = hospital.IndustryHonors;
                hospitalInfoVo.ProfileRank = hospital.ProfileRank;
                hospitalInfoVo.Description = hospital.Description;
                hospitalInfoVo.SubmitStateText = hospital.SubmitStateText;
                hospitalInfoVo.CheckStateText = hospital.CheckStateText;
                hospitalInfoVo.CheckRemark = hospital.CheckRemark;
                List<int> scaleTagList = new List<int>();
                foreach (var item in hospital.ScaleTagList)
                {
                    scaleTagList.Add(item.Id);
                }
                hospitalInfoVo.ScaleTagList = scaleTagList;


                List<int> facilityTagList = new List<int>();
                foreach (var item in hospital.FacilityTagList)
                {
                    facilityTagList.Add(item.Id);

                }
                hospitalInfoVo.FacilityTagList = facilityTagList;

                //医院环境
                var hospitalEnvironmentInfo = await _hospitalEnvironmentService.GetIdAndNames();
                List<HospitalEnvironmentInfoVo> HospitalEnvironmentInfo = new List<HospitalEnvironmentInfoVo>();
                foreach (var x in hospitalEnvironmentInfo)
                {
                    HospitalEnvironmentInfoVo environmentInfo = new HospitalEnvironmentInfoVo();
                    environmentInfo.Id = x.Id;
                    environmentInfo.Name = x.Name;
                    var picture = await _hospitalEnvironmentPictureService.GetListWithPageAsync(x.Id, hospitalInfoVo.Id, 1, 10);
                    environmentInfo.PictureUrl = picture.List.Select(x => x.PictureUrl).ToList();
                    HospitalEnvironmentInfo.Add(environmentInfo);
                }
                hospitalInfoVo.HospitalEnvironmentInfo = HospitalEnvironmentInfo;
                //科室与医生
                var hospitalDepartmentInfo = await _amiyaHospitalDepartmentService.GetIdAndNames();
                List<DepartmentAndDoctor> DepartmentAndDoctors = new List<DepartmentAndDoctor>();
                foreach (var z in hospitalDepartmentInfo)
                {
                    DepartmentAndDoctor departmentandDoctorInfo = new DepartmentAndDoctor();
                    departmentandDoctorInfo.DepartmentId = z.Id;
                    departmentandDoctorInfo.DepartmentName = z.DepartmentName;
                    var doctorList = await _doctorService.GetListByHospitalIdAndDepartmentIdAsync(hospitalInfoVo.Id, z.Id);
                    List<DoctorVo> Doctor = new List<DoctorVo>();
                    foreach (var k in doctorList)
                    {
                        DoctorVo doctorResult = new DoctorVo();
                        doctorResult.Id = k.Id;
                        doctorResult.Name = k.Name;
                        doctorResult.PicUrl = k.PicUrl;
                        doctorResult.DepartmentId = k.DepartmentId;
                        doctorResult.Position = k.Position;
                        doctorResult.ObtainEmploymentYear = k.ObtainEmploymentYear;
                        doctorResult.Description = k.Description;
                        doctorResult.HospitalId = k.HospitalId;
                        doctorResult.HosptalName = k.HosptalName;
                        doctorResult.IsMain = k.IsMain;
                        doctorResult.ProjectPicture = k.ProjectPicture;
                        Doctor.Add(doctorResult);
                    }
                    departmentandDoctorInfo.Doctor = Doctor;
                    DepartmentAndDoctors.Add(departmentandDoctorInfo);
                }
                hospitalInfoVo.DepartmentAndDoctors = DepartmentAndDoctors;
                return ResultData<SingleHospitalInfoVo>.Success().AddData("hospitalInfo", hospitalInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<SingleHospitalInfoVo>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取有效医院名称列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("nameList")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalNameVo>>> GetHospitalNameListAsync(string name)
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetHospitalNameListAsync(true, name)
                               select new HospitalNameVo
                               {
                                   Id = d.Id,
                                   Name = d.Name
                               };

                return ResultData<List<HospitalNameVo>>.Success().AddData("hospitalInfo", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalNameVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取所有医院名称列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("allNameList")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalNameVo>>> GetAllHospitalNameListAsync(string name)
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetHospitalNameListAsync(null, name)
                               select new HospitalNameVo
                               {
                                   Id = d.Id,
                                   Name = d.Name
                               };

                return ResultData<List<HospitalNameVo>>.Success().AddData("hospitalInfo", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalNameVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加医院
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddHospitalInfoVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                AddHospitalInfoDto addDto = new AddHospitalInfoDto();
                addDto.Name = addVo.Name;
                addDto.ThumbPicUrl = addVo.ThumbPicUrl;
                addDto.Address = addVo.Address;
                addDto.Longitude = addVo.Longitude;
                addDto.Latitude = addVo.Latitude;
                addDto.Phone = addVo.Phone;
                addDto.TagIds = addVo.TagIds;
                addDto.ContractUrl = addVo.ContractUrl;
                addDto.DueTime = addVo.DueTime;
                addDto.CityId = addVo.CityId;
                addDto.BusinessHours = addVo.BusinessHours;
                addDto.BelongCompany = addVo.BelongCompany;
                await hospitalInfoService.AddAsync(addDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据医院编号获取医院信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<HospitalInfoDetailVo>> GetByIdAsync(int id)
        {
            try
            {
                var hospital = await hospitalInfoService.GetByIdAsync(id);
                HospitalInfoDetailVo hospitalInfoVo = new HospitalInfoDetailVo();
                hospitalInfoVo.Id = hospital.Id;
                hospitalInfoVo.Name = hospital.Name;
                hospitalInfoVo.ThumbPicUrl = hospital.ThumbPicUrl;
                hospitalInfoVo.Address = hospital.Address;
                hospitalInfoVo.Longitude = hospital.Longitude;
                hospitalInfoVo.Latitude = hospital.Latitude;
                hospitalInfoVo.Phone = hospital.Phone;
                hospitalInfoVo.Valid = hospital.Valid;
                hospitalInfoVo.ContractUrl = hospital.ContractUrl;
                hospitalInfoVo.DueTime = hospital.DueTime;
                hospitalInfoVo.CityId = hospital.CityId;
                hospitalInfoVo.City = hospital.City;
                hospitalInfoVo.BusinessHours = hospital.BusinessHours;
                hospitalInfoVo.BelongCompany = hospital.BelongCompany;
                List<int> scaleTagList = new List<int>();
                foreach (var item in hospital.ScaleTagList)
                {
                    scaleTagList.Add(item.Id);
                }
                hospitalInfoVo.ScaleTagList = scaleTagList;


                List<int> facilityTagList = new List<int>();
                foreach (var item in hospital.FacilityTagList)
                {
                    facilityTagList.Add(item.Id);

                }
                hospitalInfoVo.FacilityTagList = facilityTagList;
                return ResultData<HospitalInfoDetailVo>.Success().AddData("hospitalInfo", hospitalInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalInfoDetailVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 管理端修改医院信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalInfoVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                UpdateHospitalInfoDto updateDto = new UpdateHospitalInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.ContractUrl = updateVo.ContractUrl;
                updateDto.DueTime = updateVo.DueTime;
                updateDto.ThumbPicUrl = updateVo.ThumbPicUrl;
                updateDto.Address = updateVo.Address;
                updateDto.Longitude = updateVo.Longitude;
                updateDto.Latitude = updateVo.Latitude;
                updateDto.Phone = updateVo.Phone;
                updateDto.Valid = updateVo.Valid;
                updateDto.TagIds = updateVo.TagIds;
                updateDto.CityId = updateVo.CityId;
                updateDto.BusinessHours = updateVo.BusinessHours;
                updateDto.BelongCompany = updateVo.BelongCompany;
                await hospitalInfoService.UpdateAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 医院端修改医院信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("HospitalUpdate")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> HospitalUpdateAsync(HospitalUpdateHospitalInfoVo updateVo)
        {
            try
            {
                int hospitalId = 0;
                if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                    hospitalId = tenant.HospitalId;

                if (hospitalId == 0)
                    throw new Exception("医院编号不能为空");


                HospitalUpdateHospitalInfoDto updateDto = new HospitalUpdateHospitalInfoDto();
                updateDto.Id = hospitalId;
                updateDto.Name = updateVo.Name;
                updateDto.ThumbPicUrl = updateVo.ThumbPicUrl;
                updateDto.Address = updateVo.Address;
                updateDto.Area = updateVo.Area;
                updateDto.TagIds = updateVo.TagIds;
                updateDto.Phone = updateVo.Phone;
                updateDto.DescriptionPicture = updateVo.DescriptionPicture;
                updateDto.HospitalCreateDate = updateVo.HospitalCreateDate;
                updateDto.IndustryHonors = updateVo.IndustryHonors;
                updateDto.ProfileRank = updateVo.ProfileRank;
                updateDto.Description = updateVo.Description;
                List<HospitalEnvironmentPictureEditDto> environmentPictureDto = new List<HospitalEnvironmentPictureEditDto>();
                foreach (var x in updateVo.HospitalEnvironmentPicture)
                {
                    HospitalEnvironmentPictureEditDto environmentPicture = new HospitalEnvironmentPictureEditDto();
                    environmentPicture.HospitalId = x.hospitalId;
                    environmentPicture.HospitalEnvironmentId = x.HospitalEnvironmentId;
                    environmentPicture.PictureUrl = x.PictureUrl;
                    environmentPictureDto.Add(environmentPicture);
                }
                updateDto.HospitalEnvironmentPicture = environmentPictureDto;
                await hospitalInfoService.HospitalUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除医院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await hospitalInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 根据商品编号获取参与项目的医院名称列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="name">医院名称，null：全部</param>
        /// <returns></returns>
        [HttpGet("partakeItemHospitalList/{goodsId}")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalNameVo>>> GetPartakeItemHospitalNameListAsync(string goodsId, string name)
        {
            var hospital = from d in await hospitalInfoService.GetPartakeItemHospitalNameListAsync(goodsId, name)
                           select new HospitalNameVo
                           {
                               Id = d.Id,
                               Name = d.Name
                           };
            return ResultData<List<HospitalNameVo>>.Success().AddData("hospital", hospital.ToList());
        }
    }
}