using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class DiaryWechat:BaseDbModel
    {       
        public string ContentUrl { get; set; }
        public string PicPath { get; set; }
        public string Title { get; set; }        
    }
}
