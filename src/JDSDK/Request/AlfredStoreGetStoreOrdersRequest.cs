using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AlfredStoreGetStoreOrdersRequest : JdRequestBase<AlfredStoreGetStoreOrdersResponse>
    {
                                                                                  public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.alfred.store.getStoreOrders";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

