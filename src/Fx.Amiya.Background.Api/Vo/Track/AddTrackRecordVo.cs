﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class AddTrackRecordVo
    {
        /// <summary>
        /// 待回访编号
        /// </summary>
        public int? WaitTrackId { get; set; }

        /// <summary>
        /// 加密电话文本
        /// </summary>
        //[Required(ErrorMessage = "加密电话文本不能为空")]
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 回访内容
        /// </summary>
       // [Required(ErrorMessage = "回访内容不能为空")]
        [StringLength(500, ErrorMessage = "回访内容不能超过{1}个字符")]
        public string TrackContent { get; set; }


        /// <summary>
        /// 回访工具编号
        /// </summary>
        public int TrackToolId { get; set; }

        /// <summary>
        /// 回访类型编号
        /// </summary>
        public int TrackTypeId { get; set; }

        /// <summary>
        /// 回访主题编号
        /// </summary>
        public int? TrackThemeId { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 通话记录编号（回访工具是电话时）
        /// </summary>
        public string CallRecordId { get; set; }

        /// <summary>
        /// 下次回访
        /// </summary>
        public List<AddWaitTrackCustomerVo> AddWaitTrackCustomer { get; set; }
    }
}
