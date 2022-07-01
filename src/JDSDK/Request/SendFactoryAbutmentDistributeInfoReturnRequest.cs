using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SendFactoryAbutmentDistributeInfoReturnRequest : JdRequestBase<SendFactoryAbutmentDistributeInfoReturnResponse>
    {
                                                                                  public  		string
              authorizedSequence
 {get; set;}
                                                          
                                                                                                                      public  		string
              orderno
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              distributeTime
 {get; set;}
                                                          
                                                          public  		string
              distributeOutletsName
 {get; set;}
                                                          
                                                          public  		string
              distributeOutletsPhone
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.sendFactoryAbutmentDistributeInfoReturn";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("authorizedSequence", this.            authorizedSequence
);
                                                                                                                                                parameters.Add("orderno", this.            orderno
);
                                                                                                        parameters.Add("distributeTime", this.            distributeTime
);
                                                                                                        parameters.Add("distributeOutletsName", this.            distributeOutletsName
);
                                                                                                        parameters.Add("distributeOutletsPhone", this.            distributeOutletsPhone
);
                                                                            }
    }
}





        
 

