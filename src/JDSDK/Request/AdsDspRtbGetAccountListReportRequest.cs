using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbGetAccountListReportRequest : JdRequestBase<AdsDspRtbGetAccountListReportResponse>
    {
                                                                                                                                              public  	    Nullable<bool>
              isDaily
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  		string
              obys
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderCaliber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatusCategory
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                      public  		string
              filters
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  		string
              platform
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.getAccountListReport";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("isDaily", this.            isDaily
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("obys", this.            obys
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("filters", this.            filters
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

