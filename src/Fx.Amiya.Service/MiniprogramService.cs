using Fx.Amiya.Dto;
using Fx.Amiya.Dto.MiniProgram;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MiniprogramService : IMiniprogramService
    {
        private readonly IDalMiniprogram dalMiniprogram;

        public MiniprogramService(IDalMiniprogram dalMiniprogram)
        {
            this.dalMiniprogram = dalMiniprogram;
        }

        /// <summary>
        /// 根据appid获取小程序信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<MiniprogramInfoDto> GetMiniprogramInfoByAppIdAsync(string appId)
        {
            var app= dalMiniprogram.GetAll().Where(e => e.AppId == appId).Select(e => new MiniprogramInfoDto
            {
                Name = e.Name,
                AppId = e.AppId,
                IsMain = e.IsMain,
                BelongLiveAnchorId = e.BelongLiveAnchorId,
                BelongMiniprogramAppId = e.BelongMiniprogramAppId
            }).SingleOrDefault();
            if (app==null) {
                throw new Exception("小程序Id错误！");
            }
            return app;
        }

        /// <summary>
        /// 获取小程序名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto<string>>> GetMiniProgramNameListAsync()
        {
            return dalMiniprogram.GetAll().Where(e => e.Valid == true).Select(e => new BaseKeyValueDto<string>
            {
                Key = e.AppId,
                Value = e.Name
            }).ToList();
        }
    }
}
