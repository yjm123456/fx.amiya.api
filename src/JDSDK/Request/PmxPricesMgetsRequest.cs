using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PmxPricesMgetsRequest : JdRequestBase<PmxPricesMgetsResponse>
    {
                                                                                  public  		string
              skuids
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              area
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pmx.prices.mgets";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuids", this.            skuids
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("area", this.            area
);
                                                                                                    }
    }
}





        
 

