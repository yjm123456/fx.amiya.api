using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdreportQuerylocationRequest : JdRequestBase<DspAdreportQuerylocationResponse>
    {
                                                                                                                                                                               public  		string
              platform
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              OrderStatusCategory
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isTodayOr15Days
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isOrderOrClick
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adreport.querylocation";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("OrderStatusCategory", this.            OrderStatusCategory
);
                                                                                                        parameters.Add("isTodayOr15Days", this.            isTodayOr15Days
);
                                                                                                        parameters.Add("isOrderOrClick", this.            isOrderOrClick
);
                                                                                                                            }
    }
}





        
 

