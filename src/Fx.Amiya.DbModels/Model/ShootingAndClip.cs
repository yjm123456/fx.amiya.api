using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class ShootingAndClip
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 拍摄人员
        /// </summary>
        public int ShootingEmpId { get; set; }
        /// <summary>
        /// 剪辑人员
        /// </summary>
        public int ClipEmpId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RecordDate { get; set; }

        public AmiyaEmployee ShootingEmoloyee { get; set; }
        public AmiyaEmployee ClipEmoloyee { get; set; }

        public LiveAnchor LiveAnchor { get; set; }
    }
}
