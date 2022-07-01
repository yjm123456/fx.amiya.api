using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedCampaignListRequest : JdRequestBase<AdsDspRtbFeaturedCampaignListResponse>
    {
                                                                                                                                              public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              clickOrOrderCaliber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              impressionOrClickEffect
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatusCategory
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                           public  		string
              nameLike
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                               public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.campaignList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                        parameters.Add("impressionOrClickEffect", this.            impressionOrClickEffect
);
                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                                                                        parameters.Add("nameLike", this.            nameLike
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

