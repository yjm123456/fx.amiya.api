using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FinishServiceRequest : JdRequestBase<FinishServiceResponse>
    {
                                                                                                                                              public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              serviceId
 {get; set;}
                                                          
                                                          public  		string
              engineerPin
 {get; set;}
                                                          
                                                          public  		string
              engineerName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              finshNum
 {get; set;}
                                                          
                                                          public  		string
              remart
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.finishService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("engineerPin", this.            engineerPin
);
                                                                                                        parameters.Add("engineerName", this.            engineerName
);
                                                                                                        parameters.Add("finshNum", this.            finshNum
);
                                                                                                        parameters.Add("remart", this.            remart
);
                                                                            }
    }
}





        
 

