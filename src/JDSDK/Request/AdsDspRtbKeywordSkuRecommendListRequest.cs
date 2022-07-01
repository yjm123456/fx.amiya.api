using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKeywordSkuRecommendListRequest : JdRequestBase<AdsDspRtbKeywordSkuRecommendListResponse>
    {
                                                                                                                                              public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              devType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  adKeywordTypes {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.keyword.sku.recommend.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("devType", this.            devType
);
                                                                                                                                                parameters.Add("adKeywordTypes", this.            adKeywordTypes
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

