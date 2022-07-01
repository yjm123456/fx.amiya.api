using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JosSecretApiReportGetRequest : JdRequestBase<JosSecretApiReportGetResponse>
    {
                                                                                                                                              public  		string
                                                                                      accessToken
 {get; set;}
                                                                                                                                  
                                                                                                                      public  		string
              businessId
 {get; set;}
                                                          
                                                          public  		string
              text
 {get; set;}
                                                          
                                                          public  		string
              attribute
 {get; set;}
                                                          
                                                                                           public  		Nullable<long>
                                                                                                                      customerUserId
 {get; set;}
                                                                                                                                                          
                                                                                           public  		string
                                                                                      serverUrl
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.jos.secret.api.report.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("access_token", this.                                                                                    accessToken
);
                                                                                                                                                parameters.Add("businessId", this.            businessId
);
                                                                                                        parameters.Add("text", this.            text
);
                                                                                                        parameters.Add("attribute", this.            attribute
);
                                                                                                                                parameters.Add("customer_user_id", this.                                                                                                                    customerUserId
);
                                                                                                                                                        parameters.Add("server_url", this.                                                                                    serverUrl
);
                                                                            }
    }
}





        
 

