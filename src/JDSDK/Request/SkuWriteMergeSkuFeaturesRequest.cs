using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SkuWriteMergeSkuFeaturesRequest : JdRequestBase<SkuWriteMergeSkuFeaturesResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  featureKey {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  featureValue {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.sku.write.mergeSkuFeatures";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                                                                                                        parameters.Add("featureKey", this.            featureKey
);
                                                                                                        parameters.Add("featureValue", this.            featureValue
);
                                                                                                    }
    }
}





        
 

