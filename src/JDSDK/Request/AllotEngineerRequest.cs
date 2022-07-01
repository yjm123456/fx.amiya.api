using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AllotEngineerRequest : JdRequestBase<AllotEngineerResponse>
    {
                                                                                                                                              public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                                          public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              engineerPin
 {get; set;}
                                                          
                                                          public  		string
              engineerName
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.allotEngineer";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                        parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("engineerPin", this.            engineerPin
);
                                                                                                        parameters.Add("engineerName", this.            engineerName
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                            }
    }
}





        
 

