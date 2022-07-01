using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordRecommendkeywordGetRequest : JdRequestBase<DspAdkckeywordRecommendkeywordGetResponse>
    {
                                                                                  public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              searchType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              order
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              keyWordType
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.recommendkeyword.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                                                                        parameters.Add("searchType", this.            searchType
);
                                                                                                        parameters.Add("order", this.            order
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("keyWordType", this.            keyWordType
);
                                                    }
    }
}





        
 

