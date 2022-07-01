using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspFeaturedorderdetailOrdereffectdetailRequest : JdRequestBase<DspFeaturedorderdetailOrdereffectdetailResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		string
              mySelf
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		string
              mediaId
 {get; set;}
                                                          
                                                          public  		string
              unionid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              clickStartDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              clickEndDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderStartDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderEndDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              realTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.featuredorderdetail.ordereffectdetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("mySelf", this.            mySelf
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("mediaId", this.            mediaId
);
                                                                                                        parameters.Add("unionid", this.            unionid
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("clickStartDay", this.            clickStartDay
);
                                                                                                        parameters.Add("clickEndDay", this.            clickEndDay
);
                                                                                                        parameters.Add("orderStartDay", this.            orderStartDay
);
                                                                                                        parameters.Add("orderEndDay", this.            orderEndDay
);
                                                                                                        parameters.Add("realTime", this.            realTime
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

