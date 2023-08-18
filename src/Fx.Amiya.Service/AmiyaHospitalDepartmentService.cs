using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AmiyaHospitalDepartment;
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
    public class AmiyaHospitalDepartmentService : IAmiyaHospitalDepartmentService
    {
        private IDalAmiyaHospitalDepartment dalAmiyaHospitalDepartment;
        private IUnitOfWork unitOfWork;

        public AmiyaHospitalDepartmentService(IUnitOfWork unitOfWork, IDalAmiyaHospitalDepartment dalAmiyaHospitalDepartment)
        {
            this.dalAmiyaHospitalDepartment = dalAmiyaHospitalDepartment;
            this.unitOfWork = unitOfWork;
        }



        public async Task<FxPageInfo<AmiyaHospitalDepartmentDto>> GetListWithPageAsync(string keyword)
        {
            try
            {
                var amiyaHospitalDepartment = from d in dalAmiyaHospitalDepartment.GetAll().OrderByDescending(z => z.Sort)
                                              where keyword == null || d.DepartmentName.Contains(keyword) || d.Description.Contains(keyword)
                                              select new AmiyaHospitalDepartmentDto
                                              {
                                                  Id = d.Id,
                                                  DepartmentName = d.DepartmentName,
                                                  Description = d.Description,
                                                  Valid = d.Valid,
                                                  Sort = d.Sort
                                              };

                FxPageInfo<AmiyaHospitalDepartmentDto> amiyaHospitalDepartmentPageInfo = new FxPageInfo<AmiyaHospitalDepartmentDto>();
                amiyaHospitalDepartmentPageInfo.TotalCount = await amiyaHospitalDepartment.CountAsync();
                amiyaHospitalDepartmentPageInfo.List = await amiyaHospitalDepartment.ToListAsync();

                return amiyaHospitalDepartmentPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(AddAmiyaHospitalDepartmentDto addDto)
        {
            try
            {
                var amiyaHospitalDepartmentDal = dalAmiyaHospitalDepartment.GetAll().Where(x => x.DepartmentName == addDto.DepartmentName).SingleOrDefault();
                if (amiyaHospitalDepartmentDal != null)
                {
                    throw new Exception("已存在该名称的科室，请重新添加！");
                }
                var maxSort = await GetMaxOrMinSortByShowDirectionType(true);
                AmiyaHospitalDepartment amiyaHospitalDepartment = new AmiyaHospitalDepartment();
                amiyaHospitalDepartment.Id = Guid.NewGuid().ToString();
                amiyaHospitalDepartment.DepartmentName = addDto.DepartmentName;
                amiyaHospitalDepartment.Description = addDto.Description;
                amiyaHospitalDepartment.Valid = true;
                amiyaHospitalDepartment.Sort = maxSort + 1;
                await dalAmiyaHospitalDepartment.AddAsync(amiyaHospitalDepartment, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<AmiyaHospitalDepartmentKeyAndValueDto>> GetIdAndNames()
        {
            try
            {
                var amiyaHospitalDepartment = from d in dalAmiyaHospitalDepartment.GetAll().OrderByDescending(z => z.Sort)
                                              where d.Valid == true
                                              select new AmiyaHospitalDepartmentKeyAndValueDto
                                              {
                                                  Id = d.Id,
                                                  DepartmentName = d.DepartmentName
                                              };
                return amiyaHospitalDepartment.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<AmiyaHospitalDepartmentDto> GetByIdAsync(string id)
        {
            try
            {
                var res = from d in dalAmiyaHospitalDepartment.GetAll()
                                              where d.Id == id
                                              select new AmiyaHospitalDepartmentDto
                                              {
                                                  Id = d.Id,
                                                  DepartmentName = d.DepartmentName,
                                                  Description = d.Description,
                                                  Valid = d.Valid,
                                                  Sort = d.Sort
                                              };
                var amiyaHospitalDepartment = res.FirstOrDefault();
                if (amiyaHospitalDepartment == null)
                {
                    return new AmiyaHospitalDepartmentDto();
                }

                AmiyaHospitalDepartmentDto amiyaHospitalDepartmentDto = new AmiyaHospitalDepartmentDto();
                amiyaHospitalDepartmentDto.Id = amiyaHospitalDepartment.Id;
                amiyaHospitalDepartmentDto.Description = amiyaHospitalDepartment.Description;
                amiyaHospitalDepartmentDto.DepartmentName = amiyaHospitalDepartment.DepartmentName;
                amiyaHospitalDepartmentDto.Valid = amiyaHospitalDepartment.Valid;
                amiyaHospitalDepartmentDto.Sort = amiyaHospitalDepartment.Sort;
                return amiyaHospitalDepartmentDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateAmiyaHospitalDepartmentDto updateDto)
        {
            try
            {
                var amiyaHospitalDepartment = await dalAmiyaHospitalDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaHospitalDepartment == null)
                    throw new Exception("医院科室编号错误！");
                var amiyaHospitalDepartmentDal = dalAmiyaHospitalDepartment.GetAll().Where(x => x.DepartmentName == updateDto.DepartmentName && x.Id != updateDto.Id).SingleOrDefault();
                if (amiyaHospitalDepartmentDal != null)
                {
                    throw new Exception("已存在该名称的科室，请重新修改！");
                }
                amiyaHospitalDepartment.Description = updateDto.Description;
                amiyaHospitalDepartment.DepartmentName = updateDto.DepartmentName;
                amiyaHospitalDepartment.Valid = updateDto.Valid;

                await dalAmiyaHospitalDepartment.UpdateAsync(amiyaHospitalDepartment, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var amiyaHospitalDepartment = await dalAmiyaHospitalDepartment.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (amiyaHospitalDepartment == null)
                    throw new Exception("医院科室编号错误");
                await dalAmiyaHospitalDepartment.DeleteAsync(amiyaHospitalDepartment, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        private async Task<int> GetMaxOrMinSortByShowDirectionType(bool IsMax)
        {
            if (IsMax == true)
            {
                var res = from d in dalAmiyaHospitalDepartment.GetAll()
                          select new AmiyaHospitalDepartmentDto
                          {
                              Id = d.Id,
                              DepartmentName = d.DepartmentName,
                              Description = d.Description,
                              Valid = d.Valid,
                              Sort = d.Sort
                          };
                return res.MaxAsync(z => z.Sort).Result;
            }
            else
            {
                var res = from d in dalAmiyaHospitalDepartment.GetAll()
                          select new AmiyaHospitalDepartmentDto
                          {
                              Id = d.Id,
                              DepartmentName = d.DepartmentName,
                              Description = d.Description,
                              Valid = d.Valid,
                              Sort = d.Sort
                          };
                return res.MinAsync(z => z.Sort).Result;
            }
        }

        public async Task MoveAsync(AmiyaHospitalDepartmentMoveDto hospitalDepartmentMove)
        {

            unitOfWork.BeginTransaction();
            var amiyaHospitalDepartment = await GetByIdAsync(hospitalDepartmentMove.Id);
            var changeAmiyaHospitalDepartment = await GetNearHospitalDepartment(hospitalDepartmentMove.Id, hospitalDepartmentMove.MoveState);
            if (changeAmiyaHospitalDepartment.Id != hospitalDepartmentMove.Id)
            {
                int changeSort = amiyaHospitalDepartment.Sort;
                //修改参数
                amiyaHospitalDepartment.Sort = changeAmiyaHospitalDepartment.Sort;
                //待修改参数数据
                changeAmiyaHospitalDepartment.Sort = changeSort;
                List<AmiyaHospitalDepartment> addAmiyaHospitalDepartment = new List<AmiyaHospitalDepartment>();
                AmiyaHospitalDepartment dep1 = new AmiyaHospitalDepartment();
                dep1.Id = amiyaHospitalDepartment.Id;
                dep1.DepartmentName = amiyaHospitalDepartment.DepartmentName;
                dep1.Description = amiyaHospitalDepartment.Description;
                dep1.Valid = amiyaHospitalDepartment.Valid;
                dep1.Sort = amiyaHospitalDepartment.Sort;
                addAmiyaHospitalDepartment.Add(dep1);
                AmiyaHospitalDepartment dep2 = new AmiyaHospitalDepartment();
                dep2.Id = changeAmiyaHospitalDepartment.Id;
                dep2.DepartmentName = changeAmiyaHospitalDepartment.DepartmentName;
                dep2.Description = changeAmiyaHospitalDepartment.Description;
                dep2.Valid = changeAmiyaHospitalDepartment.Valid;
                dep2.Sort = changeAmiyaHospitalDepartment.Sort;
                addAmiyaHospitalDepartment.Add(dep2);
                foreach (var z in addAmiyaHospitalDepartment)
                {
                    await dalAmiyaHospitalDepartment.UpdateAsync(z, true);
                }
            }
            unitOfWork.Commit();
        }

        /// <summary>
        /// 获取就近的排序医院科室
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IsUp"></param>
        /// <returns></returns>
        private async Task<AmiyaHospitalDepartmentDto> GetNearHospitalDepartment(string Id, bool IsUp)
        {
            var hospitalDepartment = from d in dalAmiyaHospitalDepartment.GetAll().OrderByDescending(z => z.Sort)
                                select new AmiyaHospitalDepartmentDto
                                {
                                    Id = d.Id,
                                    DepartmentName = d.DepartmentName,
                                    Description = d.Description,
                                    Valid = d.Valid,
                                    Sort = d.Sort
                                };
            var hospitalDepartmentList = hospitalDepartment.ToList();
            int ExistRow = 0;
            AmiyaHospitalDepartmentDto department = new AmiyaHospitalDepartmentDto();
            foreach (var x in hospitalDepartmentList)
            {
                if (x.Id == Id)
                {
                    break;
                }
                ExistRow++;
            }
            if (IsUp == true)
            {
                if (ExistRow == 0)
                {
                    var depModel = hospitalDepartmentList.Where(z => z.Id == Id).FirstOrDefault();
                    department.Id = depModel.Id;
                    department.DepartmentName = depModel.DepartmentName;
                    department.Description = depModel.Description;
                    department.Valid = depModel.Valid;
                    department.Sort = depModel.Sort;
                }
                else
                {
                    var nearRow = hospitalDepartmentList[ExistRow - 1];
                    department.Id = nearRow.Id;
                    department.DepartmentName = nearRow.DepartmentName;
                    department.Description = nearRow.Description;
                    department.Valid = nearRow.Valid;
                    department.Sort = nearRow.Sort;
                }
            }
            else
            {
                if (ExistRow + 1 == hospitalDepartmentList.Count)
                {
                    var depModel = hospitalDepartmentList.Where(z => z.Id == Id).FirstOrDefault();
                    department.Id = depModel.Id;
                    department.DepartmentName = depModel.DepartmentName;
                    department.Description = depModel.Description;
                    department.Valid = depModel.Valid;
                    department.Sort = depModel.Sort;
                }
                else
                {
                    var nearRow = hospitalDepartmentList[ExistRow + 1];
                    department.Id = nearRow.Id;
                    department.DepartmentName = nearRow.DepartmentName;
                    department.Description = nearRow.Description;
                    department.Valid = nearRow.Valid;
                    department.Sort = nearRow.Sort;
                }
            }
            return department;
        }

        public async Task MoveTopOrDownAsync(AmiyaHospitalDepartmentMoveDto goodsCategoryMove)
        {
            var goodsCategoryInfo = await GetByIdAsync(goodsCategoryMove.Id);
            if (goodsCategoryMove.MoveState == true)
            {
                goodsCategoryInfo.Sort = await GetMaxOrMinSortByShowDirectionType(true) + 1;
            }
            else
            {
                goodsCategoryInfo.Sort = await GetMaxOrMinSortByShowDirectionType(false) - 1;
            }
            //修改参数
            AmiyaHospitalDepartment hospitalDepartment = new AmiyaHospitalDepartment();
            hospitalDepartment.Id = goodsCategoryInfo.Id;
            hospitalDepartment.DepartmentName = goodsCategoryInfo.DepartmentName;
            hospitalDepartment.Description = goodsCategoryInfo.Description;
            hospitalDepartment.Valid = goodsCategoryInfo.Valid;
            hospitalDepartment.Sort = goodsCategoryInfo.Sort;
            await dalAmiyaHospitalDepartment.UpdateAsync(hospitalDepartment, true);
        }
    }
}
