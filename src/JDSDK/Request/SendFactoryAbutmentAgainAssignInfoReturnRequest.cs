using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SendFactoryAbutmentAgainAssignInfoReturnRequest : JdRequestBase<SendFactoryAbutmentAgainAssignInfoReturnResponse>
    {
                                                                                  public  		string
                                                                                      authNo
 {get; set;}
                                                                                                                                  
                                                                                                                      public  		Nullable<int>
                                                                                      msgType
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      ordNo
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
                get{return "jingdong.sendFactoryAbutmentAgainAssignInfoReturn";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("auth_no", this.                                                                                    authNo
);
                                                                                                                                                parameters.Add("msg_type", this.                                                                                    msgType
);
                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("assign_time", this.                                                                                    assignTime
);
                                                                                                        parameters.Add("at_home_time", this.                                                                                                                    atHomeTime
);
                                                                                                        parameters.Add("assigner_name", this.                                                                                    assignerName
);
                                                                                                        parameters.Add("assigner_tel", this.                                                                                    assignerTel
);
                                                                            }
    }
}





        
 

