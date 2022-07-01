using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheEffectOrderQueryRequest : JdRequestBase<AdsDspRtbKuaicheEffectOrderQueryResponse>
    {
                                                                                                                                              public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endClickDay
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isDaily
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startClickDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              platform
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		string
              orderType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endOrderDay
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.effectOrderQuery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("endClickDay", this.            endClickDay
);
                                                                                                        parameters.Add("isDaily", this.            isDaily
);
                                                                                                        parameters.Add("startClickDay", this.            startClickDay
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("startOrderDay", this.            startOrderDay
);
                                                                                                        parameters.Add("endOrderDay", this.            endOrderDay
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

