using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsQuerycodeSearchRequest : JdRequestBase<LasImHfsQuerycodeSearchResponse>
    {
                                                                                  public  		string
              no
 {get; set;}
                                                          
                                                          public  		string
              token
 {get; set;}
                                                          
                                                          public  		string
              date
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.las.im.hfs.querycode.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("no", this.            no
);
                                                                                                        parameters.Add("token", this.            token
);
                                                                                                        parameters.Add("date", this.            date
);
                                                    }
    }
}





        
 

