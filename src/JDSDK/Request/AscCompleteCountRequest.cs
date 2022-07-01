using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscCompleteCountRequest : JdRequestBase<AscCompleteCountResponse>
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
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              processResult
 {get; set;}
                                                          
                                                          public  		string
              verificationCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.complete.count";}
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
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("processResult", this.            processResult
);
                                                                                                        parameters.Add("verificationCode", this.            verificationCode
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

