using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedEffectOrderQueryRequest : JdRequestBase<AdsDspRtbFeaturedEffectOrderQueryResponse>
    {
                                                                                                                                              public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              impressionOrClickEffect
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderStartDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderEndDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              cilckStartDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              cilckEndDay
 {get; set;}
                                                          
                                                          public  		string
              mySelf
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderCaliber
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              posPackageId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.effectOrderQuery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("impressionOrClickEffect", this.            impressionOrClickEffect
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("orderStartDay", this.            orderStartDay
);
                                                                                                        parameters.Add("orderEndDay", this.            orderEndDay
);
                                                                                                        parameters.Add("cilckStartDay", this.            cilckStartDay
);
                                                                                                        parameters.Add("cilckEndDay", this.            cilckEndDay
);
                                                                                                        parameters.Add("mySelf", this.            mySelf
);
                                                                                                        parameters.Add("clickOrOrderCaliber", this.            clickOrOrderCaliber
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("posPackageId", this.            posPackageId
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

