using Fx.Amiya.Dal;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AestheticsDesign;
using Fx.Amiya.Dto.AestheticsDesignReport;
using Fx.Amiya.Dto.MiniProgramSendMessage;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AestheticsDesignService : IAestheticsDesignService
    {
        private readonly IDalAestheticsDesign dalAestheticsDesign;
        private readonly IDalFaceTagWithAestheticsDesignReport dalFaceTagWithAestheticsDesignReport;
        private readonly IUnitOfWork unitofwork;
        private readonly IDalHospitalInfo dalHospitalInfo;
        private readonly IDalCustomerTagInfo dalCustomerTag;
        private readonly IDalAestheticsDesignReport dalAestheticsDesignReport;
        private readonly IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService;
        public AestheticsDesignService(IDalAestheticsDesign dalAestheticsDesign, IDalFaceTagWithAestheticsDesignReport dalFaceTagWithAestheticsDesignReport, IUnitOfWork unitofwork, IDalHospitalInfo dalHospitalInfo, IDalCustomerTagInfo dalCustomerTag, IDalAestheticsDesignReport dalAestheticsDesignReport, IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService)
        {
            this.dalAestheticsDesign = dalAestheticsDesign;
            this.dalFaceTagWithAestheticsDesignReport = dalFaceTagWithAestheticsDesignReport;
            this.unitofwork = unitofwork;
            this.dalHospitalInfo = dalHospitalInfo;
            this.dalCustomerTag = dalCustomerTag;
            this.dalAestheticsDesignReport = dalAestheticsDesignReport;
            this.miniProgramTemplateMessageSendService = miniProgramTemplateMessageSendService;
        }


        /// <summary>
        /// 添加美学设计
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAestheticsDesignAsync(AddAestheticsDesignDto addDto)
        {
            try
            {
                unitofwork.BeginTransaction();
                AestheticsDesign aestheticsDesign = new AestheticsDesign();
                aestheticsDesign.Id = CreateOrderIdHelper.GetBillNextNumber();
                aestheticsDesign.CreateDate = DateTime.Now;
                aestheticsDesign.AestheticsDesignReportId = addDto.AestheticsDesignReportId;
                aestheticsDesign.Design = addDto.Design;
                aestheticsDesign.HospitalId = addDto.HospitalId;
                aestheticsDesign.RecommendDoctor = addDto.RecommendDoctor;
                aestheticsDesign.SidePicture = addDto.SidePicture;
                aestheticsDesign.FrontPicture = addDto.FrontPicture;
                aestheticsDesign.Valid = true;
                await dalAestheticsDesign.AddAsync(aestheticsDesign, true);
                foreach (var item in addDto.PictureTags) {
                    AddFaceTagDto addTagDto = new AddFaceTagDto();
                    addTagDto.TagId = item;
                    addTagDto.ReportId = addDto.AestheticsDesignReportId;
                    addTagDto.DirectionType = (int)PictureDirectionType.Picture;
                    await AddAestheticsDesignPictureTagAsync(addTagDto);
                }
                var report = dalAestheticsDesignReport.GetAll().Where(e => e.Id == addDto.AestheticsDesignReportId).SingleOrDefault();
                if (report == null) throw new Exception("美学设计报告编号错误！");
                report.Status = (int)AestheticsDesignReportStatus.Desgined;
                await dalAestheticsDesignReport.UpdateAsync(report, true);
                SendAestheticsDesignMessageDto sendMessage = new SendAestheticsDesignMessageDto();
                sendMessage.ReportId = aestheticsDesign.AestheticsDesignReportId;
                sendMessage.CustomerId = report.CustomerId;
                sendMessage.Content = $"编号为{sendMessage.ReportId}的美学设计报告,已设计完成,点击查看";
                sendMessage.DesignDate = DateTime.Now.ToString("yyyy-MM-dd HH-mm");
                sendMessage.Remark = "设计完成请点击查看";
                await miniProgramTemplateMessageSendService.SendAestheticsDesignMessage(sendMessage);
                unitofwork.Commit();
            }
            catch (Exception ex)
            {
                unitofwork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 添加图片标签
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAestheticsDesignPictureTagAsync(AddFaceTagDto addDto)
        {
            FaceTagWithAestheticsDesignReport faceTag = new FaceTagWithAestheticsDesignReport();
            faceTag.TagId = addDto.TagId;
            faceTag.ReportId = addDto.ReportId;
            faceTag.DirectType = addDto.DirectionType;
            await dalFaceTagWithAestheticsDesignReport.AddAsync(faceTag,true);
        }

        /// <summary>
        /// 根据美学报告id获取美学设计信息
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task<AestheticsDesignInfoDto> GetByReportIdAsync(string reportId)
        {
            var design= dalAestheticsDesign.GetAll().Where(e => e.AestheticsDesignReportId == reportId).SingleOrDefault();
            if (design == null) return null;
            AestheticsDesignInfoDto aestheticsDesignInfoDto = new AestheticsDesignInfoDto();
            aestheticsDesignInfoDto.Id = design.Id;
            aestheticsDesignInfoDto.AestheticsDesignReportId = design.AestheticsDesignReportId;
            aestheticsDesignInfoDto.Design = design.Design;
            aestheticsDesignInfoDto.HospitalId = design.HospitalId.Value;
            aestheticsDesignInfoDto.SimpleHospitalName = dalHospitalInfo.GetAll().Where(e=>e.Id==design.HospitalId).FirstOrDefault().SimpleName;
            aestheticsDesignInfoDto.RecommendDoctor = design.RecommendDoctor;
            aestheticsDesignInfoDto.PictureTags= dalFaceTagWithAestheticsDesignReport.GetAll().Where(e => e.ReportId == reportId && e.DirectType == (int)PictureDirectionType.Picture).Select(e => new BaseKeyValueDto
            {
                Key = e.TagId,
                Value = dalCustomerTag.GetAll().Where(t => t.Id == e.TagId).FirstOrDefault().TagName
            }).ToList();
            aestheticsDesignInfoDto.SidePicture = design.SidePicture;
            aestheticsDesignInfoDto.FrontPicture = design.FrontPicture; ;
            return aestheticsDesignInfoDto;
        }

        /// <summary>
        /// 修改美学设计
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAestheticsDesignAsync(UpdateAestheticsDesgnDto updateDto)
        {
            try
            {
                unitofwork.BeginTransaction();
                var design = dalAestheticsDesign.GetAll().Where(e => e.AestheticsDesignReportId == updateDto.Id).FirstOrDefault();
                if (design == null) throw new Exception("设计编号错误！");
                design.Design = updateDto.Design;
                design.HospitalId = updateDto.HospitalId;
                design.RecommendDoctor = updateDto.RecommendDoctor;
                design.UpdateDate = DateTime.Now;
                design.SidePicture = updateDto.SidePicture;
                design.FrontPicture = updateDto.FrontPicture;
                await dalAestheticsDesign.UpdateAsync(design, true);
                var faceTagList = dalFaceTagWithAestheticsDesignReport.GetAll().Where(e => e.ReportId == design.AestheticsDesignReportId).ToList();
                foreach (var item in faceTagList)
                {
                    await dalFaceTagWithAestheticsDesignReport.DeleteAsync(item, true);
                }
                foreach (var item in updateDto.PictureTags)
                {
                    AddFaceTagDto addTagDto = new AddFaceTagDto();
                    addTagDto.TagId = item;
                    addTagDto.ReportId = design.AestheticsDesignReportId;
                    addTagDto.DirectionType = (int)PictureDirectionType.Picture;
                    await AddAestheticsDesignPictureTagAsync(addTagDto);
                }
                
                unitofwork.Commit();
            }
            catch (Exception ex)
            {
                unitofwork.RollBack();
                throw ex;
            }

        }
    }
}
