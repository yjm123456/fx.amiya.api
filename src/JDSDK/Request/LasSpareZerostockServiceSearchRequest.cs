using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockServiceSearchRequest : JdRequestBase<LasSpareZerostockServiceSearchResponse>
    {
                                                                                                                                              public  		string
              begin
 {get; set;}
                                                          
                                                          public  		string
              end
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              index
 {get; set;}
                                                          
                                                          public  		string
              vc
 {get; set;}
                                                          
                                                          public  		string
              token
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.service.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("begin", this.            begin
);
                                                                                                        parameters.Add("end", this.            end
);
                                                                                                        parameters.Add("index", this.            index
);
                                                                                                        parameters.Add("vc", this.            vc
);
                                                                                                        parameters.Add("token", this.            token
);
                                                                            }
    }
}





        
 

