using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HomefwTaskSearchRequest : JdRequestBase<HomefwTaskSearchResponse>
    {
                                                                                  public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              venderCode
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.homefw.task.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                    }
    }
}





        
 

