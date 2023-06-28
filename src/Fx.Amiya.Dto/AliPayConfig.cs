using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto
{
    /// <summary>
    /// 支付宝提交类
    /// </summary>
    public class AliPayConfig
    {

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public static string partner = "";

        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        public  string seller_id = partner;

        // MD5密钥，安全检验码，由数字和字母组成的32位字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public  string key = "";

        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        //public  string notify_url = "https://app.hsltm.com/fxgatetest/amiyamini/amiya/wxmini/Notify/aliPayNotifyUrl"; //测试地址
        public string notify_url = "https://app.ameiyes.com/amiyamini/amiya/wxmini/Notify/aliPayNotifyUrl";  //正式地址
        

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        //public string return_url = "https://app.hsltm.com/fxgatetest/amiyamini/amiya/wxmini/Order/getAlreadyBuyOrderList?ExchangeType=1&pageNum=1&pageSize=10";  //测试地址
        public string return_url = "https://app.ameiyes.com/amiyamini/amiya/wxmini/Order/getAlreadyBuyOrderList?ExchangeType=1&pageNum=1&pageSize=10";  //正式地址
        // 签名方式
        public string sign_type = "MD5";

        // 字符编码格式 目前支持 gbk 或 utf-8
        public  string input_charset = "utf-8";

        // 支付类型 ，无需修改
        public  string payment_type = "1";

        // 调用的接口名，无需修改
        public  string service = "alipay.wap.create.direct.pay.by.user";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


        //↓↓↓↓↓↓↓↓↓↓请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数
        public  string anti_phishing_key = "";

        //客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1
        public  string exter_invoke_ip = "";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    }
}
