using Fx.Amiya.Dto.LiveRequirementInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class LiveRequirementInfoService : ILiveRequirementInfoService
    {
        private IDalLiveRequirementInfo dalLiveRequirementInfo;
        private IDalAmiyaDepartment dalAmiyaDepartment;
        private IDalRequirementType dalRequirementType;
        public LiveRequirementInfoService(IDalLiveRequirementInfo dalLiveRequirementInfo,
            IDalAmiyaDepartment dalAmiyaDepartment,
            IDalRequirementType dalRequirementType)
        {
            this.dalLiveRequirementInfo = dalLiveRequirementInfo;
            this.dalAmiyaDepartment = dalAmiyaDepartment;
            this.dalRequirementType = dalRequirementType;
        }

        public async Task<FxPageInfo<LiveRequirementInfoDto>> GetListWithPageAsync(int pageNum, int pageSize, byte? status, byte? liveTypeId, string keyword,string fansInfo)
        {
            var liveRequirementInfo = from d in dalLiveRequirementInfo.GetAll()
                                      where (status == null || d.Status == status)
                                      && (liveTypeId == null || d.LiveTypeId == liveTypeId)
                                      && (string.IsNullOrWhiteSpace(keyword) ||d.LiveAnchor.Name.Contains(keyword) || d.Description.Contains(keyword))
                                      && (string.IsNullOrWhiteSpace(fansInfo) || d.FansInfo.Contains(fansInfo))
                                      select new LiveRequirementInfoDto
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy = d.CreateBy,
                                          CreateName = d.CreateAmiyaEmployee.Name,
                                          Anchor =d.LiveAnchor.Name,
                                          LiveAnchorId =d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveType.Name,
                                          RequirementTypeId = d.RequirementTypeId, 
                                          RequirementTypeName = d.RequirementType.Name,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.AmiyaDepartment.Name,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = GetPriorityLevelText(d.PriorityLevel),
                                          Status = d.Status,
                                          StatusText = GetStatusText(d.Status),
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy = d.ResponseBy,
                                          ResponseByName = d.ResponseEmployee.Name,
                                          DecideBy=d.DecideBy,
                                          DecideByName=d.DecideEmployee.Name,
                                          DecideDate=d.DecideDate,
                                          DecideRemark=d.DecideRemark,
                                          ExecuteDate = d.ExecuteDate,
                                          ExecuteRemark = d.ExecuteRemark,
                                          ExecuteBy = d.ExecuteBy,
                                          ExecuteByName = d.ExecuteEmployee.Name
                                      };
            FxPageInfo<LiveRequirementInfoDto> requirementPageInfo = new FxPageInfo<LiveRequirementInfoDto>();
            requirementPageInfo.TotalCount = await liveRequirementInfo.CountAsync();
            requirementPageInfo.List = await liveRequirementInfo.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return requirementPageInfo;
        }

        /// <summary>
        /// 根据主播ID获取主播参与的需求
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <param name="liveTypeId"></param>
        /// <param name="keyword"></param>
        /// <param name="fansInfo"></param>
        /// <returns></returns>
        public async Task<List<LiveRequirementInfoDto>> GetByLiveAnchorIdAsync(int liveAnchorId)
        {
            var liveRequirementInfo = from d in dalLiveRequirementInfo.GetAll()
                                      where d.LiveAnchorId == liveAnchorId
                                      select new LiveRequirementInfoDto
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy = d.CreateBy,
                                          CreateName = d.CreateAmiyaEmployee.Name,
                                          Anchor = d.LiveAnchor.Name,
                                          LiveAnchorId = d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveType.Name,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementType.Name,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.AmiyaDepartment.Name,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = GetPriorityLevelText(d.PriorityLevel),
                                          Status = d.Status,
                                          StatusText = GetStatusText(d.Status),
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy = d.ResponseBy,
                                          ResponseByName = d.ResponseEmployee.Name,
                                          DecideBy = d.DecideBy,
                                          DecideByName = d.DecideEmployee.Name,
                                          DecideDate = d.DecideDate,
                                          DecideRemark = d.DecideRemark,
                                          ExecuteDate = d.ExecuteDate,
                                          ExecuteRemark = d.ExecuteRemark,
                                          ExecuteBy = d.ExecuteBy,
                                          ExecuteByName = d.ExecuteEmployee.Name
                                      };
            var result= await liveRequirementInfo.ToListAsync();
            return result;
        }


        /// <summary>
        /// 添加直播需求
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddLiveRequirementInfoDto addDto,int employeeId)
        {
            LiveRequirementInfo liveRequirementInfo = new LiveRequirementInfo();
            liveRequirementInfo.CreateDate = DateTime.Now;
            liveRequirementInfo.CreateBy = employeeId;
            liveRequirementInfo.LiveAnchorId = addDto.LiveAnchorId;
            liveRequirementInfo.LiveTypeId = addDto.LiveTypeId;
            liveRequirementInfo.RequirementTypeId = addDto.RequirementTypeId;
            liveRequirementInfo.FansInfo = addDto.FansInfo;
            liveRequirementInfo.Description = addDto.Description;
            liveRequirementInfo.DepartmentId = addDto.DepartmentId;
            liveRequirementInfo.PriorityLevel = addDto.PriorityLevel;
            liveRequirementInfo.Status = (byte)LiveRequirementStatus.UnResponse;
            await dalLiveRequirementInfo.AddAsync(liveRequirementInfo, true);
        }



        /// <summary>
        /// 修改需求信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateLiveRequirementInfoDto updateDto)
        {
            var liveRequirement = await dalLiveRequirementInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (liveRequirement == null)
                throw new Exception("需求编号错误");
            if (liveRequirement.Status != (byte)LiveRequirementStatus.UnResponse)
                throw new Exception("该需求已开始处理，不能修改");

            liveRequirement.LiveAnchorId = updateDto.LiveAnchorId;
            liveRequirement.LiveTypeId = updateDto.LiveTypeId;
            liveRequirement.RequirementTypeId = updateDto.RequirementTypeId;
            liveRequirement.FansInfo = updateDto.FansInfo;
            liveRequirement.Description = updateDto.Description;
            liveRequirement.DepartmentId = updateDto.DepartmentId;
            liveRequirement.PriorityLevel = updateDto.PriorityLevel;
            await dalLiveRequirementInfo.UpdateAsync(liveRequirement, true);
        }


        /// <summary>
        /// 获取待响应的需求列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<UnResponseLiveRequirementInfoDto>> GetUnResponseRequirementListAsync(int pageNum, int pageSize, int departmentId)
        {
            var department = await dalAmiyaDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == departmentId);

            var q = from d in dalLiveRequirementInfo.GetAll()
                    where d.Status == (byte)LiveRequirementStatus.UnResponse
                    select d;

            if (department.IsProcessingRequirementDepartment)
            {
                q = from d in q
                    where d.DepartmentId == departmentId
                    select d;
            }
            
            var liveRequirementInfo = from d in q
                                      select new UnResponseLiveRequirementInfoDto
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy=d.CreateBy,
                                          CreateName=d.CreateAmiyaEmployee.Name,
                                          Anchor = d.LiveAnchor.Name,
                                          LiveAnchorId = d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveType.Name,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementType.Name,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.AmiyaDepartment.Name,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = GetPriorityLevelText(d.PriorityLevel),
                                          Status = d.Status,
                                          StatusText = GetStatusText(d.Status),
                                      };

            FxPageInfo<UnResponseLiveRequirementInfoDto> requirementPageInfo = new FxPageInfo<UnResponseLiveRequirementInfoDto>();
            requirementPageInfo.TotalCount = await liveRequirementInfo.CountAsync();
            requirementPageInfo.List = await liveRequirementInfo.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return requirementPageInfo;

        }



        /// <summary>
        /// 获取部门已拒绝的需求列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<LiveRequirementInfoDto>> GetRefuseRequirementListAsync(int pageNum, int pageSize)
        {
            var liveRequirementInfo = from d in dalLiveRequirementInfo.GetAll()
                                      where d.Status == (byte)LiveRequirementStatus.Refuse
                                      select new LiveRequirementInfoDto
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy = d.CreateBy,
                                          CreateName = d.CreateAmiyaEmployee.Name,
                                          Anchor = d.LiveAnchor.Name,
                                          LiveAnchorId = d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveType.Name,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementType.Name,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.AmiyaDepartment.Name,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = GetPriorityLevelText(d.PriorityLevel),
                                          Status = d.Status,
                                          StatusText = GetStatusText(d.Status),
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy = d.ResponseBy,
                                          ResponseByName = d.ResponseEmployee.Name,
                                      };
            FxPageInfo<LiveRequirementInfoDto> requirementPageInfo = new FxPageInfo<LiveRequirementInfoDto>();
            requirementPageInfo.TotalCount = await liveRequirementInfo.CountAsync();
            requirementPageInfo.List = await liveRequirementInfo.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return requirementPageInfo;
        }

        /// <summary>
        /// 获取未处理的需求
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<LiveRequirementInfoDto>> GetUnTreatedRequirementListAsync(int pageNum, int pageSize, int departmentId)
        {
            var department = await dalAmiyaDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == departmentId);
            var q = from d in dalLiveRequirementInfo.GetAll()
                    where d.Status == (byte)LiveRequirementStatus.UnTreated
                    select d;
            if (department.IsProcessingRequirementDepartment)
            {
                q = from d in q
                    where d.DepartmentId == departmentId
                    select d;
            }
            var liveRequirementInfo = from d in q
                                      select new LiveRequirementInfoDto
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy=d.CreateBy,
                                          CreateName=d.CreateAmiyaEmployee.Name,
                                          Anchor = d.LiveAnchor.Name,
                                          LiveAnchorId = d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveType.Name,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementType.Name,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.AmiyaDepartment.Name,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = GetPriorityLevelText(d.PriorityLevel),
                                          Status = d.Status,
                                          StatusText = GetStatusText(d.Status),
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy=d.ResponseBy,
                                          ResponseByName=d.ResponseEmployee.Name,
                                          DecideBy=d.DecideBy,
                                          DecideByName=d.DecideEmployee.Name,
                                          DecideDate=d.DecideDate,
                                          DecideRemark=d.DecideRemark
                                      };
            FxPageInfo<LiveRequirementInfoDto> requirementPageInfo = new FxPageInfo<LiveRequirementInfoDto>();
            requirementPageInfo.TotalCount = await liveRequirementInfo.CountAsync();
            requirementPageInfo.List = await liveRequirementInfo.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return requirementPageInfo;
        }



        /// <summary>
        /// 部门响应直播需求
        /// </summary>
        /// <param name="responseRequirementDto"></param>
        /// <returns></returns>
        public async Task ResponseRequirementAsync(ResponseRequirementDto responseRequirementDto, int departmentId,int employeeId)
        {
            var department = await dalAmiyaDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == departmentId);
            byte status = (byte)LiveRequirementStatus.Refuse;
            if (responseRequirementDto.IsAccept == false)
            {
                status = (byte)LiveRequirementStatus.Refuse;
            }
            else
            {
                status = (byte)LiveRequirementStatus.UnTreated;
            }
            var liveRequirementInfo = await dalLiveRequirementInfo.GetAll().SingleOrDefaultAsync(e => e.Id == responseRequirementDto.Id);
            liveRequirementInfo.Status = status;
            liveRequirementInfo.ResponseRemark = responseRequirementDto.ResponseDescription;
            liveRequirementInfo.ResponseDate = DateTime.Now;
            liveRequirementInfo.ResponseBy = employeeId;
            await dalLiveRequirementInfo.UpdateAsync(liveRequirementInfo, true);
        }



        /// <summary>
        /// 评判直播需求
        /// </summary>
        /// <param name="decideRequirementDto"></param>
        /// <returns></returns>
        public async Task DecideRequirementAsync(DecideRequirementDto decideRequirementDto,int employeeId)
        {
            var liveRequirementInfo = await dalLiveRequirementInfo.GetAll().SingleOrDefaultAsync(e => e.Id == decideRequirementDto.Id);
            liveRequirementInfo.Status = decideRequirementDto.IsAcceptResponse ?  (byte)LiveRequirementStatus.Cancel: (byte)LiveRequirementStatus.UnTreated;
            liveRequirementInfo.DecideDate = DateTime.Now;
            liveRequirementInfo.DecideRemark = decideRequirementDto.DecideRemark;
            liveRequirementInfo.DecideBy = employeeId;
            if (decideRequirementDto.IsAcceptResponse == false)
            { 
                liveRequirementInfo.DepartmentId = (int)decideRequirementDto.DepartmentId;
            }

            await dalLiveRequirementInfo.UpdateAsync(liveRequirementInfo, true);
        }



        /// <summary>
        /// 执行需求
        /// </summary>
        /// <param name="executeDto"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(ExecuteLiveRequirementInfoDto executeDto,int employeeId)
        {
            var liveRequirementInfo = await dalLiveRequirementInfo.GetAll().SingleOrDefaultAsync(e => e.Id == executeDto.Id);
            if (liveRequirementInfo == null)
                throw new Exception("直播需求编号错误");
            liveRequirementInfo.Status = (byte)LiveRequirementStatus.UnConfirm;
            liveRequirementInfo.ExecuteRemark = executeDto.ExecuteRemark;
            liveRequirementInfo.ExecuteDate = DateTime.Now;
            liveRequirementInfo.ExecuteBy = employeeId;
            await dalLiveRequirementInfo.UpdateAsync(liveRequirementInfo, true);
        }



        /// <summary>
        /// 确定完成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ConfirmFinishAsync(int id)
        {
            var liveRequirementInfo = await dalLiveRequirementInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (liveRequirementInfo == null)
                throw new Exception("直播需求编号错误");
            liveRequirementInfo.Status = (byte)LiveRequirementStatus.Treated;
            await dalLiveRequirementInfo.UpdateAsync(liveRequirementInfo, true);
        }



        /// <summary>
        /// 获取总览数据
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<HeadCollectivityDataDto> GetHeadCollectivityDataAsync(int employeeId)
        {

            int totalCount = await dalLiveRequirementInfo.GetAll().CountAsync();
            int treatedCount = await dalLiveRequirementInfo.GetAll().CountAsync(e => e.Status == (byte)LiveRequirementStatus.Treated);
            int unTreatedCount = await dalLiveRequirementInfo.GetAll().CountAsync(e => e.Status == (byte)LiveRequirementStatus.UnResponse
            || e.Status == (byte)LiveRequirementStatus.Refuse|| e.Status == (byte)LiveRequirementStatus.UnTreated||e.Status==(byte)LiveRequirementStatus.UnConfirm);
            int cancelCount = await dalLiveRequirementInfo.GetAll().CountAsync(e => e.Status == (byte)LiveRequirementStatus.Cancel);
            decimal treatedRate = treatedCount != 0?Math.Round(((decimal)treatedCount / totalCount) * 100, 1):0;

            
            var requirementInfo = from d in dalLiveRequirementInfo.GetAll()
                                  group d by d.RequirementTypeId into g
                                  select new RequirementTypeRateDto
                                  {
                                      Id = g.Key,
                                      RequirementTypeRate = g.Count()!=0? Math.Round(((decimal)g.Count() / totalCount) * 100, 1):0
                                  };
            var requirements = await requirementInfo.ToListAsync();
            var requirementTypes = await dalRequirementType.GetAll().ToListAsync();
            var requirementTypeRate = from d in requirementTypes
                                      join t in requirements on d.Id equals t.Id into dt
                                      from t in dt.DefaultIfEmpty()
                                      select new RequirementTypeRateDto
                                      {
                                          Id = d.Id,
                                          Name = d.Name,
                                          RequirementTypeRate = t != null ? t.RequirementTypeRate : 0
                                      };
          
            var responseRequirements = await dalLiveRequirementInfo.GetAll().Where(e => e.ResponseDate != null).ToListAsync();
            var executeRequirements = await dalLiveRequirementInfo.GetAll().Where(e => e.ExecuteDate != null).ToListAsync();
            double responseHour = 0;
            double executeHour = 0;
            foreach (var item in responseRequirements)
            {
                responseHour += ((DateTime)item.ResponseDate - item.CreateDate).TotalHours;
            }
            foreach (var item in executeRequirements)
            {
                executeHour += ((DateTime)item.ExecuteDate - (DateTime)item.ResponseDate).TotalHours;
            }

            var waitConfirmFinishQuantity = await dalLiveRequirementInfo.GetAll().CountAsync(e=>e.CreateBy==employeeId&&e.Status==(byte)LiveRequirementStatus.UnConfirm);

            HeadCollectivityDataDto headCollectivityDataDto = new HeadCollectivityDataDto();
            headCollectivityDataDto.TotalCount = totalCount;
            headCollectivityDataDto.TreatedQuantity = treatedCount;
            headCollectivityDataDto.UnTreatedQuantity = unTreatedCount;
            headCollectivityDataDto.CancelQuantity = cancelCount;
            headCollectivityDataDto.TreatedRate = treatedRate;
            headCollectivityDataDto.RequirementTypeRateList = requirementTypeRate.ToList();
            headCollectivityDataDto.AvgResponseHour = responseRequirements.Count() != 0 ? Math.Round((decimal)responseHour / responseRequirements.Count(), 1) : 0;
            headCollectivityDataDto.AvgExecuteHour = executeRequirements.Count() != 0 ? Math.Round((decimal)executeHour / executeRequirements.Count(), 1) : 0;
            headCollectivityDataDto.WaitConfirmFinishQuantity = waitConfirmFinishQuantity;
            return headCollectivityDataDto;
        }


        /// <summary>
        /// 获取未确认完成的需求列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<UnConfirmLiveRequirementInfoDto>> GetUnConfirmFinishListAsync(int employeeId, int pageNum, int pageSize)
        {
            var unConfirmRequirement = from d in dalLiveRequirementInfo.GetAll()
                                       where d.CreateBy == employeeId
                                       && d.Status == (byte)LiveRequirementStatus.UnConfirm
                                       select new UnConfirmLiveRequirementInfoDto
                                       {
                                           Id = d.Id,
                                           CreateDate = d.CreateDate,
                                           CreateBy=d.CreateBy,
                                           CreateName=d.CreateAmiyaEmployee.Name,
                                           Anchor = d.LiveAnchor.Name,
                                           LiveAnchorId = d.LiveAnchorId,
                                           LiveTypeId = d.LiveTypeId,
                                           LiveTypeName = d.LiveType.Name,
                                           RequirementTypeId = d.RequirementTypeId,
                                           RequirementTypeName = d.RequirementType.Name,
                                           FansInfo = d.FansInfo,
                                           Description = d.Description,
                                           DepartmentId = d.DepartmentId,
                                           DepartmentName = d.AmiyaDepartment.Name,
                                           PriorityLevel = d.PriorityLevel,
                                           PriorityLevelText = GetPriorityLevelText(d.PriorityLevel),
                                           ExecuteDate = d.ExecuteDate,
                                           ExecuteRemark = d.ExecuteRemark,
                                           ExecuteBy=d.ExecuteBy,
                                           ExecuteByName=d.ExecuteEmployee.Name
                                       };
            FxPageInfo<UnConfirmLiveRequirementInfoDto> requirementPageInfo = new FxPageInfo<UnConfirmLiveRequirementInfoDto>();
            requirementPageInfo.TotalCount = await unConfirmRequirement.CountAsync();
            requirementPageInfo.List = await unConfirmRequirement.OrderByDescending(e=>e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return requirementPageInfo;
        }



        /// <summary>
        /// 获取进度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProgressBarDto> GetProgressBarAsync(int id)
        {
            var requirementInfo = await dalLiveRequirementInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            ProgressBarDto progressBarDto = new ProgressBarDto();
            progressBarDto.CreateDate = requirementInfo.CreateDate;
            if (requirementInfo.ResponseDate != null)
            {
                progressBarDto.ResponseDate = requirementInfo.ResponseDate;
                progressBarDto.ResponseSeconds = (int)((DateTime)requirementInfo.ResponseDate - requirementInfo.CreateDate).TotalSeconds;

                if (requirementInfo.ExecuteDate != null)
                {
                    progressBarDto.ExecuteDate = requirementInfo.ExecuteDate;
                    progressBarDto.ExecuteSeconds = (int)((DateTime)requirementInfo.ExecuteDate - (DateTime)requirementInfo.ResponseDate).TotalSeconds;
                }
                else
                {
                    progressBarDto.ExecuteSeconds = (int)(DateTime.Now - (DateTime)requirementInfo.ResponseDate).TotalSeconds;
                }

            }
           
            return progressBarDto;
        }


        private static string GetPriorityLevelText(byte priorityLevel)
        {
            string text = "";
            switch (priorityLevel)
            {
                case 0:
                    text = "一般";
                    break;

                case 1:
                    text = "紧急";
                    break;
            }
            return text;
        }


        private static string GetStatusText(byte status)
        {
            string statusText = "";
            switch (status)
            {
                case 0:
                    statusText = "未接单";
                    break;

                case 1:
                    statusText = "拒绝";
                    break;

                case 2:
                    statusText = "作废";
                    break;

                case 3:
                    statusText = "已接单";
                    break;

                case 4:
                    statusText = "已处理待确认";
                    break;

                case 5:
                    statusText = "已处理";
                    break;
            }
            return statusText;
        }
    }
}
