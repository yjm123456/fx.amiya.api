using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpEffectorderqueryRequest : JdRequestBase<AdsDspRtbTpEffectorderqueryResponse>
    {
                                                                                                                                              public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endClickDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              startClickDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startOrderDay
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.effectorderquery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                        parameters.Add("endClickDay", this.            endClickDay
);
                                                                                                        parameters.Add("endOrderDay", this.            endOrderDay
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                                                                        parameters.Add("startClickDay", this.            startClickDay
);
                                                                                                        parameters.Add("startOrderDay", this.            startOrderDay
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

