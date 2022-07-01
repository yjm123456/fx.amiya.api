using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderModifyOrderAddrRequest : JdRequestBase<PopOrderModifyOrderAddrResponse>
    {
                                                                                                                                              public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                                                           public  		string
              customerName
 {get; set;}
                                                          
                                                          public  		string
              customerPhone
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              provinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              townId
 {get; set;}
                                                          
                                                          public  		string
              detailAddr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.modifyOrderAddr";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("customerPhone", this.            customerPhone
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countyId", this.            countyId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                                                        parameters.Add("detailAddr", this.            detailAddr
);
                                                                            }
    }
}





        
 

