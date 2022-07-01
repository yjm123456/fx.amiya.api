using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderGetRemarkByModifyTimeRequest : JdRequestBase<PopOrderGetRemarkByModifyTimeResponse>
    {
                                                                                                                                                                               public  		string
              startTime
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.getRemarkByModifyTime";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("sortTime", this.            sortTime
);
                                                                            }
    }
}





        
 

