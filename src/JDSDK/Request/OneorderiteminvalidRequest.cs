using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OneorderiteminvalidRequest : JdRequestBase<OneorderiteminvalidResponse>
    {
                                                                                                                                                    public  		Nullable<long>
              oneOrderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              refuseType
 {get; set;}
                                                          
                                                          public  		string
              refuseReason
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.oneorderiteminvalid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("oneOrderId", this.            oneOrderId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("refuseType", this.            refuseType
);
                                                                                                        parameters.Add("refuseReason", this.            refuseReason
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

