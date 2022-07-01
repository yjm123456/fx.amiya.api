using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaWaybillQueryRequest : JdRequestBase<LdopAlphaWaybillQueryResponse>
    {
                                                                                  public  		string
              providerCode
 {get; set;}
                                                          
                                                          public  		string
              waybillCode
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ldop.alpha.waybill.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("providerCode", this.            providerCode
);
                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                    }
    }
}





        
 

