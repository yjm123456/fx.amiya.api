using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpCampaignListRequest : JdRequestBase<AdsDspRtbTpCampaignListResponse>
    {
                                                                                                                                              public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                          public  		string
              billingType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderCaliber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatusCategory
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDay
 {get; set;}
                                                          
                                                          public  		string
              nameLike
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.campaignList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                        parameters.Add("billingType", this.            billingType
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("orderStatusCategory", this.            orderStatusCategory
);
                                                                                                        parameters.Add("startDay", this.            startDay
);
                                                                                                        parameters.Add("endDay", this.            endDay
);
                                                                                                        parameters.Add("nameLike", this.            nameLike
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

