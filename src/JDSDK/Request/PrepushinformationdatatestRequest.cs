using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PrepushinformationdatatestRequest : JdRequestBase<PrepushinformationdatatestResponse>
    {
                                                                                                                                                    public  		Nullable<int>
              dataType
 {get; set;}
                                                          
                                                          public  		string
              jsonData
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.prepushinformationdatatest";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("dataType", this.            dataType
);
                                                                                                        parameters.Add("jsonData", this.            jsonData
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

