using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryCommOrderRequest : JdRequestBase<QueryCommOrderResponse>
    {
                                                                                                                                              public  		Nullable<long>
              projectId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              shopId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              beginTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              index
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              bizToken
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.queryCommOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("projectId", this.            projectId
);
                                                                                                        parameters.Add("shopId", this.            shopId
);
                                                                                                        parameters.Add("beginTime", this.            beginTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("index", this.            index
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("bizToken", this.            bizToken
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                                            }
    }
}





        
 

