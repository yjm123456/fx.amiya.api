using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SendOrderInfo
{
    public class SendOrderInfoVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 派单医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 派单医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 是否未确认时间
        /// </summary>
        public bool IsUncertainDate { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// 时间类型：1=上午，2=下午
        /// </summary>
        public byte? TimeType { get; set; }
        /// <summary>
        /// 上午/下午
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
        public string Parts { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal PurchaseSinglePrice { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public int PurchaseNum { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 医院是否已查看过该订单的电话
        /// </summary>
        public bool IsHospitalCheckPhone { get; set; }

        /// <summary>
        /// 派单人姓名
        /// </summary>
        public int SendBy { get; set; }

        /// <summary>
        /// 派单人名称
        /// </summary>
        public string SendName { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 是否已核销
        /// </summary>
        public bool IsVerification { get; set; }

        public string StatusCode { get; set; }
        public string StatusText { get; set; }


        /// <summary>
        /// 平台类型
        /// </summary>
        public byte AppType { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText { get; set; }


        /// <summary>
        /// 首次留言内容
        /// </summary>
        public string FirstMessageContent { get; set; }
        /// <summary>
        /// 是否为主派医院
        /// </summary>
        public bool IsMainHospital { get; set; }


    }
}
