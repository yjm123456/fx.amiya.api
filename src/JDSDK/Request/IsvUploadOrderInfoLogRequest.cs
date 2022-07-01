using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvUploadOrderInfoLogRequest : JdRequestBase<IsvUploadOrderInfoLogResponse>
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
                                                                                      jdId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      deviceId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      userId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      fileMd5
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      orderIds
 {get; set;}
                                                                                                                                  
                                                          public  		string
              operation
 {get; set;}
                                                          
                                                          public  		string
              url
 {get; set;}
                                                          
                                                          public  		string
                                                                                      timeStamp
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.isv.uploadOrderInfoLog";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
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
                                                                                                        parameters.Add("file_md5", this.                                                                                    fileMd5
);
                                                                                                        parameters.Add("order_ids", this.                                                                                    orderIds
);
                                                                                                        parameters.Add("operation", this.            operation
);
                                                                                                        parameters.Add("url", this.            url
);
                                                                                                        parameters.Add("time_stamp", this.                                                                                    timeStamp
);
                                                                                                                            }
    }
}





        
 

