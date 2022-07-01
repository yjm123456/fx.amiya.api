using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HangzhouCustomsQueryOrderByParamRequest : JdRequestBase<HangzhouCustomsQueryOrderByParamResponse>
    {
                                                                                                                                              public  		Nullable<long>
              beginDate
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              endDate
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.hangzhou.customs.queryOrderByParam";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                            }
    }
}





        
 

