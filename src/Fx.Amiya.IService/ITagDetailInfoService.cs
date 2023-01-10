using Fx.Amiya.Dto;
using Fx.Amiya.Dto.TagDetailInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITagDetailInfoService
    {
        public Task AddTagDetailInfoAsync(AddTagDetailInfoDto add);
        public Task DeleteAsync(string id, string tagid);
        public Task<List<TagDetailInfoDto>> GetTagNameListAsync(string id);
      
    }
}
