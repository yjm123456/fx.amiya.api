using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaVendorRechargeQueryRequest : JdRequestBase<LdopAlphaVendorRechargeQueryResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              providerId
 {get; set;}
                                                          
                                                          public  		string
              branchCode
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.alpha.vendor.recharge.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("providerId", this.            providerId
);
                                                                                                        parameters.Add("branchCode", this.            branchCode
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                            }
    }
}





        
 

