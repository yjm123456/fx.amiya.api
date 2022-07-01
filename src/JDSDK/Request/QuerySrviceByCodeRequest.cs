using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QuerySrviceByCodeRequest : JdRequestBase<QuerySrviceByCodeResponse>
    {
                                                                                                                                              public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.querySrviceByCode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                            }
    }
}





        
 

