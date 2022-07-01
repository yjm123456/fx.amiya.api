using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderStockQueryRequest : JdRequestBase<LdopAlphaProviderStockQueryResponse>
    {
                                                                                  public  		string
              providerCode
 {get; set;}
                                                          
                                                          public  		string
              branchCode
 {get; set;}
                                                          
                                                          public  		string
              vendorCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.stock.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("providerCode", this.            providerCode
);
                                                                                                        parameters.Add("branchCode", this.            branchCode
);
                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                    }
    }
}





        
 

