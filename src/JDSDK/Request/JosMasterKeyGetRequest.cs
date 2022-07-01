using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JosMasterKeyGetRequest : JdRequestBase<JosMasterKeyGetResponse>
    {
                                                                                                                                              public  		string
              sig
 {get; set;}
                                                          
                                                                                                                      public  		Nullable<int>
                                                                                      sdkVer
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
              ts
 {get; set;}
                                                          
                                                          public  		string
              tid
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.jos.master.key.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sig", this.            sig
);
                                                                                                                                                parameters.Add("sdk_ver", this.                                                                                    sdkVer
);
                                                                                                        parameters.Add("ts", this.            ts
);
                                                                                                        parameters.Add("tid", this.            tid
);
                                                                                                    }
    }
}





        
 

