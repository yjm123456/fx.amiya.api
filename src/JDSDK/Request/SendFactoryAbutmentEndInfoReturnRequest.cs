using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SendFactoryAbutmentEndInfoReturnRequest : JdRequestBase<SendFactoryAbutmentEndInfoReturnResponse>
    {
                                                                                  public  		string
              authorizedSequence
 {get; set;}
                                                          
                                                                                                                      public  		string
              orderno
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceEndState
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceEndStateLevelTow
 {get; set;}
                                                          
                                                          public  		string
              serviceEndStateLevelTowDescribe
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              serviceEndTime
 {get; set;}
                                                          
                                                          public  		string
              cancelRemark
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.sendFactoryAbutmentEndInfoReturn";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("authorizedSequence", this.            authorizedSequence
);
                                                                                                                                                parameters.Add("orderno", this.            orderno
);
                                                                                                        parameters.Add("serviceEndState", this.            serviceEndState
);
                                                                                                        parameters.Add("serviceEndStateLevelTow", this.            serviceEndStateLevelTow
);
                                                                                                        parameters.Add("serviceEndStateLevelTowDescribe", this.            serviceEndStateLevelTowDescribe
);
                                                                                                        parameters.Add("serviceEndTime", this.            serviceEndTime
);
                                                                                                        parameters.Add("cancelRemark", this.            cancelRemark
);
                                                                            }
    }
}





        
 

