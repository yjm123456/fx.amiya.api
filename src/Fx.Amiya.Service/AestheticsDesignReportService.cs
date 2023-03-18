using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AestheticsDesignReport;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
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

        public AestheticsDesignReportService(IDalAestheticsDesignReport dalAestheticsDesignReport)
        {
            this.dalAestheticsDesignReport = dalAestheticsDesignReport;
        }
        /// <summary>
        /// 添加美学设计报告
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAestheticsDesignReportAsync(AddAestheticsDesignReportDto addDto)
        {
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
            aestheticsDesignReport.Picture1 = addDto.Picture1;
            aestheticsDesignReport.Picture2 = addDto.Picture2;
            aestheticsDesignReport.Status = (int)AestheticsDesignReportStatus.Commit;
            aestheticsDesignReport.CreateDate = DateTime.Now;
            aestheticsDesignReport.Valid = true;
            await dalAestheticsDesignReport.AddAsync(aestheticsDesignReport,true);
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
        public async Task<AestheticsDesignReportInfoDto> GetById(string id)
        {
            var report= dalAestheticsDesignReport.GetAll().Where(e => e.Id == id).Select(e=>new AestheticsDesignReportInfoDto {
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
                Picture1=e.Picture1,
                Picture2=e.Picture2,
                Status=e.Status,
                StatusText=ServiceClass.GetAestheticsDesignReportStatus(e.Status)
            }).SingleOrDefault();
            if (report == null)
                throw new Exception("报告编号错误");
            return report;
        }

        public async Task<FxPageInfo<AestheticsDesignReportInfoDto>> GetListByPage(string customerId, int? designed, int pageNum, int pageSize)
        {
            var reportList = dalAestheticsDesignReport.GetAll()
                .Where(e => string.IsNullOrEmpty(customerId) || e.CustomerId == customerId)
                .Where(e => !designed.HasValue || e.Status == designed)
                .Select(e => new AestheticsDesignReportInfoDto
                {
                    Id = e.Id,
                    CreateDate = e.CreateDate,
                    CustomerId = e.CustomerId,
                    Name = e.Name,
                    BirthDay = e.BirthDay,
                    Phone = e.Phone,
                    City = e.City,
                    HasAestheticMedicineHistory = e.HasAestheticMedicineHistory,
                    HistoryDescribe1 = e.HistoryDescribe1,
                    HistoryDescribe2 = e.HistoryDescribe2,
                    HistoryDescribe3 = e.HistoryDescribe3,
                    WhetherAcceptOperation = e.WhetherAcceptOperation,
                    WhetherAllergyOrOtherDisease = e.WhetherAllergyOrOtherDisease,
                    AllergyOrOtherDiseaseDescribe = e.AllergyOrOtherDiseaseDescribe,
                    BeautyDemand = e.BeautyDemand,
                    Budget = e.Budget,
                    Picture1 = e.Picture1,
                    Picture2 = e.Picture2,
                    Status = e.Status,
                    StatusText = ServiceClass.GetAestheticsDesignReportStatus(e.Status)
                });
            FxPageInfo<AestheticsDesignReportInfoDto> fxPageInfo = new FxPageInfo<AestheticsDesignReportInfoDto>();
            fxPageInfo.TotalCount = reportList.Count();
            fxPageInfo.List = reportList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }

        public async Task UpdateAsync(UpdateAestheticsDesignReportInfoDto updateDto)
        {
            var report = dalAestheticsDesignReport.GetAll().Where(e => e.Id == updateDto.Id).SingleOrDefault();
            if (report == null) throw new Exception("报告编号错误！");                        
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
            report.Picture1 = updateDto.Picture1;
            report.Picture2 = updateDto.Picture2;
            report.UpdateDate = DateTime.Now;
            await dalAestheticsDesignReport.UpdateAsync(report, true);
        }
    }
}
