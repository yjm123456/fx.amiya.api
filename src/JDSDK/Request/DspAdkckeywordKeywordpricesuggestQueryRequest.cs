using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordKeywordpricesuggestQueryRequest : JdRequestBase<DspAdkckeywordKeywordpricesuggestQueryResponse>
    {
                                                                                                                   public  		string
              key
 {get; set;}
                                                          
                                                          public  		string
              mobileType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.keywordpricesuggest.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("key", this.            key
);
                                                                                                        parameters.Add("mobileType", this.            mobileType
);
                                                                                                    }
    }
}





        
 

