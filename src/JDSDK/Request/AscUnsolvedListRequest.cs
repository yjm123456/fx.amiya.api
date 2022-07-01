using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscUnsolvedListRequest : JdRequestBase<AscUnsolvedListResponse>
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
                                                          
                                                          public  	    Nullable<bool>
              jdInterveneFlag
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeEnd
 {get; set;}
                                                          
                                                          public  		string
              verificationCode
 {get; set;}
                                                          
                                                          public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              processResult
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              messageStatus
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
                get{return "jingdong.asc.unsolved.list";}
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
                                                                                                        parameters.Add("jdInterveneFlag", this.            jdInterveneFlag
);
                                                                                                        parameters.Add("applyTimeBegin", this.            applyTimeBegin
);
                                                                                                        parameters.Add("applyTimeEnd", this.            applyTimeEnd
);
                                                                                                        parameters.Add("verificationCode", this.            verificationCode
);
                                                                                                        parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("processResult", this.            processResult
);
                                                                                                        parameters.Add("messageStatus", this.            messageStatus
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





        
 

