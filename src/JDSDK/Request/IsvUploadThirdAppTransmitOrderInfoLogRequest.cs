using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvUploadThirdAppTransmitOrderInfoLogRequest : JdRequestBase<IsvUploadThirdAppTransmitOrderInfoLogResponse>
    {
                                                                                                                                              public  		string
                                                                                      appName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      userIp
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
                                                                                      orderIds
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      sendtoUrl
 {get; set;}
                                                                                                                                  
                                                          public  		string
              url
 {get; set;}
                                                          
                                                          public  		string
                                                                                      timeStamp
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.isv.uploadThirdAppTransmitOrderInfoLog";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("app_name", this.                                                                                    appName
);
                                                                                                        parameters.Add("user_ip", this.                                                                                    userIp
);
                                                                                                        parameters.Add("josAppKey", this.            josAppKey
);
                                                                                                        parameters.Add("device_id", this.                                                                                    deviceId
);
                                                                                                        parameters.Add("user_id", this.                                                                                    userId
);
                                                                                                        parameters.Add("order_ids", this.                                                                                    orderIds
);
                                                                                                        parameters.Add("sendto_url", this.                                                                                    sendtoUrl
);
                                                                                                        parameters.Add("url", this.            url
);
                                                                                                        parameters.Add("time_stamp", this.                                                                                    timeStamp
);
                                                                                                                            }
    }
}





        
 

