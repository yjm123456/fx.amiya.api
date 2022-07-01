using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ReceiveTaskRequest : JdRequestBase<ReceiveTaskResponse>
    {
                                                                                                                                              public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		string
              engineerPin
 {get; set;}
                                                          
                                                          public  		string
              engineerName
 {get; set;}
                                                          
                                                          public  		string
              engineerTel
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.receiveTask";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("engineerPin", this.            engineerPin
);
                                                                                                        parameters.Add("engineerName", this.            engineerName
);
                                                                                                        parameters.Add("engineerTel", this.            engineerTel
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                            }
    }
}





        
 

