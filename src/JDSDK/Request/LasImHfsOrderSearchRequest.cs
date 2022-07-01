using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsOrderSearchRequest : JdRequestBase<LasImHfsOrderSearchResponse>
    {
                                                                                                                                              public  		string
              code
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              offset
 {get; set;}
                                                          
                                                          public  		string
              no
 {get; set;}
                                                          
                                                          public  		string
              token
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.order.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("code", this.            code
);
                                                                                                        parameters.Add("offset", this.            offset
);
                                                                                                        parameters.Add("no", this.            no
);
                                                                                                        parameters.Add("token", this.            token
);
                                                                            }
    }
}





        
 

