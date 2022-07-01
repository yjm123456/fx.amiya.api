using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvUploadDBOperationLogRequest : JdRequestBase<IsvUploadDBOperationLogResponse>
    {
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
                                                                                      deviceId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      userId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              url
 {get; set;}
                                                          
                                                          public  		string
              db
 {get; set;}
                                                          
                                                          public  		string
              sql
 {get; set;}
                                                          
                                                          public  		string
                                                                                      timeStamp
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.isv.uploadDBOperationLog";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("user_ip", this.                                                                                    userIp
);
                                                                                                        parameters.Add("app_name", this.                                                                                    appName
);
                                                                                                        parameters.Add("josAppKey", this.            josAppKey
);
                                                                                                        parameters.Add("device_id", this.                                                                                    deviceId
);
                                                                                                        parameters.Add("user_id", this.                                                                                    userId
);
                                                                                                        parameters.Add("url", this.            url
);
                                                                                                        parameters.Add("db", this.            db
);
                                                                                                        parameters.Add("sql", this.            sql
);
                                                                                                        parameters.Add("time_stamp", this.                                                                                    timeStamp
);
                                                                                                                            }
    }
}





        
 

