using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JingyiyueVenderapiSyncstatusRequest : JdRequestBase<JingyiyueVenderapiSyncstatusResponse>
    {
                                                                                                                                              public  		string
              sourceKey
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              stateDesc
 {get; set;}
                                                          
                                                                                           public  		string
              stateCode
 {get; set;}
                                                          
                                                          public  		string
              pushTime
 {get; set;}
                                                          
                                                          public  		string
              extInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.jingyiyue.venderapi.syncstatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sourceKey", this.            sourceKey
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("stateDesc", this.            stateDesc
);
                                                                                                                                                        parameters.Add("stateCode", this.            stateCode
);
                                                                                                        parameters.Add("pushTime", this.            pushTime
);
                                                                                                        parameters.Add("extInfo", this.            extInfo
);
                                                                            }
    }
}





        
 

