using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareWriteMergeWareFeaturesRequest : JdRequestBase<WareWriteMergeWareFeaturesResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  featureKey {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  featureValue {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ware.write.mergeWareFeatures";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                                                        parameters.Add("featureKey", this.            featureKey
);
                                                                                                        parameters.Add("featureValue", this.            featureValue
);
                                                                                                    }
    }
}





        
 

