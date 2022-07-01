using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaVendorStockQueryRequest : JdRequestBase<LdopAlphaVendorStockQueryResponse>
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
                                                          
            public override string ApiName
            {
                get{return "jingdong.ldop.alpha.vendor.stock.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("providerId", this.            providerId
);
                                                                                                        parameters.Add("branchCode", this.            branchCode
);
                                                    }
    }
}





        
 

