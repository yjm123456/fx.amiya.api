using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OtsOrderbankExportRestOperatePayResourceRequest : JdRequestBase<OtsOrderbankExportRestOperatePayResourceResponse>
    {
                                                                                                                                              public  		string
              notePub
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              payEnum
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              payTime
 {get; set;}
                                                          
                                                          public  		string
              oper
 {get; set;}
                                                          
                                                          public  		string
              businessNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              payType
 {get; set;}
                                                          
                                                          public  		string
              payMoney
 {get; set;}
                                                          
                                                          public  		string
              currencyName
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
                                                          
                                                          public  		Nullable<int>
              currency
 {get; set;}
                                                          
                                                          public  		string
              ext2
 {get; set;}
                                                          
                                                          public  		string
              ext1
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              ver
 {get; set;}
                                                          
                                                          public  		string
              appToken
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dataType
 {get; set;}
                                                          
                                                          public  		string
              noteInner
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              updateTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              eventType
 {get; set;}
                                                          
                                                          public  		string
              payTypeName
 {get; set;}
                                                          
                                                          public  		string
              currencyPrice
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createTime
 {get; set;}
                                                          
                                                          public  		string
              rfIdType
 {get; set;}
                                                          
                                                          public  		string
              payId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              businessType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ots.orderbank.export.rest.OperatePayResource";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("notePub", this.            notePub
);
                                                                                                        parameters.Add("payEnum", this.            payEnum
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("payTime", this.            payTime
);
                                                                                                        parameters.Add("oper", this.            oper
);
                                                                                                        parameters.Add("businessNo", this.            businessNo
);
                                                                                                        parameters.Add("payType", this.            payType
);
                                                                                                        parameters.Add("payMoney", this.            payMoney
);
                                                                                                        parameters.Add("currencyName", this.            currencyName
);
                                                                                                        parameters.Add("merchantId", this.            merchantId
);
                                                                                                        parameters.Add("parentOrderId", this.            parentOrderId
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("currency", this.            currency
);
                                                                                                        parameters.Add("ext2", this.            ext2
);
                                                                                                        parameters.Add("ext1", this.            ext1
);
                                                                                                        parameters.Add("ver", this.            ver
);
                                                                                                        parameters.Add("appToken", this.            appToken
);
                                                                                                        parameters.Add("dataType", this.            dataType
);
                                                                                                        parameters.Add("noteInner", this.            noteInner
);
                                                                                                        parameters.Add("updateTime", this.            updateTime
);
                                                                                                        parameters.Add("eventType", this.            eventType
);
                                                                                                        parameters.Add("payTypeName", this.            payTypeName
);
                                                                                                        parameters.Add("currencyPrice", this.            currencyPrice
);
                                                                                                        parameters.Add("createTime", this.            createTime
);
                                                                                                        parameters.Add("rfIdType", this.            rfIdType
);
                                                                                                        parameters.Add("payId", this.            payId
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                            }
    }
}





        
 

