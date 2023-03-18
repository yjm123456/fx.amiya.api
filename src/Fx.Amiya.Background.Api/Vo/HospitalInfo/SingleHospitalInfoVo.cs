using Fx.Amiya.Background.Api.Vo.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class SingleHospitalInfoVo
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// logo
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 咨询热线
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal? Area { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime? HospitalCreateDate { get; set; }

        /// <summary>
        /// 获得行业荣誉
        /// </summary>
        public string IndustryHonors { get; set; }
        /// <summary>
        /// 当地知名度排名情况
        /// </summary>
        public string ProfileRank { get; set; }
        /// <summary>
        /// 医院简介
        /// </summary>

        public string Description { get; set; }
        /// <summary>
        /// 审核状态文本
        /// </summary>
        public string CheckStateText { get; set; }
        /// <summary>
        /// 提交状态文本
        /// </summary>
        public string SubmitStateText { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }
        /// <summary>
        /// 简介资料
        /// </summary>
        public string DescriptionPicture { get; set; }

        /// <summary>
        /// 规模
        /// </summary>
        public List<int> ScaleTagList { get; set; }
        /// <summary>
        /// 设施
        /// </summary>
        public List<int> FacilityTagList { get; set; }
        

        /// <summary>
        /// 医院环境
        /// </summary>
        public List<HospitalEnvironmentInfoVo>HospitalEnvironmentInfo{get;set;}

        /// <summary>
        /// 科室与医生
        /// </summary>
        public List<DepartmentAndDoctor> DepartmentAndDoctors { get; set; }
    }
    /// <summary>
    /// 医院环境与图片
    /// </summary>
    public class HospitalEnvironmentInfoVo
    {
        /// <summary>
        /// 环境id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 环境名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 环境图片
        /// </summary>
        public List<string> PictureUrl { get; set; }
    }

    /// <summary>
    /// 科室与医生
    /// </summary>
    public class DepartmentAndDoctor
    {
        /// <summary>
        /// 科室id
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        public List<DoctorVo> Doctor { get; set; }
    }
}
