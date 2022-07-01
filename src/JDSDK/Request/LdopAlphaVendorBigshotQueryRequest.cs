using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaVendorBigshotQueryRequest : JdRequestBase<LdopAlphaVendorBigshotQueryResponse>
    {
                                                                                                                                              public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              providerId
 {get; set;}
                                                          
                                                          public  		string
              providerCode
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.alpha.vendor.bigshot.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("providerId", this.            providerId
);
                                                                                                        parameters.Add("providerCode", this.            providerCode
);
                                                                                                                            }
    }
}





        
 

