using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpSkuInfoQuerylistRequest : JdRequestBase<CmpSkuInfoQuerylistResponse>
    {
                                                                                  public  		string
              skuIds
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.sku.info.querylist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuIds", this.            skuIds
);
                                                                                                    }
    }
}





        
 

