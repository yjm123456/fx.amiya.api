using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryPurchaseProductRequest : JdRequestBase<QueryPurchaseProductResponse>
    {
                                                                                                                                              public  		Nullable<long>
              shopId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              projectId
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
                                                          
                                                          public  		Nullable<DateTime>
              modiStartTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              modiEndTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.queryPurchaseProduct";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("shopId", this.            shopId
);
                                                                                                        parameters.Add("projectId", this.            projectId
);
                                                                                                        parameters.Add("index", this.            index
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("bizToken", this.            bizToken
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("modiStartTime", this.            modiStartTime
);
                                                                                                        parameters.Add("modiEndTime", this.            modiEndTime
);
                                                                            }
    }
}





        
 

