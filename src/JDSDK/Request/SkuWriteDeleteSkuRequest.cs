using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SkuWriteDeleteSkuRequest : JdRequestBase<SkuWriteDeleteSkuResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              skuId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.sku.write.deleteSku";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                    }
    }
}





        
 

