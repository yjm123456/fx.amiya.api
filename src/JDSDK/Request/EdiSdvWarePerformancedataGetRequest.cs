using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiSdvWarePerformancedataGetRequest : JdRequestBase<EdiSdvWarePerformancedataGetResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              queryStartTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              queryEndTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.edi.sdv.ware.performancedata.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("queryStartTime", this.            queryStartTime
);
                                                                                                        parameters.Add("queryEndTime", this.            queryEndTime
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

