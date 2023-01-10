using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.TagDetailInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class TagDetailInfoService : ITagDetailInfoService
    {
        private readonly IDalTagDetailInfo dalTagDetailInfo;
        private readonly IDalCustomerTagInfo dalCustomerTagInfo;

        public TagDetailInfoService(IDalTagDetailInfo dalTagDetailInfo, IDalCustomerTagInfo dalTagInfo)
        {
            this.dalTagDetailInfo = dalTagDetailInfo;
            this.dalCustomerTagInfo = dalTagInfo;
        }

        public async Task AddTagDetailInfoAsync(AddTagDetailInfoDto add)
        {
            TagDetailInfo tagDetailInfo = new TagDetailInfo();
            tagDetailInfo.CustomerGoodsId = add.Id;
            tagDetailInfo.TagId = add.TagId;
            dalTagDetailInfo.AddAsync(tagDetailInfo,true);
            
        }
        
        public async Task DeleteAsync(string id,string tagid)
        {
            var tagDetail = dalTagDetailInfo.GetAll().Where(e => e.CustomerGoodsId == id && e.TagId == tagid).SingleOrDefault();
            if (tagDetail == null) throw new Exception("编号错误");
            dalTagDetailInfo.DeleteAsync(tagDetail,true);
        }
        

        /// <summary>
        /// 获取指定id的用户或商品的标签
        /// </summary>
        /// <returns></returns>
        public async Task<List<TagDetailInfoDto>> GetTagNameListAsync(string id)
        {
            var tagDetail = from d in dalTagDetailInfo.GetAll().Where(e => e.CustomerGoodsId == id)
                            join c in dalCustomerTagInfo.GetAll() on d.TagId equals c.Id
                            select new TagDetailInfoDto
                            {
                                TagId=d.TagId,
                                TagName = c.TagName                       
                            };
            return tagDetail.ToList();
        }
        
    }
}
