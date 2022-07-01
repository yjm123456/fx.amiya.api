using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvUploadBatchLogRequest : JdRequestBase<IsvUploadBatchLogResponse>
    {
                                                                                                                                              public  		string
              josAppKey
 {get; set;}
                                                          
                                                          public  		string
              data
 {get; set;}
                                                          
                                                          public  		string
                                                                                      timeStamp
 {get; set;}
                                                                                                                                  
                                                          public  		string
              type
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.isv.uploadBatchLog";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("josAppKey", this.            josAppKey
);
                                                                                                        parameters.Add("data", this.            data
);
                                                                                                        parameters.Add("time_stamp", this.                                                                                    timeStamp
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                                            }
    }
}





        
 

