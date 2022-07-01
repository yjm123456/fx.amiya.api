using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKeywordQueryRequest : JdRequestBase<AdsDspRtbKeywordQueryResponse>
    {
                                                                                  public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                             public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.keyword.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

