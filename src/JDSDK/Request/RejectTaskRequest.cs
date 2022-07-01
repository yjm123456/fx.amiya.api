using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class RejectTaskRequest : JdRequestBase<RejectTaskResponse>
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
              rejectReason
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.rejectTask";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                        parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("rejectReason", this.            rejectReason
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                            }
    }
}





        
 

