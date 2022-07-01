using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdreportTrendChartGetRequest : JdRequestBase<DspAdreportTrendChartGetResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              businessType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              granularity
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              adId
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.dsp.adreport.trendChart.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                        parameters.Add("granularity", this.            granularity
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("adId", this.            adId
);
                                                                                                                                                                            }
    }
}





        
 

