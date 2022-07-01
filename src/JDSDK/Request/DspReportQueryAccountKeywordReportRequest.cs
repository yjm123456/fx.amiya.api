using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspReportQueryAccountKeywordReportRequest : JdRequestBase<DspReportQueryAccountKeywordReportResponse>
    {
                                                                                                                                                                               public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isDaily
 {get; set;}
                                                          
                                                          public  		string
              platform
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
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		string
              valType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.report.queryAccountKeywordReport";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("isDaily", this.            isDaily
);
                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("valType", this.            valType
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

