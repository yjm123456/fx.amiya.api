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
    }
}
