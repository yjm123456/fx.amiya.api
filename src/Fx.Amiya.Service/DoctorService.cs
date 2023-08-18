using Fx.Amiya.Dto.Doctor;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.DbModels.Model;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class DoctorService : IDoctorService
    {
        private IDalDoctor dalDoctor;
        private IAmiyaHospitalDepartmentService _hospitalDepartmentService;
        public DoctorService(IDalDoctor dalDoctor, IAmiyaHospitalDepartmentService hospitalDepartmentService)
        {
            this.dalDoctor = dalDoctor;
            _hospitalDepartmentService = hospitalDepartmentService;
        }



        public async Task<FxPageInfo<DoctorDto>> GetListWithPageAsync(int? hospitalId, string keyword,int? isLeaveOffice,int? isMain, int pageNum, int pageSize)
        {
            try
            {
                var doctor = from d in dalDoctor.GetAll()
                             where (keyword == null || d.Name.Contains(keyword) || d.HospitalInfo.Name.Contains(keyword) || d.Position.Contains(keyword))
                             && (!hospitalId.HasValue || d.HospitalId == hospitalId.Value)
                             && (!isLeaveOffice.HasValue || d.IsLeaveOffice==isLeaveOffice)
                             && (!isMain.HasValue || d.IsMain==isMain.Value)                          
                             select new DoctorDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 PicUrl = d.PicUrl,
                                 DepartmentId = d.DepartmentId,
                                 Position = d.Position,
                                 ObtainEmploymentYear = d.ObtainEmploymentYear,
                                 Description = d.Description,
                                 HospitalId = d.HospitalId,
                                 HosptalName = d.HospitalInfo.Name,
                                 IsMain = d.IsMain,
                                 ProjectPicture = d.ProjectPicture,
                                 IsLeaveOffice=d.IsLeaveOffice
                             };

                FxPageInfo<DoctorDto> doctorPageInfo = new FxPageInfo<DoctorDto>();
                doctorPageInfo.TotalCount = await doctor.CountAsync();
                doctorPageInfo.List = await doctor.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var z in doctorPageInfo.List)
                {
                    if (!string.IsNullOrEmpty(z.DepartmentId))
                    {
                        var departmentInfo = await _hospitalDepartmentService.GetByIdAsync(z.DepartmentId);
                        z.DepartmentName = departmentInfo.DepartmentName;
                    }
                }
                return doctorPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<List<DoctorDto>> GetListByHospitalIdAndDepartmentIdAsync(int hospitalId, string departmentId)
        {
            try
            {
                var doctor = from d in dalDoctor.GetAll()
                             where d.HospitalId == hospitalId && d.DepartmentId == departmentId
                             select new DoctorDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 PicUrl = d.PicUrl,
                                 DepartmentId = d.DepartmentId,
                                 Position = d.Position,
                                 ObtainEmploymentYear = d.ObtainEmploymentYear,
                                 Description = d.Description,
                                 HospitalId = d.HospitalId,
                                 HosptalName = d.HospitalInfo.Name,
                                 IsMain = d.IsMain,
                                 ProjectPicture = d.ProjectPicture
                             };

                List<DoctorDto> doctorPageInfo = new List<DoctorDto>();
                doctorPageInfo = await doctor.OrderByDescending(x=>x.IsMain).ToListAsync();
                foreach (var z in doctorPageInfo)
                {
                    if (!string.IsNullOrEmpty(z.DepartmentId))
                    {
                        var departmentInfo = await _hospitalDepartmentService.GetByIdAsync(z.DepartmentId);
                        z.DepartmentName = departmentInfo.DepartmentName;
                    }
                }
                return doctorPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddAsync(AddDoctorDto addDto)
        {
            try
            {

                if (addDto.ObtainEmploymentYear > DateTime.Now.Year)
                    throw new Exception("工作年份不能大于今年");

                Doctor doctor = new Doctor();
                doctor.Name = addDto.Name;
                doctor.PicUrl = addDto.PicUrl;
                doctor.Position = addDto.Position;
                doctor.ObtainEmploymentYear = addDto.ObtainEmploymentYear;
                doctor.Description = addDto.Description;
                doctor.HospitalId = addDto.HospitalId;
                doctor.IsMain = addDto.IsMain;
                doctor.DepartmentId = addDto.DepartmentId;
                doctor.ProjectPicture = addDto.ProjectPicture;
                doctor.IsLeaveOffice = 1;
                await dalDoctor.AddAsync(doctor, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            try
            {
                var doctor = await dalDoctor.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);
                if (doctor == null)
                    throw new Exception("医生编号错误");

                DoctorDto doctorDto = new DoctorDto();
                doctorDto.Id = doctor.Id;
                doctorDto.Name = doctor.Name;
                doctorDto.PicUrl = doctor.PicUrl;
                doctorDto.Position = doctor.Position;
                doctorDto.ObtainEmploymentYear = doctor.ObtainEmploymentYear;
                doctorDto.Description = doctor.Description;
                doctorDto.HospitalId = doctor.HospitalId;
                doctorDto.HosptalName = doctor.HospitalInfo.Name;
                doctorDto.Description = doctor.Description;
                doctorDto.DepartmentId = doctor.DepartmentId;
                doctorDto.IsMain = doctor.IsMain;
                doctorDto.ProjectPicture = doctor.ProjectPicture;
                doctorDto.IsLeaveOffice = doctor.IsLeaveOffice;
                return doctorDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateDoctorDto updateDto)
        {
            try
            {
                var doctor = await dalDoctor.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (doctor == null)
                    throw new Exception("医生编号错误");

                doctor.Name = updateDto.Name;
                doctor.PicUrl = updateDto.PicUrl;
                doctor.Position = updateDto.Position;
                doctor.ObtainEmploymentYear = updateDto.ObtainEmploymentYear;
                doctor.Description = updateDto.Description;
                doctor.HospitalId = updateDto.HospitalId;

                doctor.Description = updateDto.Description;
                doctor.DepartmentId = updateDto.DepartmentId;
                doctor.IsMain = updateDto.IsMain;
                doctor.ProjectPicture = updateDto.ProjectPicture;
                doctor.IsLeaveOffice = updateDto.IsLeaveOffice;
                await dalDoctor.UpdateAsync(doctor, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var doctor = await dalDoctor.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (doctor == null)
                    throw new Exception("医生编号错误");

                await dalDoctor.DeleteAsync(doctor, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 更新医生在职状态
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateStatusAsync(UpdateDoctorSatusDto updateDto)
        {
            try
            {
                var doctor = await dalDoctor.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (doctor == null)
                    throw new Exception("医生编号错误");

                doctor.IsLeaveOffice = updateDto.IsLeaveOffice;

                await dalDoctor.UpdateAsync(doctor, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
