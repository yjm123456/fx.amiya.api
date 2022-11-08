using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HuiShouQianPaymentService : IHuiShouQianPaymentService
    {
        public bool CheckHSQCommonParams(HuiShouQianCommonInfo huiShouQianCommonInfo, out string errmsg)
        {
            bool result = true;
            errmsg = "";
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.Method) || huiShouQianCommonInfo.Method.Length > 32)
            {
                errmsg = "请求方法名错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.Version) || huiShouQianCommonInfo.Version.Length > 16)
            {

                errmsg = "版本号错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.Format) || huiShouQianCommonInfo.Format.Length > 16)
            {

                errmsg = "业务请求参数格式错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.MerchantNo) || huiShouQianCommonInfo.MerchantNo.Length > 16)
            {

                errmsg = "商户号错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.SignType) || huiShouQianCommonInfo.SignType.Length > 16)
            {

                errmsg = "加密类型错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.SignContent))
            {

                errmsg = "业务数据不能为空";
                return false;
            }
            return result;

        }

        public bool CheckHSQMemoParam(HuiShouQianMemoInfo huiShouQianMemoInfo, out string errmsg)
        {
            bool result = true;
            errmsg = "";
            
        }

        public bool CheckHSQRequestParam(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo, out string errmsg)
        {
            bool result = true;
            errmsg = "";
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.TransNo)|| huiShouQianPayRequestInfo.TransNo.Length>64) {
                errmsg = "订单号错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.PayType) || huiShouQianPayRequestInfo.PayType.Length > 32)
            {
                errmsg = "支付类型错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.OrderAmt) || huiShouQianPayRequestInfo.OrderAmt.Length > 16)
            {
                errmsg = "交易金额错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.GoodsInfo) || huiShouQianPayRequestInfo.GoodsInfo.Length > 128)
            {
                errmsg = "商品说明信息错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.RequestDate) || huiShouQianPayRequestInfo.RequestDate.Length > 14)
            {
                errmsg = "商品说明信息错误";
                return false;
            }
        }
    }
}
