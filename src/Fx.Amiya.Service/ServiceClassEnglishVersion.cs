using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{

    public static class ServiceClassEnglishVersion
    {
        /// <summary>
        /// 获取重要程度文本【英文版】,0可忽略，1轻微，2一般，3重要，4非常重要
        /// </summary>
        /// <param name="emergencyLevel"></param>
        /// <returns></returns>
        public static string GetShopCartRegisterEmergencyLevelTextEnglish(int emergencyLevel)
        {
            string emergencyLevelText = "";
            switch (emergencyLevel)
            {
                case 0:
                    emergencyLevelText = "Third level clue";
                    break;
                case 2:
                    emergencyLevelText = "Second level clue";
                    break;
                case 3:
                    emergencyLevelText = "First level clue";
                    break;
                case 4:
                    emergencyLevelText = "Invalid clue";
                    break;
                default:
                    emergencyLevelText = "Third level clue";
                    break;

            }
            return emergencyLevelText;
        }



        /// <summary>
        /// 获取抖音新增客户来源类型【英文版】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTiktokCustomerSourceTextEnglish(int? type)
        {
            string sourceText = "";
            switch (type)
            {
                case 0:
                    sourceText = "Short video";
                    break;
                case 1:
                    sourceText = "Living room";
                    break;
                case 2:
                    sourceText = "Fan chat group";
                    break;
                case 3:
                    sourceText = "Private message";
                    break;
                case 4:
                    sourceText = "Intelligent AI";
                    break;
                case 5:
                    sourceText = "Other";
                    break;
                case 6:
                    sourceText = "Product transformation";
                    break;
                case 7:
                    sourceText = "Tiktok windmill";
                    break;
                case 8:
                    sourceText = "Tiktok lucky bag";
                    break;
                case 9:
                    sourceText = "Living public screen";
                    break;
                case 10:
                    sourceText = "Old customers bring in new ones";
                    break;
                case 11:
                    sourceText = "24 hours living";
                    break;
                default:
                    sourceText = "";
                    break;
            }
            return sourceText;

        }



        /// <summary>
        /// 获取小黄车带货产品类型【英文版】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetShoppingCartTakeGoodsProductTypeTextEnglish(int? type)
        {
            string sourceText = "";
            switch (type)
            {
                case 0:
                    sourceText = "Other";
                    break;
                case 1:
                    sourceText = "Ultrasound Cannon";
                    break;
                case 2:
                    sourceText = "Skin care products";
                    break;
                case 3:
                    sourceText = "beauty makeup";
                    break;
                case 4:
                    sourceText = "Ornament&Clothes";
                    break;
                default:
                    sourceText = "";
                    break;
            }
            return sourceText;

        }



        /// <summary>
        /// 获取小黄车获客方式【英文版】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetShoppingCartGetCustomerTypeTextEnglish(int type)
        {
            string sourceText = "";
            switch (type)
            {
                case 0:
                    sourceText = "Other";
                    break;
                case 1:
                    sourceText = "Independent customer acquisition";
                    break;
                case 2:
                    sourceText = "Distribution within the group";
                    break;
            }
            return sourceText;

        }


        /// <summary>
        /// 获取小黄车顾客类型【英文版】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetShoppingCartCustomerTypeTextEnglish(int type)
        {
            string sourceText = "";
            switch (type)
            {
                case 0:
                    sourceText = "Other";
                    break;
                case 1:
                    sourceText = "Medical aesthetics customers";
                    break;
                case 2:
                    sourceText = "Promoting products get customers";
                    break;
            }
            return sourceText;

        }


        /// <summary>
        /// 小黄车客户归属渠道英文版
        /// </summary>
        /// <param name="belongChannel"></param>
        /// <returns></returns>
        public static string BelongChannelTextEnglish(int belongChannel)
        {
            string text = "";
            switch (belongChannel)
            {
                case 1:
                    text = "Before the live broadcast";
                    break;
                case 2:
                    text = "Live streaming";
                    break;
                case 3:
                    text = "After the live broadcast";
                    break;
                default:
                    text = "Unattributed [not choose]";
                    break;
            }
            return text;
        }



        /// <summary>
        /// 获取归属公司【英文版】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetBelongCompanyTypeTextEnglish(int type)
        {
            string sourceText = "";
            switch (type)
            {
                case 0:
                    sourceText = "Other";
                    break;
                case 1:
                    sourceText = "Ameiya";
                    break;
                case 2:
                    sourceText = "Ameiya SaiDa";
                    break;
                case 3:
                    sourceText = "Ameiya ShangXueYuan";
                    break;

                case 4:
                    sourceText = "Ameiya Meiyan";
                    break;

                case 5:
                    sourceText = "Run Tang";
                    break;
            }
            return sourceText;

        }



        /// <summary>
        /// 内容平台订单状态【英文版】
        /// </summary>
        /// <param name="appType"></param>
        /// <returns></returns>
        public static string GetContentPlateFormOrderStatusTextEnglish(byte appType)
        {
            string typeText = "";
            switch (appType)
            {
                case 1:
                    typeText = "Created order";
                    break;

                case 2:
                    typeText = "Dispatched order";
                    break;

                case 3:
                    typeText = "Accepted order";
                    break;

                case 4:
                    typeText = "Deal order";
                    break;

                case 5:
                    typeText = "Repeat order-can work together";
                    break;

                case 6:
                    typeText = "UnDeal order";
                    break;
                case 7:
                    typeText = "Repeat order-can't work together";
                    break;
            }
            return typeText;
        }


        /// <summary>
        /// 获取内容平台订单来源【英文版】
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerContentPlatFormOrderSourceTextEnglish(int channel)
        {
            string channelTypeText = "";
            switch (channel)
            {
                case 1:
                    channelTypeText = "Consulation card";
                    break;

                case 2:
                    channelTypeText = "Other card";
                    break;
                case 3:
                    channelTypeText = "Beauty card";
                    break;
                case 4:
                    channelTypeText = "Living room";
                    break;
                case 5:
                    channelTypeText = "Short video";
                    break;
                case 6:
                    channelTypeText = "Private message";
                    break;
            }
            return channelTypeText;
        }


        /// <summary>
        /// 获取内容平台面诊类型【英文版】
        /// </summary>
        /// <param name="ConsultationType"></param>
        /// <returns></returns>
        public static string GetContentPlateFormOrderConsultationTypeTextEnglish(int ConsultationType)
        {
            string typeText = "";
            switch (ConsultationType)
            {

                case 1:
                    typeText = "(Assistant)Consulationed by photo";
                    break;
                case 2:
                    typeText = "(Live anchor)Consulationed by video";
                    break;
                case 3:
                    typeText = "(Live anchor)Consulationed by voice";
                    break;
                case 0:
                    typeText = "Other";
                    break;

            }
            return typeText;
        }

        /// <summary>
        /// 内容平台订单类型【英文版】
        /// </summary>
        /// <param name="appType"></param>
        /// <returns></returns>

        public static string GetContentPlateFormOrderTypeTextEnglish(byte appType)
        {
            string typeText = "";
            switch (appType)
            {
                case 1:
                    typeText = "Consultation order";
                    break;

                case 2:
                    typeText = "Deposit order";
                    break;
                case 3:
                    typeText = "Appointment order";
                    break;

            }
            return typeText;
        }


        /// <summary>
        /// 获取客户预约日程的预约类型【英文版】
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetAppointmentTypeTextEnglish(int type)
        {
            var statusText = "";
            switch (type)
            {
                //case 0:
                //    statusText = "其他";
                //    break;
                case 1:
                    statusText = "Video Design reservation";
                    break;
                case 2:
                    statusText = "Make an appointment for hospital consultation";
                    break;
                default:
                    statusText = "Unknown";
                    break;
            }
            return statusText;
        }

        /// <summary>
        /// 获取录单申请类型【英文版】
        /// </summary>
        /// <param name="rankcode"></param>
        /// <returns></returns>
        public static string GetContentPlatformOrderAddWorkTypeTextEnglish(int contentPlatformOrderAddWorkType)
        {
            string contentPlatformOrderAddWorkTypeText = "";
            switch (contentPlatformOrderAddWorkType)
            {
                case 1:
                    contentPlatformOrderAddWorkTypeText = "Add order application";
                    break;
                case 2:
                    contentPlatformOrderAddWorkTypeText = "Update bind application";
                    break;
            }
            return contentPlatformOrderAddWorkTypeText;
        }

        /// <summary>
        /// 获取审核情况【英文版】
        /// </summary>
        /// <param name="BuyAgainType"></param>
        /// <returns></returns>
        public static string GetCheckTypeTextEnglish(int CheckType)
        {
            string CheckTypeText = "";
            switch (CheckType)
            {
                case 0:
                    CheckTypeText = "UnChecked";
                    break;

                case 1:
                    CheckTypeText = "Check not pass";
                    break;
                case 2:
                    CheckTypeText = "Check successful";
                    break;
                case 3:
                    CheckTypeText = "Checking";
                    break;
            }
            return CheckTypeText;
        }



        /// <summary>
        /// 获取内容平台到院类型文本【英文版】
        /// </summary>
        /// <param name="consumeType"></param>
        /// <returns></returns>
        public static string GerContentPlatFormOrderToHospitalTypeTextEnglish(int toHospitalType)
        {
            string toHospitalTypeText = "";
            switch (toHospitalType)
            {
                case 1:
                    toHospitalTypeText = "First examination";
                    break;

                case 2:
                    toHospitalTypeText = "Follow-up examination";
                    break;

                case 3:
                    toHospitalTypeText = "Repeat consumption";

                    break;
                case 4:
                    toHospitalTypeText = "Refund";
                    break;

                case 0:
                    toHospitalTypeText = "Other";
                    break;

            }
            return toHospitalTypeText;
        }

        /// <summary>
        /// 业绩类型文本【英文版】
        /// </summary>
        /// <param name="performanceType"></param>
        /// <returns></returns>
        public static string GetContentPlateFormOrderDealPerformanceTypeEnglish(int performanceType)
        {
            string typeText = "";
            switch (performanceType)
            {
                case 0:
                    typeText = "Other";
                    break;
                case 1:
                    typeText = "Assistant activate";
                    break;

                case 2:
                    typeText = "VIP steward activate";
                    break;
                case 3:
                    typeText = "Hospital submit the order";
                    break;
                case 4:
                    typeText = "Assistant checked";
                    break;
                case 5:
                    typeText = "Financial staff checked";
                    break;
                case 6:
                    typeText = "VIP steward checked";
                    break;
                case 7:
                    typeText = "Hospital submit the order-API（Not checked）";
                    break;
                case 8:
                    typeText = "Assistant replenishment order";
                    break;
            }
            return typeText;
        }


        /// <summary>
        /// 获取成交情况消费类型【英文版】
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetConsumptionTypeTextEnglish(int? type)
        {
            string consumptionType = "";
            switch (type)
            {
                case 0:
                    consumptionType = "Deposit consumption";
                    break;
                case 1:
                    consumptionType = "Deal consumption";
                    break;
                case 2:
                    consumptionType = "Refund consumption";
                    break;
                case 3:
                    consumptionType = "Other consumption";
                    break;
                case 4:
                    consumptionType = "Debt recovery";
                    break;
                default:
                    consumptionType = "Unknow";
                    break;
            }
            return consumptionType;

        }


        public static string GetRFMTagTextEnglish(int tag)
        {
            string str = "";
            switch (tag)
            {
                case 0:
                    str = "Super VIP（RV）";
                    break;
                case 1:
                    str = "Important value customers(R1)";
                    break;
                case 2:
                    str = "Important retained customers(R2)";
                    break;
                case 3:
                    str = "Important development clients(R3)";
                    break;
                case 4:
                    str = "Important customer retention(R4)";
                    break;
                case 5:
                    str = "General value customer(R5)";
                    break;
                case 6:
                    str = "Generally maintain customers(R6)";
                    break;
                case 7:
                    str = "Generally develop customers(R7)";
                    break;
                case 8:
                    str = "Generally retain customers(R8)";
                    break;
                default:
                    str = "/";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 获取消息通知类型【英文版】
        /// </summary>
        /// <param name="consulationType"></param>
        /// <returns></returns>
        public static string GetNoticeTypeTextEnglish(int noticeType)
        {
            string inventoryStateText = "";
            switch (noticeType)
            {
                case 1:
                    inventoryStateText = "Order notice";
                    break;

                case 2:
                    inventoryStateText = "Schedule notice";
                    break;

                case 3:
                    inventoryStateText = "Operation notice";
                    break;

                case 4:
                    inventoryStateText = "Triage notice";
                    break;

                case 5:
                    inventoryStateText = "System notice";
                    break;
            }
            return inventoryStateText;
        }
    }
}
