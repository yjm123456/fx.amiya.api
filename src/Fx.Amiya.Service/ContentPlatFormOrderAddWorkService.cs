
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlatFormOrderAddWork;
using Fx.Amiya.Dto.ContentPlatFormOrderAddWork.Input;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ContentPlatFormOrderAddWorkService : IContentPlatFormOrderAddWorkService
    {
        private IDalContentPlatFormOrderAddWork _dalContentPlatFormOrderAddWork;
        private IAmiyaEmployeeService amiyaEmployeeService;
        private IUnitOfWork unitOfWork;
        public ContentPlatFormOrderAddWorkService(IDalContentPlatFormOrderAddWork dalContentPlatFormOrderAddWork,
            IAmiyaEmployeeService amiyaEmployeeService,
            IUnitOfWork unitOfWork)
        {
            _dalContentPlatFormOrderAddWork = dalContentPlatFormOrderAddWork;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<FxPageInfo<ContentPlatFormOrderAddWorkDto>> GetListByPageAsync(QueryContentPlatFormOrderAddWorkPageDto query)
        {
            var record = _dalContentPlatFormOrderAddWork.GetAll().Include(x => x.CreateEmployee).Include(x => x.AcceptEmployee).Include(x => x.HospitalInfo)
                .Where(e => (string.IsNullOrEmpty(query.KeyWord) || e.Phone.Contains(query.KeyWord) || e.Id.Contains(query.KeyWord)))
                .Where(e => !query.HospitalId.HasValue || e.HospitalId == query.HospitalId.Value)
                .Where(e => !query.CheckState.HasValue || e.CheckState == query.CheckState.Value)
                .Where(e => !query.StartDate.HasValue || e.CreateDate >= query.StartDate)
                .Where(e => !query.EndDate.HasValue || e.CreateDate <= query.EndDate.Value.AddDays(1))
                .OrderByDescending(x => x.CreateDate)
                .Where(e => e.Valid == true)
                .Select(e => new ContentPlatFormOrderAddWorkDto
                {
                    Id = e.Id,
                    HospitalId = e.HospitalId,
                    HospitalName = e.HospitalInfo.Name,
                    AcceptBy = e.AcceptBy,
                    AcceptByEmpName = e.AcceptEmployee.Name,
                    Phone = e.Phone,
                    SendRemark = e.SendRemark,
                    CreateBy = e.CreateBy,
                    CreateByEmpName = e.CreateEmployee.Name,
                    CreateDate = e.CreateDate,
                    BelongCustomerServiceId = e.BelongCustomerServiceId,
                    CheckState = e.CheckState,
                    CheckStateText = ServiceClass.GetCheckTypeText(e.CheckState),
                    CheckRemark = e.CheckRemark,
                    CheckDate = e.CheckDate,
                });
            FxPageInfo<ContentPlatFormOrderAddWorkDto> fxPageInfo = new FxPageInfo<ContentPlatFormOrderAddWorkDto>();
            fxPageInfo.TotalCount = await record.CountAsync();
            fxPageInfo.List = await record.Skip((query.PageNum - 1) * query.PageSize).Take(query.PageSize).ToListAsync();
            foreach (var x in fxPageInfo.List)
            {
                if (x.BelongCustomerServiceId.HasValue)
                {
                    var empInfo = await amiyaEmployeeService.GetByIdAsync(x.BelongCustomerServiceId.Value);
                    x.BelongCustomerServiceName = empInfo.Name;
                }
            }
            return fxPageInfo;
        }

        public async Task AddAsync(AddContentPlatFormOrderAddWorkDto addDto)
        {
            ContentPlatFormOrderAddWork contentPlatFormOrderAddWork = new ContentPlatFormOrderAddWork();
            contentPlatFormOrderAddWork.Id = CreateOrderIdHelper.GetBillNextNumber();
            contentPlatFormOrderAddWork.HospitalId = addDto.HospitalId;
            contentPlatFormOrderAddWork.AcceptBy = addDto.AcceptBy;
            contentPlatFormOrderAddWork.Phone = addDto.Phone;
            contentPlatFormOrderAddWork.SendRemark = addDto.SendRemark;
            contentPlatFormOrderAddWork.CheckState = (int)CheckState.CheckPending;
            contentPlatFormOrderAddWork.CheckRemark = "";
            contentPlatFormOrderAddWork.Valid = true;
            contentPlatFormOrderAddWork.CreateBy = addDto.CreateBy;
            contentPlatFormOrderAddWork.CreateDate = DateTime.Now;
            await _dalContentPlatFormOrderAddWork.AddAsync(contentPlatFormOrderAddWork, true);

        }

        public async Task<ContentPlatFormOrderAddWorkDto> GetByIdAsync(string id)
        {
            var selectResult = await _dalContentPlatFormOrderAddWork.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectResult == null)
            {
                throw new Exception("未找到录单申请列表数据，请重新获取！");
            }
            ContentPlatFormOrderAddWorkDto result = new ContentPlatFormOrderAddWorkDto();
            result.Id = selectResult.Id;
            result.HospitalId = selectResult.HospitalId;
            result.AcceptBy = selectResult.AcceptBy;
            result.Phone = selectResult.Phone;
            result.SendRemark = selectResult.SendRemark;
            result.CreateBy = selectResult.CreateBy;
            result.CreateDate = selectResult.CreateDate;
            result.BelongCustomerServiceId = selectResult.BelongCustomerServiceId;
            result.CheckState = selectResult.CheckState;
            result.CheckStateText = ServiceClass.GetCheckTypeText(selectResult.CheckState);
            result.CheckRemark = selectResult.CheckRemark;
            result.CheckDate = selectResult.CheckDate;
            return result;
        }
        public async Task UpdateAsync(UpdateContentPlatFormOrderAddWorkDto updateContentPlatFormOrderAddWorkDto)
        {
            var result = await _dalContentPlatFormOrderAddWork.GetAll().Where(x => x.Id == updateContentPlatFormOrderAddWorkDto.Id).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("未找到录单申请列表数据，请重新获取！");
            }
            result.AcceptBy = updateContentPlatFormOrderAddWorkDto.AcceptBy;
            result.Phone = updateContentPlatFormOrderAddWorkDto.Phone;
            result.HospitalId = updateContentPlatFormOrderAddWorkDto.HospitalId;
            result.SendRemark = updateContentPlatFormOrderAddWorkDto.SendRemark;
            result.UpdateDate = DateTime.Now;
            await _dalContentPlatFormOrderAddWork.UpdateAsync(result, true);
        }

        /// <summary>
        /// 审核录单申请工单
        /// </summary>
        /// <param name="updateContentPlatFormOrderAddWorkDto"></param>
        /// <returns></returns>
        public async Task CheckAsync(CheckContentPlatFormOrderAddWorkDto updateContentPlatFormOrderAddWorkDto)
        {
            var result = await _dalContentPlatFormOrderAddWork.GetAll().Where(x => x.Id == updateContentPlatFormOrderAddWorkDto.Id).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("未找到录单申请列表数据，请重新获取！");
            }
            result.BelongCustomerServiceId = updateContentPlatFormOrderAddWorkDto.BelongCustomerServiceId;
            result.HospitalId = updateContentPlatFormOrderAddWorkDto.HospitalId;
            result.CheckRemark = updateContentPlatFormOrderAddWorkDto.CheckRemark;
            result.CheckState = updateContentPlatFormOrderAddWorkDto.CheckState;
            result.CheckDate = DateTime.Now;
            await _dalContentPlatFormOrderAddWork.UpdateAsync(result, true);
        }

        public async Task DeleteAsync(List<string> idList)
        {
            unitOfWork.BeginTransaction();
            try
            {
                foreach (var k in idList)
                {

                    var result = await _dalContentPlatFormOrderAddWork.GetAll().Where(x => x.Id == k).FirstOrDefaultAsync();
                    if (result == null)
                    {
                        continue;
                    }
                    result.Valid = false;
                    result.DeleteDate = DateTime.Now;
                    await _dalContentPlatFormOrderAddWork.UpdateAsync(result, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }
    }
}
