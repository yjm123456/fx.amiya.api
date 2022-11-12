using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.BeautyDiaryManage
{
    //微信公众号文章内容
    public class WeChatBeautyDiaryDto
    {
        public int total_count { get; set; }
        public int item_count { get; set; }
        public List<WechatBeautyDiaryItem> item { get; set; }
    }
    public class WechatBeautyDiaryItem {
        public string media_id { get; set; }
        public WechatBeautyDiaryContent content { get; set; }
        public string update_time { get; set; }
    }
    public class WechatBeautyDiaryContent
    {
        public List<WechatBeautyDiaryNewsItem> news_item { get; set; }

    }

    public class WechatBeautyDiaryNewsItem {
        public string title { get; set; }
        public string thumb_media_id { get; set; }
        public string show_cover_pic { get; set; }
        public string author { get; set; }
        public string digest { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string content_source_url { get; set; }
    }

    public class WechatBeautyDiaryNewsItemDto
    {
        public string Title { get; set; }    
        public string Author { get; set; }       
        public string ContentSourceUrl { get; set; }
        public string PicPath { get; set; }
    }
}
