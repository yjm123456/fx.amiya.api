using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EptWarecenterOutapiCtgattrQueryRequest : JdRequestBase<EptWarecenterOutapiCtgattrQueryResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              catId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ept.warecenter.outapi.ctgattr.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("catId", this.            catId
);
                                                                            }
    }
}





        
 

