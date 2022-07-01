using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeautyDiaryTagInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Valid { get; set; }

        public List<BeautyDiaryTagDetail> BeautyDiaryTagDetail { get; set; }
    }
}
