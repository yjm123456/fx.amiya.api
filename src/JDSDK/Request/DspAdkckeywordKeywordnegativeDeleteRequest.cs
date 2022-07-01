using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordKeywordnegativeDeleteRequest : JdRequestBase<DspAdkckeywordKeywordnegativeDeleteResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  id {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  keywordName {get; set; }
                                                                                                                                                                                                                                                                  public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.keywordnegative.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("keywordName", this.            keywordName
);
                                                                                                                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                    }
    }
}





        
 

