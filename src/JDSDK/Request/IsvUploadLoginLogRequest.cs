using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvUploadLoginLogRequest : JdRequestBase<IsvUploadLoginLogResponse>
    {
                                                                                                                                              public  		string
              result
 {get; set;}
                                                          
                                                          public  		string
                                                                                      userIp
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      appName
 {get; set;}
                                                                                                                                  
                                                          public  		string
              josAppKey
 {get; set;}
                                                          
                                                          public  		string
                                                                                      jdId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      deviceId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      userId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              message
 {get; set;}
                                                          
                                                          public  		string
                                                                                      timeStamp
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.isv.uploadLoginLog";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("result", this.            result
);
                                                                                                        parameters.Add("user_ip", this.                                                                                    userIp
);
                                                                                                        parameters.Add("app_name", this.                                                                                    appName
);
                                                                                                        parameters.Add("josAppKey", this.            josAppKey
);
                                                                                                        parameters.Add("jd_id", this.                                                                                    jdId
);
                                                                                                        parameters.Add("device_id", this.                                                                                    deviceId
);
                                                                                                        parameters.Add("user_id", this.                                                                                    userId
);
                                                                                                        parameters.Add("message", this.            message
);
                                                                                                        parameters.Add("time_stamp", this.                                                                                    timeStamp
);
                                                                                                                            }
    }
}





        
 

