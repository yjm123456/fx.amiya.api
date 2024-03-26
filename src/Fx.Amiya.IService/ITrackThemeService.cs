using Fx.Amiya.Dto.TrackTheme;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITrackThemeService
    {
        /// <summary>
        /// 获取回访主题列表（分页）
        /// </summary>
        /// <param name="trackTypeId">回访类型编号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TrackThemeDto>> GetListWithPageAsync(int? trackTypeId,int pageNum, int pageSize,bool?valid);



        /// <summary>
        /// 根据回访类型编号获取回访主题名称列表
        /// </summary>
        /// <param name="trackTypeId"></param>
        /// <returns></returns>
        Task<List<TrackThemeNameDto>> GetNameListByTrackTypeIdAsync(int trackTypeId);





        /// <summary>
        /// 添加回访主题
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddTrackThemeDto addDto);



        /// <summary>
        /// 根据主题编号回去回访主题信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<TrackThemeDto> GetByIdAsync(int id);


        /// <summary>
        /// 修改回访主题
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateTrackThemeDto updateDto);


        /// <summary>
        /// 删除回访主题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
