using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.IService
{
    public enum AuthorizeStatusEnum
    {
        /// <summary>
        /// 管理端
        /// </summary>
        InternalAuthorize = 0,
        /// <summary>
        /// 医院端
        /// </summary>
        TenantAuhtorize = 1,

    }


    /// <summary>
    /// 预约状态
    /// </summary>
    public enum AppointmentStatus
    {
        /// <summary>
        /// 待完成=1
        /// </summary>
        WaitAccomplish = 1,

        /// <summary>
        /// 已完成=2
        /// </summary>
        Finish = 2,

        /// <summary>
        /// 取消=3
        /// </summary>
        Cancel = 3,
        /// <summary>
        /// 已派单
        /// </summary>
        SendToHospital = 4
    }
    /// <summary>
    /// 预约叫车抵扣类型
    /// </summary>
    public enum AppointmentCarExchangeType
    {
        //积分抵扣
        PointDeduction = 0,
        //优惠券抵扣
        VoucherDeduction = 1
    }
    /// <summary>
    /// 预约车型
    /// </summary>
    public enum AppointmentCarType
    {
        //经济型
        EconomyType = 0,
        //舒适型
        ConfirmtableType = 1,
        //商务型
        BusinessType = 2,
        //豪华型
        LuxuriousType = 3
    }
    /// <summary>
    /// 预约叫车状态
    /// </summary>
    public enum AppointmentCarStatus
    {
        //提交处理
        Commit = 0,
        //取消预约
        Cancle = 1,
        //预约成功
        Completed = 2
    }

    public enum CheckType
    {
        /// <summary>
        /// 未审核
        /// </summary>
        NotChecked = 0,
        /// <summary>
        /// 审核不通过
        /// </summary>
        CheckNotPassed = 1,
        /// <summary>
        /// 审核通过
        /// </summary>
        CheckedSuccess = 2,
        /// <summary>
        /// 审核中
        /// </summary>
        Checking = 3,

    }

    public enum SubmintType
    {
        /// <summary>
        /// 未提交
        /// </summary>
        UnSubmit = 0,
        /// <summary>
        /// 已提交
        /// </summary>
        Submited = 1,
    }


    public enum TagType
    {
        /// <summary>
        /// 规模标签=0
        /// </summary>
        ScaleTag,

        /// <summary>
        /// 设施标签=1
        /// </summary>
        FacilityTag
    }


    public enum WxEventType
    {
        /// <summary>
        /// 首次关注=0
        /// </summary>
        FirstSubscribe,

        /// <summary>
        /// 再次关注=1
        /// </summary>
        AgainSubscribe
    }


    public enum WxRspMsgType
    {
        /// <summary>
        /// 文本消息=1
        /// </summary>
        TextMessage = 1,

        /// <summary>
        /// 图文消息=2
        /// </summary>
        NewsMessage = 2,
    }



    public enum EmployeeType
    {
        /// <summary>
        /// 啊美雅员工
        /// </summary>
        AmiyaEmployee = 1,



        /// <summary>
        /// 医院员工
        /// </summary>
        HospitalEmployee = 2
    }






    /// <summary>
    /// 留言类型（留言/回复）
    /// </summary>
    public enum LeaveMessageType
    {
        /// <summary>
        /// 留言
        /// </summary>
        LeaveMessage = 1,

        /// <summary>
        /// 回复
        /// </summary>
        Reply = 2
    }

    /// <summary>
    /// 升单类型枚举
    /// </summary>
    public enum BuyAgainType
    {
        /// <summary>
        /// 升单5%
        /// </summary>
        FivePercent = 0,
        /// <summary>
        /// 升单30%
        /// </summary>
        ThirtyPercent = 1,
        /// <summary>
        /// 升单35%
        /// </summary>
        ThirtyFivePercent = 2,
        /// <summary>
        /// 升单10%
        /// </summary>
        TenPercent = 3,
        /// <summary>
        /// 升单15%
        /// </summary>
        FifteenPercent = 4,
        /// <summary>
        /// 升单20%
        /// </summary>
        TwentyPercent = 5,
        /// <summary>
        /// 升单50%
        /// </summary>
        FiftyPercent = 6,
    }

    /// <summary>
    /// 升单渠道
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// 医院添加
        /// </summary>
        Hospital = 0,
        /// <summary>
        /// 天猫
        /// </summary>
        TaoBao = 1,
        /// <summary>
        /// 抖音
        /// </summary>
        TikTok = 2,
        /// <summary>
        /// 抖音代运营
        /// </summary>
        TikTokThirdpartnar = 3,

    }

    /// <summary>
    /// 下单平台
    /// </summary>
    public enum AppType
    {
        /// <summary>
        /// 天猫=0
        /// </summary>
        Tmall,

        /// <summary>
        /// 京东=1
        /// </summary>
        JD,

        /// <summary>
        /// 小程序=2
        /// </summary>
        MiniProgram,

        /// <summary>
        /// 公众号（微分销平台）=3
        /// </summary>
        WeChatOfficialAccount,
        /// <summary>
        /// 抖音
        /// </summary>
        Douyin,
        /// <summary>
        /// 其他
        /// </summary>
        Other
    }

    #region 内容平台相关枚举
    /// <summary>
    /// 内容平台订单的订单类型
    /// </summary>
    public enum ContentPlateFormOrderType
    {
        /// <summary>
        /// 咨询=1
        /// </summary>
        SEEK_ADVICE = 1,

        /// <summary>
        /// 定金=2
        /// </summary>
        BARGAIN_MONEY = 2,

        /// <summary>
        /// 预约
        /// </summary>
        APPOINTMENT = 3,
    }

    /// <summary>
    /// 内容平台订单面诊状态
    /// </summary>
    public enum ContentPlateFormOrderConsultationType
    {

        /// <summary>
        /// 独立跟进=1
        /// </summary>
        IndependentFollowUp = 1,

        /// <summary>
        /// 协作完成=2
        /// </summary>
        Collaboration = 2,
        /// <summary>
        /// 其他=0
        /// </summary>
        OTHER = 0,

    }


    /// <summary>
    /// 内容平台订单到院类型
    /// </summary>
    public enum ContentPlateFormOrderToHospitalType
    {
        /// <summary>
        /// 初诊=1
        /// </summary>
        FIRST_SEEK_ADVICE = 1,

        /// <summary>
        /// 复诊=2
        /// </summary>
        AGAIN_SEEK_ADVICE = 2,
        /// <summary>
        /// 再消费=3
        /// </summary>
        AGAIN_CONSUMPTION = 3,
        /// <summary>
        /// 退款=4
        /// </summary>
        REFUND = 4,
        /// <summary>
        /// 其他
        /// </summary>
        OTHER = 0,
    }

    /// <summary>
    /// 内容平台订单的订单来源
    /// </summary>
    public enum ContentPlateFormOrderSource
    {
        /// <summary>
        /// 面诊卡
        /// </summary>
        Consultation_Card = 1,

        /// <summary>
        /// 非面诊卡
        /// </summary>
        Other = 2,
        /// <summary>
        /// 美肤卡
        /// </summary>
        BeautifulSkinCard = 3,
    }

    /// <summary>
    /// 内容平台的订单状态
    /// </summary>
    public enum ContentPlateFormOrderStatus
    {
        /// <summary>
        /// 未派单=1
        /// </summary>
        HaveOrder = 1,

        /// <summary>
        /// 已派单=2
        /// </summary>
        SendOrder = 2,

        /// <summary>
        /// 已接单
        /// </summary>
        ConfirmOrder = 3,

        /// <summary>
        /// 已成交=4
        /// </summary>
        OrderComplete = 4,

        /// <summary>
        /// 医院重单-不可深度=5
        /// </summary>
        RepeatOrder = 5,

        /// <summary>
        /// 未成交=6
        /// </summary>
        WithoutCompleteOrder = 6,
        /// <summary>
        /// 医院重单-可深度
        /// </summary>
        RepeatOrderProfundity=7
    }
    #endregion

    /// <summary>
    /// 订单性质
    /// </summary>
    public enum OrderNatureType
    {
        /// <summary>
        /// 正常下单=0
        /// </summary>
        RegularOrder,

        /// <summary>
        /// 朋友推荐=1
        /// </summary>
        FriendRecommended,

        /// <summary>
        /// 私域合作=2
        /// </summary>
        PrivateDomainCooperation,

        /// <summary>
        /// 财务添加=3
        /// </summary>
        FinancialInsert,

    }

    /// <summary>
    /// 初始化类型
    /// </summary>
    public enum InitializerType
    {
        /// <summary>
        /// 天猫
        /// </summary>
        Tmall,

        /// <summary>
        /// 京东
        /// </summary>
        JD,

        /// <summary>
        /// 积分=2
        /// </summary>
        Integration
    }


    public enum OrderFrom
    {
        /// <summary>
        /// 下单平台
        /// </summary>
        ThirdPartyOrder = 1,

        /// <summary>
        /// 内容平台
        /// </summary>
        ContentPlatFormOrder = 2,

        /// <summary>
        /// 客户升单
        /// </summary>
        BuyAgainOrder = 3
    }

    /// <summary>
    /// 直播需求优先级
    /// </summary>
    public enum LiveRequirementPriorityLevel
    {
        /// <summary>
        /// 一般=0
        /// </summary>
        Ordinary,


        /// <summary>
        /// 紧急
        /// </summary>
        Urgent
    }


    /// <summary>
    /// 直播需求状态
    /// </summary>
    public enum LiveRequirementStatus
    {
        /// <summary>
        /// 未响应=0
        /// </summary>
        UnResponse,

        /// <summary>
        /// 拒绝=1
        /// </summary>
        Refuse,

        /// <summary>
        /// 作废=2
        /// </summary>
        Cancel,

        /// <summary>
        /// 未处理=3
        /// </summary>
        UnTreated,

        /// <summary>
        /// 已处理待确认=4
        /// </summary>
        UnConfirm,

        /// <summary>
        /// 已处理=5
        /// </summary>
        Treated,
    }

    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 虚拟订单
        /// </summary>
        VirtualOrder,

        /// <summary>
        /// 实物订单
        /// </summary>
        MaterialOrder,
    }


    /// <summary>
    /// 派单留言方类型
    /// </summary>
    public enum SendOrderMessageBoardType
    {
        /// <summary>
        /// 啊美雅=0
        /// </summary>
        Amiya,

        /// <summary>
        /// 医院=1
        /// </summary>
        Hospital
    }

    /// <summary>
    /// 医院查看电话订单类型
    /// </summary>
    public enum CheckPhoneRecordOrderType
    {
        /// <summary>
        /// 正常交易订单
        /// </summary>
        TradeOrder,

        /// <summary>
        /// 内容平台订单
        /// </summary>
        ContentPlatformOrder
    }


    /// <summary>
    /// 追踪回访提报状态
    /// </summary>
    public enum SendStatus
    {
        /// <summary>
        /// 未提报
        /// </summary>
        UnSend = 0,
        /// <summary>
        /// 已提报
        /// </summary>
        Sended = 1,
        /// <summary>
        /// 跟进中
        /// </summary>
        FollowingUp = 2,
        /// <summary>
        /// 跟进完成
        /// </summary>
        FollowUpFinished = 3,
        /// <summary>
        /// 跟进失败
        /// </summary>
        FollowUpFailed = 4,
    }
    public enum InventoryStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        UnKnow = 0,
        /// <summary>
        /// 盘平
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 盘盈
        /// </summary>
        Profit = 2,
        /// <summary>
        /// 盘亏
        /// </summary>
        Loss = 3,
    }
    public enum EmergencyLevel
    {
        //可忽略
        Ignorable = 0,
        //轻微
        //Slight=1,
        //一般
        Generally = 2,
        //重要
        Important = 3,
        //非常重要
        // VeryImportant=4
    }
    public enum RechargeStatus
    {
        //待付款/余额退款初始化
        PendingPayment = 0,
        //成功(充值成功/余额退款审核通过)
        Success = 1,
        //取消(充值取消/余额退款未通过)
        Cacncel = 2,
        //失败(已付款,但账号余额异常修改余额失败或订单状态改变导致修改状态失败)
        Fail = 3
    }
    /// <summary>
    /// 预约状态
    /// </summary>
    public enum AppointmentStatusType { 
        //预约处理
        Process=0,
        //预约取消
        Cancel=1,
        //预约成功
        Success=2
    }



    public enum ShoppingCartConsultationType
    {
        /// <summary>
        /// 视频
        /// </summary>
        Video = 1,
        /// <summary>
        /// 图片
        /// </summary>
        Picture = 2,
        /// <summary>
        /// 私信
        /// </summary>
        DirectMessages = 3,
        /// <summary>
        /// 其他
        /// </summary>
        Others = 4,
        /// <summary>
        /// 短视频
        /// </summary>
        ShortVideo = 5
    }

    public enum ShootingAndClipVideoType
    {
        /// <summary>
        /// 广告片
        /// </summary>
        AdvertisingFilm = 1,
        /// <summary>
        /// 口播
        /// </summary>
        MouthBroadcast = 2,

        /// <summary>
        /// vlong
        /// </summary>
        Vlong = 3,
        /// <summary>
        ///  企业宣传文化片
        /// </summary>
        EnterprisePropagandaCultureFilm = 4,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 0,
    }
    public enum CheckState
    {
        /// <summary>
        /// 待审核
        /// </summary>
        CheckPending = 0,
        /// <summary>
        /// 审核通过
        /// </summary>
        CheckSuccess = 1,
        /// <summary>
        /// 审核失败
        /// </summary>
        CheckFail = 2
    }
    public enum RefundState
    {
        /// <summary>
        /// 待退款
        /// </summary>
        RefundPending = 0,
        /// <summary>
        /// 退款成功
        /// </summary>
        RefundSuccess = 1,
        /// <summary>
        /// 退款失败
        /// </summary>
        RefundFail = 2,
        /// <summary>
        /// 退款中
        /// </summary>
        Refunding = 3
    }

    /// <summary>
    /// 标签分类
    /// </summary>
    public enum TagCategory
    {
        /// <summary>
        /// 用户标签
        /// </summary>
        UserTag = 0,
        /// <summary>
        /// 商品标签
        /// </summary>
        GoodsTag = 1
    }

    /// <summary>
    /// 财务对账单状态
    /// </summary>
    public enum ReconciliationDocumentsStateEnum
    {
        /// <summary>
        /// 已提交
        /// </summary>
        Submited = 0,
        /// <summary>
        /// 待确认
        /// </summary>
        WaitingConfirmed = 1,
        /// <summary>
        /// 问题账单
        /// </summary>
        QuestionDocument = 2,
        /// <summary>
        /// 对账完成
        /// </summary>
        Successful = 3,
        /// <summary>
        /// 回款完成
        /// </summary>
        ReturnBackPriceSuccessful=4,
    }


    /// <summary>
    /// 票据类型
    /// </summary>
    public enum BillTypeTextEnum
    {
        /// <summary>
        /// 医美票据
        /// </summary>
        BeautyClinic = 0,
        /// <summary>
        /// 其他票据
        /// </summary>
        Other = 1,
    }
    /// <summary>
    /// 票据回款状态
    /// </summary>
    public enum BillReturnBackStateTextEnum
    {
        /// <summary>
        /// 未回款
        /// </summary>
        UnReturnBack = 0,
        /// <summary>
        /// 回款中
        /// </summary>
        ReturnBacking = 1,
        /// <summary>
        /// 已回款
        /// </summary>
        ReturnBackSuccessful = 2,
    }
}
