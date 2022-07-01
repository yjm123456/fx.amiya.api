using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKeywordAddRequest : JdRequestBase<AdsDspRtbKeywordAddResponse>
    {
                                                                                                                                              public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  keywordName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  keywordPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  type {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.keyword.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                                                                                                        parameters.Add("keywordName", this.            keywordName
);
                                                                                                        parameters.Add("keywordPrice", this.            keywordPrice
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

