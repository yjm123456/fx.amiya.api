using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Amiya.Dto.RunTangDateOperation.Input;
using Fx.Amiya.Dto.RunTangDateOperation.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class RunTangDateOperationService : IRunTangDateOperationService
    {
        private readonly IDalRunTangDateOperation dalRunTangDateOperation;
        public RunTangDateOperationService(IDalRunTangDateOperation dalRunTangDateOperation)
        {
            this.dalRunTangDateOperation = dalRunTangDateOperation;
        }



        /// <summary>
        /// 根据条件获取润棠运营添加反馈信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<RunTangDateOperationDto>> GetListAsync(QueryRunTangDateOperationDto query)
        {
            AmiyaEmployeeDto employeeInfo = new AmiyaEmployeeDto();
            var runTangDateOperations = from d in dalRunTangDateOperation.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorBaseInfo)
                                        where (string.IsNullOrEmpty(query.KeyWord) || d.Remark.Contains(query.KeyWord))
                                        && (d.Valid == query.Valid)
                                        select new RunTangDateOperationDto
                                        {
                                            Id = d.Id,
                                            CreateDate = d.CreateDate,
                                            RecordDate = d.RecordDate,
                                            UpdateDate = d.UpdateDate,
                                            Valid = d.Valid,
                                            DeleteDate = d.DeleteDate,
                                            CreateBy = d.CreateBy,
                                            CreateByName = d.AmiyaEmployee.Name,
                                            LiveAnchorBaseId = d.LiveAnchorBaseId,
                                            LiveAnchorBaseName = d.LiveAnchorBaseInfo.LiveAnchorName,
                                            CustomerAddNum = d.CustomerAddNum,
                                            CompanyAddNum = d.CompanyAddNum,
                                            TotalAddNum = d.TotalAddNum,
                                            EffictiveCommunicationNum = d.EffictiveCommunicationNum,
                                            EffictiveCommunicationRate = d.EffictiveCommunicationRate,
                                            InvalidCustomerNum = d.InvalidCustomerNum,
                                            EffictiveCustomerNum = d.EffictiveCustomerNum,
                                            EffictiveCustomerRate = d.EffictiveCustomerRate,
                                            Remark = d.Remark,
                                        };
            FxPageInfo<RunTangDateOperationDto> runTangDateOperationPageInfo = new FxPageInfo<RunTangDateOperationDto>();
            runTangDateOperationPageInfo.TotalCount = await runTangDateOperations.CountAsync();
            runTangDateOperationPageInfo.List = await runTangDateOperations.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return runTangDateOperationPageInfo;
        }


        /// <summary>
        /// 添加润棠运营添加反馈
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddRunTangDateOperationDto addDto)
        {
            try
            {
                RunTangDateOperation runTangDateOperation = new RunTangDateOperation();
                runTangDateOperation.Id = Guid.NewGuid().ToString();
                runTangDateOperation.CreateDate = DateTime.Now;
                runTangDateOperation.Valid = true;
                runTangDateOperation.CreateBy = addDto.CreateBy;
                runTangDateOperation.RecordDate = addDto.RecordDate;
                runTangDateOperation.LiveAnchorBaseId = addDto.LiveAnchorBaseId;
                runTangDateOperation.CustomerAddNum = addDto.CustomerAddNum;
                runTangDateOperation.CompanyAddNum = addDto.CompanyAddNum;
                runTangDateOperation.TotalAddNum = addDto.TotalAddNum;
                runTangDateOperation.EffictiveCommunicationNum = addDto.EffictiveCommunicationNum;
                runTangDateOperation.EffictiveCommunicationRate = addDto.EffictiveCommunicationRate;
                runTangDateOperation.InvalidCustomerNum = addDto.InvalidCustomerNum;
                runTangDateOperation.EffictiveCustomerNum = addDto.EffictiveCustomerNum;
                runTangDateOperation.EffictiveCustomerRate = addDto.EffictiveCustomerRate;
                runTangDateOperation.Remark = addDto.Remark;
                await dalRunTangDateOperation.AddAsync(runTangDateOperation, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



        public async Task<RunTangDateOperationDto> GetByIdAsync(string id)
        {
            var result = await dalRunTangDateOperation.GetAll().Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new RunTangDateOperationDto();
            }

            RunTangDateOperationDto returnResult = new RunTangDateOperationDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.CreateBy = result.CreateBy;
            returnResult.RecordDate = result.RecordDate;
            returnResult.LiveAnchorBaseId = result.LiveAnchorBaseId;
            returnResult.CustomerAddNum = result.CustomerAddNum;
            returnResult.CompanyAddNum = result.CompanyAddNum;
            returnResult.TotalAddNum = result.TotalAddNum;
            returnResult.EffictiveCommunicationNum = result.EffictiveCommunicationNum;
            returnResult.EffictiveCommunicationRate = result.EffictiveCommunicationRate;
            returnResult.InvalidCustomerNum = result.InvalidCustomerNum;
            returnResult.EffictiveCustomerNum = result.EffictiveCustomerNum;
            returnResult.EffictiveCustomerRate = result.EffictiveCustomerRate;
            returnResult.Remark = result.Remark;
            return returnResult;
        }

        /// <summary>
        /// 修改润棠运营添加反馈
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateRunTangDateOperationDto updateDto)
        {
            var result = await dalRunTangDateOperation.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("未找到润棠运营添加反馈信息");
            }
            
            result.RecordDate = updateDto.RecordDate;
            result.LiveAnchorBaseId = updateDto.LiveAnchorBaseId;
            result.CustomerAddNum = updateDto.CustomerAddNum;
            result.CompanyAddNum = updateDto.CompanyAddNum;
            result.TotalAddNum = updateDto.TotalAddNum;
            result.EffictiveCommunicationNum = updateDto.EffictiveCommunicationNum;
            result.EffictiveCommunicationRate = updateDto.EffictiveCommunicationRate;
            result.InvalidCustomerNum = updateDto.InvalidCustomerNum;
            result.EffictiveCustomerNum = updateDto.EffictiveCustomerNum;
            result.EffictiveCustomerRate = updateDto.EffictiveCustomerRate;
            result.Remark = updateDto.Remark;
            result.UpdateDate = DateTime.Now;
            await dalRunTangDateOperation.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废润棠运营添加反馈
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalRunTangDateOperation.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到润棠运营添加反馈信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalRunTangDateOperation.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }

    }
}
