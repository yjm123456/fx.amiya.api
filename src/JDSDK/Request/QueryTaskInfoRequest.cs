using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryTaskInfoRequest : JdRequestBase<QueryTaskInfoResponse>
    {
                                                                                                                                              public  		Nullable<int>
              serviceState
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              updateTimeStart
 {get; set;}
                                                          
                                                          public  		string
              updateTimeEnd
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.queryTaskInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("serviceState", this.            serviceState
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("updateTimeStart", this.            updateTimeStart
);
                                                                                                        parameters.Add("updateTimeEnd", this.            updateTimeEnd
);
                                                                            }
    }
}





        
 

