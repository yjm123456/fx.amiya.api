using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordKeywordDeleteRequest : JdRequestBase<DspAdkckeywordKeywordDeleteResponse>
    {
                                                                                                                   public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  keyWordsName {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.keyword.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                                                                parameters.Add("keyWordsName", this.            keyWordsName
);
                                                                            }
    }
}





        
 

