using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscAuditListRequest : JdRequestBase<AscAuditListResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              customerExpect
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceStatus
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              timeoutFlag
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		string
              customerName
 {get; set;}
                                                          
                                                          public  		string
              customerTel
 {get; set;}
                                                          
                                                          public  		string
              verificationCode
 {get; set;}
                                                          
                                                                                                                      public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.audit.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("customerExpect", this.            customerExpect
);
                                                                                                        parameters.Add("serviceStatus", this.            serviceStatus
);
                                                                                                        parameters.Add("timeoutFlag", this.            timeoutFlag
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("customerTel", this.            customerTel
);
                                                                                                        parameters.Add("verificationCode", this.            verificationCode
);
                                                                                                                                                parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

