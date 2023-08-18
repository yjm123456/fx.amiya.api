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
using Fx.Amiya.Dto.LiveAnchorWeChatInfo;

namespace Fx.Amiya.Service
{
    public class LiveAnchorWeChatInfoService : ILiveAnchorWeChatInfoService
    {
        private IDalLiveAnchorWeChatInfo dalLiveAnchorWeChatInfo;
        private IDalContentplatform _contentPlateForm;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;
        private ILiveRequirementInfoService _liveRequirementInfoService;
        public LiveAnchorWeChatInfoService(IDalLiveAnchorWeChatInfo dalLiveAnchorWeChatInfo,
            ILiveRequirementInfoService liveRequirementInfoService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            IDalContentplatform contentPlateForm)
        {
            this.dalLiveAnchorWeChatInfo = dalLiveAnchorWeChatInfo;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
            _liveRequirementInfoService = liveRequirementInfoService;
            _contentPlateForm = contentPlateForm;
        }


        /// <summary>
        /// 获取有效的主播微信列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorWeChatInfoDto>> GetValidAsync()
        {
            var liveAnchorWeChatInfos = from d in dalLiveAnchorWeChatInfo.GetAll()
                                        where d.Valid == true
                                        select new LiveAnchorWeChatInfoDto
                                        {
                                            Id = d.Id,
                                            LiveAnchorId = d.LiveAnchorId,
                                            LiveAnchorName = d.LiveAnchor.Name,
                                            ContentPlatFormId = d.LiveAnchor.ContentPlateFormId,
                                            WeChatNo = d.WeChatNo,
                                            NickName = d.NickName,
                                            Remark = d.Remark,
                                            Valid = d.Valid
                                        };
            var resultList = await liveAnchorWeChatInfos.ToListAsync();
            foreach (var x in resultList)
            {
                if (!string.IsNullOrEmpty(x.ContentPlatFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlatFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlatFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return resultList;
        }


        /// <summary>
        /// 根据内容平台id获取有效的主播列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorWeChatInfoDto>> GetValidListByLiveAnchorIdAsync(int? liveAnchorId, int employeeId)
        {
            List<int> liveAnchorIds = new List<int>();
            if (liveAnchorId.HasValue)
            {
                liveAnchorIds.Add(liveAnchorId.Value);
            }
            var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
            if (empInfo.PositionId == 19)
            {
                var bindLiveAnchorInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                foreach (var x in bindLiveAnchorInfo)
                {
                    liveAnchorIds.Add(x.LiveAnchorId);
                }
            }

            var liveAnchors = from d in dalLiveAnchorWeChatInfo.GetAll().Include(e => e.LiveAnchor)
                              where d.Valid == true
                              && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorId))
                              select new LiveAnchorWeChatInfoDto
                              {
                                  Id = d.Id,
                                  LiveAnchorId = d.LiveAnchorId,
                                  LiveAnchorName = d.LiveAnchor.Name,
                                  ContentPlatFormId = d.LiveAnchor.ContentPlateFormId,
                                  WeChatNo = d.WeChatNo,
                                  NickName = d.NickName,
                                  Remark = d.Remark,
                                  Valid = d.Valid
                              };
            var resultList = await liveAnchors.ToListAsync();
            foreach (var x in resultList)
            {
                if (!string.IsNullOrEmpty(x.ContentPlatFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlatFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlatFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return resultList;
        }


        public async Task<FxPageInfo<LiveAnchorWeChatInfoDto>> GetListAsync(string keyword, int? liveAnchorId, int employeeId, bool valid, int pageNum, int pageSize)
        {
            List<int> liveAnchorWeChatInfoIds = new List<int>();
            if (liveAnchorId.HasValue)
            {
                liveAnchorWeChatInfoIds.Add(liveAnchorId.Value);
            }
            var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
            if (empInfo.PositionId == 19)
            {
                var bindLiveAnchorWeChatInfoInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                foreach (var x in bindLiveAnchorWeChatInfoInfo)
                {
                    liveAnchorWeChatInfoIds.Add(x.LiveAnchorId);
                }
            }

            var liveAnchorWeChatInfos = from d in dalLiveAnchorWeChatInfo.GetAll().Include(e => e.LiveAnchor)
                                        where (string.IsNullOrWhiteSpace(keyword) || d.LiveAnchor.Name.Contains(keyword) || d.WeChatNo.Contains(keyword) || d.NickName.Contains(keyword) || d.Remark.Contains(keyword))
                                        && (liveAnchorWeChatInfoIds.Count == 0 || liveAnchorWeChatInfoIds.Contains(d.LiveAnchorId))
                                        && (d.Valid == valid)
                                        select new LiveAnchorWeChatInfoDto
                                        {
                                            Id = d.Id,
                                            LiveAnchorId = d.LiveAnchorId,
                                            LiveAnchorName = d.LiveAnchor.Name,
                                            ContentPlatFormId = d.LiveAnchor.ContentPlateFormId,
                                            WeChatNo = d.WeChatNo,
                                            NickName = d.NickName,
                                            Remark = d.Remark,
                                            Valid = d.Valid
                                        };
            FxPageInfo<LiveAnchorWeChatInfoDto> liveAnchorWeChatInfoPageInfo = new FxPageInfo<LiveAnchorWeChatInfoDto>();
            liveAnchorWeChatInfoPageInfo.TotalCount = await liveAnchorWeChatInfos.CountAsync();
            liveAnchorWeChatInfoPageInfo.List = await liveAnchorWeChatInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in liveAnchorWeChatInfoPageInfo.List)
            {
                if (!string.IsNullOrEmpty(x.ContentPlatFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlatFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlatFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return liveAnchorWeChatInfoPageInfo;
        }


        /// <summary>
        /// 添加主播微信账号
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddLiveAnchorWeChatInfoDto addDto)
        {
            try
            {
                var resultCount = await this.GetValidListAsync();
                var result = resultCount.FirstOrDefault(e => e.LiveAnchorId == addDto.LiveAnchorId && e.WeChatNo == addDto.WeChatNo);
                if (result != null)
                    throw new Exception("已存在该主播微信账号");
                LiveAnchorWeChatInfo liveAchorWeChat = new LiveAnchorWeChatInfo();
                liveAchorWeChat.Id = Guid.NewGuid().ToString();
                liveAchorWeChat.LiveAnchorId = addDto.LiveAnchorId;
                liveAchorWeChat.Valid = true;
                liveAchorWeChat.WeChatNo = addDto.WeChatNo;
                liveAchorWeChat.NickName = addDto.NickName;
                liveAchorWeChat.Remark = addDto.Remark;
                await dalLiveAnchorWeChatInfo.AddAsync(liveAchorWeChat, true);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message.ToString());
            }
        }



        public async Task<LiveAnchorWeChatInfoDto> GetByIdAsync(string id)
        {
            var result = from d in dalLiveAnchorWeChatInfo.GetAll().Include(x => x.LiveAnchor)
                         select d;
            var x = result.FirstOrDefault(e => e.Id == id);
            if (x == null)
            {
                return new LiveAnchorWeChatInfoDto();
            }

            LiveAnchorWeChatInfoDto liveAnchorWeChatInfoDto = new LiveAnchorWeChatInfoDto();
            liveAnchorWeChatInfoDto.Id = x.Id;
            liveAnchorWeChatInfoDto.ContentPlatFormId = x.LiveAnchor.ContentPlateFormId;
            liveAnchorWeChatInfoDto.LiveAnchorId = x.LiveAnchorId;
            liveAnchorWeChatInfoDto.WeChatNo = x.WeChatNo;
            liveAnchorWeChatInfoDto.NickName = x.NickName;
            liveAnchorWeChatInfoDto.Remark = x.Remark;
            liveAnchorWeChatInfoDto.Valid = x.Valid;
            return liveAnchorWeChatInfoDto;
        }


        /// <summary>
        /// 修改主播微信账号
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateLiveAnchorWeChatInfoDto updateDto)
        {
            var resultCount = await this.GetValidListAsync();
            var result = resultCount.FirstOrDefault(e => e.Id != updateDto.Id && e.LiveAnchorId == updateDto.LiveAnchorId && e.WeChatNo == updateDto.WeChatNo);
            if (result != null)
                throw new Exception("已存在该主播微信账号");
            LiveAnchorWeChatInfo liveAchor = new LiveAnchorWeChatInfo();
            liveAchor.Id = updateDto.Id;
            liveAchor.LiveAnchorId = updateDto.LiveAnchorId;
            liveAchor.WeChatNo = updateDto.WeChatNo;
            liveAchor.Valid = updateDto.Valid;
            liveAchor.NickName = updateDto.NickName;
            liveAchor.Remark = updateDto.Remark;
            await dalLiveAnchorWeChatInfo.UpdateAsync(liveAchor, true);
        }



        ///// <summary>
        ///// 删除主播微信账号
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task DeleteAsync(string id)
        //{
        //    var result = await dalLiveAnchorWeChatInfo.GetAll().FirstOrDefaultAsync(e => e.Id == id);
        //    await dalLiveAnchorWeChatInfo.DeleteAsync(result, true);
        //}

        /// <summary>
        /// 删除主播微信账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var result = await dalLiveAnchorWeChatInfo.GetAll().FirstOrDefaultAsync(e => e.Id == id);
            result.Valid = false;
            await dalLiveAnchorWeChatInfo.UpdateAsync(result, true);
        }

        /// <summary>
        /// 获取有效的主播微信账号
        /// </summary>
        /// <returns></returns>
        private async Task<List<LiveAnchorWeChatInfoDto>> GetValidListAsync()
        {
            var liveAnchorWeChatInfos = from d in dalLiveAnchorWeChatInfo.GetAll()
                                        where d.Valid == true
                                        select new LiveAnchorWeChatInfoDto
                                        {
                                            Id = d.Id,
                                            LiveAnchorId = d.LiveAnchorId,
                                            LiveAnchorName = d.LiveAnchor.Name,
                                            ContentPlatFormId = d.LiveAnchor.ContentPlateFormId,
                                            WeChatNo = d.WeChatNo,
                                            NickName = d.NickName,
                                            Remark = d.Remark,
                                            Valid = d.Valid
                                        };
            var resultList = await liveAnchorWeChatInfos.ToListAsync();
            foreach (var x in resultList)
            {
                if (!string.IsNullOrEmpty(x.ContentPlatFormId))
                {
                    var contentPlateFormInfo = _contentPlateForm.GetAll().FirstOrDefaultAsync(z => z.Id == x.ContentPlatFormId);
                    if (contentPlateFormInfo.Result != null)
                    {
                        x.ContentPlatFormName = contentPlateFormInfo.Result.ContentPlatformName;
                    }
                }
            }
            return resultList;
        }
    }
}
