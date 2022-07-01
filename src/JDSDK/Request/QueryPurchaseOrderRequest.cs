using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryPurchaseOrderRequest : JdRequestBase<QueryPurchaseOrderResponse>
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
                                                          
                                                          public  		Nullable<DateTime>
              completedBeginTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              completedEndTime
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
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  orderList {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.queryPurchaseOrder";}
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
                                                                                                        parameters.Add("completedBeginTime", this.            completedBeginTime
);
                                                                                                        parameters.Add("completedEndTime", this.            completedEndTime
);
                                                                                                        parameters.Add("index", this.            index
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("bizToken", this.            bizToken
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                                                                parameters.Add("orderList", this.            orderList
);
                                                                                                    }
    }
}





        
 

