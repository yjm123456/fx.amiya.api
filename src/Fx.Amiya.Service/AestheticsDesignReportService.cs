using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AestheticsDesignReport;
using Fx.Amiya.Dto.CustomerBaseInfo;
using Fx.Amiya.Dto.MiniProgramSendMessage;
using Fx.Amiya.Dto.UserInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AestheticsDesignReportService : IAestheticsDesignReportService
    {
        private readonly IDalAestheticsDesignReport dalAestheticsDesignReport;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAestheticsDesignService aestheticsDesignService;
        private readonly ICustomerBaseInfoService customerBaseInfoService;
        private readonly IDalCustomerInfo dalCustomerInfo;
        private readonly IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService;
        public AestheticsDesignReportService(IDalAestheticsDesignReport dalAestheticsDesignReport, IUserService userService, IUnitOfWork unitOfWork, IAestheticsDesignService aestheticsDesignService, ICustomerBaseInfoService customerBaseInfoService, IDalCustomerInfo dalCustomerInfo, IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService)
        {
            this.dalAestheticsDesignReport = dalAestheticsDesignReport;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.aestheticsDesignService = aestheticsDesignService;
            this.customerBaseInfoService = customerBaseInfoService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.miniProgramTemplateMessageSendService = miniProgramTemplateMessageSendService;
        }
        /// <summary>
        /// 添加美学设计报告
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAestheticsDesignReportAsync(AddAestheticsDesignReportDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                AestheticsDesignReport aestheticsDesignReport = new AestheticsDesignReport();
                aestheticsDesignReport.Id = CreateOrderIdHelper.GetBillNextNumber();
                aestheticsDesignReport.CustomerId = addDto.CustomerId;
                aestheticsDesignReport.Name = addDto.Name;
                aestheticsDesignReport.BirthDay = addDto.BirthDay;
                aestheticsDesignReport.Phone = addDto.Phone;
                aestheticsDesignReport.City = addDto.City;
                aestheticsDesignReport.HasAestheticMedicineHistory = addDto.HasAestheticMedicineHistory;
                aestheticsDesignReport.HistoryDescribe1 = addDto.HistoryDescribe1;
                aestheticsDesignReport.HistoryDescribe2 = addDto.HistoryDescribe2;
                aestheticsDesignReport.HistoryDescribe3 = addDto.HistoryDescribe3;
                aestheticsDesignReport.WhetherAcceptOperation = addDto.WhetherAcceptOperation;
                aestheticsDesignReport.WhetherAllergyOrOtherDisease = addDto.WhetherAllergyOrOtherDisease;
                aestheticsDesignReport.AllergyOrOtherDiseaseDescribe = addDto.AllergyOrOtherDiseaseDescribe;
                aestheticsDesignReport.BeautyDemand = addDto.BeautyDemand;
                aestheticsDesignReport.Budget = addDto.Budget;
                aestheticsDesignReport.FrontPicture = addDto.FrontPicture;
                aestheticsDesignReport.SidePicture = addDto.SidePicture;
                aestheticsDesignReport.Status = (int)AestheticsDesignReportStatus.Commit;
                aestheticsDesignReport.CreateDate = DateTime.Now;
                aestheticsDesignReport.Valid = true;
                await dalAestheticsDesignReport.AddAsync(aestheticsDesignReport, true);
                UpdateUserInfoByAestheticsDto updateUserInfoDto = new UpdateUserInfoByAestheticsDto();
                updateUserInfoDto.UserId = addDto.UserId;
                updateUserInfoDto.CustomerId = addDto.CustomerId;
                updateUserInfoDto.BirthDay = addDto.BirthDay.Value;
                updateUserInfoDto.Name = addDto.Name;
                updateUserInfoDto.Phone = addDto.Phone;
                updateUserInfoDto.City = addDto.City.Split("-")[1];
                updateUserInfoDto.Area = addDto.City.Split("-")[2];
                updateUserInfoDto.Province = addDto.City.Split("-")[0];
                await userService.UpdateUserInfoByAestheticsDesignReportAsync(updateUserInfoDto);
                var customer = dalCustomerInfo.GetAll().Where(e => e.Id == addDto.CustomerId).FirstOrDefault();
                var baseInfo = await customerBaseInfoService.GetByPhoneAsync(customer.Phone);
                if (baseInfo != null)
                {
                    UpdateCustomerBaseInfoDto updateCustomerBaseInfoDto = new UpdateCustomerBaseInfoDto();
                    updateCustomerBaseInfoDto.Id = baseInfo.Id;
                    updateCustomerBaseInfoDto.PersonalWechat = baseInfo.PersonalWechat;
                    updateCustomerBaseInfoDto.Phone = baseInfo.Phone;
                    updateCustomerBaseInfoDto.BusinessWeChat = baseInfo.BusinessWeChat;
                    updateCustomerBaseInfoDto.WechatMiniProgram = baseInfo.WechatMiniProgram;
                    updateCustomerBaseInfoDto.OfficialAccounts = baseInfo.OfficialAccounts;
                    updateCustomerBaseInfoDto.RealName = addDto.Name;
                    updateCustomerBaseInfoDto.WechatNumber = baseInfo.WechatNumber;
                    updateCustomerBaseInfoDto.Sex = baseInfo.Sex;
                    updateCustomerBaseInfoDto.Birthday = addDto.BirthDay;
                    updateCustomerBaseInfoDto.Occupation = baseInfo.Occupation;
                    updateCustomerBaseInfoDto.OtherPhone = addDto.Phone;
                    updateCustomerBaseInfoDto.DetailAddress = baseInfo.DetailAddress;
                    updateCustomerBaseInfoDto.IsSendNote = baseInfo.IsSendNote;
                    updateCustomerBaseInfoDto.IsCall = baseInfo.IsCall;
                    updateCustomerBaseInfoDto.IsSendWeChat = baseInfo.IsSendWeChat;
                    updateCustomerBaseInfoDto.UnTrackReason = baseInfo.UnTrackReason;
                    updateCustomerBaseInfoDto.Remark = baseInfo.Remark;
                    updateCustomerBaseInfoDto.City = addDto.City;
                    await customerBaseInfoService.UpdateAsync(updateCustomerBaseInfoDto);
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
        /// 删除美学设计报告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id,string customerId)
        {
            var report= dalAestheticsDesignReport.GetAll().Where(e => e.Id == id && e.CustomerId == customerId).SingleOrDefault();
            if (report == null)
                throw new Exception("报告编号错误！");
            report.Valid = false;
            await dalAestheticsDesignReport.UpdateAsync(report,true);
        }
        /// <summary>
        /// 根据id获取美学设计报告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AestheticsDesignReportAndDesignInfoDto> GetByIdAsync(string id)
        {
            var report= dalAestheticsDesignReport.GetAll().Where(e => e.Id == id).Select(e=>new AestheticsDesignReportAndDesignInfoDto
            {
                Id=e.Id,
                CreateDate=e.CreateDate,
                CustomerId=e.CustomerId,
                Name=e.Name,
                BirthDay=e.BirthDay,
                Phone=e.Phone,
                City=e.City,
                HasAestheticMedicineHistory=e.HasAestheticMedicineHistory,
                HistoryDescribe1=e.HistoryDescribe1,
                HistoryDescribe2 = e.HistoryDescribe2,
                HistoryDescribe3 = e.HistoryDescribe3,
                WhetherAcceptOperation =e.WhetherAcceptOperation,
                WhetherAllergyOrOtherDisease=e.WhetherAllergyOrOtherDisease,
                AllergyOrOtherDiseaseDescribe=e.AllergyOrOtherDiseaseDescribe,
                BeautyDemand=e.BeautyDemand,
                Budget=e.Budget,
                FrontPicture=e.FrontPicture,
                SidePicture=e.SidePicture,
                Status=e.Status,
                StatusText=ServiceClass.GetAestheticsDesignReportStatus(e.Status),
            }).SingleOrDefault();
            if (report == null)
                throw new Exception("报告编号错误");
            var design =await aestheticsDesignService.GetByReportIdAsync(report.Id);
            DesignInfo designInfo = new DesignInfo();
            if (design!=null) {
                designInfo.Id = design.Id;
                designInfo.AestheticsDesignReportId = design.AestheticsDesignReportId;
                designInfo.Design = design.Design;
                designInfo.HospitalId = design.HospitalId;
                designInfo.PictureTags = design.PictureTags;
                designInfo.SimpleHospitalName = design.SimpleHospitalName;
                designInfo.SidePicture = design.SidePicture;
                designInfo.FrontPicture = design.FrontPicture;
            }
            report.Design = designInfo;
            return report;
        }

        public async Task<FxPageInfo<AestheticsDesignReportInfoDto>> GetListByPage(DateTime? startDate, DateTime? endDate, string keyword, string customerId, int? designed, int? pageNum, int? pageSize)
        {
            var reportList = dalAestheticsDesignReport.GetAll()
                .Where(e => string.IsNullOrEmpty(customerId) || e.CustomerId == customerId)
                .Where(e => !designed.HasValue || e.Status == designed)
                .Where(e=>!startDate.HasValue||e.CreateDate>=startDate.Value.Date)
                .Where(e=>!endDate.HasValue||e.CreateDate<endDate.Value.Date.AddDays(1))
                .Where(e=>string.IsNullOrEmpty(keyword)||e.Name.Contains(keyword))
                .Where(e => string.IsNullOrEmpty(keyword) || e.Phone.Contains(keyword))
                .Select(e => new AestheticsDesignReportInfoDto
                {
                    Id = e.Id,
                    CreateDate = e.CreateDate,
                    CustomerId = e.CustomerId ?? "",
                    Name = e.Name,
                    BirthDay = e.BirthDay,
                    Phone = e.Phone ?? "",
                    City = e.City,
                    HasAestheticMedicineHistory = e.HasAestheticMedicineHistory,
                    HistoryDescribe1 = e.HistoryDescribe1 ?? "",
                    HistoryDescribe2 = e.HistoryDescribe2 ?? "",
                    HistoryDescribe3 = e.HistoryDescribe3 ?? "",
                    WhetherAcceptOperation = e.WhetherAcceptOperation,
                    WhetherAllergyOrOtherDisease = e.WhetherAllergyOrOtherDisease,
                    AllergyOrOtherDiseaseDescribe = e.AllergyOrOtherDiseaseDescribe ?? "",
                    BeautyDemand = e.BeautyDemand ?? "",
                    Budget = e.Budget,
                    FrontPicture = e.FrontPicture ?? "",
                    SidePicture = e.SidePicture ?? "",
                    Status = e.Status,
                    StatusText = ServiceClass.GetAestheticsDesignReportStatus(e.Status)
                }).OrderByDescending(e=>e.CreateDate);
            FxPageInfo<AestheticsDesignReportInfoDto> fxPageInfo = new FxPageInfo<AestheticsDesignReportInfoDto>();
            fxPageInfo.TotalCount = reportList.Count();
            fxPageInfo.List = reportList.Skip((pageNum.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
            return fxPageInfo;
        }
        /// <summary>
        /// 修改美学报告
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateAestheticsDesignReportInfoDto updateDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var report = dalAestheticsDesignReport.GetAll().Where(e => e.Id == updateDto.Id).SingleOrDefault();
                if (report == null) throw new Exception("报告编号错误！");
                if(report.Status==(int)AestheticsDesignReportStatus.Desgined) throw new Exception("已完成设计的美学报告不能修改！");
                report.Name = updateDto.Name;
                report.BirthDay = updateDto.BirthDay;
                report.Phone = updateDto.Phone;
                report.City = updateDto.City;
                report.HasAestheticMedicineHistory = updateDto.HasAestheticMedicineHistory;
                report.HistoryDescribe1 = updateDto.HistoryDescribe1;
                report.HistoryDescribe2 = updateDto.HistoryDescribe2;
                report.HistoryDescribe3 = updateDto.HistoryDescribe3;
                report.WhetherAcceptOperation = updateDto.WhetherAcceptOperation;
                report.WhetherAllergyOrOtherDisease = updateDto.WhetherAllergyOrOtherDisease;
                report.AllergyOrOtherDiseaseDescribe = updateDto.AllergyOrOtherDiseaseDescribe;
                report.BeautyDemand = updateDto.BeautyDemand;
                report.Budget = updateDto.Budget;
                report.FrontPicture = updateDto.FrontPicture;
                report.SidePicture = updateDto.SidePicture;
                report.UpdateDate = DateTime.Now;
                await dalAestheticsDesignReport.UpdateAsync(report, true);
                UpdateUserInfoByAestheticsDto updateUserInfoDto = new UpdateUserInfoByAestheticsDto();
                updateUserInfoDto.UserId = updateDto.UserId;
                updateUserInfoDto.CustomerId = updateDto.CustomerId;
                updateUserInfoDto.BirthDay = updateDto.BirthDay.Value;
                updateUserInfoDto.Name = updateDto.Name;
                updateUserInfoDto.Phone = updateDto.Phone;
                updateUserInfoDto.City = updateDto.City.Split("-")[1];
                updateUserInfoDto.Area = updateDto.City.Split("-")[2];
                updateUserInfoDto.Province = updateDto.City.Split("-")[0];
                await userService.UpdateUserInfoByAestheticsDesignReportAsync(updateUserInfoDto);
                var customer = dalCustomerInfo.GetAll().Where(e => e.Id == updateDto.CustomerId).FirstOrDefault();
                var baseInfo = await customerBaseInfoService.GetByPhoneAsync(customer.Phone);
                if (baseInfo != null)
                {
                    UpdateCustomerBaseInfoDto updateCustomerBaseInfoDto = new UpdateCustomerBaseInfoDto();
                    updateCustomerBaseInfoDto.Id = baseInfo.Id;
                    updateCustomerBaseInfoDto.PersonalWechat = baseInfo.PersonalWechat;
                    updateCustomerBaseInfoDto.Phone = baseInfo.Phone;
                    updateCustomerBaseInfoDto.BusinessWeChat = baseInfo.BusinessWeChat;
                    updateCustomerBaseInfoDto.WechatMiniProgram = baseInfo.WechatMiniProgram;
                    updateCustomerBaseInfoDto.OfficialAccounts = baseInfo.OfficialAccounts;
                    updateCustomerBaseInfoDto.RealName = updateDto.Name;
                    updateCustomerBaseInfoDto.WechatNumber = baseInfo.WechatNumber;
                    updateCustomerBaseInfoDto.Sex = baseInfo.Sex;
                    updateCustomerBaseInfoDto.Birthday = updateDto.BirthDay;
                    updateCustomerBaseInfoDto.Occupation = baseInfo.Occupation;
                    updateCustomerBaseInfoDto.OtherPhone = updateDto.Phone;
                    updateCustomerBaseInfoDto.DetailAddress = baseInfo.DetailAddress;
                    updateCustomerBaseInfoDto.IsSendNote = baseInfo.IsSendNote;
                    updateCustomerBaseInfoDto.IsCall = baseInfo.IsCall;
                    updateCustomerBaseInfoDto.IsSendWeChat = baseInfo.IsSendWeChat;
                    updateCustomerBaseInfoDto.UnTrackReason = baseInfo.UnTrackReason;
                    updateCustomerBaseInfoDto.Remark = baseInfo.Remark;
                    updateCustomerBaseInfoDto.City = updateDto.City;
                    await customerBaseInfoService.UpdateAsync(updateCustomerBaseInfoDto);
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
        /// 美学设计报告状态列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto<int>>> GetStatusListAsync()
        {
            var showDirectionTypes = Enum.GetValues(typeof(AestheticsDesignReportStatus));
            List<BaseKeyValueDto<int>> requestTypeList = new List<BaseKeyValueDto<int>>();
            foreach (var item in showDirectionTypes)
            {
                BaseKeyValueDto<int> requestType = new BaseKeyValueDto<int>();
                requestType.Key = Convert.ToInt32(item);
                requestType.Value = ServiceClass.GetAestheticsDesignReportStatus(Convert.ToInt32(item));
                requestTypeList.Add(requestType);
            }
            return requestTypeList;
        }
        /// <summary>
        /// 修改美学设计报告状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task UpdateStatusAsync(string id, int status)
        {
            var report = dalAestheticsDesignReport.GetAll().Where(e => e.Id == id).SingleOrDefault();
            if (report == null) throw new Exception("美学设计报告编号错误！");
            report.Status = status;
            await dalAestheticsDesignReport.UpdateAsync(report, true);
        }
    }
}
