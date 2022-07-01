using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderQueryRequest : JdRequestBase<LdopAlphaProviderQueryResponse>
    {
                                                                                  public  		Nullable<int>
              providerState
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("providerState", this.            providerState
);
                                                    }
    }
}





        
 

