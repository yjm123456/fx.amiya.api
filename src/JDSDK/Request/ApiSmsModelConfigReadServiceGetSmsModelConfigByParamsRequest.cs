using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ApiSmsModelConfigReadServiceGetSmsModelConfigByParamsRequest : JdRequestBase<ApiSmsModelConfigReadServiceGetSmsModelConfigByParamsResponse>
    {
                                                                                                                                                                                                                                                                            public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serveType
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              businessType
 {get; set;}
                                                          
                                                                                           public  		string
              name
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.api.SmsModelConfigReadService.getSmsModelConfigByParams";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                        parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("serveType", this.            serveType
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                            }
    }
}





        
 

