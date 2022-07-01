using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ApiSmsModelConfigReadServiceCountSmsModelConfigByParamsRequest : JdRequestBase<ApiSmsModelConfigReadServiceCountSmsModelConfigByParamsResponse>
    {
                                                                                                                                                                                                                                                                            public  		Nullable<int>
              serveType
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              businessType
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.api.SmsModelConfigReadService.countSmsModelConfigByParams";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                        parameters.Add("serveType", this.            serveType
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                                            }
    }
}





        
 

