using Fx.Amiya.Dto.LiveAnchor;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure;
using Fx.Common;
using Fx.Amiya.DbModels.Model;

namespace Fx.Amiya.Service
{
    public class LiveAnchorService : ILiveAnchorService
    {
        private IDalLiveAnchor dalLiveAnchor;
        private IDalContentplatform _contentPlateForm;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private ILiveRequirementInfoService _liveRequirementInfoService;
        public LiveAnchorService(IDalLiveAnchor dalLiveAnchor,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            ILiveRequirementInfoService liveRequirementInfoService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IDalContentplatform contentPlateForm)
        {
            this.dalLiveAnchor = dalLiveAnchor;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
            _amiyaEmployeeService = amiyaEmployeeService;
            _liveRequirementInfoService = liveRequirementInfoService;
            _contentPlateForm = contentPlateForm;
        }


        /// <summary>
        /// 根据主播基础id获取有效的主播列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorDto>> GetValidListByLiveAnchorBaseIdAsync(string liveAnchorBaseId)
        {
            if (string.IsNullOrEmpty(liveAnchorBaseId))
            {
                throw new Exception("主播基础id为空！");
            }
            List<int> liveAnchorIds = new List<int>();

            var liveAnchors = from d in dalLiveAnchor.GetAll()
                              where d.Valid == true
                              && d.LiveAnchorBaseId == liveAnchorBaseId
                              select new LiveAnchorDto
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = string.IsNullOrWhiteSpace(d.HostAccountName) ? "" : d.HostAccountName,
                                  ContentPlateFormId = string.IsNullOrWhiteSpace(d.ContentPlateFormId) ? "" : d.ContentPlateFormId,
                                  LiveAnchorBaseId = d.LiveAnchorBaseId,
                                  Valid = d.Valid
                              };
            var resultList = await liveAnchors.ToListAsync();
            return resultList;
        }

