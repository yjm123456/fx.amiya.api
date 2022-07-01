using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SendFactoryAbutmentAssignInfoReturnRequest : JdRequestBase<SendFactoryAbutmentAssignInfoReturnResponse>
    {
                                                                                  public  		string
              authorizedSequence
 {get; set;}
                                                          
                                                                                                                      public  		string
              orderno
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              assignTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              atHomeTime
 {get; set;}
                                                          
                                                          public  		string
              assignerName
 {get; set;}
                                                          
                                                          public  		string
              assignerTel
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.sendFactoryAbutmentAssignInfoReturn";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("authorizedSequence", this.            authorizedSequence
);
                                                                                                                                                parameters.Add("orderno", this.            orderno
);
                                                                                                        parameters.Add("assignTime", this.            assignTime
);
                                                                                                        parameters.Add("atHomeTime", this.            atHomeTime
);
                                                                                                        parameters.Add("assignerName", this.            assignerName
);
                                                                                                        parameters.Add("assignerTel", this.            assignerTel
);
                                                                            }
    }
}





        
 

