using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaVendorStockQueryByProviderCodeRequest : JdRequestBase<LdopAlphaVendorStockQueryByProviderCodeResponse>
    {
                                                                                  public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              providerCode
 {get; set;}
                                                          
                                                          public  		string
              branchCode
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ldop.alpha.vendor.stock.queryByProviderCode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("providerCode", this.            providerCode
);
                                                                                                        parameters.Add("branchCode", this.            branchCode
);
                                                    }
    }
}





        
 

