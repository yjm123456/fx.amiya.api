using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class EmployeeBindLiveAnchorService : IEmployeeBindLiveAnchorService
    {
        private IUnitOfWork unitOfWork;
        private IDalEmployeeBindLiveAnchor dalEmployeeBindLiveAnchor;

        public EmployeeBindLiveAnchorService(IUnitOfWork unitOfWork, IDalEmployeeBindLiveAnchor dalEmployeeBindLiveAnchor)
        {
            this.dalEmployeeBindLiveAnchor = dalEmployeeBindLiveAnchor;
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<EmployeeBindLiveAnchorDto>> GetByEmpIdAsync(int employeeId)
        {
            try
            {
                var empbindLiveAnchor = await dalEmployeeBindLiveAnchor.GetAll().Where(e => e.EmployeeId == employeeId).ToListAsync();
                if (empbindLiveAnchor == null)
                {
                    return new List<EmployeeBindLiveAnchorDto>();
                }
                else
                {
                    List<EmployeeBindLiveAnchorDto> result = new List<EmployeeBindLiveAnchorDto>();
                    foreach (var x in empbindLiveAnchor)
                    {
                        EmployeeBindLiveAnchorDto empbindAnchor = new EmployeeBindLiveAnchorDto();
                        empbindAnchor.Id = x.Id;
                        empbindAnchor.EmployeeId = x.EmployeeId;
                        empbindAnchor.LiveAnchorId = x.LiveAnchorId;
                        result.Add(empbindAnchor);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateEmployeeBindLiveAnchorDto updateDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                await DeleteAsync(updateDto.EmployeeId);
                foreach (var x in updateDto.LiveAnchorId)
                {
                    EmployeeBindLiveAnchor result = new EmployeeBindLiveAnchor();
                    result.Id = Guid.NewGuid().ToString();
                    result.EmployeeId = updateDto.EmployeeId;
                    result.LiveAnchorId = x;
                    await dalEmployeeBindLiveAnchor.AddAsync(result, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        private async Task DeleteAsync(int empId)
        {
            try
            {
                var result = await dalEmployeeBindLiveAnchor.GetAll().Where(e => e.EmployeeId == empId).ToListAsync();
                foreach (var x in result)
                {
                    await dalEmployeeBindLiveAnchor.DeleteAsync(x, true);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