        /// <summary>
        /// 根据主播基础id集合获取有效的主播列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorDto>> GetValidListByLiveAnchorBaseIdAsync(List<string> liveAnchorBaseIds)
        {
            if (liveAnchorBaseIds.Count == 0)
            {
                throw new Exception("主播基础id为空！");
            }
            var liveAnchors = from d in dalLiveAnchor.GetAll()
                              where d.Valid == true
                              && liveAnchorBaseIds.Contains(d.LiveAnchorBaseId)
                              select new LiveAnchorDto
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = string.IsNullOrWhiteSpace(d.HostAccountName) ? "" : d.HostAccountName,
                                  ContentPlateFormId = string.IsNullOrWhiteSpace(d.ContentPlateFormId) ? "" : d.ContentPlateFormId,
                                  LiveAnchorBaseId = d.LiveAnchorBaseId,
                                  Valid = d.Valid
                              };
            var resultList = await liveAnchors.ToListAsync();
            return resultList;
        }

        /// <summary>
        /// 根据内容平台id获取有效的主播列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorDto>> GetValidListByContentPlatFormIdAsync(string contentPlatFormId, int employeeId)
        {
            if (string.IsNullOrEmpty(contentPlatFormId))
            {
                throw new Exception("请先选择内容平台进行主播账号查询！");
            }
            List<int> liveAnchorIds = new List<int>();

            var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
            if (empInfo.PositionId == 19)
            {
                var bindLiveAnchorInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                foreach (var x in bindLiveAnchorInfo)
                {
                    liveAnchorIds.Add(x.LiveAnchorId);
                }
            }

            var liveAnchors = from d in dalLiveAnchor.GetAll()
                              where d.Valid == true
                              && d.ContentPlateFormId == contentPlatFormId
                              && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.Id))
                              select new LiveAnchorDto
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = string.IsNullOrWhiteSpace(d.HostAccountName) ? "" : d.HostAccountName,
                                  ContentPlateFormId = string.IsNullOrWhiteSpace(d.ContentPlateFormId) ? "" : d.ContentPlateFormId,
                                  LiveAnchorBaseId = d.LiveAnchorBaseId,
                                  Valid = d.Valid
                              };
            var resultList = await liveAnchors.ToListAsync();
            foreach (var x in resultList)
            {
                if (!string.IsNullOrEmpty(x.ContentPlateFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlateFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlateFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// 获取有效的主播列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorDto>> GetValidAsync()
        {
            var liveAnchors = from d in dalLiveAnchor.GetAll()
                              where d.Valid == true
                              select new LiveAnchorDto
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = string.IsNullOrWhiteSpace(d.HostAccountName) ? "" : d.HostAccountName,
                                  ContentPlateFormId = string.IsNullOrWhiteSpace(d.ContentPlateFormId) ? "" : d.ContentPlateFormId,
                                  Valid = d.Valid
                              };
            var resultList = await liveAnchors.ToListAsync();
            foreach (var x in resultList)
            {
                if (!string.IsNullOrEmpty(x.ContentPlateFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlateFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlateFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return resultList;
        }



        public async Task<FxPageInfo<LiveAnchorDto>> GetListAsync(string name, int employeeId, string contentPlatformId, bool valid, int pageNum, int pageSize)
        {
            List<int> liveAnchorIds = new List<int>();

            var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
            if (empInfo.PositionId == 19)
            {
                var bindLiveAnchorInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                foreach (var x in bindLiveAnchorInfo)
                {
                    liveAnchorIds.Add(x.LiveAnchorId);
                }
            }

            var liveAnchors = from d in dalLiveAnchor.GetAll()
                              where (string.IsNullOrWhiteSpace(name) || d.Name.Contains(name))
                              && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.Id))
                              && (string.IsNullOrEmpty(contentPlatformId) || d.ContentPlateFormId == contentPlatformId)
                              && (d.Valid == valid)
                              select new LiveAnchorDto
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = string.IsNullOrWhiteSpace(d.HostAccountName) ? "" : d.HostAccountName,
                                  ContentPlateFormId = string.IsNullOrWhiteSpace(d.ContentPlateFormId) ? "" : d.ContentPlateFormId,
                                  LiveAnchorBaseId=d.LiveAnchorBaseId,
                                  Valid = d.Valid
                              };
            FxPageInfo<LiveAnchorDto> liveAnchorPageInfo = new FxPageInfo<LiveAnchorDto>();
            liveAnchorPageInfo.TotalCount = await liveAnchors.CountAsync();
            liveAnchorPageInfo.List = await liveAnchors.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in liveAnchorPageInfo.List)
            {
                if (!string.IsNullOrEmpty(x.ContentPlateFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlateFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlateFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return liveAnchorPageInfo;
        }


        /// <summary>
        /// 添加主播账号
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddLiveAnchorDto addDto)
        {
            try
            {
                var resultCount = await this.GetValidListAsync();
                var result = resultCount.FirstOrDefault(e => e.HostAccountName == addDto.HostAccountName && e.ContentPlateFormId == addDto.ContentPlateFormId);
                if (result != null)
                    throw new Exception("已存在该主播账号");
                LiveAnchor liveAchor = new LiveAnchor();
                liveAchor.Name = addDto.Name;
                liveAchor.Valid = addDto.Valid;
                liveAchor.LiveAnchorBaseId = addDto.LiveAnchorBaseId;
                liveAchor.HostAccountName = addDto.HostAccountName;
                liveAchor.ContentPlateFormId = addDto.ContentPlateFormId;
                await dalLiveAnchor.AddAsync(liveAchor, true);
            }
            catch (Exception err)
            {
                string erra = err.Message.ToString();
                string u = "";
            }
        }



        public async Task<LiveAnchorDto> GetByIdAsync(int id)
        {
            var result = from d in dalLiveAnchor.GetAll()
                         select d;
            var x = result.SingleOrDefault(e => e.Id == id);
            if (x == null)
            {
                return new LiveAnchorDto()
                {
                    Name = "",
                    Id = 0,
                    HostAccountName = "",
                    ContentPlateFormId = "",
                    LiveAnchorBaseId = "",
                    Valid = false
                };
            }

            LiveAnchorDto liveAnchorDto = new LiveAnchorDto();
            liveAnchorDto.Id = x.Id;
            liveAnchorDto.Name = x.Name;
            liveAnchorDto.LiveAnchorBaseId = x.LiveAnchorBaseId;
            liveAnchorDto.HostAccountName = x.HostAccountName;
            liveAnchorDto.ContentPlateFormId = x.ContentPlateFormId;
            liveAnchorDto.Valid = x.Valid;
            return liveAnchorDto;
        }


        /// <summary>
        /// 修改主播账号
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateLiveAnchorDto updateDto)
        {
            var resultCount = await this.GetValidListAsync();
            var result = resultCount.FirstOrDefault(e => e.Id != updateDto.Id && e.HostAccountName == updateDto.HostAccountName && e.ContentPlateFormId == updateDto.ContentPlateFormId);
            if (result != null)
                throw new Exception("已存在该主播账号");
            LiveAnchor liveAchor = new LiveAnchor();
            liveAchor.Id = updateDto.Id;
            liveAchor.Name = updateDto.Name;
            liveAchor.Valid = updateDto.Valid;
            liveAchor.LiveAnchorBaseId = updateDto.LiveAnchorBaseId;
            liveAchor.HostAccountName = updateDto.HostAccountName;
            liveAchor.ContentPlateFormId = updateDto.ContentPlateFormId;
            await dalLiveAnchor.UpdateAsync(liveAchor, true);
        }



        /// <summary>
        /// 删除主播账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var result = await dalLiveAnchor.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            var livingRequirement = _liveRequirementInfoService.GetByLiveAnchorIdAsync(id);
            if (livingRequirement.Result.Count > 0)
            { throw new Exception("该主播已发布过直播间需求信息，请清空对应需求后进行删除！"); }
            await dalLiveAnchor.DeleteAsync(result, true);
        }

        /// <summary>
        /// 获取有效的主播账号
        /// </summary>
        /// <returns></returns>
        private async Task<List<LiveAnchorDto>> GetValidListAsync()
        {
            var liveAnchors = from d in dalLiveAnchor.GetAll()
                              where d.Valid == true
                              select new LiveAnchorDto
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = string.IsNullOrWhiteSpace(d.HostAccountName) ? "" : d.HostAccountName,
                                  ContentPlateFormId = string.IsNullOrWhiteSpace(d.ContentPlateFormId) ? "" : d.ContentPlateFormId,
                                  Valid = d.Valid
                              };
            var resultList = await liveAnchors.ToListAsync();
            foreach (var x in resultList)
            {
                if (!string.IsNullOrEmpty(x.ContentPlateFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlateFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlateFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return resultList;
        }

        public async Task<List<LiveAnchorDto>> GetLiveAnchorListByBaseInfoId(string baseInfoId)
        {
            return await dalLiveAnchor.GetAll().Where(l => l.LiveAnchorBaseId == baseInfoId&&l.Valid==true).Select(l=>new LiveAnchorDto {
                Id=l.Id
            }).ToListAsync();
        }
    }
}
