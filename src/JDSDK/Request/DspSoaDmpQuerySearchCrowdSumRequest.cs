using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspSoaDmpQuerySearchCrowdSumRequest : JdRequestBase<DspSoaDmpQuerySearchCrowdSumResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isOrderOrClick
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isTodayOr15Days
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatusCategory
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.soa.dmp.querySearchCrowdSum";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("isOrderOrClick", this.            isOrderOrClick
);
                                                                                                        parameters.Add("isTodayOr15Days", this.            isTodayOr15Days
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                                            }
    }
}





        
 

