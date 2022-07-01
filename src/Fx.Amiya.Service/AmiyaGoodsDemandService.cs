using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsDemand;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaGoodsDemandService : IAmiyaGoodsDemandService
    {
        private IDalAmiyaGoodsDemand dalAmiyaGoodsDemand;
        private IAmiyaHospitalDepartmentService _amiyaHospitalDepartmentService;

        public AmiyaGoodsDemandService(IDalAmiyaGoodsDemand dalAmiyaGoodsDemand, IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService)
        {
            this.dalAmiyaGoodsDemand = dalAmiyaGoodsDemand;
            _amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
        }



        public async Task<FxPageInfo<AmiyaGoodsDemandDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var amiyaGoodsDemand = from d in dalAmiyaGoodsDemand.GetAll()
                                       where keyword == null || d.ProjectNname.Contains(keyword) || d.Description.Contains(keyword)
                                       select new AmiyaGoodsDemandDto
                                       {
                                           Id = d.Id,
                                           ProjectNname = d.ProjectNname,
                                           HospitalDepartmentId = d.HospitalDepartmentId,
                                           Description = d.Description,
                                           ThumbPictureUrl = d.ThumbPictureUrl,
                                           Valid = d.Valid
                                       };

                FxPageInfo<AmiyaGoodsDemandDto> amiyaGoodsDemandPageInfo = new FxPageInfo<AmiyaGoodsDemandDto>();
                amiyaGoodsDemandPageInfo.TotalCount = await amiyaGoodsDemand.CountAsync();
                amiyaGoodsDemandPageInfo.List = await amiyaGoodsDemand.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return amiyaGoodsDemandPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddAmiyaGoodsDemandDto addDto)
        {
            try
            {
                var amiyaGoodsDemandtDal = dalAmiyaGoodsDemand.GetAll().Where(x => x.ProjectNname == addDto.ProjectNname && x.HospitalDepartmentId == addDto.HospitalDepartmentId).SingleOrDefault();
                if (amiyaGoodsDemandtDal != null)
                {
                    throw new Exception("已存在该名称的商品需求，请重新添加！");
                }
                AmiyaGoodsDemand amiyaGoodsDemand = new AmiyaGoodsDemand();
                amiyaGoodsDemand.Id = Guid.NewGuid().ToString();
                amiyaGoodsDemand.ProjectNname = addDto.ProjectNname;
                amiyaGoodsDemand.HospitalDepartmentId = addDto.HospitalDepartmentId;
                amiyaGoodsDemand.ThumbPictureUrl = addDto.ThumbPictureUrl;
                amiyaGoodsDemand.Description = addDto.Description;
                amiyaGoodsDemand.Valid = true;
                await dalAmiyaGoodsDemand.AddAsync(amiyaGoodsDemand, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<AmiyaGoodsDemandKeyAndValueDto>> GetIdAndNames(string hospitalDepartmentId)
        {
            try
            {
                var amiyaGoodsDemand = from d in dalAmiyaGoodsDemand.GetAll()
                                       where hospitalDepartmentId == null || d.HospitalDepartmentId == hospitalDepartmentId
                                       where d.Valid == true
                                       select new AmiyaGoodsDemandKeyAndValueDto
                                       {
                                           Id = d.Id,
                                           ProjectNname = d.ProjectNname
                                       };
                return amiyaGoodsDemand.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<AmiyaGoodsDemandDto> GetByIdAsync(string id)
        {
            try
            {
                var amiyaGoodsDemand = await dalAmiyaGoodsDemand.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (amiyaGoodsDemand == null)
                    throw new Exception("商品需求编号错误");

                AmiyaGoodsDemandDto amiyaGoodsDemandDto = new AmiyaGoodsDemandDto();
                amiyaGoodsDemandDto.Id = amiyaGoodsDemand.Id;
                amiyaGoodsDemandDto.ProjectNname = amiyaGoodsDemand.ProjectNname;
                amiyaGoodsDemandDto.HospitalDepartmentId = amiyaGoodsDemand.HospitalDepartmentId;
                amiyaGoodsDemandDto.HospitalDepartmentName = _amiyaHospitalDepartmentService.GetByIdAsync(amiyaGoodsDemand.HospitalDepartmentId).Result.DepartmentName;
                amiyaGoodsDemandDto.ThumbPictureUrl = (!string.IsNullOrEmpty(amiyaGoodsDemand.ThumbPictureUrl)) ? amiyaGoodsDemand.ThumbPictureUrl : "";
                amiyaGoodsDemandDto.Description = amiyaGoodsDemand.Description;
                amiyaGoodsDemandDto.Valid = amiyaGoodsDemand.Valid;
                return amiyaGoodsDemandDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<AmiyaGoodsDemandDto> GetByNameAsync(string name)
        {
            try
            {
                var amiyaGoodsDemand = await dalAmiyaGoodsDemand.GetAll().SingleOrDefaultAsync(e => e.ProjectNname == name);
                if (amiyaGoodsDemand == null)
                {
                    return new AmiyaGoodsDemandDto()
                    {
                        ThumbPictureUrl = "",
                        ProjectNname = "",
                        Id = ""
                    };
                }

                AmiyaGoodsDemandDto amiyaGoodsDemandDto = new AmiyaGoodsDemandDto();
                amiyaGoodsDemandDto.Id = amiyaGoodsDemand.Id;
                amiyaGoodsDemandDto.ProjectNname = amiyaGoodsDemand.ProjectNname;
                amiyaGoodsDemandDto.HospitalDepartmentId = amiyaGoodsDemand.HospitalDepartmentId;
                amiyaGoodsDemandDto.HospitalDepartmentName = _amiyaHospitalDepartmentService.GetByIdAsync(amiyaGoodsDemand.HospitalDepartmentId).Result.DepartmentName;
                amiyaGoodsDemandDto.ThumbPictureUrl = (!string.IsNullOrEmpty(amiyaGoodsDemand.ThumbPictureUrl)) ? amiyaGoodsDemand.ThumbPictureUrl : "";
                amiyaGoodsDemandDto.Description = amiyaGoodsDemand.Description;
                amiyaGoodsDemandDto.Valid = amiyaGoodsDemand.Valid;
                return amiyaGoodsDemandDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task UpdateAsync(UpdateAmiyaGoodsDemandDto updateDto)
        {
            try
            {
                var amiyaGoodsDemand = await dalAmiyaGoodsDemand.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (amiyaGoodsDemand == null)
                    throw new Exception("商品需求编号错误！");
                var hospitalDepartmentInfo = _amiyaHospitalDepartmentService.GetByIdAsync(updateDto.HospitalDepartmentId).Result;
                if (hospitalDepartmentInfo == null)
                {
                    throw new Exception("未找到对应的科室类型，请重新选择！");
                }
                var amiyaGoodsDemandDal = dalAmiyaGoodsDemand.GetAll().Where(x => x.ProjectNname == updateDto.ProjectNname && x.HospitalDepartmentId == updateDto.HospitalDepartmentId && x.Id != updateDto.Id).SingleOrDefault();
                if (amiyaGoodsDemandDal != null)
                {
                    throw new Exception("已存在该名的商品需求，请重新修改！");
                }
                amiyaGoodsDemand.ProjectNname = updateDto.ProjectNname;
                amiyaGoodsDemand.HospitalDepartmentId = updateDto.HospitalDepartmentId;
                amiyaGoodsDemand.ThumbPictureUrl = updateDto.ThumbPictureUrl;
                amiyaGoodsDemand.Description = updateDto.Description;
                amiyaGoodsDemand.Valid = updateDto.Valid;

                await dalAmiyaGoodsDemand.UpdateAsync(amiyaGoodsDemand, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var amiyaGoodsDemand = await dalAmiyaGoodsDemand.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (amiyaGoodsDemand == null)
                    throw new Exception("商品需求编号错误");

                await dalAmiyaGoodsDemand.DeleteAsync(amiyaGoodsDemand, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaGoodsDemandDto>> GetAll()
        {
            var amiyaGoodsDemand = from d in dalAmiyaGoodsDemand.GetAll()
                                   select new AmiyaGoodsDemandDto
                                   {
                                       Id = d.Id,
                                       ProjectNname = d.ProjectNname,
                                       HospitalDepartmentId = d.HospitalDepartmentId,
                                       Description = d.Description,
                                       ThumbPictureUrl = d.ThumbPictureUrl,
                                       Valid = d.Valid
                                   };
            return amiyaGoodsDemand.ToList();
        }

    }
}
