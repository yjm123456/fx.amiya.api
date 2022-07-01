using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordBootRecommendWordsQueryRequest : JdRequestBase<DspAdkckeywordBootRecommendWordsQueryResponse>
    {
                                                                                                                   public  		string
              keyword
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              order
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortType
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.boot.recommend.words.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("keyword", this.            keyword
);
                                                                                                        parameters.Add("order", this.            order
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                    }
    }
}





        
 

