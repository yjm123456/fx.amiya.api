using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordListRequest : JdRequestBase<DspAdkckeywordListResponse>
    {
                                                                                                                                                                               public  		string
              platform
 {get; set;}
                                                          
                                                          public  		string
              valType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("valType", this.            valType
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

