using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JtkQueryordersRequest : JdRequestBase<JtkQueryordersResponse>
    {
                                                                                                                                                                               public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              pageIndex
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              startDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.jtk.queryorders";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                            }
    }
}





        
 

