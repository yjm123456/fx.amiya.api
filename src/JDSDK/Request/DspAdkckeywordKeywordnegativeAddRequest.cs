using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordKeywordnegativeAddRequest : JdRequestBase<DspAdkckeywordKeywordnegativeAddResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  keywordName {get; set; }
                                                                                                                                                                                                                                                                  public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.keywordnegative.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("keywordName", this.            keywordName
);
                                                                                                                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                    }
    }
}





        
 

