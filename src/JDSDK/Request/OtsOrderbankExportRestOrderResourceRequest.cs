using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OtsOrderbankExportRestOrderResourceRequest : JdRequestBase<OtsOrderbankExportRestOrderResourceResponse>
    {
                                                                                                                                              public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		string
              sendPay
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              totalPrice
 {get; set;}
                                                          
                                                          public  		string
              discount
 {get; set;}
                                                          
                                                          public  		string
              yun
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderTime
 {get; set;}
                                                          
                                                          public  		string
              payDiscount
 {get; set;}
                                                          
                                                          public  		string
              merchantId
 {get; set;}
                                                          
                                                          public  		string
              parentOrderId
 {get; set;}
                                                          
                                                          public  		string
              appId
 {get; set;}
                                                          
                                                          public  		string
              systemNo
 {get; set;}
                                                          
                                                          public  		string
              orderPrice
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currency
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              delivery
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              ver
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              payMode
 {get; set;}
                                                          
                                                          public  		string
              appToken
 {get; set;}
                                                          
                                                          public  		string
              otherMoney
 {get; set;}
                                                          
                                                          public  		string
              productCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  notePub {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payEnum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payOrderId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  businessNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payMoney {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payCurrencyName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payMerchantId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payParentOrderId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payAppId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  paySystemNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payCurrency {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  ext2 {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  ext1 {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payVer {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payAppToken {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  dataType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  noteInner {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  updateTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderBankNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eventType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payTypeName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  currencyPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payCreateTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  rfIdType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  morePay {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  businessType {get; set; }
                                                                                                                                                                                                public  		string
              paidIn
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderCode
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              tuotouTime
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  receivableTypeName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receAmount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receivableId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receivableType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receCurrencyName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receCreateTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receAppToken {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receAppId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receSystemNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receCurrency {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.ots.orderbank.export.rest.OrderResource";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("sendPay", this.            sendPay
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("totalPrice", this.            totalPrice
);
                                                                                                        parameters.Add("discount", this.            discount
);
                                                                                                        parameters.Add("yun", this.            yun
);
                                                                                                        parameters.Add("orderTime", this.            orderTime
);
                                                                                                        parameters.Add("payDiscount", this.            payDiscount
);
                                                                                                        parameters.Add("merchantId", this.            merchantId
);
                                                                                                        parameters.Add("parentOrderId", this.            parentOrderId
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("systemNo", this.            systemNo
);
                                                                                                        parameters.Add("orderPrice", this.            orderPrice
);
                                                                                                        parameters.Add("currency", this.            currency
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("delivery", this.            delivery
);
                                                                                                        parameters.Add("ver", this.            ver
);
                                                                                                        parameters.Add("payMode", this.            payMode
);
                                                                                                        parameters.Add("appToken", this.            appToken
);
                                                                                                        parameters.Add("otherMoney", this.            otherMoney
);
                                                                                                        parameters.Add("productCode", this.            productCode
);
                                                                                                                                                                                        parameters.Add("notePub", this.            notePub
);
                                                                                                        parameters.Add("payEnum", this.            payEnum
);
                                                                                                        parameters.Add("payOrderId", this.            payOrderId
);
                                                                                                        parameters.Add("payTime", this.            payTime
);
                                                                                                        parameters.Add("businessNo", this.            businessNo
);
                                                                                                        parameters.Add("payType", this.            payType
);
                                                                                                        parameters.Add("payMoney", this.            payMoney
);
                                                                                                        parameters.Add("payCurrencyName", this.            payCurrencyName
);
                                                                                                        parameters.Add("payMerchantId", this.            payMerchantId
);
                                                                                                        parameters.Add("payParentOrderId", this.            payParentOrderId
);
                                                                                                        parameters.Add("payAppId", this.            payAppId
);
                                                                                                        parameters.Add("paySystemNo", this.            paySystemNo
);
                                                                                                        parameters.Add("payCurrency", this.            payCurrency
);
                                                                                                        parameters.Add("ext2", this.            ext2
);
                                                                                                        parameters.Add("ext1", this.            ext1
);
                                                                                                        parameters.Add("payVer", this.            payVer
);
                                                                                                        parameters.Add("payAppToken", this.            payAppToken
);
                                                                                                        parameters.Add("dataType", this.            dataType
);
                                                                                                        parameters.Add("noteInner", this.            noteInner
);
                                                                                                        parameters.Add("updateTime", this.            updateTime
);
                                                                                                        parameters.Add("orderBankNo", this.            orderBankNo
);
                                                                                                        parameters.Add("eventType", this.            eventType
);
                                                                                                        parameters.Add("payTypeName", this.            payTypeName
);
                                                                                                        parameters.Add("currencyPrice", this.            currencyPrice
);
                                                                                                        parameters.Add("payCreateTime", this.            payCreateTime
);
                                                                                                        parameters.Add("rfIdType", this.            rfIdType
);
                                                                                                        parameters.Add("morePay", this.            morePay
);
                                                                                                        parameters.Add("payId", this.            payId
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                                                                        parameters.Add("paidIn", this.            paidIn
);
                                                                                                        parameters.Add("orderCode", this.            orderCode
);
                                                                                                        parameters.Add("tuotouTime", this.            tuotouTime
);
                                                                                                                                                                                        parameters.Add("receivableTypeName", this.            receivableTypeName
);
                                                                                                        parameters.Add("receAmount", this.            receAmount
);
                                                                                                        parameters.Add("receivableId", this.            receivableId
);
                                                                                                        parameters.Add("receivableType", this.            receivableType
);
                                                                                                        parameters.Add("receCurrencyName", this.            receCurrencyName
);
                                                                                                        parameters.Add("receCreateTime", this.            receCreateTime
);
                                                                                                        parameters.Add("receAppToken", this.            receAppToken
);
                                                                                                        parameters.Add("receAppId", this.            receAppId
);
                                                                                                        parameters.Add("receSystemNo", this.            receSystemNo
);
                                                                                                        parameters.Add("receCurrency", this.            receCurrency
);
                                                                                                                            }
    }
}





        
 

