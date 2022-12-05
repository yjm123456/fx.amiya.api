using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Service
{
    public static class ServiceClass
    {


        /// <summary>
        /// 获取订单状态文本
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetOrderStatusText(string status)
        {
            string statusText = "";
            switch (status)
            {
                case "WAIT_BUYER_PAY":
                    statusText = "等待买家付款";
                    break;

                case "WAIT_SELLER_SEND_GOODS":
                    statusText = "等待卖家发货";

                    break;
                case "WAIT_BUYER_CONFIRM_GOODS":
                    statusText = "等待买家确认收货";
                    break;

                case "TRADE_BUYER_SIGNED":
                    statusText = "买家已签收";
                    break;
                case "TRADE_BUYER_PAID":
                    statusText = "买家已付款";
                    break;

                case "TRADE_FINISHED":
                    statusText = "交易成功";
                    break;

                case "TRADE_CLOSED":
                    statusText = "退款成功交易关闭";
                    break;

                case "TRADE_CLOSED_BY_TAOBAO":
                    statusText = "付款前交易关闭";
                    break;

                //-------
                case "TRADE_CANCELED":
                    statusText = "取消";
                    break;

                case "LOCKED":
                    statusText = "已锁定";
                    break;

                case "POP_ORDER_PAUSE POP":
                    statusText = "暂停";
                    break;

                case "REFUNDING":
                    statusText = "退款中";
                    break;
                case "SEEK_ADVICE":
                    statusText = "咨询订单";
                    break;

                case "BARGAIN_MONEY":
                    statusText = "定金订单";
                    break;
                case "CHECK_FAIL":
                    statusText = "审核未通过";
                    break;
                case "PARTIAL_REFUND":
                    statusText = "部分退款";
                    break;
            }
            return statusText;
        }

        /// <summary>
        /// 获取抖店订单状态文本
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetTikTokOrderStatusText(string status)
        {
            string statusText = "";
            switch (status)
            {
                case "PENDING_REFUND":
                    statusText = "待退款";
                    break;
                case "REFUNDING":
                    statusText = "退款中";
                    break;
                case "TRADE_CLOSED_AFTER_REFUND":
                    statusText = "退款成功交易关闭";
                    break;
                case "REFUND_FAIL":
                    statusText = "退款失败";
                    break;
                case "WAIT_BUYER_PAY":
                    statusText = "等待买家付款";
                    break;

                case "WAIT_SELLER_SEND_GOODS":
                    statusText = "等待卖家发货";
                    break;
                case "WAIT_BUYER_CONFIRM_GOODS":
                    statusText = "等待买家收货";
                    break;

                case "TRADE_FINISHED":
                    statusText = "交易成功";
                    break;

                case "TRADE_CLOSED":
                    statusText = "订单付款前取消";
                    break;
                case "UNKNOW":
                    statusText = "未知状态";
                    break;
            }
            return statusText;
        }

        #region 获取小程序模块订单状态文本展示

        /// <summary>
        /// 获取订单状态文本（虚拟订单）
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetMiniOrderStatusText(string status)
        {
            string statusText = "";
            switch (status)
            {
                case "WAIT_BUYER_PAY":
                    statusText = "待付款";
                    break;

                case "WAIT_SELLER_SEND_GOODS":
                    statusText = "待核销";

                    break;
                case "WAIT_BUYER_CONFIRM_GOODS":
                    statusText = "待核销";
                    break;

                case "TRADE_BUYER_SIGNED":
                    statusText = "待核销";
                    break;

                case "TRADE_FINISHED":
                    statusText = "已完成";
                    break;

                case "TRADE_CLOSED":
                    statusText = "已关闭";
                    break;

                case "TRADE_CLOSED_BY_TAOBAO":
                    statusText = "已关闭";
                    break;

                //-------
                case "TRADE_CANCELED":
                    statusText = "已取消";
                    break;

                case "LOCKED":
                    statusText = "已锁定";
                    break;

                case "POP_ORDER_PAUSE POP":
                    statusText = "暂停";
                    break;

                case "REFUNDING":
                    statusText = "退款中";
                    break;

                case "REFUND_FAIL":
                    statusText = "已关闭";
                    break;
                case "SEEK_ADVICE":
                    statusText = "咨询订单";
                    break;

                case "BARGAIN_MONEY":
                    statusText = "定金订单";
                    break;
            }
            return statusText;
        }

        /// <summary>
        /// 获取订单状态文本（实物订单）
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetMiniGoodsOrderStatusText(string status)
        {
            string statusText = "";
            switch (status)
            {
                case "WAIT_BUYER_PAY":
                    statusText = "未兑换";
                    break;

                case "WAIT_SELLER_SEND_GOODS":
                    statusText = "兑换成功";

                    break;
                case "WAIT_BUYER_CONFIRM_GOODS":
                    statusText = "兑换成功";
                    break;

                case "TRADE_BUYER_SIGNED":
                    statusText = "兑换成功";
                    break;

                case "TRADE_FINISHED":
                    statusText = "兑换成功";
                    break;

                case "TRADE_CLOSED":
                    statusText = "已关闭";
                    break;

                case "TRADE_CLOSED_BY_TAOBAO":
                    statusText = "已关闭";
                    break;

                //-------
                case "TRADE_CANCELED":
                    statusText = "已取消";
                    break;

                case "LOCKED":
                    statusText = "已锁定";
                    break;

                case "POP_ORDER_PAUSE POP":
                    statusText = "暂停";
                    break;

                case "REFUNDING":
                    statusText = "退款中";
                    break;

                case "REFUND_FAIL":
                    statusText = "已关闭";
                    break;
            }
            return statusText;
        }
        #endregion

        public static string GetAppTypeText(byte appType)
        {
            string typeText = "";
            switch (appType)
            {
                case 0:
                    typeText = "天猫";
                    break;

                case 1:
                    typeText = "京东";
                    break;

                case 2:
                    typeText = "小程序";
                    break;

                case 3:
                    typeText = "公众号";
                    break;
                case 4:
                    typeText = "抖音";
                    break;
                case 5:
                    typeText = "其他";
                    break;
            }
            return typeText;
        }

        #region 内容平台订单相关枚举
        public static string GetContentPlateFormOrderTypeText(byte appType)
        {
            string typeText = "";
            switch (appType)
            {
                case 1:
                    typeText = "咨询订单";
                    break;

                case 2:
                    typeText = "定金订单";
                    break;
                case 3:
                    typeText = "预约订单";
                    break;

            }
            return typeText;
        }

        public static string GetContentPlateFormOrderConsultationTypeText(int ConsultationType)
        {
            string typeText = "";
            switch (ConsultationType)
            {

                case 1:
                    typeText = "独立跟进";
                    break;
                case 2:
                    typeText = "协作完成";
                    break;
                case 0:
                    typeText = "其他";
                    break;

            }
            return typeText;
        }
        public static string GetContentPlateFormOrderStatusText(byte appType)
        {
            string typeText = "";
            switch (appType)
            {
                case 1:
                    typeText = "未派单";
                    break;

                case 2:
                    typeText = "已派单";
                    break;

                case 3:
                    typeText = "已接单";
                    break;

                case 4:
                    typeText = "已成交";
                    break;

                case 5:
                    typeText = "医院重单";
                    break;

                case 6:
                    typeText = "未成交";
                    break;

            }
            return typeText;
        }

        #endregion

        /// <summary>
        /// 获取订单类型文本
        /// </summary>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public static string GetOrderTypeText(long? orderType)
        {
            string orderTypeText = "";
            switch (orderType)
            {
                case 0:
                    orderTypeText = "虚拟订单";
                    break;

                case 1:
                    orderTypeText = "实物订单";
                    break;
            }
            return orderTypeText;
        }
        /// <summary>
        /// 获取抖点订单类型文本
        /// </summary>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public static string GetTikTokOrderTypeText(byte orderType)
        {
            string orderTypeText = "";
            switch (orderType)
            {
                case 0:
                    orderTypeText = "实物订单";
                    break;

                case 2:
                    orderTypeText = "虚拟订单";
                    break;
                case 4:
                    orderTypeText = "电子券poi核销";
                    break;
                case 5:
                    orderTypeText = "三方核销";
                    break;
            }
            return orderTypeText;
        }
        /// <summary>
        /// 获取重要程度文本,0可忽略，1轻微，2一般，3重要，4非常重要
        /// </summary>
        /// <param name="emergencyLevel"></param>
        /// <returns></returns>
        public static string GetShopCartRegisterEmergencyLevelText(int emergencyLevel)
        {
            string emergencyLevelText = "";
            switch (emergencyLevel)
            {
                case 0:
                    emergencyLevelText = "可忽略";
                    break;
                /*case 1:
                    emergencyLevelText = "轻微";
                    break;*/
                case 2:
                    emergencyLevelText = "一般";
                    break;
                case 3:
                    emergencyLevelText = "重要";
                    break;
                /*case 4:
                    emergencyLevelText = "非常重要";
                    break;*/
                default:
                    emergencyLevelText = "可忽略";
                    break;

            }
            return emergencyLevelText;
        }

        /// <summary>
        /// 获取订单性质文本
        /// </summary>
        /// <param name="orderNature"></param>
        /// <returns></returns>
        public static string GetOrderNatureText(byte orderNature)
        {
            string orderTypeText = "";
            switch (orderNature)
            {
                case 0:
                    orderTypeText = "正常下单";
                    break;

                case 1:
                    orderTypeText = "朋友推荐";
                    break;
                case 2:
                    orderTypeText = "私域合作";
                    break;
            }
            return orderTypeText;
        }

        public static string GetOrderFromText(int orderFrom)
        {
            string orderTypeText = "";
            switch (orderFrom)
            {
                case 0:
                    orderTypeText = "未知";
                    break;

                case 1:
                    orderTypeText = "下单平台";
                    break;
                case 2:
                    orderTypeText = "内容平台";
                    break;
                case 3:
                    orderTypeText = "消费追踪";
                    break;
            }
            return orderTypeText;
        }


        /// <summary>
        /// 获取交易类型文本
        /// </summary>
        /// <param name="exchangeType"></param>
        /// <returns></returns>
        public static string GetExchangeTypeText(byte exchangeType)
        {
            string orderTypeText = "";
            switch (exchangeType)
            {
                case 0:
                    orderTypeText = "积分支付";
                    break;
                case 1:
                    orderTypeText = "三方支付";
                    break;
                case 2:
                    orderTypeText = "线下支付";
                    break;
                case 3:
                    orderTypeText = "余额支付";
                    break;
                case 4:
                    orderTypeText = "微信支付";
                    break;
                case 5:
                    orderTypeText = "支付宝支付";
                    break;
                case 6:
                    orderTypeText = "慧收钱支付";
                    break;
                default:
                    orderTypeText = "未知";
                    break;
            }
            return orderTypeText;
        }




        /// <summary>
        /// 获取消费追踪类型文本
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerConsumeTypeText(byte consumeType)
        {
            string consumeTypeText = "";
            switch (consumeType)
            {
                case 0:
                    consumeTypeText = "当天其他消费";
                    break;

                case 1:
                    consumeTypeText = "再消费";
                    break;
            }
            return consumeTypeText;
        }

        /// <summary>
        /// 获取升单渠道文本
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerConsumeChannelText(int channel)
        {
            string channelTypeText = "";
            switch (channel)
            {
                case 0:
                    channelTypeText = "医院";
                    break;

                case 1:
                    channelTypeText = "天猫";
                    break;

                case 2:
                    channelTypeText = "抖音";
                    break;

                case 3:
                    channelTypeText = "抖音代运营";
                    break;
            }
            return channelTypeText;
        }

        /// <summary>
        /// 获取内容平台到院类型文本
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerContentPlatFormOrderToHospitalTypeText(int toHospitalType)
        {
            string toHospitalTypeText = "";
            switch (toHospitalType)
            {
                case 1:
                    toHospitalTypeText = "初诊";
                    break;

                case 2:
                    toHospitalTypeText = "复诊";
                    break;

                case 3:
                    toHospitalTypeText = "再消费";

                    break;
                case 4:
                    toHospitalTypeText = "退款";
                    break;

                case 0:
                    toHospitalTypeText = "其他";
                    break;

            }
            return toHospitalTypeText;
        }

        /// <summary>
        /// 获取内容平台订单来源
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerContentPlatFormOrderSourceText(int channel)
        {
            string channelTypeText = "";
            switch (channel)
            {
                case 1:
                    channelTypeText = "面诊卡";
                    break;

                case 2:
                    channelTypeText = "非面诊卡";
                    break;
                case 3:
                    channelTypeText = "美肤卡";
                    break;
            }
            return channelTypeText;
        }

        /// <summary>
        /// 获取升单类型
        /// </summary>
        /// <param name="BuyAgainType"></param>
        /// <returns></returns>
        public static string GetBuyAgainTypeText(int BuyAgainType)
        {
            string BuyAgainTypeText = "";
            switch (BuyAgainType)
            {
                case 0:
                    BuyAgainTypeText = "升单5%";
                    break;

                case 1:
                    BuyAgainTypeText = "升单30%";
                    break;
                case 2:
                    BuyAgainTypeText = "升单35%";
                    break;
                case 3:
                    BuyAgainTypeText = "升单10%";
                    break;
                case 4:
                    BuyAgainTypeText = "升单15%";
                    break;
                case 5:
                    BuyAgainTypeText = "升单20%";
                    break;
                case 6:
                    BuyAgainTypeText = "升单50%";
                    break;
            }
            return BuyAgainTypeText;
        }
        /// <summary>
        /// 获取获得积分类型
        /// </summary>
        /// <param name="IntegrationType"></param>
        /// <returns></returns>
        public static string GetIntegrationTypeText(int IntegrationType)
        {
            string BuyAgainTypeText = "";
            switch (IntegrationType)
            {
                case 0:
                    BuyAgainTypeText = "消费产生积分";
                    break;

                case 1:
                    BuyAgainTypeText = "赠送积分";
                    break;
                case 2:
                    BuyAgainTypeText = "活动积分";
                    break;
                case 3:
                    BuyAgainTypeText = "期初积分";
                    break;
                case 4:
                    BuyAgainTypeText = "退费归还积分";
                    break;
                case 5:
                    BuyAgainTypeText = "退还礼品积分";
                    break;
            }
            return BuyAgainTypeText;
        }
        /// <summary>
        /// 获取使用积分类型
        /// </summary>
        /// <param name="IntegrationType"></param>
        /// <returns></returns>
        public static string GetUseIntegrationTypeText(int IntegrationType)
        {
            string BuyAgainTypeText = "";
            switch (IntegrationType)
            {
                case 0:
                    BuyAgainTypeText = "消费抵用";
                    break;

                case 1:
                    BuyAgainTypeText = "归还信用积分";
                    break;
                case 2:
                    BuyAgainTypeText = "积分过期";
                    break;
                case 3:
                    BuyAgainTypeText = "退费";
                    break;
                case 4:
                    BuyAgainTypeText = "转介绍人退费";
                    break;
                case 5:
                    BuyAgainTypeText = "兑换礼品";
                    break;
            }
            return BuyAgainTypeText;
        }
        /// <summary>
        /// 获取审核情况
        /// </summary>
        /// <param name="BuyAgainType"></param>
        /// <returns></returns>
        public static string GetCheckTypeText(int CheckType)
        {
            string CheckTypeText = "";
            switch (CheckType)
            {
                case 0:
                    CheckTypeText = "未审核";
                    break;

                case 1:
                    CheckTypeText = "审核不通过";
                    break;
                case 2:
                    CheckTypeText = "审核通过";
                    break;
                case 3:
                    CheckTypeText = "审核中";
                    break;
            }
            return CheckTypeText;
        }
        /// <summary>
        /// 获取退款订审核情况
        /// </summary>
        /// <param name="CheckType"></param>
        /// <returns></returns>
        public static string GetOrderRefundCheckTypeText(int CheckType)
        {
            string CheckTypeText = "";
            switch (CheckType)
            {
                case 0:
                    CheckTypeText = "待审核";
                    break;

                case 1:
                    CheckTypeText = "审核通过";
                    break;
                case 2:
                    CheckTypeText = "审核未通过";
                    break;
            }
            return CheckTypeText;
        }


        /// <summary>
        /// 获取退款订单退款情况
        /// </summary>
        /// <param name="CheckType"></param>
        /// <returns></returns>
        public static string GetRefundStateText(int CheckType)
        {
            string CheckTypeText = "";
            switch (CheckType)
            {
                case 0:
                    CheckTypeText = "待退款";
                    break;

                case 1:
                    CheckTypeText = "退款成功";
                    break;
                case 2:
                    CheckTypeText = "退款失败";
                    break;
                case 3:
                    CheckTypeText = "退款中";
                    break;
            }
            return CheckTypeText;
        }

        /// <summary>
        /// 获取提交情况
        /// </summary>
        /// <param name="BuyAgainType"></param>
        /// <returns></returns>
        public static string GetSubmitTypeText(int CheckType)
        {
            string CheckTypeText = "";
            switch (CheckType)
            {
                case 0:
                    CheckTypeText = "未提交";
                    break;

                case 1:
                    CheckTypeText = "已提交";
                    break;
            }
            return CheckTypeText;
        }

        /// <summary>
        /// 获取提报涨停
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerSendStatusText(int sendStatus)
        {
            string channelTypeText = "";
            switch (sendStatus)
            {
                case 0:
                    channelTypeText = "未提报";
                    break;

                case 1:
                    channelTypeText = "已提报";
                    break;

                case 2:
                    channelTypeText = "跟进中";
                    break;

                case 3:
                    channelTypeText = "跟进完成";
                    break;

                case 4:
                    channelTypeText = "跟进失败";
                    break;
            }
            return channelTypeText;
        }


        /// <summary>
        /// 获取盘库状态
        /// </summary>
        /// <param name="orderFrom"></param>
        /// <returns></returns>
        public static string GetInventoryStateText(int inventoryState)
        {
            string inventoryStateText = "";
            switch (inventoryState)
            {
                case 1:
                    inventoryStateText = "盘平";
                    break;

                case 2:
                    inventoryStateText = "盘盈";
                    break;

                case 3:
                    inventoryStateText = "盘亏";
                    break;
            }
            return inventoryStateText;
        }


        /// <summary>
        /// 获取面诊方式
        /// </summary>
        /// <param name="consulationType"></param>
        /// <returns></returns>
        public static string GetConsulationTypeText(int consulationType)
        {
            string inventoryStateText = "";
            switch (consulationType)
            {
                case 1:
                    inventoryStateText = "视频";
                    break;

                case 2:
                    inventoryStateText = "图片";
                    break;

                case 3:
                    inventoryStateText = "私信";
                    break;

                case 4:
                    inventoryStateText = "其他";
                    break;

                case 5:
                    inventoryStateText = "短视频";
                    break;
            }
            return inventoryStateText;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content">需要加密的内容</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string content, string encryptKey)
        {
            if (string.IsNullOrWhiteSpace(content))
                return "";
            DesHelper desUtil = new DesHelper(encryptKey);
            return desUtil.EncryptToBase64String(content);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptContent">需解密的加密内容</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns></returns>
        public static string Decrypto(string encryptContent, string encryptKey)
        {
            DesHelper desUtil = new DesHelper(encryptKey);
            return desUtil.DecryptFromBase64String(encryptContent);
        }


        /// <summary>
        /// 获取不完整电话，中间四位用*代替
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string GetIncompletePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return "";
            return phone.Substring(0, 3) + "****" + phone.Substring(phone.Length - 4);
        }

        public static int GetAge(DateTime? birthdayInfo)
        {
            int age = 0;
            if (birthdayInfo != null)
            {
                DateTime date = DateTime.Now;
                DateTime birthday = (DateTime)birthdayInfo;
                age = date.Year - birthday.Year;
                if (date.Month < birthday.Month || (date.Month == birthday.Month && date.Day < birthday.Day))
                    age--;
            }
            return age;
        }

        /// <summary>
        /// 根据会员卡编号获取会员卡所需成长值范围
        /// </summary>
        /// <param name="rankcode"></param>
        /// <returns></returns>
        public static Dictionary<string, decimal> GetMemberCradScope(string rankcode)
        {
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
            switch (rankcode)
            {
                case "62":
                    dic = new Dictionary<string, decimal>
                    {
                        ["min_amount"] = 0,
                        ["max_amount"] = 200
                    };
                    break;
                case "68":
                    dic = new Dictionary<string, decimal>
                    {
                        ["min_amount"] = 200,
                        ["max_amount"] = 500
                    };
                    break;
                case "70":
                    dic = new Dictionary<string, decimal>
                    {
                        ["min_amount"] = 500,
                        ["max_amount"] = 10000000
                    };
                    break;
                default: throw new Exception("请输入正确的会员卡编码");
            }
            return dic;
        }
        /// <summary>
        /// 根据会员卡编号获取会员卡名称
        /// </summary>
        /// <param name="rankcode"></param>
        /// <returns></returns>
        public static string GetMemberCradName(string rankcode)
        {
            string rankCodeText = "";
            switch (rankcode)
            {
                case "62":
                    rankCodeText = "普通会员";
                    break;
                case "68":
                    rankCodeText = "MEIYA白金会员";
                    break;
                case "70":
                    rankCodeText = "MEIYA黑金会员";
                    break;
                default: throw new Exception("请输入正确的会员卡编码");
            }
            return rankCodeText;
        }
        /// <summary>
        /// 根据类型exchangetype获取支付方式名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetRechargeExchangeTypeText(int type)
        {
            string typeText = "";
            switch (type)
            {
                case 0:
                    typeText = "支付宝";
                    break;
                case 1:
                    typeText = "微信";
                    break;
                case 2:
                    typeText = "商品退款";
                    break;
                case 3:
                    typeText = "储值赠送";
                    break;
                case 4:
                    typeText = "微信支付";
                    break;
                default:
                    typeText = "其他";
                    break;
            }
            return typeText;
        }
        /// <summary>
        /// 根据支付类型编码获取支付类型
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int GetRechargeTypeByExchangeCode(string code)
        {
            int type = 0;
            switch (code)
            {
                case "ALIPAY":
                    type = 0;
                    break;
                case "WECHAT":
                    type = 1;
                    break;
                case "HSQ":
                    type = 4;
                    break;
                default:
                    type = -1;
                    break;
            }
            return type;
        }
        /// <summary>
        /// 获取充值状态文本
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetRechargeStatusText(int status)
        {
            string statusText = "";
            switch (status)
            {
                case 0:
                    statusText = "待付款";
                    break;
                case 1:
                    statusText = "成功";
                    break;
                case 2:
                    statusText = "取消";
                    break;
                case 3:
                    statusText = "支付中";
                    break;
                default:
                    statusText = "其他";
                    break;
            };
            return statusText;
        }

        /// <summary>
        /// 获取拍剪组视频类型文本
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerShootingAndClipVideoTypeText(int type)
        {
            string channelTypeText = "";
            switch (type)
            {

                case 1:
                    channelTypeText = "广告片";
                    break;

                case 2:
                    channelTypeText = "口播";
                    break;

                case 3:
                    channelTypeText = "vlong";
                    break;

                case 4:
                    channelTypeText = "企业宣传文化片";
                    break;
                case 0:
                    channelTypeText = "其他";
                    break;
            }
            return channelTypeText;
        }
    }
}
