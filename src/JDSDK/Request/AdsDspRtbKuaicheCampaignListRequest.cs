using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheCampaignListRequest : JdRequestBase<AdsDspRtbKuaicheCampaignListResponse>
    {
                                                                                                                                              public  		Nullable<int>
              putType
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatusCategory
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  		string
              nameLike
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              activityId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              platform
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderCaliber
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.campaign.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("putType", this.            putType
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("nameLike", this.            nameLike
);
                                                                                                        parameters.Add("activityId", this.            activityId
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

