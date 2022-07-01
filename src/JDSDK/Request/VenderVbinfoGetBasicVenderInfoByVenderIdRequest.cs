using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VenderVbinfoGetBasicVenderInfoByVenderIdRequest : JdRequestBase<VenderVbinfoGetBasicVenderInfoByVenderIdResponse>
    {
                                                                                                                                               public  		string
              colNames
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vender.vbinfo.getBasicVenderInfoByVenderId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("colNames", this.            colNames
);
                                                                                                        parameters.Add("source", this.            source
);
                                                    }
    }
}





        
 

