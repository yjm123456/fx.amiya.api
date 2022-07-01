using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAbnormalGetRequest : JdRequestBase<LdopAbnormalGetResponse>
    {
                                                                                                                                              public  		string
              customerCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.abnormal.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                            }
    }
}





        
 

