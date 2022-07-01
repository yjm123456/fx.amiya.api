using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpAccountAdGroupReportRequest : JdRequestBase<AdsDspRtbTpAccountAdGroupReportResponse>
    {
                                                                                                                                              public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderCaliber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isDaily
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatusCategory
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.accountAdGroupReport";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("isDaily", this.            isDaily
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

