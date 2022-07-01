using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ServiceInfoProviderQueryServicePageRequest : JdRequestBase<ServiceInfoProviderQueryServicePageResponse>
    {
                                                                                                                                              public  		Nullable<int>
              afsServiceId
 {get; set;}
                                                          
                                                          public  		string
              buId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              afsApplyTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              afsApplyTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              afsServiceStep
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              afsServiceProcessResult
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              approvedDateBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              approvedDateEnd
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
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                                                                                      public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              pageIndex
 {get; set;}
                                                          
                                                                                                                                                       public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              operatorNick
 {get; set;}
                                                          
                                                          public  		string
              operatorRemark
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatorDate
 {get; set;}
                                                          
                                                          public  		string
              platformSrc
 {get; set;}
                                                          
                                                                                           public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              newOrderId
 {get; set;}
                                                          
                                                          public  		string
              verificationCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ServiceInfoProvider.queryServicePage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("afsServiceId", this.            afsServiceId
);
                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("afsApplyTimeBegin", this.            afsApplyTimeBegin
);
                                                                                                        parameters.Add("afsApplyTimeEnd", this.            afsApplyTimeEnd
);
                                                                                                        parameters.Add("afsServiceStep", this.            afsServiceStep
);
                                                                                                        parameters.Add("afsServiceProcessResult", this.            afsServiceProcessResult
);
                                                                                                        parameters.Add("approvedDateBegin", this.            approvedDateBegin
);
                                                                                                        parameters.Add("approvedDateEnd", this.            approvedDateEnd
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("customerTel", this.            customerTel
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                                                                parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                                                                                        parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("operatorNick", this.            operatorNick
);
                                                                                                        parameters.Add("operatorRemark", this.            operatorRemark
);
                                                                                                        parameters.Add("operatorDate", this.            operatorDate
);
                                                                                                        parameters.Add("platformSrc", this.            platformSrc
);
                                                                                                                                parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("newOrderId", this.            newOrderId
);
                                                                                                        parameters.Add("verificationCode", this.            verificationCode
);
                                                                            }
    }
}





        
 

