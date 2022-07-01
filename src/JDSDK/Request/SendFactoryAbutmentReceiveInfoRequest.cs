using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SendFactoryAbutmentReceiveInfoRequest : JdRequestBase<SendFactoryAbutmentReceiveInfoResponse>
    {
                                                                                  public  		string
              authorizedSequence
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceType
 {get; set;}
                                                          
                                                                                                                      public  		string
              orderno
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              disposeTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              disposeResult
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.sendFactoryAbutmentReceiveInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("authorizedSequence", this.            authorizedSequence
);
                                                                                                        parameters.Add("serviceType", this.            serviceType
);
                                                                                                                                                parameters.Add("orderno", this.            orderno
);
                                                                                                        parameters.Add("disposeTime", this.            disposeTime
);
                                                                                                        parameters.Add("disposeResult", this.            disposeResult
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                            }
    }
}





        
 

